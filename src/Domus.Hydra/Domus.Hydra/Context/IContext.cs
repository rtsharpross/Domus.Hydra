namespace Domus.Hydra.Context
{
    public interface IContext
    {
        bool Get<T>(string key, out T result);
    }
}
