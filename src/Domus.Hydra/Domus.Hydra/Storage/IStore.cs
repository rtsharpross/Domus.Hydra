namespace Domus.Hydra.Storage
{
    public interface IStore<TKey, TRecord, TConfig>
    {
        string Name { get; }

        TRecord this[TKey key] { get; }

        void Remove(TKey key);

        bool Has(TKey key);

        void Initialize(TConfig configuration);
    }
}
