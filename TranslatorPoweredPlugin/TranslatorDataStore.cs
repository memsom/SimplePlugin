using RatCow.SimplePlugin.Interfaces;
using System;
using TranslatorPoweredPlugin.Support;
using RatCow.SimplePlugin.Interfaces.Events;
using RatCow.SimplePlugin.Interfaces.Support;
using System.Collections.Concurrent;
using RatCow.SimplePlugin.Interfaces.Commands;
using System.Threading.Tasks;
using System.Threading;

namespace TranslatorPoweredPlugin
{
    public class TranslatorDataStore : Base, IDataStore
    {
        public event EventHandler<AddDataEventArgs> DataAdded;
        public event EventHandler<GetDataEventArgs> DataRetrieved;

        readonly ConcurrentQueue<BaseCommand> commandQueue;
        readonly ConcurrentQueue<BaseEventArgs> eventQueue;
        readonly ITranslatorFactory factory;

        CancellationTokenSource tokenSource;
        CancellationToken token;
        Task eventLoopTask;
        object stopping = new object();
        object syncObject = new object();

        public TranslatorDataStore(ITranslatorFactory factory)
        {
            this.factory = factory;
            commandQueue = new ConcurrentQueue<BaseCommand>();
            eventQueue = new ConcurrentQueue<BaseEventArgs>();
            Start();
        }

        void Start()
        {
            lock (syncObject)
            {
                if (eventLoopTask == null)
                {
                    tokenSource = new CancellationTokenSource();
                    token = tokenSource.Token;

                    eventLoopTask = Task.Factory.StartNew(() =>
                    {
                        RunEventLoop();
                    },
                    token)
                    .ContinueWith((t) =>
                    {
                        try
                        {
                            t.Wait();
                        }
                        catch (AggregateException ae)
                        {
                            OperationCanceledException oce = ae.InnerException as OperationCanceledException;
                            if (oce == null)
                            {
                                lock (stopping)
                                {
                                    if (!t.IsCanceled && !(bool)stopping)
                                    {
                                        tokenSource.Dispose();
                                        eventLoopTask = null;
                                    }
                                }
                            }
                        }
                    });
                }
            }
        }

        void Stop()
        {
            lock (syncObject)
            {
                lock (stopping)
                {
                    stopping = true;
                }

                if (eventLoopTask != null)
                {
                    tokenSource.Cancel();
                    tokenSource.Dispose();

                    eventLoopTask.Wait();
                    eventLoopTask.Dispose();
                    eventLoopTask = null;
                }

                stopping = false;
            }
        }

        void RunEventLoop()
        {
            do
            {
                BaseCommand command;
                if (commandQueue.TryDequeue(out command))
                {
                    TranslateCommand(command);
                }

                BaseEventArgs eventargs;
                if (eventQueue.TryDequeue(out eventargs))
                {
                    TranslateEventArg(eventargs);
                }
                Thread.Sleep(100);
            }
            while (!token.IsCancellationRequested);
        }

        void TranslateCommand(BaseCommand command)
        {
            using (var translator = factory.CreateTranslator(command))
            {
                var response = translator.Run(command);
                eventQueue.Enqueue(response);
            }
        }

        void TranslateEventArg(BaseEventArgs eventArg)
        {
            var translator = factory.CreateTranslator(eventArg);
            translator.Run(eventArg);
        }

        public ItemId Add(string data)
        {
            var command = new AddDataCommand { Data = data };
            commandQueue.Enqueue(command);
            return command.Id;
        }

        public ItemId Retrieve(ItemId id)
        {
            var command = new GetDataCommand { DataId = id };
            commandQueue.Enqueue(command);
            return command.Id;
        }

        public void CallDataRetrieved(GetDataEventArgs e)
        {
            DataRetrieved?.Invoke(this, e);
        }

        public void CallDataAdded(AddDataEventArgs e)
        {
            DataAdded?.Invoke(this, e);
        }

        protected override void DisposeManaged()
        {
            Stop();
        }

        #region Not used (need to factor out)

        public string RetrieveData(ItemId id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
