using System;
using System.Collections.Generic;
using System.Text;

namespace MenuDemoLibrary
{
    public class RuokaLista
    {

        private string _nimi;
        public List<Kategoria> kategoriat = new List<Kategoria>();
        private int _id;
        private string _description;

        public string Nimi
        {
            get { return _nimi; }
            set { _nimi = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
