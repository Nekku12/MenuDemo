using System;
using System.Collections.Generic;
using System.Text;

namespace MenuDemoLibrary
{
    public class Ravintola
    {
        private string _nimi;
        private string _osoite;
        private int _puhelinNro;
        private int _id;
        public List<RuokaLista> ruokalistat = new List<RuokaLista>();

        public string Nimi
        {
            get { return _nimi; }
            set { _nimi = value; }
        }

        public string Osoite
        {
            get { return _osoite; }
            set { _osoite = value; }
        }

        public int PuhelinNro
        {
            get { return _puhelinNro; }
            set { _puhelinNro = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
