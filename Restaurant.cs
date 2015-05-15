using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace LogicielReservation
{
    [Serializable()]
    public class Restaurant
    {
        #region variables
        [XmlIgnore]
        protected List<Salle> _salles;
        [XmlIgnore]
        protected List<Personnel> _personnels;
        [XmlIgnore]
        protected List<Formule> _formules;
        [XmlIgnore]
        protected List<Reservation> _reservations;
        [XmlIgnore]
        protected string _nom;
        [XmlIgnore]
        protected string _motDePasse;
        [XmlIgnore]
        protected List<Plat> _plats;
        
        #endregion


        #region accesseurs
        
        [XmlElement("Nom")]
        public string monNom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        [XmlElement("MotDePasse")]
        public string monMotDePasse
        {
            get { return _motDePasse; }
            set { _motDePasse = value; }
        }

        [XmlArray("Salles")]
        [XmlArrayItem("Salle")]
        public List<Salle> mesSalles
        {
            get { return _salles; }
            set { _salles = value; }
        }

        [XmlArray("Personnels")]
        [XmlArrayItem("Personnel")]
        [XmlIgnore]
        public List<Personnel> mesPersonnels
        {
            get { return _personnels; }
            set { _personnels = value; }
        }

        [XmlArray("Formules")]
        [XmlArrayItem("Formule")]
        public List<Formule> mesFormules
        {
            get { return _formules; }
            set { _formules = value; }
        }

        [XmlArray("Reservations")]
        [XmlArrayItem("Reservation")]
        public List<Reservation> mesReservations
        {
            get { return _reservations; }
            set { _reservations = value; }
        }

        [XmlArray("Plats")]
        [XmlArrayItem("Plat")]
        public List<Plat> mesPlats {
            get { return _plats; }
            set { _plats = value; }
        }

        #endregion


        #region constructeur

        public Restaurant() {
            /*
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("**** Entrez un nom pour votre restaurant ***");
            string nom = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("**** Entrez un mot de passe pour votre restaurant ***");
            string mdp = Console.ReadLine();

            mesSalles = new List<Salle>();
            mesPersonnels = new List<Personnel>();
            mesFormules = new List<Formule>();
            mesReservations = new List<Reservation>();
            monNom = nom;
            monMotDePasse = mdp;
            */
        }

        public Restaurant(string restaurant, string mdp)
        {
            Directory.CreateDirectory("../../../DonneesRestaurants/" + restaurant);

            mesSalles = new List<Salle>();
            mesPersonnels = new List<Personnel>();
            mesFormules = new List<Formule>();
            mesReservations = new List<Reservation>();
            monNom = restaurant;
            monMotDePasse = mdp;
        }   

        #endregion


        #region methodes

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public override string ToString() {
            string st = "";

            st += "Mon nom " + monNom + " \n";
            st += "Mdp " + monMotDePasse + " \n";

            return st;
        }
        
        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public bool chercheRestaurant(string n) {
            bool toReturn = false;
            string pathToAllDir = "../../../DonneesRestaurants";

            string[] tempListDir = Directory.GetDirectories(pathToAllDir);
            List<string> listDirectories = new List<string>();

            foreach (var item in tempListDir) {
                listDirectories.Add(item.Split(new Char[] { '\\' })[1]);
                if (item.ToString() == n)
	            {
		            toReturn = true;
                    break;
	            }
            }

            return toReturn;
        }


        #region gestion reservations

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void gererReservations()
        {
            int choix;
            bool choixOk = false;
            do {
                Console.WriteLine("\n---------\n Que voulez-vous faire ? \n---------\n");

                Console.WriteLine("\n[1] Ajouter une réservation \n[2] Supprimer une réservation \n[3] Voir les réservations pour une salle \n \n \n[0] Retour");

                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk);
            switch (choix)
                {
                    case 1:
                        ajoutReservation();
                        break;
                    case 2:
                        suppressionReservation();
                        break;
                    case 3:
                        afficherReservations();
                        break;
                    case 0:
                        break;
                }
        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void ajoutReservation() {

        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void suppressionReservation() {
            bool choixOk = false;
            int choix = -1;
            do {
                Console.WriteLine("Quelle réservation voulez-vous supprimer ?");
                for (int i = 0; i < mesReservations.Count; i++) {
                    Console.WriteLine("[{0}] : {1}  {2}", i, mesReservations[i].monNomReservation, mesReservations[i].maDate);
                }
                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk && (choix >= mesReservations.Count) && (choix < 0));

            mesSalles.RemoveAt(choix);
            Console.WriteLine("Réservation supprimée");
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void afficherReservations() {
            Console.Clear();
            Console.WriteLine("Liste des réservations du restaurant : ");
            foreach (var reservation in mesReservations) {
                Console.WriteLine(reservation.ToString());
            }
            Console.ReadLine();
        }

        #endregion


        #region gestion salles


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void gererSalles() {
            int choix;
            bool choixOk = false;
            do {
                Console.WriteLine("\n---------\n Que voulez-vous faire ? \n---------\n");

                Console.WriteLine("\n[1] Ajouter une salle \n[2] Supprimer une salle \n[3] Voir les salles \n \n \n[0] Retour");

                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk);
            switch (choix) {
                case 1:
                    ajoutSalle();
                    break;
                case 2:
                    suppressionSalle();
                    break;
                case 3:
                    afficherSalle();
                    break;
                case 0:
                    break;
            }
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void ajoutSalle() {
            Console.WriteLine("*** Quel est le nom de la salle ? ***");
            string nom = Console.ReadLine();
            Salle salle = chercheSalle(nom);
            if (salle == null) {
                mesSalles.Add(salle);
            }
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void suppressionSalle() {
            bool choixOk = false;
            int choix = -1;
            do {
                Console.WriteLine("Quelle salle voulez-vous supprimer ?");
                for (int i = 0; i < mesSalles.Count; i++) {
                    Console.WriteLine("[{0}] : {1}", i, mesSalles[i].monNom);
                }
                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk && (choix >= mesSalles.Count) && (choix < 0));

            mesSalles.RemoveAt(choix);
            Console.WriteLine("Salle supprimée");
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void afficherSalle() {
            Console.Clear();
            Console.WriteLine("Liste des salles du restaurant : ");
            foreach (var salle in mesSalles) {
                Console.WriteLine(salle.ToString());
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public int cherchePositionSalle(string s) {
            var index = mesSalles.FindIndex(item => item.monNom == s);

            return (int)index;
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public Salle chercheSalle(string s) {
            Salle salle = new Salle();
            if (mesSalles.Exists(item => item.monNom == s)) {
                salle = mesSalles.Find(item => item.monNom == s);
            }

            return salle;
        }

        #endregion


        #region gestion tables


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void gererTables()
        {
            int choix;
            bool choixOk = false;
            do {
                Console.WriteLine("\n---------\n Que voulez-vous faire ? \n---------\n");

                Console.WriteLine("\n[1] Ajouter une table \n[2] Supprimer une table \n[3] Voir les tables \n \n \n[0] Retour");

                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk);
            switch (choix) {
                case 1:
                    ajoutTable();
                    break;
                case 2:
                    suppressionTable();
                    break;
                case 3:
                    afficherTable();
                    break;
                case 0:
                    break;
            }
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void ajoutTable() {

        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void suppressionTable() {
            bool choixOk = false;
            int choixSalle = -1, choixTable = -1;
            do {
                Console.WriteLine("Dan quelle salle voulez-vous supprimer une table ?");
                for (int i = 0; i < mesSalles.Count; i++) {
                    Console.WriteLine("[{0}] : {1}", i, mesSalles[i].monNom);
                }
                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choixSalle);
            }
            while (!choixOk && (choixSalle >= mesSalles.Count) && (choixSalle < 0));

            choixOk = false;
            do {
                Console.WriteLine("Dan quelle salle voulez-vous supprimer une table ?");
                for (int i = 0; i < mesSalles[choixSalle].mesTables.Count; i++) {
                    Console.WriteLine("[{0}] : {1}", i, mesSalles[choixSalle].mesTables[i].monNumTable);
                }
                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choixTable);
            }
            while (!choixOk && (choixTable >= mesSalles[choixSalle].mesTables.Count) && (choixTable < 0));

            mesSalles[choixSalle].mesTables.RemoveAt(choixTable);
            Console.WriteLine("Tablle supprimée");
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void afficherTable() {
            Console.Clear();
            Console.WriteLine("Liste des tables du restaurant : ");
            foreach (var salle in mesSalles) {
                Console.WriteLine("Salle : {0} est composé des tables : ", salle.monNom);
                foreach (var table in salle.mesTables) {
                    Console.WriteLine(table.ToString());                    
                }
            }
            Console.ReadLine();
        }


        #endregion


        #region gestion formules


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void gererFormules()
        {
            int choix;
            bool choixOk = false;
            do {
                Console.WriteLine("\n---------\n Que voulez-vous faire ? \n---------\n");

                Console.WriteLine("\n[1] Ajouter une formule \n[2] Supprimer une formule \n[3] Voir les formules \n \n \n[0] Retour");

                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk);
            switch (choix) {
                case 1:
                    ajoutFormule();
                    break;
                case 2:
                    suppressionFormule();
                    break;
                case 3:
                    afficherFormule();
                    break;
                case 0:
                    break;
            }
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void ajoutFormule() {

        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void suppressionFormule() {
            bool choixOk = false;
            int choix = -1;
            do {
                Console.WriteLine("Quel formule voulez-vous supprimer ?");
                for (int i = 0; i < mesFormules.Count; i++) {
                    Console.WriteLine("[{0}] : {1}", i, mesFormules[i].monNom);
                }
                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk && (choix >= mesFormules.Count) && (choix < 0));

            mesFormules.RemoveAt(choix);
            Console.WriteLine("Formule supprimé");
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void afficherFormule() {
            Console.Clear();
            Console.WriteLine("Liste des formules du restaurant : ");
            foreach (var formule in mesFormules) {
                Console.WriteLine(formule.ToString());
            }
            Console.ReadLine();

        }


        #endregion


        #region gestion plats

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void gererPlats()
        {
            int choix;
            bool choixOk = false;
            do {
                Console.WriteLine("\n---------\n Que voulez-vous faire ? \n---------\n");

                Console.WriteLine("\n[1] Ajouter un plat \n[2] Supprimer un plat \n[3] Voir les plats \n \n \n[0] Retour");

                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk);
            switch (choix) {
                case 1:
                    ajoutPlat();
                    break;
                case 2:
                    suppressionPlat();
                    break;
                case 3:
                    afficherPlats();
                    break;
                case 0:
                    break;
            }
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void ajoutPlat() {
            Plat p = new Plat();
            p.ajouterPlat();
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void suppressionPlat() {
            bool choixOk = false;
            int choix=-1;
            do {
                Console.WriteLine("Quel plat voulez-vous supprimer ?");
                for (int i = 0; i < mesPlats.Count; i++)
			    {
                    Console.WriteLine("[{0}] : {1}", i, mesPlats[i].monNom);
			    }
                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk && (choix >= mesPlats.Count) && (choix < 0));

            mesPlats.RemoveAt(choix);
            Console.WriteLine("Plat supprimé");
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void afficherPlats() {
            Console.Clear();
            Console.WriteLine("Liste des plats du restaurant : ");
            foreach (var plat in mesPlats) {
                Console.WriteLine(plat.ToString());
            }
            Console.ReadLine();
        }


        #endregion


        #region gestion personnels


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void gererPersonnels()
        {
            int choix;
            bool choixOk = false;
            do {
                Console.WriteLine("\n---------\n Que voulez-vous faire ? \n---------\n");

                Console.WriteLine("\n[1] Ajouter un personnel \n[2] Supprimer une personnel \n[3] Voir les personnels \n \n \n[0] Retour");

                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk);
            switch (choix) {
                case 1:
                    ajoutPersonnel();
                    break;
                case 2:
                    suppressionPersonnel();
                    break;
                case 3:
                    afficherPersonnel();
                    break;
                case 0:
                    break;
            }
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void ajoutPersonnel() {

        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void suppressionPersonnel() {
            bool choixOk = false;
            int choix = -1;
            do {
                Console.WriteLine("Quel personnel voulez-vous supprimer ?");
                for (int i = 0; i < mesPersonnels.Count; i++) {
                    Console.WriteLine("[{0}] : {1}", i, mesPersonnels[i].monNom);
                }
                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk && (choix >= mesPersonnels.Count) && (choix < 0));

            mesPersonnels.RemoveAt(choix);
            Console.WriteLine("Personnel supprimé");
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void afficherPersonnel() {
            Console.Clear();
            Console.WriteLine("Liste du personnel du restaurant : ");
            foreach (var personnel in mesPersonnels) {
                Console.WriteLine(personnel.ToString());
            }
            Console.ReadLine();
        }


        #endregion


        #endregion


        #region serialisation


        /// <summary>
        /// Cette fonction va permettre de créer un fichier XML avec les informations caractérisant un restaurant
        /// </summary>
        /// <param name=""></param> 
        public void sauveInfosRestaurant() {
            XmlSerializer xs = new XmlSerializer(typeof(Restaurant));
            using (StreamWriter wr = new StreamWriter("../../../DonneesRestaurants/" + monNom + "/restaurant.xml", true)) {
                xs.Serialize(wr, this);
            }

        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param>        
        public void sauveRestaurant() {
            XmlDocument rootRestau = new XmlDocument();

            XmlNode restaurantNode = rootRestau.CreateElement("Restaurant");
            rootRestau.AppendChild(restaurantNode);
            XmlNode nomRestaurant = rootRestau.CreateElement("Nom");
            nomRestaurant.InnerText = this.monNom;
            restaurantNode.AppendChild(nomRestaurant);



            //Sauvegarde de la liste des tables
            XmlNode listesTables = rootRestau.CreateElement("Tables");
            foreach (Table table in listesTables) {
                table.sauveTable(rootRestau, listesTables);
            }
            restaurantNode.AppendChild(listesTables);

            /*
            
            //Sauvegarde de la liste des formules
            XmlNode listeFormules = rootRestau.CreateElement("listeFormules");
            foreach (var formule in listeFormules)
            {
                formule.sauvegardeFormule(rootRestau, listeFormules);
            }

            restaurantNode.AppendChild(listeFormules);

            //Sauvegarde de la liste des employés
            XmlNode listeSalaries = rootRestau.CreateElement("listeSalaries");
            foreach (var salarie in mesPersonnels)
            {
                salarie.sauvegardeSalarie(rootRestau, listeSalaries);
            }

            restaurantNode.AppendChild(listeSalaries);


            //Sauvegarde de la liste des reservations
            XmlNode listeReservations = rootRestau.CreateElement("listeSalles");
            foreach (Salle reserv in mesSalles)
            {
                reserv.sauvegardeReservation(rootRestau, listeReservations);
            }


            restaurantNode.AppendChild(listeReservations);
             
            */

            rootRestau.Save(monNom + ".xml");
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param>        
        public void serialiser() {
            // Verifier si le dossier avec le même nom n'existe pas
            bool exists = false;
            string pathToAllDir = "../../../DonneesRestaurants";

            string[] tempListDir = Directory.GetDirectories(pathToAllDir);
            List<string> listDirectories = new List<string>();

            foreach (var item in tempListDir) {
                listDirectories.Add(item.Split(new Char[] { '\\' })[1]);
                exists = true;
                break;
            }

            if (exists == false) {
                XmlSerializer xs = new XmlSerializer(typeof(Restaurant));
                // Ouverture de l'instance d'écriture en précisant le chemin du fichier
                using (TextWriter writer = new StreamWriter("./..//..//DonneesRestaurants//" + monNom + "//restaurant.xml")) {
                    xs.Serialize(writer, this);
                }

                Console.WriteLine(string.Format("Restaurant : enregistrement réussi"));
            }



        }
        
        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param>        
        public Restaurant deserialiser() {
            Restaurant r = null;
            if (File.Exists(("./..//..//DonneesRestaurants//" + monNom + "//restaurant.xml"))) {
                XmlSerializer xs = new XmlSerializer(typeof(Restaurant));
                using (StreamReader sr = new StreamReader("./..//..//DonneesRestaurants//" + monNom + "//restaurant.xml")) {
                    r = xs.Deserialize(sr) as Restaurant;
                }
            }
            return r;

        }


        #endregion


    }
}
