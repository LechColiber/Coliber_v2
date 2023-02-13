using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;

namespace Translate_Manager
{
    public class TranslateReader
    {
        private string _path;
        private Dictionary<string, string> _dictionary;
        public Dictionary<string, string> Dictionary { get { return _dictionary; } }
        public TranslateReader(string culture)
        {
            _dictionary = new Dictionary<string, string>();

            readTranslations(string.Format(@".\lang\lang.{0}.resx", culture));
        }

        public TranslateReader(string culture, string directoryPath)
        {
            _dictionary = new Dictionary<string, string>();

            readTranslations(Path.Combine(directoryPath, string.Format("lang.{0}.resx", culture)));
        }

        private void readTranslations(string path)
        {
            ResXResourceReader reader = null;

            try
            {
                reader = new ResXResourceReader(path);

                foreach (DictionaryEntry item in reader)
                {
                    _dictionary.Add(item.Key.ToString(), item.Value.ToString());
                }

            }
            finally
            {
                if(reader != null)
                    reader.Close();
            }
        }
    }
}
