using System;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Otus.MyDictionary
{
    public class MyDictionary<TKey, TValue>
    {
        private struct Entry
        {
            public int hashCode;
            public int next;
            public TKey key;
            public TValue value;
        }
        private int[] buckets = new int[32];
        private Entry[] entries = new Entry[32];
        private int _counter = 0;

        public void Add(TKey key, TValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Значение не может быть null.");
            }
            if (_counter >= buckets.Length)
            {
                ResizeArrays();
            }

            int bucketNum = (key.GetHashCode() & 0x7fffffff) % entries.Length;

            if (entries[bucketNum].key.GetHashCode() == key.GetHashCode())
            {
                var newEntry = new Entry();
                newEntry.value = value;
                newEntry.key = key;
                newEntry.hashCode = (key.GetHashCode() & 0x7fffffff);
                newEntry.next = 0;
                entries[bucketNum] = newEntry;
            }
            else
            {
                if (entries[bucketNum].value != null)
                {
                    ResizeArrays();
                }
                var entry = new Entry();
                entry.value = value;
                entry.key = key;
                entry.hashCode = (key.GetHashCode() & 0x7fffffff);
                entry.next = 0;
                entries[bucketNum] = entry;
                buckets[_counter] = bucketNum;
                _counter++;
            }
        }
        public TValue Get(TKey key)
        {
            int bucketNum = (key.GetHashCode() & 0x7fffffff) % entries.Length;
            return entries[bucketNum].value;
        }
        private void ResizeArrays()
        {
            int[] newBuckets = new int[buckets.Length * 2];
            Entry[] newEntries = new Entry[entries.Length * 2];
            foreach (Entry entry in entries)
            {
                if (entry.key != null)
                {
                    int boocketNum = (entry.key.GetHashCode() & 0x7fffffff) % newEntries.Length;
                    newEntries[boocketNum] = entry;
                }
            }
            for (int i = 0; i < buckets.Length; i++)
            {
                newBuckets[i] = buckets[i];
            }
            buckets = newBuckets;
            entries = newEntries;
        }
    }
}

