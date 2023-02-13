using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class AddressCollection : BaseCollection<int, Address>
    {
        public override void Remove(int key)
        {
            if (_valuesDictionary.ContainsKey(key) && _valuesDictionary[key].AddressId >= 0)
                _valuesToDeleteList.Add(_valuesDictionary[key].AddressId);

            _valuesDictionary.Remove(key);
        }
        /*private List<int> _addressesToDelete;
        private Dictionary<int, Address> _addresses;

        public ReadOnlyCollection<int> AddressesToDelete { get { return _addressesToDelete.AsReadOnly(); } }

        public Address this[int key]
        {
            get { return _addresses[key]; }
            set { _addresses[key] = value; }
        }

        public int Count
        {
            get { return _addresses.Count; }
        }
            
        public AddressCollection()
        {
            _addressesToDelete = new List<int>();
            _addresses = new Dictionary<int, Address>();
        }

        /// <summary>
        /// Adds user address to collection.
        /// </summary>
        /// <param name="address">User address.</param>
        /// <returns>Retrun unique key in collection.</returns>
        public int Add(Address address)
        {
            _addresses.Add(address.GetHashCode(), address);
            return address.GetHashCode();
        }

        public void Remove(int key)
        {
            if (_addresses.ContainsKey(key) && _addresses[key].AddressId >= 0)
                _addressesToDelete.Add(_addresses[key].AddressId);

            _addresses.Remove(key);
        }

        public bool ContainsKey(int key)
        {
            return _addresses.ContainsKey(key);
        }

        public bool ContainsValue(Address value)
        {
            return _addresses.ContainsValue(value);
        }

        public void Clear()
        {
            _addresses.Clear();
        }

        public Dictionary<int, Address>.KeyCollection Keys
        {
            get { return _addresses.Keys; }
        }

        public Dictionary<int, Address>.ValueCollection Values
        {
            get { return _addresses.Values; }
        }

        public Dictionary<int, Address>.Enumerator GetEnumerator()
        {
            return _addresses.GetEnumerator();
        }*/
    }
}
