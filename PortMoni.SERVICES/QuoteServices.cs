using PortMoni.MODEL;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace PortMoni.SERVICES
{
    public class QuoteServices
    {
        public static string GetShareListQuoteString(List<Share> shareList)
        {
            string response = string.Empty;

            //http://bvmf.bmfbovespa.com.br/cotacoes2000/FormConsultaCotacoes.asp?strListaCodigos=BBPO11%7CPETR4
            string requestString = "http://bvmf.bmfbovespa.com.br/cotacoes2000/FormConsultaCotacoes.asp?strListaCodigos=";

            foreach (Share share in shareList)
            {
                requestString += share.Code + "%7C";
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestString);
            HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
            response = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();

            return response;
        }
    }
}
