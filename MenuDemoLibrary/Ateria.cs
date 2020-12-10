using System;
using System.Collections.Generic;
using System.Text;

namespace MenuDemoLibrary
{
    public class Ateria : Kategoria
    {
        
       // private string _nimi;
        private float _hinta;
        private string _sisaltaa;
        private string _ruokaAineet;
        //private enum _ruokaValio { M , L , GL, V };
        private string _ruokaValio;
        //private string _allergeenit;
        public List<string> allergeenit = new List<string>();
        private string _vkpaiva;
        public List<Ateria> ateriarakentuu = new List<Ateria>();
        private int _koottuAteriaId;
        private int _ateriaTyyppiId;

        public int AteriaTyyppiId
        {
            get { return _ateriaTyyppiId; }
            set { _ateriaTyyppiId = value; }
        }

        public int KoottuAteriaId
        {
            get { return _koottuAteriaId; }
            set { _koottuAteriaId = value; }
        }

        /*  public string Nimi
          {
              get { return _nimi; }
              set { _nimi = value; }
          }  */

        public float Hinta
        {
            get { return _hinta; }
            set { _hinta = value; }
        }

        public string Sisaltaa
        {
            get { return _sisaltaa; }
            set { _sisaltaa = value; }
        }

        public string RuokaAineet
        {
            get { return _ruokaAineet; }
            set { _ruokaAineet = value; }
        }

        public string RuokaValio
        {
            get { return _ruokaValio; }
            set { _ruokaValio = value; }
        }

        public List<string> GetAllergiat()
        {
            return allergeenit;
        }

        public void AddAllergia(string value)
        {
            allergeenit.Add(value);
        }

        public string Vkpaiva
        {
            get { return _vkpaiva; }
            set { _vkpaiva = value; }
        }


        /*
        public int GetAteriaTyyppiFromDB()
        {
            return GetAteriaTyyppiDB(this);
        }

        private static int GetAteriaTyyppiDB(Ateria ateria)
        {
            if (typeof(Ateria) == ateria.GetType())
            {
                return 1;
            }
            if (typeof(Juoma) == ateria.GetType())
            {
                return 2;
            }
            if (typeof(Salaatti) == ateria.GetType())
            {
                return 3;
            }
            if (typeof(Ruoka) == ateria.GetType())
            {
                return 4;
            }
            if (typeof(Jalkiruoka) == ateria.GetType())
            {
                return 5;
            }
            return 0;
        }  */

    }
}
