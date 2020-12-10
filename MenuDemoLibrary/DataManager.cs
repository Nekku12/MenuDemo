using System;
using System.Collections.Generic;
using System.Text;

using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MenuDemoLibrary
{
    public class DataManager: DataAccess
    {
        private List<Ateria> _ateriatkaikki = new List<Ateria>();
        private List<Ravintola> _ravintolat = new List<Ravintola>();

        public static Object GetTestDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using(IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.QueryFirst< Object >("SELECT Nimi FROM Ravintola");
                return toReturn;
            }
        }

        public static int SelectRavintolaIdDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var idLista = connection.Query<int>("SELECT Id FROM Ravintola").ToList();
                var nimiLista = connection.Query<string>("SELECT Nimi FROM Ravintola").ToList();

                for (int i = 0; i < idLista.Count ; i++)
                {
                    Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                }
            }
            Console.WriteLine("Valitse ravintola. Anna valitsemasi ravintolan Id numero.");
            int idnum = int.Parse(Console.ReadLine());
            return idnum;
        }

        public static int SelectAteriaIdDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var idLista = connection.Query<int>("SELECT Id FROM Ateria").ToList();
                var nimiLista = connection.Query<string>("SELECT Nimi FROM Ateria").ToList();

                for (int i = 0; i < idLista.Count; i++)
                {
                    Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                }
            }
            Console.WriteLine("Valitse ateria. Anna valitsemasi aterian Id numero.");
            int idnum = int.Parse(Console.ReadLine());
            return idnum;
        }



        public static void InsertRavintolaDB()
        {
            //RuokaLista ruokalista = new RuokaLista();
            Console.WriteLine("Anna ravintolan nimi: ");
            string nimirav = Console.ReadLine();
            //ruokalista.Nimi = nimi;
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query("INSERT Ravintola (Nimi) VALUES (@nimi)", new { nimi = nimirav });
            }
        }

        public static void InsertRuokaListaDB()
        {
            //RuokaLista ruokalista = new RuokaLista();
            Console.WriteLine("Anna ruokalistan nimi: ");
            string nimiruoklist = Console.ReadLine();
            //ruokalista.Nimi = nimi;
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query("INSERT RuokaLista (Nimi) VALUES (@nimi)", new { nimi = nimiruoklist });
            }
        }

        public static void InsertKategoriaDB()
        {
            Kategoria kategoria = new Kategoria();
            Console.WriteLine("Anna kategorian nimi: ");
            string nimi = Console.ReadLine();
            kategoria.Nimi = nimi;
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query("INSERT Kategoria (Nimi) VALUES (@nimi)", new { nimi = kategoria.Nimi });
            }
        }

        public static void InsertJuomaDB()
        {
            Juoma juoma = new Juoma();
            Console.WriteLine("Anna juoman nimi: ");
            string nimi = Console.ReadLine();
            juoma.Nimi = nimi;
            Console.WriteLine("Anna juoman hinta: ");
            int hinta = int.Parse(Console.ReadLine());
            juoma.Hinta = hinta;
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query("INSERT Juoma (Nimi,Hinta) VALUES (@nimi,@hinta)", new { nimi = juoma.Nimi, hinta = juoma.Hinta });
                
            }
        }

        public static void InsertSalaattiDB()
        {
            Salaatti salaatti = new Salaatti();
            Console.WriteLine("Anna salaatin nimi: ");
            string nimi = Console.ReadLine();
            salaatti.Nimi = nimi;
            Console.WriteLine("Anna salaatin hinta: ");
            int hinta = int.Parse(Console.ReadLine());
            salaatti.Hinta = hinta;
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query("INSERT Salaatti (Nimi,Hinta) VALUES (@nimi,@hinta)", new { nimi = salaatti.Nimi, hinta = salaatti.Hinta });

            }
        }

        public static void InsertRuokaDB()
        {
            Ruoka ruoka = new Ruoka();
            Console.WriteLine("Anna ruuan nimi: ");
            string nimi = Console.ReadLine();
            ruoka.Nimi = nimi;
            Console.WriteLine("Anna ruuan hinta: ");
            int hinta = int.Parse(Console.ReadLine());
            ruoka.Hinta = hinta;
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query("INSERT Ruoka (Nimi,Hinta) VALUES (@nimi,@hinta)", new { nimi = ruoka.Nimi, hinta = ruoka.Hinta });

            }
        }

        public static void InsertJalkiruokaDB()
        {
            Jalkiruoka jalkiruoka = new Jalkiruoka();
            Console.WriteLine("Anna jälkiruuan nimi: ");
            string nimi = Console.ReadLine();
            jalkiruoka.Nimi = nimi;
            Console.WriteLine("Anna jälkiruuan hinta: ");
            int hinta = int.Parse(Console.ReadLine());
            jalkiruoka.Hinta = hinta;
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query("INSERT Jalkiruoka (Nimi,Hinta) VALUES (@nimi,@hinta)", new { nimi = jalkiruoka.Nimi, hinta = jalkiruoka.Hinta });

            }
        }

        public static void InsertKoottuAteriaDB()
        {
            Console.WriteLine("Valitse lisättävän aterian tyyppi:");
            Console.WriteLine("1. KoottuAteria");
            Console.WriteLine("2. Juoma");
            Console.WriteLine("3. Salaatti");
            Console.WriteLine("4. Ruoka");
            Console.WriteLine("5. Jalkiruoka");
            int tyyppi = int.Parse(Console.ReadLine());

            if ((tyyppi == 2) || (tyyppi == 1))
            {
                string str = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str))
                {
                    var idLista = connection.Query<int>("SELECT Id FROM Juoma").ToList();
                    var nimiLista = connection.Query<string>("SELECT Nimi FROM Juoma").ToList();

                    for (int i = 0; i < idLista.Count-1; i++)
                    {
                        Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                    }
                }
                Console.WriteLine("Valitse lisättävä juoma. Anna valitsemasi juoman Id numero.");
                int idnum = int.Parse(Console.ReadLine());
                var juoma = GetJuomaWithIdDB(idnum);
                string str2 = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str2))
                {
                    var toReturn = connection.Query("INSERT KoottuAteria (Nimi,JuomaId,Hinta) VALUES (@nimi,@juomaid,@hinta)", new { nimi = juoma.Nimi,juomaid = idnum, hinta = juoma.Hinta });

                }
            }
            if ((tyyppi == 3) || (tyyppi == 1))
            {
                string str = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str))
                {
                    var idLista = connection.Query<int>("SELECT Id FROM Salaatti").ToList();
                    var nimiLista = connection.Query<string>("SELECT Nimi FROM Salaatti").ToList();

                    for (int i = 0; i < idLista.Count - 1; i++)
                    {
                        Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                    }
                }
                Console.WriteLine("Valitse lisättävä salaatti. Anna valitsemasi salaatin Id numero.");
                int idnum = int.Parse(Console.ReadLine());
                var salaatti = GetSalaattiWithIdDB(idnum);
                string str2 = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str2))
                {
                    var toReturn = connection.Query("INSERT KoottuAteria (Nimi,SalaattiId,Hinta) VALUES (@nimi,@salaattiid,@hinta)", new { nimi = salaatti.Nimi, salaattiid = idnum, hinta = salaatti.Hinta });

                }
            }
            if ((tyyppi == 4) || (tyyppi == 1))
            {
                string str = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str))
                {
                    var idLista = connection.Query<int>("SELECT Id FROM Ruoka").ToList();
                    var nimiLista = connection.Query<string>("SELECT Nimi FROM Ruoka").ToList();

                    for (int i = 0; i < idLista.Count - 1; i++)
                    {
                        Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                    }
                }
                Console.WriteLine("Valitse lisättävä ruoka. Anna valitsemasi ruuan Id numero.");
                int idnum = int.Parse(Console.ReadLine());
                var ruoka = GetRuokaWithIdDB(idnum);
                string str2 = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str2))
                {
                    var toReturn = connection.Query("INSERT KoottuAteria (Nimi,RuokaId,Hinta) VALUES (@nimi,@ruokaid,@hinta)", new { nimi = ruoka.Nimi, ruokaid = idnum, hinta = ruoka.Hinta });

                }
            }
            if ((tyyppi == 5) || (tyyppi == 1))
            {
                string str = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str))
                {
                    var idLista = connection.Query<int>("SELECT Id FROM Jalkiruoka").ToList();
                    var nimiLista = connection.Query<string>("SELECT Nimi FROM Jalkiruoka").ToList();

                    for (int i = 0; i < idLista.Count - 1; i++)
                    {
                        Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                    }
                }
                Console.WriteLine("Valitse lisättävä jälkiruoka. Anna valitsemasi jälkiruuan Id numero.");
                int idnum = int.Parse(Console.ReadLine());
                var jalkiruoka = GetJalkiruokaWithIdDB(idnum);
                string str2 = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str2))
                {
                    var toReturn = connection.Query("INSERT KoottuAteria (Nimi,JalkiruokaId,Hinta) VALUES (@nimi,@jalkiruokaid,@hinta)", new { nimi = jalkiruoka.Nimi, jalkiruokaid = idnum, hinta = jalkiruoka.Hinta });

                }
            }
        }

        public static void InsertAteriaDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var idLista = connection.Query<int>("SELECT Id FROM KoottuAteria").ToList();
                var nimiLista = connection.Query<string>("SELECT Nimi FROM KoottuAteria").ToList();

                for (int i = 0; i < idLista.Count - 1; i++)
                {
                    Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                }
            }
            Console.WriteLine("Valitse lisättävä ateria. Anna valitsemasi aterian Id numero.");
            int idnum = int.Parse(Console.ReadLine());
            string aternimi = " ";
            string str1 = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str1))
            {
                var nimi = connection.QueryFirst<string>("SELECT Nimi FROM KoottuAteria WHERE Id = @id", new {id = idnum }).ToString();
                aternimi = nimi;
            }
            Console.WriteLine(" Anna valitsemasi aterian hinta.");
            int aterhinta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valitse lisättävän aterian tyyppi:");
            Console.WriteLine("1. KoottuAteria");
            Console.WriteLine("2. Juoma");
            Console.WriteLine("3. Salaatti");
            Console.WriteLine("4. Ruoka");
            Console.WriteLine("5. Jalkiruoka");
            int tyyppi = int.Parse(Console.ReadLine());
            string str2 = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str2))
            {
                var toReturn = connection.Query("INSERT Ateria (Nimi,Hinta,KoottuAteriaId,AteriaTyyppiId) VALUES (@nimi,@hinta,@koottuateriaid,@ateriatyyppiid)", new { nimi = aternimi, hinta = aterhinta, koottuateriaid = idnum, ateriatyyppiid = tyyppi });

            }
        }

        public static void InsertAteriaToKategoriaDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var idLista = connection.Query<int>("SELECT Id FROM Kategoria").ToList();
                var nimiLista = connection.Query<string>("SELECT Nimi FROM Kategoria").ToList();

                for (int i = 0; i < idLista.Count - 1; i++)
                {
                    Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                }
            }
            Console.WriteLine("Valitse mihin kategoriaan ateria lisätään. Anna valitsemasi kategorian Id numero.");
            int idnumkat = int.Parse(Console.ReadLine());
            string str1 = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str1))
            {
                var idLista = connection.Query<int>("SELECT Id FROM Ateria").ToList();
                var nimiLista = connection.Query<string>("SELECT Nimi FROM Ateria").ToList();

                for (int i = 0; i < idLista.Count - 1; i++)
                {
                    Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                }
            }
            Console.WriteLine("Valitse lisättävä ateria. Anna valitsemasi aterian Id numero.");
            int idnumater = int.Parse(Console.ReadLine());
            string str2 = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str2))
            {
                var toReturn = connection.Query("INSERT KategAter (KategoriaId,AteriaId) VALUES (@kategoriaid, @ateriaid)", new { kategoriaid = idnumkat, ateriaid = idnumater});
            }
        }

        public static void InsertKategoriaToRuokaListaDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var idLista = connection.Query<int>("SELECT Id FROM RuokaLista").ToList();
                var nimiLista = connection.Query<string>("SELECT Nimi FROM Ruokalista").ToList();

                for (int i = 0; i < idLista.Count - 1; i++)
                {
                    Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                }
            }
            Console.WriteLine("Valitse mihin ruokalistaan kategoria lisätään. Anna valitsemasi ruokalistan Id numero.");
            int idnumruoklist = int.Parse(Console.ReadLine());
            string str1 = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str1))
            {
                var idLista = connection.Query<int>("SELECT Id FROM Kategoria").ToList();
                var nimiLista = connection.Query<string>("SELECT Nimi FROM Kategoria").ToList();

                for (int i = 0; i < idLista.Count - 1; i++)
                {
                    Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                }
            }
            Console.WriteLine("Valitse lisättävä kategoria. Anna valitsemasi kategorian Id numero.");
            int idnumkat = int.Parse(Console.ReadLine());
            string str2 = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str2))
            {
                var toReturn = connection.Query("INSERT RuokListKat (KategoriaId,RuokaListaId) VALUES (@kategoriaid, @ruokalistaid)", new { kategoriaid = idnumkat, ruokalistaid = idnumruoklist });
            }
        }

        public static void InsertRuokalistaToRavintolaDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var idLista = connection.Query<int>("SELECT Id FROM Ravintola").ToList();
                var nimiLista = connection.Query<string>("SELECT Nimi FROM Ravintola").ToList();

                for (int i = 0; i < idLista.Count - 1; i++)
                {
                    Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                }
            }
            Console.WriteLine("Valitse mihin ravintolaan ruokalista lisätään. Anna valitsemasi ravintolan Id numero.");
            int idnumrav = int.Parse(Console.ReadLine());
            string str1 = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str1))
            {
                var idLista = connection.Query<int>("SELECT Id FROM RuokaLista").ToList();
                var nimiLista = connection.Query<string>("SELECT Nimi FROM RuokaLista").ToList();

                for (int i = 0; i < idLista.Count - 1; i++)
                {
                    Console.WriteLine(idLista[i] + "  " + nimiLista[i]);
                }
            }
            Console.WriteLine("Valitse lisättävä ruokalista. Anna valitsemasi ruokalistan Id numero.");
            int idnumruoklist = int.Parse(Console.ReadLine());
            string str2 = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str2))
            {
                var toReturn = connection.Query("INSERT RavRuokList (RavintolaId,RuokaListaId) VALUES (@ravintolaid, @ruokalistaid)", new { ravintolaid = idnumrav, ruokalistaid = idnumruoklist });
            }
        }


        public static Object GetAllRavintolatDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.QueryFirst<Object>("SELECT Nimi FROM Ravintola");
                return toReturn;
            }

            //return str;
        }


        public static List<RuokaLista> GetAllRuokaListatDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query<RuokaLista>("SELECT Nimi FROM RuokaLista").ToList();
                return toReturn;
            }

            //return str;
        }

        public static List<Kategoria> GetAllKategoriatDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query<Kategoria>("SELECT Nimi FROM Kategoria").ToList();
                return toReturn;
            }

            //return str;
        }

        public static List<Ateria> GetAllAteriatDB()
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query<Ateria>("SELECT * FROM Ateria").ToList();
                return toReturn;
            }

            //return str;
        }


        public static Ravintola GetRavintolaWithIdDB(int RavintolaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.QueryFirst<Ravintola>("SELECT * FROM Ravintola WHERE id = @id", new { id = RavintolaId });
                return toReturn;
            }
        }


        public static RuokaLista GetRuokaListaWithIdDB(int RuokaListaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.QueryFirst<RuokaLista>("SELECT * FROM RuokaLista WHERE id = @id", new { id = RuokaListaId });
                return toReturn;
            }
        }


        public static Kategoria GetKategoriaWithIdDB(int KategoriaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.QueryFirst<Kategoria>("SELECT * FROM Kategoria WHERE id = @id", new { id = KategoriaId });
                return toReturn;
            }
        }


        public static Ateria GetAteriaWithIdDB(int AteriaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.QueryFirst<Ateria>("SELECT * FROM Ateria WHERE id = @id", new { id = AteriaId });
                return toReturn;
            }

            //return str;
        }


        public static int[] GetRuokaListaIdsFromRavintolaDB(int RavintolaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query<int>("SELECT RuokaListaId FROM RavRuokList WHERE RavintolaId = @id", new { id = RavintolaId }).ToArray();
                return toReturn;
            }
        }


        public static int[] GetKategoriaIdsFromRuokaListaDB(int RuokaListaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query<int>("SELECT KategoriaId FROM RuokListKat WHERE RuokaListaId = @id", new { id = RuokaListaId }).ToArray();
                return toReturn;
            }

        }


        public static int[] GetAteriaIdsFromKategoriaDB(int KategoriaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.Query<int>("SELECT AteriaId FROM KategAter WHERE KategoriaId = @id", new {id = KategoriaId}).ToArray();
                return toReturn;
            }
        }


        public static List<RuokaLista> GetAllRuokaListatFromRavintolaDB(int RavintolaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                int[] ids = GetRuokaListaIdsFromRavintolaDB(RavintolaId);
                List<RuokaLista> ruokalistat = new List<RuokaLista>();
                foreach (int id in ids)
                {
                    ruokalistat.Add(GetRuokaListaWithIdDB(id));
                }
                return ruokalistat;
            }
        }


        public static List<Kategoria> GetAllKategoriatFromRuokaListaDB(int RuokaListaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                int[] ids = GetKategoriaIdsFromRuokaListaDB(RuokaListaId);
                List<Kategoria> kategoriat = new List<Kategoria>();
                foreach (int id in ids)
                {
                    kategoriat.Add(GetKategoriaWithIdDB(id));
                }
                return kategoriat;
            }
        }


        public static List<Ateria> GetAllAteriatFromKategoriaDB(int KategoriaId)
       {
           string str = DataAccess.CnnVal(DataAccess.currentDBname);
           using (IDbConnection connection = new SqlConnection(str))
           {
               int[] ids = GetAteriaIdsFromKategoriaDB(KategoriaId);
               List<Ateria> ateriat = new List<Ateria>();
               foreach (int id in ids)
               {
                  ateriat.Add(GetAteriaWithIdDB(id));
               }
               return ateriat;
           }
       }  


        public static Ravintola GetAllRavintolaDataWithIdDB(int RavintolaId)
        {
            Ravintola ravintola = GetRavintolaWithIdDB(RavintolaId);
            ravintola.ruokalistat = GetAllRuokaListatFromRavintolaDB(ravintola.Id);

            foreach (RuokaLista ruokalista in ravintola.ruokalistat)
            {
                ruokalista.kategoriat = GetAllKategoriatFromRuokaListaDB(ruokalista.Id);
                foreach (Kategoria kategoria in ruokalista.kategoriat)
                {
                    kategoria.kategoriarakentuu = GetAllAteriatFromKategoriaDB(kategoria.Id);
                }

            }
            return ravintola;
        }

          
         public static void GetAteriaDetailsDB(int AteriaId)
        {
            var ateria = GetAteriaWithIdDB(AteriaId);
            int koottuAteriaId = ateria.KoottuAteriaId;
            int ateriaTyyppi = ateria.AteriaTyyppiId;
            //Console.WriteLine(ateriaTyyppi);
           // Console.WriteLine(koottuAteriaId);

            if ((ateriaTyyppi == 2) || (ateriaTyyppi == 1))
            {
                string str = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str))
                {
                    var juomaId = connection.QueryFirst<int>("SELECT JuomaId FROM KoottuAteria WHERE Id = @id", new { id = koottuAteriaId });
                    var juoma = GetJuomaWithIdDB(juomaId);
                    Console.WriteLine(juoma.Nimi);
                    //Console.WriteLine(juoma.Hinta);
                   // Console.WriteLine(juoma.AnnosDl);
                }
            }
            if ((ateriaTyyppi == 3) || (ateriaTyyppi == 1))
            {
                string str = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str))
                {
                    var salaattiId = connection.QueryFirst<int>("SELECT SalaattiId FROM KoottuAteria WHERE Id = @id", new { id = koottuAteriaId });
                    var salaatti = GetSalaattiWithIdDB(salaattiId);
                    Console.WriteLine(salaatti.Nimi);
                    //Console.WriteLine(salaatti.Hinta);
                }
            }
            if ((ateriaTyyppi == 4) || (ateriaTyyppi == 1))
            {
                string str = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str))
                {
                    var ruokaId = connection.QueryFirst<int>("SELECT RuokaId FROM KoottuAteria WHERE Id = @id", new { id = koottuAteriaId });
                    var ruoka = GetRuokaWithIdDB(ruokaId);
                    Console.WriteLine(ruoka.Nimi);
                    //Console.WriteLine(ruoka.Hinta);
                }
            }
            if ((ateriaTyyppi == 5) || (ateriaTyyppi == 1))
            {
                string str = DataAccess.CnnVal(DataAccess.currentDBname);
                using (IDbConnection connection = new SqlConnection(str))
                {
                    var jalkiruokaId = connection.QueryFirst<int>("SELECT JalkiruokaId FROM KoottuAteria WHERE Id = @id", new { id = koottuAteriaId });
                    var jalkiruoka = GetJalkiruokaWithIdDB(jalkiruokaId);
                    Console.WriteLine(jalkiruoka.Nimi);
                    //Console.WriteLine(jalkiruoka.Hinta);
                }
            }

        }

        public static Juoma GetJuomaWithIdDB(int juomaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.QueryFirst<Juoma>("SELECT * FROM Juoma WHERE id = @id", new { id = juomaId });
                return toReturn;
            }
        }

        public static Salaatti GetSalaattiWithIdDB(int salaattiId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.QueryFirst<Salaatti>("SELECT * FROM Salaatti WHERE id = @id", new { id = salaattiId });
                return toReturn;
            }
        }

        public static Ruoka GetRuokaWithIdDB(int ruokaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.QueryFirst<Ruoka>("SELECT * FROM Ruoka WHERE id = @id", new { id = ruokaId });
                return toReturn;
            }
        }

        public static Jalkiruoka GetJalkiruokaWithIdDB(int jalkiruokaId)
        {
            string str = DataAccess.CnnVal(DataAccess.currentDBname);
            using (IDbConnection connection = new SqlConnection(str))
            {
                var toReturn = connection.QueryFirst<Jalkiruoka>("SELECT * FROM Jalkiruoka WHERE id = @id", new { id = jalkiruokaId });
                return toReturn;
            }
        }


        public List<Ravintola> GetRavintolat()
        {
            return _ravintolat;
        }

        public void InsertRavintola(Ravintola ravintola)
        {
            _ravintolat.Add(ravintola);
        }

        public List<Ateria> GetAllAteriat()
        {
            return _ateriatkaikki;
        }

        public void InsertAteria(Ateria ateria)
        {
            _ateriatkaikki.Add(ateria);
        }

        public DataManager()
        {
            this.AddBasicData();
        }
       

        public void AddBasicData()
        {
            //Allergia

            Allergia allergiat = new Allergia();
            Dictionary<string, string> perusallergiat = allergiat.AsetaPerusAllergiat();

            //Juomat
            Juoma maito = new Juoma();
            maito.Nimi = "maito";
            maito.Hinta = 2.0F;
            maito.AnnosDl = 2.0F;

            Juoma vesi = new Juoma();
            vesi.Nimi = "vesi";
            vesi.Hinta = 0.5F;
            vesi.AnnosDl = 2.5F;

            Juoma olut = new Juoma();
            olut.Nimi = "olut";
            olut.Hinta = 5.0F;
            olut.AnnosDl = 2.5F;

            //salaatit
            Salaatti caesar = new Salaatti();
            caesar.Nimi = "Caesar-salaatti";
            caesar.Hinta = 7.5F;
            caesar.Kastike = "Kevytmajoneesi";
            caesar.RuokaValio = "M , L, GL, V";
            //caesar.Allergeenit = "maito, laktoosi, gluteeni, vege";
            caesar.AddAllergia("maito");
            caesar.AddAllergia("laktoosi");
            caesar.AddAllergia("gluteeni");
            caesar.AddAllergia("vege");

            Salaatti kreikkalainen = new Salaatti();
            kreikkalainen.Nimi = "Kreikkalainen-salaatti";
            kreikkalainen.Hinta = 6.5F;
            kreikkalainen.Kastike = "Kevytmajoneesi";
            kreikkalainen.RuokaValio = "M , L, GL, V";
            //kreikkalainen.Allergeenit = "maito, laktoosi, gluteeni, vege";
            kreikkalainen.AddAllergia("maito");
            kreikkalainen.AddAllergia("laktoosi");
            kreikkalainen.AddAllergia("gluteeni");
            kreikkalainen.AddAllergia("vege");

            Salaatti peruna = new Salaatti();
            peruna.Nimi = "Peruna-salaatti";
            peruna.Hinta = 4.0F;
            peruna.RuokaValio = "L, GL, V";
           // peruna.Allergeenit = "laktoosi, gluteeni, vege";
            peruna.AddAllergia("laktoosi");
            peruna.AddAllergia("gluteeni");
            peruna.AddAllergia("vege");

            Salaatti italia = new Salaatti();
            italia.Nimi = "Italian-salaatti";
            italia.Hinta = 4.0F;
            italia.RuokaValio = "L";
            //italia.Allergeenit = "laktoosi";
            italia.AddAllergia("laktoosi");

            Salaatti perussalaatti = new Salaatti();
            perussalaatti.Nimi = "Perus-salaatti";
            perussalaatti.Hinta = 3.5F;
            perussalaatti.RuokaValio = "M,L,GL,V";
            //perussalaatti.Allergeenit = "maito, laktoosi, gluteeni, vege";
            perussalaatti.AddAllergia("maito");
            perussalaatti.AddAllergia("laktoosi");
            perussalaatti.AddAllergia("gluteeni");
            perussalaatti.AddAllergia("vege");

            //Ruoka
            Ruoka karjalanpaisti = new Ruoka();
            karjalanpaisti.Nimi = "Karjalanpaisti + perunamuusi";
            karjalanpaisti.Hinta = 14.5F;
            karjalanpaisti.RuokaAineet = " liha, peruna, juureksia";
            karjalanpaisti.RuokaValio = "L, GL";
            //karjalanpaisti.Allergeenit = "laktoosi, gluteeni";
            karjalanpaisti.AddAllergia("laktoosi");
            karjalanpaisti.AddAllergia("gluteeni");

            Ruoka uunilohi = new Ruoka();
            uunilohi.Nimi = "Uunilohi + uuniperunat";
            uunilohi.RuokaAineet = " kala, peruna, juureksia";
            uunilohi.Hinta = 15.5F;
            uunilohi.RuokaValio = "L, GL";
           // uunilohi.Allergeenit = "laktoosi, gluteeni";
            uunilohi.AddAllergia("laktoosi");
            uunilohi.AddAllergia("gluteeni");

            Ruoka lihakeitto = new Ruoka();
            lihakeitto.Nimi = "Lihakeitto";
            lihakeitto.RuokaAineet = " liha, peruna, juureksia";
            lihakeitto.Hinta = 10F;
            lihakeitto.RuokaValio = "L, GL";
            // lihakeitto.Allergeenit = "laktoosi, gluteeni";
            lihakeitto.AddAllergia("laktoosi");
            lihakeitto.AddAllergia("gluteeni");

            Ruoka kalakeitto = new Ruoka();
            kalakeitto.Nimi = "Kalakeitto";
            kalakeitto.RuokaAineet = " kala, peruna, juureksia";
            kalakeitto.Hinta = 10F;
            kalakeitto.RuokaValio = "L, GL";
           // kalakeitto.Allergeenit = "laktoosi, gluteeni";
            kalakeitto.AddAllergia("laktoosi");
            kalakeitto.AddAllergia("gluteeni");

            Ruoka pizza = new Ruoka();
            pizza.Nimi = "FruttidiMare-Pizza";
            pizza.RuokaAineet = "tonnikala, simpukka, katkarapu, juusto, tomaattikastike";
            pizza.Hinta = 7.5F;
            pizza.RuokaValio = "L";
            //pizza.Allergeenit = "laktoosi";
            pizza.AddAllergia("laktoosi");

            //jalkiruoka
            Jalkiruoka jaatelo = new Jalkiruoka();
            jaatelo.Nimi = "Jäätelö";
            jaatelo.Hinta = 2.0F;
            jaatelo.RuokaValio = "L";
            //jaatelo.Allergeenit = "laktoosi";
            jaatelo.AddAllergia("laktoosi");

            Jalkiruoka rahka = new Jalkiruoka();
            rahka.Nimi = "Rahka";
            rahka.Hinta = 2.0F;
            rahka.RuokaValio = "L";
            //rahka.Allergeenit = "laktoosi";
            rahka.AddAllergia("laktoosi");

            Jalkiruoka kahvi = new Jalkiruoka();
            kahvi.Nimi = "Kahvi";
            kahvi.Hinta = 1.5F;

            InsertAteria(maito);
            InsertAteria(vesi);
            InsertAteria(olut);
            InsertAteria(karjalanpaisti);
            InsertAteria(uunilohi);
            InsertAteria(lihakeitto);
            InsertAteria(kalakeitto);
            InsertAteria(caesar);
            InsertAteria(kreikkalainen);
            InsertAteria(peruna);
            InsertAteria(italia);
            InsertAteria(perussalaatti);
            InsertAteria(jaatelo);
            InsertAteria(rahka);
            InsertAteria(kahvi);
            InsertAteria(pizza);

            //Ateriat
            Ateria ateria1 = new Ateria();
            ateria1.Nimi = "Karjalanpaisti";
            ateria1.Hinta = 18F;
            ateria1.ateriarakentuu.Add(_ateriatkaikki[3]);
            ateria1.ateriarakentuu.Add(_ateriatkaikki[0]);
            ateria1.ateriarakentuu.Add(_ateriatkaikki[11]);
            ateria1.ateriarakentuu.Add(_ateriatkaikki[13]);


            Ateria ateria2 = new Ateria();
            ateria2.Nimi = "UUnilohi";
            ateria2.Hinta = 18F;
            ateria2.ateriarakentuu.Add(_ateriatkaikki[4]);
            ateria2.ateriarakentuu.Add(_ateriatkaikki[0]);
            ateria2.ateriarakentuu.Add(_ateriatkaikki[11]);
            ateria2.ateriarakentuu.Add(_ateriatkaikki[12]);


            Ateria ateria3 = new Ateria();
            ateria3.Nimi = "Kreikkalainen-salaatti";
            ateria3.Hinta = 10F;
            ateria3.ateriarakentuu.Add(_ateriatkaikki[8]);
            ateria3.ateriarakentuu.Add(_ateriatkaikki[1]);
            ateria3.ateriarakentuu.Add(_ateriatkaikki[12]);



            Ateria ateria4 = new Ateria();
            ateria4.Nimi = "Lihakeitto";
            ateria4.Hinta = 10F;
            ateria4.ateriarakentuu.Add(_ateriatkaikki[5]);
            ateria4.ateriarakentuu.Add(_ateriatkaikki[1]);
            ateria4.ateriarakentuu.Add(_ateriatkaikki[11]);
            ateria4.ateriarakentuu.Add(_ateriatkaikki[12]);


            Ateria ateria5 = new Ateria();
            ateria5.Nimi = "Kalakeitto";
            ateria5.Hinta = 10F;
            ateria5.ateriarakentuu.Add(_ateriatkaikki[6]);
            ateria5.ateriarakentuu.Add(_ateriatkaikki[1]);
            ateria5.ateriarakentuu.Add(_ateriatkaikki[11]);
            ateria5.ateriarakentuu.Add(_ateriatkaikki[14]);

            //Kategoriat
            Kategoria keitot = new Kategoria();
            keitot.Nimi = "Keitot";
            keitot.kategoriarakentuu.Add(ateria5);
            keitot.kategoriarakentuu.Add(ateria4);

            Kategoria salaatit = new Kategoria();
            salaatit.Nimi = "Salaatit";
            salaatit.kategoriarakentuu.Add(ateria3);

            Kategoria liharuuat = new Kategoria();
            liharuuat.Nimi = "Liharuuat";
            liharuuat.kategoriarakentuu.Add(ateria1);
            liharuuat.kategoriarakentuu.Add(ateria4);

            Kategoria kalaruuat = new Kategoria();
            kalaruuat.Nimi = "Kalaruuat";
            kalaruuat.kategoriarakentuu.Add(ateria2);
            kalaruuat.kategoriarakentuu.Add(ateria5);

            Kategoria juomat = new Kategoria();
            juomat.Nimi = "Juomat";
            juomat.kategoriarakentuu.Add(_ateriatkaikki[0]);
            juomat.kategoriarakentuu.Add(_ateriatkaikki[1]);
            juomat.kategoriarakentuu.Add(_ateriatkaikki[2]);

            Kategoria jalkiruuat = new Kategoria();
            jalkiruuat.Nimi = "Jälkiruuat";
            jalkiruuat.kategoriarakentuu.Add(_ateriatkaikki[12]);
            jalkiruuat.kategoriarakentuu.Add(_ateriatkaikki[13]);
            jalkiruuat.kategoriarakentuu.Add(_ateriatkaikki[14]);

            Kategoria pizzat = new Kategoria();
            pizzat.Nimi = "Pizzat";
            pizzat.kategoriarakentuu.Add(_ateriatkaikki[15]);

            //Ruokalistat
            RuokaLista menu1 = new RuokaLista();
            menu1.Nimi = "Ruoka-lista1";
            menu1.kategoriat.Add(keitot);
            menu1.kategoriat.Add(salaatit);
            menu1.kategoriat.Add(liharuuat);
            menu1.kategoriat.Add(kalaruuat);
            menu1.kategoriat.Add(juomat);
            menu1.kategoriat.Add(jalkiruuat);

            RuokaLista menu2 = new RuokaLista();
            menu2.Nimi = "Ruoka-lista2";
            menu2.kategoriat.Add(salaatit);
            menu2.kategoriat.Add(pizzat);
            menu2.kategoriat.Add(juomat);
            menu2.kategoriat.Add(jalkiruuat);

            //Ravintolat
            Ravintola ravintola1 = new Ravintola();
            ravintola1.Nimi = "Liisan Ravintola";
            ravintola1.Osoite = "Koulukatu 5";
            ravintola1.PuhelinNro = 044123456;
            ravintola1.ruokalistat.Add(menu1);

            Ravintola ravintola2 = new Ravintola();
            ravintola2.Nimi = "Keijon Pizza";
            ravintola2.Osoite = "Kotikatu 12";
            ravintola2.PuhelinNro = 050567894;
            ravintola2.ruokalistat.Add(menu2);

            InsertRavintola(ravintola1);
            InsertRavintola(ravintola2);


            /*
            //Ateriat
            Ateria ateria1 = new Ateria();
            ateria1.Nimi = "Karjalanpaisti";
            ateria1.Hinta = 18F;
            ateria1.ateriarakentuu.Add(karjalanpaisti);
            ateria1.ateriarakentuu.Add(maito);
            ateria1.ateriarakentuu.Add(perussalaatti);
            ateria1.ateriarakentuu.Add(rahka);


            Ateria ateria2 = new Ateria();
            ateria2.Nimi = "UUnilohi";
            ateria2.Hinta = 18F;
            ateria2.ateriarakentuu.Add(uunilohi);
            ateria2.ateriarakentuu.Add(maito);
            ateria2.ateriarakentuu.Add(perussalaatti);
            ateria2.ateriarakentuu.Add(jaatelo);

            Ateria ateria3 = new Ateria();
            ateria3.Nimi = "Kreikkalainen-salaatti";
            ateria3.Hinta = 10F;
            ateria3.ateriarakentuu.Add(kreikkalainen);
            ateria3.ateriarakentuu.Add(vesi);
            ateria3.ateriarakentuu.Add(jaatelo);

            Ateria ateria4 = new Ateria();
            ateria4.Nimi = "Lihakeitto";
            ateria4.Hinta = 10F;
            ateria4.ateriarakentuu.Add(lihakeitto);
            ateria4.ateriarakentuu.Add(vesi);
            ateria4.ateriarakentuu.Add(perussalaatti);
            ateria4.ateriarakentuu.Add(jaatelo);

            Ateria ateria5 = new Ateria();
            ateria5.Nimi = "Kalakeitto";
            ateria5.Hinta = 10F;
            ateria5.ateriarakentuu.Add(kalakeitto);
            ateria5.ateriarakentuu.Add(vesi);
            ateria5.ateriarakentuu.Add(perussalaatti);
            ateria5.ateriarakentuu.Add(jaatelo); */


            /*
            //Kategoriat
            Kategoria keitot = new Kategoria();
            keitot.Nimi = "Keitot";
            keitot.kategoriarakentuu.Add(ateria5);
            keitot.kategoriarakentuu.Add(ateria4);

            Kategoria salaatit = new Kategoria();
            salaatit.Nimi = "Salaatit";
            salaatit.kategoriarakentuu.Add(ateria3);

            Kategoria liharuuat = new Kategoria();
            liharuuat.Nimi = "Liharuuat";
            liharuuat.kategoriarakentuu.Add(ateria1);
            liharuuat.kategoriarakentuu.Add(ateria4);

            Kategoria kalaruuat = new Kategoria();
            kalaruuat.Nimi = "Kalaruuat";
            kalaruuat.kategoriarakentuu.Add(ateria2);
            kalaruuat.kategoriarakentuu.Add(ateria5);

            Kategoria juomat = new Kategoria();
            juomat.Nimi = "Juomat";
            juomat.kategoriarakentuu.Add(maito);
            juomat.kategoriarakentuu.Add(vesi);
            juomat.kategoriarakentuu.Add(olut);

            Kategoria jalkiruuat = new Kategoria();
            jalkiruuat.Nimi = "Jälkiruuat";
            jalkiruuat.kategoriarakentuu.Add(jaatelo);
            jalkiruuat.kategoriarakentuu.Add(rahka);
            jalkiruuat.kategoriarakentuu.Add(kahvi);

           // Kategoria pizzat = new Kategoria();
           // pizzat.Nimi = "Pizzat";


            //Ruokalista
            RuokaLista menu = new RuokaLista();
            menu.Nimi = "Ruoka-lista";
            menu.kategoriat.Add(keitot);
            menu.kategoriat.Add(salaatit);
            menu.kategoriat.Add(liharuuat);
            menu.kategoriat.Add(kalaruuat);
            menu.kategoriat.Add(juomat);
            menu.kategoriat.Add(jalkiruuat); */


        }


    }
}
