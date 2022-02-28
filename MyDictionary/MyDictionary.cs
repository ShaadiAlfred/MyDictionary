using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    class MyDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private KeyValuePair<K, V>?[] arrayBucket;
        private int capacity = 8;
        public int Count { get; private set; }

        public MyDictionary()
        {
            arrayBucket = new KeyValuePair<K, V>?[capacity];
        }

        private int GetHash(K key)
        {
            return Math.Abs(key.GetHashCode()) % capacity;
        }


        public void Add(K key, V value)
        {
            int index = GetHash(key);

            if (Count >= 0.75 * capacity)
            {
                IncreaseCapacity();
            }

            while (arrayBucket[index].HasValue)
            {
                if (arrayBucket[index].Value.Key.Equals(key))
                {
                    throw new InvalidOperationException($"The key [{key}] is already assigned to a value");
                }

                index++;
            }

            var kVP = new KeyValuePair<K, V>(key, value);
            arrayBucket[index] = new KeyValuePair<K, V>?(kVP);

            Count++;
        }

        private void IncreaseCapacity()
        {
            capacity *= 2;

            Count = 0;

            var tempOldArrayBucket = arrayBucket;

            arrayBucket = new KeyValuePair<K, V>?[capacity];

            foreach (var keyValuePair in tempOldArrayBucket)
            {
                if (keyValuePair.HasValue)
                {
                    Add(keyValuePair.Value.Key, keyValuePair.Value.Value);
                }
            }
        }

        public V Get(K key)
        {
            foreach (var kVP in arrayBucket)
            {
                if (kVP.HasValue)
                {
                    if (kVP.Value.Key.Equals(key))
                    {
                        return kVP.Value.Value;
                    }
                }
            }

            throw new InvalidOperationException($"Key [{key}] was not found");
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var keyValuePair in arrayBucket)
            {
                if (keyValuePair.HasValue)
                {
                    yield return keyValuePair.Value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public V this[K key]
        {
            get { return Get(key); }
            set { Add(key, value); }
        }
    }
}
