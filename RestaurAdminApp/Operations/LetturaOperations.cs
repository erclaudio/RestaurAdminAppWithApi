using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


using Newtonsoft.Json;
using RestaurAdminApp.Models;

namespace RestaurAdminApp.Operations
{
    public class LetturaOperations
    {
        static string pathCodice = AppDomain.CurrentDomain.BaseDirectory + @"\Info\DatiSensibili\RegInfo.json";
        public static bool ExistsCode(out string code)
        {
            code = string.Empty;
            bool info = false;
            try
            {
                if (File.Exists(pathCodice))
                {
                    string codice = File.ReadAllText(pathCodice);
                    var result = JsonConvert.DeserializeObject < Models.CodiceControllo>(codice);
                    code = string.Format(result.Codice);
                    info = true;
                }
                else
                {
                    
                }

            }
            catch (Exception ex)
            {
                
            }
            return info;
        }
    }
}
