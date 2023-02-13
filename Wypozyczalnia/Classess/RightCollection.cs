using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class RightCollection : BaseCollection<int, Right>
    {
        public override void Remove(int key)
        {
            if (_valuesDictionary.ContainsKey(key) && _valuesDictionary[key].RightId >= 0)
                _valuesToDeleteList.Add(_valuesDictionary[key].RightId);

            _valuesDictionary.Remove(key);
        }
    }
}
