using System;
using System.Collections.Generic;
using System.Text;

namespace ERP
{
    internal class Client
    {
        public string firstName;
        public string secondName;
        public string mail;
        public string postalAdress;

        public Client(string firstName, string secondName, string mail, string postalAdress)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.mail = mail;
            this.postalAdress = postalAdress;
        }
    }

    

}
