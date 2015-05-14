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

        protected List<Salle> _salles;
        protected List<Personnel> _personnels;
        protected List<Formule> _formules;
        protected List<Reservation> _reservations;
        protected DateTime[] _horaires;
        protected string _nom;
        protected string _motDePasse;

        #endregion


        #region getters/setters
        
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

        [XmlArray("Horaires")]
        [XmlArrayItem("Horaire")]
        public DateTime[] mesHoraires
        {
            get { return _horaires; }
            set { _horaires = value; }
        }
        /*
        public string DateOfBirthFormatted
        {
            get { return DateOfBirth.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); }
            set { DateOfBirth = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
        }
        */

        #endregion


        #region constructeur

        public Restaurant() { 
            
        }

        public Restaurant(String restaurant, string mdp)
        {

            Directory.CreateDirectory("../../../DonneesRestaurants/" + restaurant);

            mesSalles = new List<Salle>();
            mesPersonnels = new List<Personnel>();
            mesFormules = new List<Formule>();
            mesReservations = new List<Reservation>();
            mesHoraires = new DateTime[4];
            monNom = restaurant;
            monMotDePasse = mdp;
        }   

        #endregion


        #region methodes


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public override string ToString()
        {
            string st = "";
            
            st += "Mon nom " + monNom + " \n";
            st += "Mdp " + monMotDePasse + " \n";
            
            return st;
        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void ajouterSalle(string s) {

            Salle salle = chercheSalle(s);
            if (salle==null) {


                mesSalles.Add(salle);
                
            }
        }

        
        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void supprimerSalle() {


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
            Salle salle = null;
            if (mesSalles.Exists(item => item.monNom == s)) {
                salle = mesSalles.Find(item => item.monNom == s);
            }

            return salle;
        }


        /// <summary>
        /// Cette fonction va permettre de créer un fichier XML avec les informations caractérisant un restaurant
        /// </summary>
        /// <param name=""></param> 
        public void sauveInfosRestaurant() {
            XmlSerializer xs = new XmlSerializer(typeof(Restaurant));
            using (StreamWriter wr = new StreamWriter("../../../DonneesRestaurants/"+monNom+"/restaurant.xml", true)) {
                xs.Serialize(wr, this);
            }

        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param>        
        public void sauveRestaurant()
        {
            XmlDocument rootRestau = new XmlDocument();

            XmlNode restaurantNode = rootRestau.CreateElement("Restaurant");
            rootRestau.AppendChild(restaurantNode);
            XmlNode nomRestaurant = rootRestau.CreateElement("Nom");
            nomRestaurant.InnerText = this.monNom;
            restaurantNode.AppendChild(nomRestaurant);

            

            //Sauvegarde de la liste des tables
            XmlNode listesTables = rootRestau.CreateElement("Tables");
            foreach (Table table in listesTables)
            {
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
        public void listerReservations()
        {

        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void listerSalles()
        {
            Console.Clear();
            Console.WriteLine("-------------------\n");
            Console.WriteLine("Voici la liste des salles : \n");
            for (int i = 0; i < mesSalles.Count; i++)
            {
                Console.WriteLine("La salle {0} comporte {1} tables dont {2} tables réservées.\n", (i + 1), mesSalles[i].mesTables.Count, mesSalles[i].mesTablesReservees.Count);
            }
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void listerTablesSalle(int n)
        {
        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void listerFormules()
        {

        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void listerPlats()
        {

        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void listerPersonnels()
        {

        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void listerParametres()
        {

        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public static int demanderEntier(int entierDebut, int entierFin)
        {
            int entARetourner = 0;
            bool boolean = false;
            string demande;
            // Si entierDebut ou entierFin vaut -1, il n'est pas considéré utile
            if ((entierDebut != -1) && (entierFin == -1))
            {
                while ((boolean == false) || (entARetourner < entierDebut))
                { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    Console.WriteLine("Entrez un entier supérieur ou égal à {0}.", entierDebut);
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    boolean = Int32.TryParse(demande, out entARetourner);
                }
            }
            else if ((entierDebut == -1) && (entierFin != -1))
            {
                entARetourner = 5000;
                while ((boolean == false) || (entARetourner > entierFin))
                {
                    Console.WriteLine("Entrez un entier inférieur ou égal à {0}.", entierFin);
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    boolean = Int32.TryParse(demande, out entARetourner);
                    if (entARetourner == 0) entARetourner = 5000;
                }
            }
            else
            {
                while ((boolean == false) || (entARetourner > entierFin) || (entARetourner < entierDebut))
                {
                    Console.WriteLine("Entrez un entier compris entre {0} et {1}.", entierDebut, entierFin);
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    boolean = Int32.TryParse(demande, out entARetourner);
                }
            }
            return entARetourner;
        }

        #endregion

    }
}
