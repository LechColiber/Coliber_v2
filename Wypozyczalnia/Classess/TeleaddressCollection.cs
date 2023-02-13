using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class TeleaddressCollection : BaseCollection<int, Teleaddress>
    {
        public override void Remove(int key)
        {
            if (_valuesDictionary.ContainsKey(key) && _valuesDictionary[key].TeleaddressId >= 0)
                _valuesToDeleteList.Add(_valuesDictionary[key].TeleaddressId);

            _valuesDictionary.Remove(key);
        }
        /*private List<int> _teleaddressesToDelete;
        private Dictionary<int, Teleaddress> _teleaddresses;

        public ReadOnlyCollection<int> TeleaddressesToDelete { get { return _teleaddressesToDelete.AsReadOnly(); } }

        public Teleaddress this[int key]
        {
            get { return _teleaddresses[key]; }
            set { _teleaddresses[key] = value; }
        }

        public int Count
        {
            get { return _teleaddresses.Count; }
        }

        public TeleaddressCollection()
        {
            _teleaddressesToDelete = new List<int>();
            _teleaddresses = new Dictionary<int, Teleaddress>();
        }

        /// <summary>
        /// Adds user teleaddress to collection.
        /// </summary>
        /// <param name="teleaddress">User teleaddress.</param>
        /// <returns>Retrun unique key in collection.</returns>
        public int Add(Teleaddress teleaddress)
        {
            _teleaddresses.Add(teleaddress.GetHashCode(), teleaddress);
            return teleaddress.GetHashCode();
        }

        public void Remove(int key)
        {
            if (_teleaddresses.ContainsKey(key) && _teleaddresses[key].TeleaddressId >= 0)
                _teleaddressesToDelete.Add(_teleaddresses[key].TeleaddressId);

            _teleaddresses.Remove(key);
        }

        public bool ContainsKey(int key)
        {
            return _teleaddresses.ContainsKey(key);
        }

        public bool ContainsValue(Teleaddress value)
        {
            return _teleaddresses.ContainsValue(value);
        }

        public void Clear()
        {
            _teleaddresses.Clear();
        }

        public Dictionary<int, Teleaddress>.KeyCollection Keys
        {
            get { return _teleaddresses.Keys; }
        }

        public Dictionary<int, Teleaddress>.ValueCollection Values
        {
            get { return _teleaddresses.Values; }
        }

        public Dictionary<int, Teleaddress>.Enumerator GetEnumerator()
        {
            return _teleaddresses.GetEnumerator();
        }*/               
    }
}
