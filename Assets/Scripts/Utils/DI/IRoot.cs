namespace SergeyPchelintsev.Expedito.Utils.DI
{
    public interface IRoot
    {
        void Add<T>(T obj) where T : class;
        T Get<T>() where T : class;
    }
}