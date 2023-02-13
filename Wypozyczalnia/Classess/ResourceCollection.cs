using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class ResourceCollection : BaseCollection<int, Resource>
    {
        public override void Remove(int key)
        {
            if (_valuesDictionary.ContainsKey(key) && _valuesDictionary[key].ResourceId >= 0)
                _valuesToDeleteList.Add(_valuesDictionary[key].ResourceId);

            _valuesDictionary.Remove(key);
        }
    }
}
