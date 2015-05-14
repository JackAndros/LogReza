using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace LogicielReservation
{
    class Program
    {
        static void Main(string[] args) {

            Salle t = new Salle("Grande Salle");
            t.tousTypesTables();

            Console.ReadKey();

            #region test serialisation table

            //Restaurant r = new Restaurant("test", "mdp");

            #endregion

            #region test1

            /*
            XmlSerializer xs = new XmlSerializer(typeof(Restaurant));

            Restaurant r = new Restaurant("Cadjee", "azety");
            using (StreamWriter wr = new StreamWriter("restaurant1.xml",true))
            {
                xs.Serialize(wr, r);
            }

            using (StreamReader rd = new StreamReader("restaurant1.xml"))
            {
                    Restaurant p = xs.Deserialize(rd) as Restaurant;
                Console.WriteLine("Nom : {0}", p.monNom);
                Console.WriteLine("Mdp : {0}", p.monMotDePasse);
            }

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("users");
            xmlDoc.AppendChild(rootNode);

            XmlNode userNode = xmlDoc.CreateElement("user");
            XmlAttribute attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = "42";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "John Doe";
            rootNode.AppendChild(userNode);

            userNode = xmlDoc.CreateElement("user");
            attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = "39";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "Jane Doe";
            rootNode.AppendChild(userNode);

            xmlDoc.Save("test-doc.xml");



            xmlDoc = new XmlDocument();
            xmlDoc.Load("test-doc.xml");
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
                Console.WriteLine(xmlNode.Attributes["currency"].Value + ": " + xmlNode.Attributes["rate"].Value);
            Console.ReadKey();


            */

            #endregion

            #region test2

            /*

            XmlDocument docResto = new XmlDocument();
            XmlNode listesTables = docResto.CreateElement("Tables");

            XmlNode rootNode = docResto.CreateElement("table");

            XmlNode numTable = docResto.CreateElement("NumeroTable");
            numTable.InnerText = "aze";
            XmlNode mobilite = docResto.CreateElement("Mobilite");
            mobilite.InnerText = "qsdé";
            XmlNode etat = docResto.CreateElement("Etat");
            etat.InnerText = "aze";

            rootNode.AppendChild(numTable);
            rootNode.AppendChild(mobilite);
            rootNode.AppendChild(etat);

            listesTables.AppendChild(rootNode);
            docResto.AppendChild(listesTables);

            docResto.Save("test" + ".xml");

            */

            #endregion

            #region Real

            string pathToAllDir = "../../../DonneesRestaurants";

            string[] tempListDir = Directory.GetDirectories(pathToAllDir);
            List<string> listDirectories = new List<string>();

            foreach (var item in tempListDir) {
                listDirectories.Add(item.Split(new Char[] { '\\' })[1]);
            }

            int choix = 0;
            bool quitte = false;
            bool choixOk = false;
            List<Restaurant> listRestaurants = new List<Restaurant>();
            string nomRestaurant;
            string pathRestaurant;


            //Gestion du menu
            while (!quitte)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("*************************************************************");
                Console.WriteLine("**** Bienvenue sur le logiciel de gestion de réservations ***");
                Console.WriteLine("**************** Menu principal du logiciel *****************");
                Console.WriteLine("*************************************************************");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("\n[1] Choisir un restaurant parmi ceux déjà existants dans le logiciel \n[2] Créer un restaurant \n \n \n[0] Quitter");
                choixOk = false;
                do
                {
                    Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                    choixOk = Int32.TryParse(Console.ReadLine(), out choix);
                }
                while (!choixOk);


                switch (choix)
                {
                    case 1:
                        ChoixRestaurant(listDirectories); 
                        break;
                    case 2:
                        Restaurant r = CreerRestaurant();
                        listRestaurants.Add(r); //Fonction à créer (avec création d'un dossier) qui permet ensuite d'accéder à "MenuRestaurant" avec pour entrée le restaurant créé
                        listDirectories.Add(r.monNom);                        
                        break;
                    case 0:
                        quitte = true;
                        break;
                }
                choix = 0;
            }
            
            #endregion

        }

        /// <summary>
        /// Cette fonction va permettre de créer un nouveau restaurant avec le peu d'informations nécessaires, et de créer un dossier qui lui sera propre
        /// </summary>
        public static Restaurant CreerRestaurant(){
            Console.WriteLine("");
            Console.WriteLine("*****************************************");
            Console.WriteLine("*** Création d'un nouveau restaurant ***");
            Console.WriteLine("*****************************************");

            Console.WriteLine("");
            Console.WriteLine("Quel est le nom de votre restaurant ?");
            String nomRest = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Quel est le mot de passe de votre restaurant ?");
            String mdpRest = Console.ReadLine();

            Restaurant r = new Restaurant(nomRest, mdpRest);

            System.IO.Directory.CreateDirectory("../../../DonneesRestaurants/" + nomRest);

            r.sauveInfosRestaurant();

            return r;
        }


        /// <summary>
        /// Cette fonction va permettre d'accéder à "MenuRestaurant" avec pour entrée le restaurant choisi
        /// </summary>
        /// <param name=""></param> 
        public static void ChoixRestaurant(List<string> listRestaurants)
        {
            bool choixOk = false;
            int choix = 0;
            do {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("*****************************************************************************");
                Console.WriteLine("*** Choisissez votre restaurant parmi la liste des restaurants ci-dessous ***");
                Console.WriteLine("*****************************************************************************");
                Console.WriteLine();
                Console.ResetColor();


                for (int i = 0; i < listRestaurants.Count(); i++) {
                    Console.WriteLine("[{0}]  : {1}", i, listRestaurants[i]);
                }

                choixOk = Int32.TryParse(Console.ReadLine(), out choix);

            }
            while (!choixOk && (choix > listRestaurants.Count()) && (choix < 0));

            MenuRestaurant(listRestaurants[choix]);

        }

        /// <summary>
        /// Gestion du menu interne au restaurant. Permet d'accéder au menu de chaque fonction
        /// </summary>
        /// <param name="restaurant">Le restaurant choisi par l'utilisateur</param>
        public static void MenuRestaurant(string restaurant)
        {
            Console.Clear();
            string pathToAllDir = "../../../DonneesRestaurants";
            int choix = 0;
            bool quitte = false;
            bool choixOk = false;
            Restaurant restaurantChoisi;

            XmlSerializer xs = new XmlSerializer(typeof(Restaurant));

            using (StreamReader rd = new StreamReader(pathToAllDir+"/"+restaurant+"/restaurant.xml")) {
                restaurantChoisi = xs.Deserialize(rd) as Restaurant;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("************************************************************");
            Console.WriteLine("*** Bienvenue sur le logiciel de gestion de réservations ***");
            Console.WriteLine("******************** Restaurant {0} *********************", restaurant);
            Console.WriteLine("************************************************************");
            Console.ResetColor();
            Console.WriteLine("");

            //Gestion du menu
            while (!quitte)
            {
                Console.WriteLine("\n[1] Gérer les réservations \n[2] Gérer les salles \n[3] Gérer les tables \n[4] Gérer les formules \n[5] Gérer les plats \n[6] Gérer le personnel\n[7] Régler les paramètres du restaurant \n \n \n[0] Quitter");

                choixOk = false;
                do
                {
                    Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                    choixOk = Int32.TryParse(Console.ReadLine(), out choix);
                }
                while (!choixOk);

                switch (choix)
                {
                    case 1:
                        restaurantChoisi.listerReservations();
                        break;
                    case 2:
                        restaurantChoisi.listerSalles();
                        break;
                    case 3:
                        restaurantChoisi.listerTables();
                        break;
                    case 4:
                        restaurantChoisi.listerFormules();
                        break;
                    case 5:
                        restaurantChoisi.listerPlats();
                        break;
                    case 6:
                        restaurantChoisi.listerPersonnels();
                        break;
                    case 7:
                        restaurantChoisi.listerParametres();
                        break;
                    case 0:
                        quitte = true;
                        break;
                }
            }
        }


    }
 }
