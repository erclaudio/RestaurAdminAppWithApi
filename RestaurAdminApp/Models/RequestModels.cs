using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurAdminApp
{
    internal class RequestModels
    {
        public class RequestClient
        {
            public string RegioneSociale { get; set; }
            public string Piva { get; set; }
            public string Indirizzo { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }
        }
    }
}
