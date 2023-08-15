using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Connection
    {
        public bool IsConnectionProcess { get; private set; }

        private static Connection _connection;

        private Connection() { }

        public static Connection GetInstance()
        {
            if (_connection == null)
            {
                _connection = new Connection();
            }
            return _connection;
        }

        public void Start()
        {
            IsConnectionProcess = true;
        }

        public void Stop()
        {
            IsConnectionProcess = false;
        }
    }
}
