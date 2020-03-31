//Auteur : Maxence
//Date   : 30.03.2020 
//Lieu   : Cossonay
//Descr. : ERP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class MenuEntry
    {
        static int instanceCounter = 0;
        static int longestText = 0;

        //Couleurs par défaut
        ConsoleColor selectedBGColor = ConsoleColor.DarkRed;
        ConsoleColor selectedFGColor = ConsoleColor.White;
        ConsoleColor unselectedBGColor = ConsoleColor.Black;
        ConsoleColor unselectedFGColor = ConsoleColor.Gray;

        private int id; //identifiant unique
        private string text;

        private bool isSelected = false; //Option déselectionnée par défaut

        /// <summary>
        /// Constructeur avec identifiant automatique
        /// </summary>
        /// <param name="text"></param>
        public MenuEntry(string text)
        {
            this.id = instanceCounter++;
            this.text = text;

            //Stocke la plus longue option en terme de caractères
            if (text.Length > longestText)
            {
                longestText = text.Length;
            }

        }

        //Retourne le texte
        public string Text { get => text; }
        //Retourne l'id
        public int Id { get => id; }
        public bool IsSelected { get => isSelected; set => isSelected = value; }

        public void WriteOption()
        {
            //backup state
            ConsoleColor previousBG = Console.BackgroundColor;
            ConsoleColor previousFG = Console.ForegroundColor;

            if (isSelected)
            {
                Console.BackgroundColor = selectedBGColor;
                Console.ForegroundColor = selectedFGColor;
            }
            else
            {
                Console.BackgroundColor = unselectedBGColor;
                Console.ForegroundColor = unselectedFGColor;
            }

            //Ajoute des caractères vides
            Console.Write(ToString());

            //put original state
            Console.BackgroundColor = previousBG;
            Console.ForegroundColor = previousFG;
        }

        //Renvoie le numéro et le texte de l'entrée
        public override string ToString()
        {
            return id + "." + text;
        }
    }
