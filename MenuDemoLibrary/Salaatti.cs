using System;
using System.Collections.Generic;
using System.Text;

namespace MenuDemoLibrary
{
    public class Salaatti : Ateria
    {
        private string _kastike;

        public string Kastike
        {
            get { return _kastike; }
            set { _kastike = value; }
        }
    }
}
