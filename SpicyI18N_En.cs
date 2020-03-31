using System;
using System.Collections.Generic;
using System.Text;

namespace ERP
{
    class SpicyI18N_En : SpicyI18N
    {
        public string showClient()
        {
            return "Client";
        }

        public string showProducts()
        {
            return "Products";
        }

        public string showOrders()
        {
            return "Commandes";
        }
        public string showQuit()
        {
            return "Bye Bye";
        }
    }
}
