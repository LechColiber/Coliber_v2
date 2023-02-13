using System;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class PermissionCollection : BaseCollection<Guid, Permission>
    {
        public override void Remove(int key)
        {
            if (_valuesDictionary.ContainsKey(key) && _valuesDictionary[key].PermissionId != Guid.Empty)
                _valuesToDeleteList.Add(_valuesDictionary[key].PermissionId);

            _valuesDictionary.Remove(key);
        }

        /*private List<Guid> _permissionsToDelete;
        private Dictionary<int, Permission> _permissions;

        public ReadOnlyCollection<Guid> PermissionsToDelete { get { return _permissionsToDelete.AsReadOnly(); } }

        public Permission this[int key]
        {
            get { return _permissions[key]; }
            set { _permissions[key] = value; }
        }

        public int Count
        {
            get { return _permissions.Count; }
        }

        public PermissionCollection()
        {
            _permissionsToDelete = new List<Guid>();
            _permissions = new Dictionary<int, Permission>();
        }

        /// <summary>
        /// Adds value to collection.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns>Retrun unique key in collection.</returns>
        public int Add(Permission permission)
        {
            _permissions.Add(permission.GetHashCode(), permission);
            return permission.GetHashCode();
        }

        public void Remove(int key)
        {
            if (_permissions.ContainsKey(key) && _permissions[key].PermissionId != Guid.Empty)
                _permissionsToDelete.Add(_permissions[key].PermissionId);

            _permissions.Remove(key);
        }

        public bool ContainsKey(int key)
        {
            return _permissions.ContainsKey(key);
        }

        public bool ContainsValue(Permission value)
        {
            return _permissions.ContainsValue(value);
        }

        public void Clear()
        {
            _permissions.Clear();
        }

        public Dictionary<int, Permission>.KeyCollection Keys
        {
            get { return _permissions.Keys; }
        }

        public Dictionary<int, Permission>.ValueCollection Values
        {
            get { return _permissions.Values; }
        }

        public Dictionary<int, Permission>.Enumerator GetEnumerator()
        {
            return _permissions.GetEnumerator();
        }*/        
    }
}
