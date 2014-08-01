using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace СкладскойУчет.Оборудование
{
    public class SingleInstance
    {

        private bool firstInstance = false;
        public bool FirstInstance
        {
            get { return firstInstance; }
        }
        public SingleInstance()
        {
            System.Threading.Mutex M = new System.Threading.Mutex(true);
        }
    }
}
