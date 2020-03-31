using System;
using System.Collections.Generic;
using System.Text;

namespace ERP
{
    class SpicyI18N_Fr : SpicyI18N
    {
        public string showClient()
        {
            return "Client";
        }

        public string showProducts()
        {
            return "Produits";
        }

        public string showOrders()
        {
            return "Commandes";
        }
        public string showQuit()
        {
            return "Quitter";
        }
    }
}
