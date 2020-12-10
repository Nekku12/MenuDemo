using System;
using System.Collections.Generic;
using System.Text;

namespace MenuDemoLibrary
{
    public class Juoma : Ateria
    {
        private float _annosDl;

        public float AnnosDl
        {
            get { return _annosDl; }
            set { _annosDl = value; }
        }

    }
}
