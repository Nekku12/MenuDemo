using System;
using System.Collections.Generic;
using System.Text;

namespace MenuDemoLibrary
{
    public class MenuDataHandler
    {
        DataManager dm = new DataManager();


        public void PrintMenu(RuokaLista menu)
        {
            Console.WriteLine(menu.Nimi);
            for (int i = 0; i < menu.kategoriat.Count - 2; i++)
            {
                Console.WriteLine("\t" + menu.kategoriat[i].Nimi);
                for (int j = 0; j < (menu.kategoriat[i].kategoriarakentuu.Count); j++)
                {
                    Console.WriteLine("\t \t" + menu.kategoriat[i].kategoriarakentuu[j].Nimi + "   " + menu.kategoriat[i].kategoriarakentuu[j].Hinta + "e");

                   // if (menu.kategoriat[i].kategoriarakentuu[j].ateriarakentuu.Count > 0)
                   // {
                        for (int k = 0; k < menu.kategoriat[i].kategoriarakentuu[j].ateriarakentuu.Count; k++)
                        {
                           // if (menu.kategoriat[i].kategoriarakentuu[j].ateriarakentuu.Count > 0)
                           // {
                                PrintAteria(menu.kategoriat[i].kategoriarakentuu[j].ateriarakentuu[k]);

                           // }
                        }
                }
            }
            
            if (menu.kategoriat.Count > 2)
            {
                for (int i = (menu.kategoriat.Count - 2); i < menu.kategoriat.Count; i++)
                {
                    Console.WriteLine("\t" + menu.kategoriat[i].Nimi);
                    for (int j = 0; j < (menu.kategoriat[i].kategoriarakentuu.Count); j++)
                    {
                        Console.WriteLine("\t \t" + menu.kategoriat[i].kategoriarakentuu[j].Nimi + "   " + menu.kategoriat[i].kategoriarakentuu[j].Hinta + "e");
                    }
                }
            } 
        }


        public void PrintAteria(Ateria ateria)
        {
            Type type = ateria.GetType();
            if (type == typeof(Juoma))
            {
                Juoma juoma = (Juoma)ateria;
                Console.WriteLine("\t \t \t" + juoma.Nimi);
            }

            if (type == typeof(Salaatti))
            {
                Salaatti salaatti = (Salaatti)ateria;
                Console.WriteLine("\t \t \t" + salaatti.Nimi);
            }

            if (type == typeof(Ruoka))
            {
                Ruoka ruoka = (Ruoka)ateria;
                Console.WriteLine("\t \t \t" + ruoka.Nimi);
            }

            if (type == typeof(Jalkiruoka))
            {
                Jalkiruoka jalkiruoka = (Jalkiruoka)ateria;
                Console.WriteLine("\t \t \t" + jalkiruoka.Nimi);
            }

        }


        public void PrintKategoriaWithNumbers(RuokaLista menu)
        {
            Console.WriteLine(menu.Nimi);
            for (int i = 0; i < menu.kategoriat.Count; i++)
            {
                Console.WriteLine("\t " + i + "  " + menu.kategoriat[i].Nimi);
            }
        }


        public int SelectKategoriaInt(RuokaLista menu)
        {
            PrintKategoriaWithNumbers(menu);
            int valinta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valintasi oli: " + menu.kategoriat[valinta].Nimi);
            return valinta;
        }


        public void PrintAteriaWithNumbers(Kategoria kategoria)
        {
            Console.WriteLine("Kategoria on: " + kategoria.Nimi);

            for (int j = 0; j < (kategoria.kategoriarakentuu.Count); j++)
            {
                Console.WriteLine("\t \t" + j + "   " + kategoria.kategoriarakentuu[j].Nimi + "   " + kategoria.kategoriarakentuu[j].Hinta + "e");
            }
            /* for (int j = 0; j < (kategoria.kategoriarakentuu.Count); j++)
             {
                 Console.WriteLine("\t \t" + j + "   " + kategoria.kategoriarakentuu[j].Nimi + "   " + kategoria.kategoriarakentuu[j].Hinta + "e");
             }*/

        }


        public int SelectAteriaInt(Kategoria kat)
        {
            PrintAteriaWithNumbers(kat);
            int valinta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valintasi oli: " + valinta);
            return valinta;
        }


        public void PrintAteriaData(Ateria ateria)
        {
            for (int i = 0; i < ateria.ateriarakentuu.Count; i++)
            {
                PrintAteria(ateria.ateriarakentuu[i]);
            }
        }


        public void DeleteAteriaData(Kategoria kategoria, Ateria ateria)
        {
            kategoria.kategoriarakentuu.Remove(ateria);
        }


        public void DeleteKategoriaData(RuokaLista ruokaLista, Kategoria kategoria)
        {
            ruokaLista.kategoriat.Remove(kategoria);
        }


        public void DeleteRuokalistaData(Ravintola ravintola, RuokaLista ruokaLista)
        {
            ravintola.ruokalistat.Remove(ruokaLista);
        }


        public void DeleteRavintolaData(Ravintola ravintola)
        {
            List<Ravintola> ravintolat = dm.GetRavintolat();
            ravintolat.Remove(ravintola);
        }


        public void InsertRavintola()
        {
            Console.WriteLine("Anna ravintolan nimi:   ");
            string ravname = Console.ReadLine();
            Ravintola ravintola = new Ravintola();
            ravintola.Nimi = ravname;
            dm.InsertRavintola(ravintola);           
        }


        public void InsertRuokalista(Ravintola ravintola)
        {
            Console.WriteLine("Anna raukalistan nimi:   ");
            string ruokalistaname = Console.ReadLine();
            RuokaLista ruokalista = new RuokaLista();
            ruokalista.Nimi = ruokalistaname;
            ravintola.ruokalistat.Add(ruokalista);
        }


        public void InsertKategoria(RuokaLista ruokaLista)
        {
            Console.WriteLine("Anna kategorian nimi:   ");
            string katname = Console.ReadLine();
            Kategoria kategoria = new Kategoria();
            kategoria.Nimi = katname;
            ruokaLista.kategoriat.Add(kategoria);
        }


        public void InsertAteriaToKategoria(Kategoria kategoria)
        {
            PrintAnnokset();
            Console.WriteLine("Valitse lisättävä annos: ");
            int valinta = int.Parse(Console.ReadLine());
            List<Ateria> ateriat = dm.GetAllAteriat();
            kategoria.kategoriarakentuu.Add(ateriat[valinta]);
        }


        public void PrintAteriaWithNumbers(Ateria ateria, int i)
        {
            Type type = ateria.GetType();
            if (type == typeof(Juoma))
            {
                Juoma juoma = (Juoma)ateria;
                Console.WriteLine(i + "  " + juoma.Nimi);
            }

            if (type == typeof(Salaatti))
            {
                Salaatti salaatti = (Salaatti)ateria;
                Console.WriteLine(i + "  " + salaatti.Nimi);
            }

            if (type == typeof(Ruoka))
            {
                Ruoka ruoka = (Ruoka)ateria;
                Console.WriteLine(i + "  " + ruoka.Nimi);
            }

            if (type == typeof(Jalkiruoka))
            {
                Jalkiruoka jalkiruoka = (Jalkiruoka)ateria;
                Console.WriteLine(i + "  " + jalkiruoka.Nimi);
            }
            if (type == typeof(Ateria))
            {
                //Jalkiruoka jalkiruoka = (Jalkiruoka)ateria;
                Console.WriteLine(i + "  " + ateria.Nimi);
            }

        }


        public Ateria LisaaUusiAteria()
        {
            Console.WriteLine("Anna aterian nimi: ");
            string nimi = Console.ReadLine();

            Console.WriteLine("Valitse onko ateria: ");
            Console.WriteLine("1. Juoma ");
            Console.WriteLine("2. Salaatti ");
            Console.WriteLine("3. Ruoka ");
            Console.WriteLine("4. Jälkiruoka ");
            int tyyppi = int.Parse(Console.ReadLine());
            Ateria ateria = null;
            if (tyyppi == 1)
            {
                ateria = new Juoma();
            }
            if (tyyppi == 2)
            {
                ateria = new Salaatti();
            }
            if (tyyppi == 3)
            {
                ateria = new Ruoka();
            }
            if (tyyppi == 4)
            {
                ateria = new Jalkiruoka();
            }

            Console.WriteLine("Anna aterian hinta: ");
            float hinta = float.Parse(Console.ReadLine());
            float maara = 0.0F;
            string kastike = " ";
            string allergeenit = " ";
            string ruokaAineet = " ";
            string ruokavalio = " ";

            if (tyyppi == 1)
            {
                Console.WriteLine("Anna juoman määrä : ");
                maara = float.Parse(Console.ReadLine());
            }
            if (tyyppi == 2)
            {
                Console.WriteLine("Anna salaattikastike : ");
                kastike = Console.ReadLine();

            }
            if ((tyyppi == 3) || (tyyppi == 4) || (tyyppi == 2))
            {
                Console.WriteLine("Anna allergeenit pilkulla erotettuina: ");
                allergeenit = Console.ReadLine();
                Console.WriteLine("Anna ruokavalio : ");
                ruokavalio = Console.ReadLine();
                Console.WriteLine("Anna ruoka-aineet : ");
                ruokaAineet = Console.ReadLine();
            }

            ateria.Nimi = nimi;
            ateria.Hinta = hinta;

            if (tyyppi == 1)
            {
                ((Juoma)ateria).Nimi = nimi;
                ((Juoma)ateria).Hinta = hinta;
                ((Juoma)ateria).AnnosDl = maara;
            }
            if (tyyppi == 2)
            {
                ((Salaatti)ateria).Nimi = nimi;
                ((Salaatti)ateria).Hinta = hinta;
                ((Salaatti)ateria).Kastike = kastike;
                ((Salaatti)ateria).RuokaAineet = ruokaAineet;
                ((Salaatti)ateria).RuokaValio = ruokavalio;
                if (allergeenit.Contains("maito"))
                {
                    ((Salaatti)ateria).AddAllergia("maito");
                }
                if (allergeenit.Contains("laktoosi"))
                {
                    ((Salaatti)ateria).AddAllergia("laktoosi");
                }
                if (allergeenit.Contains("gluteeni"))
                {
                    ((Salaatti)ateria).AddAllergia("gluteeni");
                }
                if (allergeenit.Contains("vege"))
                {
                    ((Salaatti)ateria).AddAllergia("vege");
                }
                if (allergeenit.Contains("pähkinä"))
                {
                    ((Salaatti)ateria).AddAllergia("pahkina");
                }
            }
            if (tyyppi == 3)
            {
                ((Ruoka)ateria).Nimi = nimi;
                ((Ruoka)ateria).Hinta = hinta;
                ((Ruoka)ateria).RuokaAineet = ruokaAineet;
                ((Ruoka)ateria).RuokaValio = ruokavalio;
                //((Ruoka)ateria).Allergeenit = allergeenit;
                if (allergeenit.Contains("maito"))
                {
                    ((Ruoka)ateria).AddAllergia("maito");
                }
                if (allergeenit.Contains("laktoosi"))
                {
                    ((Ruoka)ateria).AddAllergia("laktoosi");
                }
                if (allergeenit.Contains("gluteeni"))
                {
                    ((Ruoka)ateria).AddAllergia("gluteeni");
                }
                if (allergeenit.Contains("vege"))
                {
                    ((Ruoka)ateria).AddAllergia("vege");
                }
                if (allergeenit.Contains("pähkinä"))
                {
                    ((Ruoka)ateria).AddAllergia("pahkina");
                }
            }
            if (tyyppi == 4)
            {
                ((Jalkiruoka)ateria).Nimi = nimi;
                ((Jalkiruoka)ateria).Hinta = hinta;
                ((Jalkiruoka)ateria).RuokaAineet = ruokaAineet;
                ((Jalkiruoka)ateria).RuokaAineet = ruokaAineet;
                ((Jalkiruoka)ateria).RuokaValio = ruokavalio;
                //((Jalkiruoka)ateria).Allergeenit = allergeenit;
                if (allergeenit.Contains("maito"))
                {
                    ((Jalkiruoka)ateria).AddAllergia("maito");
                }
                if (allergeenit.Contains("laktoosi"))
                {
                    ((Jalkiruoka)ateria).AddAllergia("laktoosi");
                }
                if (allergeenit.Contains("gluteeni"))
                {
                    ((Jalkiruoka)ateria).AddAllergia("gluteeni");
                }
                if (allergeenit.Contains("vege"))
                {
                    ((Jalkiruoka)ateria).AddAllergia("vege");
                }
                if (allergeenit.Contains("pähkinä"))
                {
                    ((Jalkiruoka)ateria).AddAllergia("pahkina");
                }
            }
            return ateria;
        }


        public void PrintRavintolatWithNumbers(List<Ravintola> ravintolat)
        {
            Console.WriteLine("Ravintolat ovat:");
            for (int i = 0; i < ravintolat.Count; i++)
            {
                Console.WriteLine("\t " + i + "  " + ravintolat[i].Nimi);
            }
        }


        public Ravintola SelectRavintola(List<Ravintola> ravintolat)
        {
            PrintRavintolatWithNumbers(ravintolat);
            int valinta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valintasi oli: " + ravintolat[valinta].Nimi);

            return ravintolat[valinta];
        }


        public void PrintRavintolaMenut(Ravintola ravintola)
        {
            Console.WriteLine("Ravintolan nimi: " + ravintola.Nimi);
            for (int i = 0; i < ravintola.ruokalistat.Count; i++)
                PrintMenu(ravintola.ruokalistat[i]);
        }


        public void PrintRavintolaMenuWithNumbers(Ravintola ravintola)
        {
            Console.WriteLine("Ravintolan nimi: " + ravintola.Nimi);
            for (int i = 0; i < ravintola.ruokalistat.Count; i++)
                Console.WriteLine(i + "    " + ravintola.ruokalistat[i].Nimi);
        }


        public RuokaLista SelectMenu(Ravintola ravintola)
        {
            PrintRavintolaMenuWithNumbers(ravintola);
            int valinta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valintasi oli: " + ravintola.ruokalistat[valinta].Nimi);

            return ravintola.ruokalistat[valinta];
        }


        public void PrintRavintolaKategoriatWithNumbers(RuokaLista ruokaLista)
        {
            Console.WriteLine("RuokaListan nimi: " + ruokaLista.Nimi);
            PrintKategoriaWithNumbers(ruokaLista);
        }


        public Kategoria SelectKategoria(RuokaLista ruokaLista)
        {
            PrintRavintolaKategoriatWithNumbers(ruokaLista);
            int valinta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valintasi oli: " + ruokaLista.kategoriat[valinta].Nimi);

            return ruokaLista.kategoriat[valinta];
        }


        public int SelectValinta()
        {
            int valinta = int.Parse(Console.ReadLine());
            return valinta;
        }


        public void PrintRavintolaAteriatWithNumbers(Kategoria kategoria)
        {
            Console.WriteLine("Kategorian nimi: " + kategoria.Nimi);
            PrintAteriaWithNumbers(kategoria);
        }


        public Ateria SelectAteria(Kategoria kategoria)
        {
            PrintRavintolaAteriatWithNumbers(kategoria);
            int valinta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valintasi oli: " + kategoria.kategoriarakentuu[valinta].Nimi);

            return kategoria.kategoriarakentuu[valinta];
        }


        public void PrintAteriaSis(Ateria ateria)
        {
            for (int i = 0; i < ateria.ateriarakentuu.Count; i++)
            {
                PrintAteriaDetails(ateria.ateriarakentuu[i]);
            }
        }


        public void PrintAteriaDetails(Ateria ateria)
        {
            Type type = ateria.GetType();
            if (type == typeof(Juoma))
            {
                Juoma juoma = (Juoma)ateria;
                Console.WriteLine("  ");
                Console.WriteLine("\t Nimi: " + juoma.Nimi);
                PrintJuomaData(juoma);
            }

            if (type == typeof(Salaatti))
            {
                Salaatti salaatti = (Salaatti)ateria;
                Console.WriteLine("  ");
                Console.WriteLine("\t Nimi: " + salaatti.Nimi);
                PrintSalaattiData(salaatti);
            }

            if (type == typeof(Ruoka))
            {
                Ruoka ruoka = (Ruoka)ateria;
                Console.WriteLine("  ");
                Console.WriteLine("\t Nimi: " + ruoka.Nimi);
                PrintRuokaData(ruoka);
            }

            if (type == typeof(Jalkiruoka))
            {
                Jalkiruoka jalkiruoka = (Jalkiruoka)ateria;
                Console.WriteLine("  ");
                Console.WriteLine("\t Nimi: " + jalkiruoka.Nimi);
                PrintJalkiruokaData(jalkiruoka);
            }

        }


        public void PrintRuokaData(Ruoka ruoka)
        {
            Console.WriteLine("Nimi: " + ruoka.Nimi);
            Console.WriteLine("Hinta: " + ruoka.Hinta);
            Console.WriteLine("Allergeenit: ");
            for (int i = 0; i < (ruoka.GetAllergiat()).Count; i++)
            {
                Console.WriteLine(ruoka.GetAllergiat()[i]);
            }
        }

        public void PrintJalkiruokaData(Jalkiruoka jalkiruoka)
        {
            Console.WriteLine("Nimi: " + jalkiruoka.Nimi);
            Console.WriteLine("Hinta: " + jalkiruoka.Hinta);
            Console.WriteLine("Allergeenit: ");
            for (int i = 0; i < (jalkiruoka.GetAllergiat()).Count; i++)
            {
                Console.WriteLine(jalkiruoka.GetAllergiat()[i]);
            }
        }


        public void PrintSalaattiData(Salaatti salaatti)
        {
            Console.WriteLine("Nimi: " + salaatti.Nimi);
            Console.WriteLine("Hinta: " + salaatti.Hinta);
            Console.WriteLine("Salaattikastike: " + salaatti.Kastike);
            Console.WriteLine("Allergeenit: ");
            for (int i = 0; i < (salaatti.GetAllergiat()).Count; i++)
            {
                Console.WriteLine(salaatti.GetAllergiat()[i]);
            }
        }


        public void PrintJuomaData(Juoma juoma)
        {
            Console.WriteLine("Nimi: " + juoma.Nimi);
            Console.WriteLine("Hinta: " + juoma.Hinta);
            Console.WriteLine("Annos: " + juoma.AnnosDl);
        }

        public void PrintAnnokset()
        {
            Console.WriteLine("Annokset ovat:");
            List<Ateria> ateriatkaikki = dm.GetAllAteriat();
            for (int i = 0; i<ateriatkaikki.Count; i++)
             {
                 PrintAteriaWithNumbers(ateriatkaikki[i], i);
             }
         }


    public void StartMenu()
        {
            
            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine(" **********  MenuDemo Valikko  *************************");
                Console.WriteLine(" 0.  Poistu ");
                Console.WriteLine(" 1.  Näytä annokset ");
                Console.WriteLine(" 2.  Lisää uusi annos ");
                Console.WriteLine(" 3.  Valitse ravintola ja näytä ruokalistat ");
                Console.WriteLine(" 4.  Lisää uusi kategoria valitsemasi ravintolan ruokalistaan");               
                Console.WriteLine(" 5.  Lisää ateria kategoriaan ");
                Console.WriteLine(" 6.  Poista ateria ");
                Console.WriteLine(" 7.  Poista kategoria ");
                Console.WriteLine(" 8.  Lisää Ruokalista ");
                Console.WriteLine(" 9.  Poista Ruokalista ");
                Console.WriteLine(" A.  Lisää Ravintola ");
                Console.WriteLine(" B.  Poista Ravintola ");
                Console.WriteLine(" C.  Listaa Ravintolat ");
                Console.WriteLine(" D.  Näytä aterian tarkemmat tiedot ");
                Console.WriteLine(" E.  Tee ateria kokonaisuus. Mukana ruoka,juoma,salaatti,jälkiruoka ");

                Console.WriteLine("  ");
                Console.WriteLine("Valitse toiminto:  ");
                ConsoleKey valinta = Console.ReadKey().Key;

                switch (valinta)
                {
                    case ConsoleKey.D0:
                        Console.Clear();
                        showMenu = false;
                        break;
                    case ConsoleKey.D1:
                        Console.Clear();
                        PrintAnnokset();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Lisätään uusi annos listaan:  ");
                        Ateria testiateria = LisaaUusiAteria();
                        dm.InsertAteria(testiateria);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Ruokalista:  ");
                        Ravintola ravintola1 = SelectRavintola(dm.GetRavintolat());
                        PrintRavintolaMenut(ravintola1);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Lisätään kategoria:  ");
                        Ravintola ravintola4 = SelectRavintola(dm.GetRavintolat());
                        RuokaLista ruokalista4 = SelectMenu(ravintola4);
                        InsertKategoria(ruokalista4);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Lisätään kategoria:  ");
                        Ravintola ravintola5 = SelectRavintola(dm.GetRavintolat());
                        RuokaLista ruokalista5 = SelectMenu(ravintola5);
                        Kategoria kategoria5 = SelectKategoria(ruokalista5);
                        InsertAteriaToKategoria(kategoria5);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        Console.WriteLine("Poista ateria ruokalistasta:  ");
                        Ravintola ravintola6 = SelectRavintola(dm.GetRavintolat());
                        RuokaLista ruokalista6 = SelectMenu(ravintola6);
                        Kategoria kategoria6 = SelectKategoria(ruokalista6);
                        Ateria ateria6 = SelectAteria(kategoria6);
                        DeleteAteriaData(kategoria6, ateria6);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        Console.WriteLine("Poista kategoria ruokalistasta:  ");
                        Ravintola ravintola7 = SelectRavintola(dm.GetRavintolat());
                        RuokaLista ruokalista7 = SelectMenu(ravintola7);
                        Kategoria kategoria7 = SelectKategoria(ruokalista7);
                        DeleteKategoriaData(ruokalista7, kategoria7);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D8:
                        Console.Clear();
                        Console.WriteLine("Lisää ruokalista:  ");
                        Ravintola ravintola8 = SelectRavintola(dm.GetRavintolat());
                        InsertRuokalista(ravintola8);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D9:
                        Console.Clear();
                        Console.WriteLine("Poista ruokalista:  ");
                        Ravintola ravintola9 = SelectRavintola(dm.GetRavintolat());
                        RuokaLista ruokalista9 = SelectMenu(ravintola9);
                        DeleteRuokalistaData(ravintola9, ruokalista9);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        Console.WriteLine("Lisätään ravintola:  ");
                        InsertRavintola();
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.B:
                        Console.Clear();
                        Console.WriteLine("Poistetaan ravintola:  ");
                        Ravintola ravintolaB = SelectRavintola(dm.GetRavintolat());
                        DeleteRavintolaData(ravintolaB);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        Console.WriteLine("Listataan ravintolat:  ");
                        PrintRavintolatWithNumbers(dm.GetRavintolat());
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        Console.WriteLine("Aterian tarkemmat tiedot:  ");
                        Ravintola ravintolaD = SelectRavintola(dm.GetRavintolat());
                        RuokaLista ruokalistaD = SelectMenu(ravintolaD);
                        Kategoria kategoriaD = SelectKategoria(ruokalistaD);
                        Ateria ateriaD = SelectAteria(kategoriaD);
                        PrintAteriaSis(ateriaD);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.E:
                        Console.Clear();
                        Console.WriteLine("Tee uusi ateria kokonaisuus:  ");
                        Ateria newateria = MakeAteriaKokonaisuus();
                        dm.InsertAteria(newateria);
                        Console.WriteLine("Paina jotakin näppäintä :  ");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

            }
        }


        public Ateria MakeAteriaKokonaisuus()
        {
            PrintAnnokset();
            Ateria newateria = new Ateria();
            Console.WriteLine("Anna ateriakokonaisuudelle nimi: ");
            string nimi = Console.ReadLine();
            newateria.Nimi = nimi;
            Console.WriteLine("Anna ateriakokonaisuudelle hinta: ");
            float hinta = float.Parse(Console.ReadLine());
            newateria.Hinta = hinta;

           // PrintAnnokset();
            Console.WriteLine("Valitse ateriaan lisättävä ruoka: ");
            int ruokavalinta = SelectValinta();
            Console.WriteLine("Valitse ateriaan lisättävä juoma: ");
            int juomavalinta = SelectValinta();
            Console.WriteLine("Valitse ateriaan lisättävä salaatti: ");
            int salaattivalinta = SelectValinta();
            Console.WriteLine("Valitse ateriaan lisättävä jälkiruoka: ");
            int jalkiruokavalinta = SelectValinta();

            List<Ateria> ateriatkaikki = dm.GetAllAteriat();

            newateria.ateriarakentuu.Add(ateriatkaikki[ruokavalinta]);
            newateria.ateriarakentuu.Add(ateriatkaikki[juomavalinta]);
            newateria.ateriarakentuu.Add(ateriatkaikki[salaattivalinta]);
            newateria.ateriarakentuu.Add(ateriatkaikki[jalkiruokavalinta]);

            return newateria;


        }

        public void StartMenuDB()
        {
            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine(" **********  MenuDemo Valikko  *************************");
                Console.WriteLine(" 0.  Poistu ");
                Console.WriteLine(" 1.  Lisää uusi Juoma ");
                Console.WriteLine(" 2.  Lisää uusi Salaatti ");
                Console.WriteLine(" 3.  Lisää uusi Ruoka ");
                Console.WriteLine(" 4.  Lisää uusi Jälkiruoka");
                Console.WriteLine(" 5.  Kokoa uusi ateria ");
                Console.WriteLine(" 6.  Lisää Kategoria ");
                Console.WriteLine(" 7.  Lisåå Ruokalista ");
                Console.WriteLine(" 8.  Lisää Ravintola ");
                Console.WriteLine(" 9.  Vie ateria kategoriaan ");
                Console.WriteLine(" A.  Vie kategoria ruokalistaan ");
                Console.WriteLine(" B.  Vie ruokalista ravintolaan ");
                Console.WriteLine(" C.  Tulosta ruokalista valitsemastasi ravintolasta ");
                Console.WriteLine(" D.  Näytä aterian tarkemmat tiedot ");

                Console.WriteLine("  ");
                Console.WriteLine("Valitse toiminto:  ");
                ConsoleKey valinta = Console.ReadKey().Key;
                switch (valinta)
                {
                    case ConsoleKey.D0:
                        Console.Clear();
                        showMenu = false;
                        break;
                    case ConsoleKey.D1:
                        Console.Clear();
                        DataManager.InsertJuomaDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        DataManager.InsertSalaattiDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        DataManager.InsertRuokaDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        DataManager.InsertJalkiruokaDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        DataManager.InsertAteriaDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        DataManager.InsertKategoriaDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        DataManager.InsertRuokaListaDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D8:
                        Console.Clear();
                        DataManager.InsertRavintolaDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D9:
                        Console.Clear();
                        DataManager.InsertAteriaToKategoriaDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        DataManager.InsertKategoriaToRuokaListaDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.B:
                        Console.Clear();
                        DataManager.InsertRuokalistaToRavintolaDB();
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        var ravintolaId = DataManager.SelectRavintolaIdDB();
                        var ravintola = DataManager.GetAllRavintolaDataWithIdDB(ravintolaId);
                        PrintRavintolaMenut(ravintola);
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        var ateriaId = DataManager.SelectAteriaIdDB();
                        DataManager.GetAteriaDetailsDB(ateriaId);
                        Console.WriteLine("Paina jotakin näppäintä kun katsottu:  ");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
             }
        }




    }
}
