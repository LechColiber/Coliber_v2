using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public abstract class BaseCollection<T, T1>
    {
        protected List<T> _valuesToDeleteList;
        protected Dictionary<int, T1> _valuesDictionary;

        public ReadOnlyCollection<T> ValuesToDelete { get { return _valuesToDeleteList.AsReadOnly(); } }

        public T1 this[int key]
        {
            get { return _valuesDictionary[key]; }
            set { _valuesDictionary[key] = value; }
        }

        public int Count
        {
            get { return _valuesDictionary.Count; }
        }

        public BaseCollection()
        {
            _valuesToDeleteList = new List<T>();
            _valuesDictionary = new Dictionary<int, T1>();
        }

        /// <summary>
        /// Adds value to collection.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Retrun unique key in collection.</returns>
        public int Add(T1 value)
        {
            _valuesDictionary.Add(value.GetHashCode(), value);
            return value.GetHashCode();
        }

        public abstract void Remove(int key);

        public bool ContainsKey(int key)
        {
            return _valuesDictionary.ContainsKey(key);
        }

        public bool ContainsValue(T1 value)
        {
            return _valuesDictionary.ContainsValue(value);
        }

        public void Clear()
        {
            _valuesDictionary.Clear();
        }

        public Dictionary<int, T1>.KeyCollection Keys
        {
            get { return _valuesDictionary.Keys; }
        }

        public Dictionary<int, T1>.ValueCollection Values
        {
            get { return _valuesDictionary.Values; }
        }

        public Dictionary<int, T1>.Enumerator GetEnumerator()
        {
            return _valuesDictionary.GetEnumerator();
        }
    }
}
