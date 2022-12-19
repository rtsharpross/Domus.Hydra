using Domus.Hydra.Utils;

namespace Domus.Hydra.Keys
{
    public record class BaseKey
    {
        public BaseKey(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                ThrowHelper.ArgumentNull(value);
            }

            if (value.Length >= Constants.KEY_max_length)
            {
                ThrowHelper.InvalidKeyNameLength(value);
            }

            if (value.HasForbiddenSymbols())
            {
                ThrowHelper.HasForbiddenSymbols(value);
            }

            _value = $"{Constants.KEY_open}{value}{Constants.KEY_close}";
        }

        private readonly string _value;

        public override string? ToString() => _value;
    }

    public record class BaseKey<T> : BaseKey
    {
        public BaseKey(T parent, string value) : base(value)
        {
            if (parent == null) throw new ArgumentNullException(nameof(value));

            Parent = parent;
        }

        public readonly T Parent;

        public override string? ToString() => $"{Parent}{Constants.KEY_sepatator}{base.ToString()}";
    }
}
