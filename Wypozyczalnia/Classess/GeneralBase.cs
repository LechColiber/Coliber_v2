using System.Data.SqlClient;
using System.Threading;

namespace Wypozyczalnia
{
    public abstract class GeneralBase
    {
        private static int m_currentCode = 0;
        private int _currentCode;
        public int HashCode { get { return _currentCode; } }
        
        protected GeneralBase()
        {
            _currentCode = SetId();
        }

        public override int GetHashCode()
        {
            return _currentCode;
        }

        private static int SetId()
        {
            Interlocked.Increment(ref m_currentCode);
            return m_currentCode;
        }

        public enum CreatingMode
        {
            New,
            Edit,
            None
        };

        protected CreatingMode _currentMode;

        public CreatingMode CurrentMode { get { return _currentMode; } }
        protected void SetChanged()
        {
            if (_currentMode == CreatingMode.None)
                _currentMode = CreatingMode.Edit;
        }

        public static bool ConvertToBool(string value)
        {
            return value.Trim().ToLower() == bool.TrueString.ToLower() || value.Trim() == "1";
        }        

        public abstract void prepareSaveCommand(ref SqlCommand command, object onwer);
    }
}
