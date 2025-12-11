namespace Solves
{
    public class NullItemDictionarySolved<TKey, TValue> : Dictionary<TKey, TValue>, IDictionary<TKey, TValue>
    {
        private TValue nullVal = default(TValue);
        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            if (key == null)
            {
                nullVal = value;
                return;
            }
            
            base[key] = value;
        }

        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get
            {
                if (key == null)
                    return nullVal;

                return !base.ContainsKey(key)
                    ? default(TValue)
                    : base[key];
            }
            set
            {
                if (key == null)
                {
                    nullVal = value;
                    return;
                }
                base[key] = value;
            }
        }
    }
}