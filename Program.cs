using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LogicielReservation
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlSerializer xs = new XmlSerializer(typeof(Restaurant));

            Restaurant r = new Restaurant("Cadjee", "azety");
            using (StreamWriter wr = new StreamWriter("restaurant1.xml"))
            {
                xs.Serialize(wr, r);
            }

            using (StreamReader rd = new StreamReader("restaurant1.xml"))
            {
                Restaurant p = xs.Deserialize(rd) as Restaurant;
                Console.WriteLine("Nom : {0}", p.monNom);
                Console.WriteLine("Mdp : {0}", p.monMotDePasse);
            } 
            Console.ReadKey();

            #region test

            /*
            int choix = 0;
            bool quitte = false;
            bool choixOk = false;
            string nomrestaurant;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("*****************************************************");
                Console.WriteLine("Bienvenue sur le logiciel de gestion de réservations.");
                Console.WriteLine("*****************************************************");
                Console.ResetColor();
                Console.WriteLine("");

            //Gestion du menu
            while (!quitte)
            {
                Console.WriteLine("\n[1] Ouvrir un restaurant existant \n[2] Créer un restaurant \n \n \n[0] Quitter");
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
                        Console.WriteLine("Entrez le nom du restaurant");
                        nomrestaurant = Console.ReadLine();
                        ChoixRestaurant(nomrestaurant);  //Fonction à créer (avec recherche sur un dossier) qui permet d'accéder à "MenuRestaurant" avec pour entrée le restaurant choisi
                        break;
                    case 2:
                        CreerRestaurant(); //Fonction à créer (avec création d'un dossier) qui permet ensuite d'accéder à "MenuRestaurant" avec pour entrée le restaurant créé
                        break;
                    case 0:
                        quitte = true;
                        break;
                }
            }
            */
            #endregion

        }

        /// <summary>
        /// Gestion du menu interne au restaurant. Permet d'accéder au menu de chaque fonction
        /// </summary>
        /// <param name="restaurant">Le restaurant choisi par l'utilisateur</param>
        /*
        public static void MenuRestaurant(Restaurant restaurant)
        {
            Console.Clear();

            int choix = 0;
            bool quitte = false;
            bool choixOk = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("***Bienvenue sur le logiciel de gestion de réservations***");
            Console.WriteLine("*****************************************************");
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
                        restaurant.MenuReservations();
                        break;
                    case 2:
                        restaurant.MenuSalles();
                        break;
                    case 3:
                        restaurant.MenuTables();
                        break;
                    case 4:
                        restaurant.MenuFormules();
                        break;
                    case 5:
                        restaurant.MenuPlats();
                        break;
                    case 6:
                        restaurant.MenuPersonnel();
                        break;
                    case 7:
                        restaurant.MenuParametres();
                        break;
                    case 0:
                        quitte = true;
                        break;
                }
            }
        }

        */

    }
 }
