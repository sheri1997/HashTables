using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    class NodeMap<K,V>
    {
        public readonly int size;//will hold the size of the hash table.
        public readonly LinkedList<KeyValue<K, V>>[] items;
        public NodeMap(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        public int getArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public V Get(K key)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = getLinkedList(position);
            foreach(KeyValue<K,V> item in linkedList)
            {
                if(item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        public void Add(K key, V Value)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = getLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = Value };
            linkedList.AddLast(item);
        }
        public void Remove(K key)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = getLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach(KeyValue<K,V> item in linkedList)
            {
                if(item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if(itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        public LinkedList<KeyValue<K,V>> getLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if(linkedList==null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        public struct KeyValue<k,v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
    }
}
