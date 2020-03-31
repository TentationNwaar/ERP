//Auteur : Maxence
//Date   : 30.03.2020 
//Lieu   : Cossonay
//Descr. : ERP
using System;
using System.Collections.Generic;


    class Menu
    {
        //Titre du menu
        private string title;

        //Entrées du menu
        private List<MenuEntry> entries = new List<MenuEntry>();

        public Menu(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// Ajouter une entrée dans le menu
        /// </summary>
        /// <param name="menuEntry"></param>
        public void Add(MenuEntry menuEntry)
        {
            //Force la sélection de la première option
            if (entries.Count == 0)
            {
                menuEntry.IsSelected = true;
            }
            entries.Add(menuEntry);
        }

        /// <summary>
        /// Afficher le menu et retourner l'option sélectionnée
        /// </summary>
        /// <returns></returns>
        public MenuEntry ShowMenu()
        {
            Console.Clear();

            Console.WriteLine(title);
            Console.WriteLine(new string('-', title.Length));//Souligne le titre
            Console.WriteLine();
            int initialY = Console.CursorTop;

            //Affichage des options de bases
            WriteOptions(initialY);

            //TODO gérer les flèches pour sélectionner une entrée
            MenuEntry selectedEntry = null;
            int currentlySelected = 0;
            while (selectedEntry == null)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentlySelected > 0)
                        {
                            entries[currentlySelected].IsSelected = false;
                            entries[currentlySelected - 1].IsSelected = true;
                            currentlySelected--;
                            Console.SetCursorPosition(0, initialY);

                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentlySelected < entries.Count - 1)
                        {
                            entries[currentlySelected].IsSelected = false;
                            entries[currentlySelected + 1].IsSelected = true;
                            currentlySelected++;
                            Console.SetCursorPosition(0, initialY);
                        }
                        break;
                    case ConsoleKey.Enter:
                        return entries[currentlySelected];

                }
                WriteOptions(initialY);
            }

            Console.ReadLine();
            return null;//TODO retourner l'entrée sélectionnée
        }

        /// <summary>
        /// Affiche toutes les options depuis la position courante du curseur
        /// </summary>
        private void WriteOptions(int y)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                Console.SetCursorPosition(0, y + i);
                entries[i].WriteOption();
            }
        }
    }
