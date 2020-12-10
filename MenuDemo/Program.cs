using System;
using System.Collections.Generic;
using MenuDemoLibrary;

namespace MenuDemo
{
    class Program
    {
       
        static void Main(string[] args)
        {
            MenuDataHandler mdh = new MenuDataHandler();
            DataManager dm = new DataManager();

            mdh.StartMenuDB();

            //var test = DataManager.GetTestDB();
            // var lista = DataManager.GetAllRuokaListatDB();
            // Console.WriteLine(lista[1].Nimi);
            // var ateria = DataManager.GetAteriaWithIdDB(6);
            // var id = DataManager.GetAteriaIdsFromKategoriaDB(4);
            // Console.WriteLine(id[0]);
            // Console.WriteLine(id[1]);
            // var ateria = DataManager.GetAllAteriatFromKategoriaDB(1);
            // Console.WriteLine(ateria[0].Nimi);
            // Juoma juoma = new Juoma();
            // juoma.Nimi = "Limsa";
            // juoma.Hinta = 2F;
            // DataManager.InsertJuomaDB(juoma);
            //var ravintola = DataManager.GetAllRavintolaDataWithIdDB(1);
            // mdh.PrintRavintolaMenut(ravintola);

            //DataManager.GetAteriaDetailsDB(2);
            // DataManager.InsertJuomaDB();
            // DataManager.InsertKoottuAteriaDB();


            //List<Ateria> ateriatkaikki = dm.GetAllAteriat();
            //List<Ravintola> ravintolat = dm.GetRavintolat();

            // mdh.StartMenu();

            /*
            Ravintola ravintola1 = mdh.SelectRavintola(ravintolat);
            mdh.PrintRavintolaMenut(ravintola1);
            RuokaLista ruokalista1 = mdh.SelectMenu(ravintola1);
            Kategoria kategoria1 = mdh.SelectKategoria(ruokalista1);
            Ateria ateria1 = mdh.SelectAteria(kategoria1);
            mdh.PrintAteriaData(ateria1);
            //mdh.PrintAteriaSis(ateria1);

            //mdh.DeleteKategoriaData(ruokalista1, kategoria1);
            mdh.DeleteAteriaData( kategoria1, ateria1);
            mdh.PrintRavintolaMenut(ravintola1);
            */

            /*
             Kategoria leipa = new Kategoria();
             leipa.Nimi = "leipa";

             mdh.InsertKategoria(ravintolat, valintaRavintola, valintaRuokaLista, leipa);


             mdh.InsertAteriaToKategoria(ravintolat, valintaRavintola, valintaRuokaLista, valintaKategoria ,ateriatkaikki[15]);

             mdh.PrintRavintolaMenut(ravintolat, valintaRavintola);



             for (int i = 0; i < ateriatkaikki.Count; i++)
             {
                 mdh.PrintAteriaWithNumbers(ateriatkaikki[i], i);
             }

             Ateria testiateria = mdh.LisaaUusiAteria();
             dm.InsertAteria(testiateria);

             for (int i = 0; i < ateriatkaikki.Count; i++)
             {
                 mdh.PrintAteriaWithNumbers(ateriatkaikki[i], i);
             }

             Console.WriteLine(ateriatkaikki[ateriatkaikki.Count-1].Nimi);
             Console.WriteLine(ateriatkaikki[ateriatkaikki.Count-1].allergeenit[0]); */

        }
    }
}
