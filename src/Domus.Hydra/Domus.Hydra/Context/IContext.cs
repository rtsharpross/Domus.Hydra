namespace Domus.Hydra.Context
{
    public interface IContext
    {
        bool TryGet<T>(string key, out T result);

        Task<T?> TryGetAsync<T>(string key);
    }
}
