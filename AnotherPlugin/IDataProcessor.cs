using RatCow.SimplePlugin.Interfaces.Support;

namespace AnotherPlugin
{
    public interface IDataProcessor
    {
        ItemId Add(string data);
        string Retrieve(ItemId dataId);
    }
}