//Auteur : Maxence
//Date   : 30.03.2020 
//Lieu   : Cossonay
//Descr. : ERP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP
{
    //Définit les messages à traduire
    interface SpicyI18N
    {
        string showClient();
        string showProducts();
        string showOrders();
        string showQuit();

    }
}

