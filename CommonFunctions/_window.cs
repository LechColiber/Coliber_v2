using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

    class _Window : Form
    {
        private Dictionary<string, string> _translationsDictionary;

        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }

    }
