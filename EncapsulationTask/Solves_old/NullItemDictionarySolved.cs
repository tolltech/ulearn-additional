using System.Collections.Generic;

namespace Solves_old
{
    public class NullItemDictionarySolved<TKey, TValue> : Dictionary<TKey, TValue>, IDictionary<TKey, TValue>
    {
        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            base[key] = value;
        }

        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get
            {
                if (key == null)
                    return default(TValue);

                return !base.ContainsKey(key)
                    ? default(TValue)
                    : base[key];
            }
            set => base[key] = value;
        }
    }
}