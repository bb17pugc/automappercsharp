using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomapperTest.Models.Core
{
    public class CollectionBase<T> : ICollection<T>
    {
        public ICollection<T> _items;
        public CollectionBase()
        {
            _items = new List<T>();
        }
        protected CollectionBase(ICollection<T> collection)
        {
            // Let derived classes specify the exact type of ICollection<T> to wrap.
            _items = collection;
        }
        public string FullName { get; set; }
        public bool Enabled { get; set; }
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}