using System;
using System.Collections.Generic;
using System.Text;

namespace MenuDemoLibrary
{
    public class Allergia : Ateria
    {


        public Dictionary<string, string> allergialist = new Dictionary<string, string>();

        public Dictionary<string, string> AsetaPerusAllergiat()
        {
            allergialist.Add("Maito", "M");
            allergialist.Add("Laktoosi", "L");
            allergialist.Add("Gluteeni", "GL");
            allergialist.Add("Vege", "V");
            allergialist.Add("Pahkina", "P") ;

            return allergialist;
        }

    }
}
