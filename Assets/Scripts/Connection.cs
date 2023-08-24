using Assets.Scripts.UIClasses.MapItemButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Assets.Scripts
{
    public class Connection
    {
        public bool isConnectionProcess { get; private set; }

        private static Connection connection;
        public List<TransitionButton> TransitionButtons { get; private set; } = new List<TransitionButton>();

        private Connection() { }

        public static Connection GetInstance()
        {
            if (connection == null)
            {
                connection = new Connection();
            }
            return connection;
        }

        public bool ConnectionProcess()
        {
            isConnectionProcess = !isConnectionProcess;
            return isConnectionProcess;
        }
    }
}
