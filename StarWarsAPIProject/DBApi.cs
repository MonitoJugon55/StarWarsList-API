using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace StarWarsListAPI
{
    public class DBApi
    {
        public dynamic Get(string url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36 OPR/60.0.3255.50962 OPRGX/60.0.3255.50962";
            myRequest.Credentials = CredentialCache.DefaultCredentials;
            myRequest.Proxy = null;
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            Stream myStream = myResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);

            //Read Data
            string requestData = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

            dynamic Data = JsonConvert.DeserializeObject(requestData);

            return Data;
        }
    }
}
