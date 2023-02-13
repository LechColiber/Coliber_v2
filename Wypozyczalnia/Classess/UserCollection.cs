using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class UserCollection : BaseCollection<int, User>
    {
        public override void Remove(int key)
        {
            if (_valuesDictionary.ContainsKey(key) && _valuesDictionary[key].UserID >= 0)
                _valuesToDeleteList.Add(_valuesDictionary[key].UserID);

            _valuesDictionary.Remove(key);
        }
    }
}
