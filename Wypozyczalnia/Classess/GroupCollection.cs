using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class GroupCollection : BaseCollection<int, Group>
    {
        public override void Remove(int key)
        {
            if (_valuesDictionary.ContainsKey(key) && _valuesDictionary[key].GroupId >= 0)
                _valuesToDeleteList.Add(_valuesDictionary[key].GroupId);

            _valuesDictionary.Remove(key);
        }
        /*private List<int> _groupsToDelete;
        private Dictionary<int, Group> _groups;

        public ReadOnlyCollection<int> GroupsToDelete { get { return _groupsToDelete.AsReadOnly(); } }

        public Group this[int key]
        {
            get { return _groups[key]; }
            set { _groups[key] = value; }
        }

        public int Count
        {
            get { return _groups.Count; }
        }

        public GroupCollection()
        {
            _groupsToDelete = new List<int>();
            _groups = new Dictionary<int, Group>();
        }

        /// <summary>
        /// Adds user address to collection.
        /// </summary>
        /// <param name="address">User address.</param>
        /// <returns>Retrun unique key in collection.</returns>
        public int Add(Group address)
        {
            _groups.Add(address.GetHashCode(), address);
            return address.GetHashCode();
        }

        public void Remove(int key)
        {
            if (_groups.ContainsKey(key) && _groups[key].GroupId >= 0)
                _groupsToDelete.Add(_groups[key].GroupId);

            _groups.Remove(key);
        }

        public bool ContainsKey(int key)
        {
            return _groups.ContainsKey(key);
        }

        public bool ContainsValue(Group value)
        {
            return _groups.ContainsValue(value);
        }

        public void Clear()
        {
            _groups.Clear();
        }

        public Dictionary<int, Group>.KeyCollection Keys
        {
            get { return _groups.Keys; }
        }

        public Dictionary<int, Group>.ValueCollection Values
        {
            get { return _groups.Values; }
        }

        public Dictionary<int, Group>.Enumerator GetEnumerator()
        {
            return _groups.GetEnumerator();
        }*/
    }
}
