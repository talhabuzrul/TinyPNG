using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TinifyAPI;

namespace SendImgToApi
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\PC\Desktop\testxslt.xml");
            XmlNodeList node = doc.DocumentElement.GetElementsByTagName("img");

            Tinify.Key = "";
            foreach (var item in node)
            {
                string text = ((XmlElement)item).GetAttribute("src");
                string convert = text.Split(',')[1];
                byte[] bytes = Convert.FromBase64String(convert);
                var result =  Tinify.FromBuffer(bytes).ToBuffer().Result;
            }
 

 


        }
    }
}
