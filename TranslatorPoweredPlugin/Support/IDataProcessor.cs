using RatCow.SimplePlugin.Interfaces.Support;

namespace TranslatorPoweredPlugin.Support
{
    public interface IDataProcessor
    {
        ItemId Add(string data);
        string Retrieve(ItemId dataId);
    }
}