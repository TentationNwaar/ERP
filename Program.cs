//Auteur : Maxence
//Date   : 30.03.2020 
//Lieu   : Cossonay
//Descr. : ERP
using Figgle;
using System;
using System.Collections.Generic;

namespace ERP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Titre
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(FiggleFonts.Standard.Render("ERP"));

            //Message de bienvenue
            Console.Write("Bonjour, bienvenue dans l'ERP");
            Console.WriteLine();

            //Creation du menu
            Menu menu = new Menu("ERP");

            //Choix du langages
            SpicyI18N language;
            Console.WriteLine("\r\nchoisissez la langue : (0=fr, 1=en)");
            int languageCode = Convert.ToInt32(Console.ReadLine());

            if (languageCode == 0)
            {
                language = new SpicyI18N_Fr();
            }

            else
            {
                language = new SpicyI18N_En();
            }

            //Création des menus
            MenuEntry Client = new MenuEntry(language.showClient());
            MenuEntry Produits = new MenuEntry(language.showProducts());
            MenuEntry Commandes = new MenuEntry(language.showOrders());
            MenuEntry Quit = new MenuEntry(language.showQuit());

            //Ajout des menus
            menu.Add(Client);
            menu.Add(Produits);
            menu.Add(Commandes);
            menu.Add(Quit);

            MenuEntry choice = null;
            do
            {
                choice = menu.ShowMenu();

                if (choice == Client)
                {
                    clientMenu();
                }


                if (choice == Produits)
                {
                    productsMenu();
                }

                if (choice == Commandes)
                {
                    ordersMenu();
                }

            } while (choice != Quit);

            Console.WriteLine("Au revoir");
            Console.ReadKey();

            Console.ReadLine();

            Console.WriteLine("------Test DB-----");

            //Crée l'objet pour la connexion
            SqliteConnection dbConnection = new SqliteConnection(@"Data Source = MagicERP.db;");
            //Ouverture de la connexion au serveur (serveur virtuel pour SQLite)
            dbConnection.Open();

            //Création d'une commande pour envoyer une requête
            var command = dbConnection.CreateCommand();
            command.CommandText = "select * from Client";

            //Traitement du résultat
            var reader = command.ExecuteReader();
            while (reader.Read())//tant qu'il y a une ligne disponible
            {
                //Affichage de la ligne en cours
                Console.WriteLine(reader["id"] + " " + reader["firstname"]);

            }
            dbConnection.Close();

            Console.WriteLine("-------- FIN DU TEST DB -----------");
        }

        //Si le choix est "clients"
        static void clientMenu()
        {

            Console.Clear();

            List<Client> clients = new List<Client>();
            clients.Add(new Client("Marc", "Boutonnier", "Marcboutonnier@hotmail.com", "Avenue des montagnes 6"));
            clients.Add(new Client("Delphine", "Bergere", "Delphinebergere@hotmail.com", "Avenue du leman 4"));
            clients.Add(new Client("Marie", "Delacompta", "Mariedelacompta@hotmail.com", "Chemin des pizza 32"));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(FiggleFonts.Standard.Render("Clients"));
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Client client in clients)
            {
                Console.WriteLine(client.firstName + " " + client.secondName + "\r\n");
            }

            Console.ReadLine();
            Console.Clear();
        }
        //Si le choix est "produits"
        static void productsMenu()
        {

        }
        //Si le choix est "commandes"
        static void ordersMenu()
        {

        }


    }
}
