using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace SmartDeviceProject2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {



            var x = CallWebService();

            //MessageBox.Show(x);
            Console.Write(x);
            //var x = FormXml();

            //var root = GetXmlRoot("http://test.com/1.xml");
            //response.GetResponseStream();
            //XDocument xd =  XDocument.Load(
            //var test = new List<Uri>();
            //test.Add("http://google.com");
            //test.Add("https://wasm.ru");

            //var query = from x in test where x.Scheme = "https" select new { host=x.Host, scheme = x.Scheme };
            //var google = query.FirstOrDefault();
            //MessageBox.Show(google.host);
        }

        private static XDocument GetXmlRoot(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Credentials = new NetworkCredential("sadasd", "dasdas");

            var instr = request.GetRequestStream();

            var xdoc = FormXml();
            var xbytes = Encoding.UTF8.GetBytes(xdoc.ToString());

            request.ContentLength = xbytes.Length;

            using (instr)
            {
                instr.Write(xbytes, 0, xbytes.Length);
            }

            var testDict = new Dictionary<string, int>()
            {
                {"test",1},
                {"tedasd",2}
            };
            var query = from word
                            in testDict
                        where word.Key.StartsWith("te")
                        orderby word.Key[2]
                        select Encoding.UTF8.GetBytes(word.Value.ToString());


            var re = new Regex("^te", RegexOptions.Compiled);

            //Regex.Match("test", "^(te)").Groups[1];

            var testStr = @"C:\";


            var result = new List<byte[]>();

            foreach (var item in testDict)
                if (item.Key.StartsWith("te"))
                    result.Add(Encoding.UTF8.GetBytes(item.Value.ToString()));



            var response = (HttpWebResponse)request.GetResponse();

            using (var rgs = response.GetResponseStream())
            using (XmlTextReader xtr = new XmlTextReader(response.GetResponseStream()))
            {
                return XDocument.Load(xtr);
            }
        }

        public static string CallWebService()
        {
            var _url = "http://adm-zheludkov/zheludkov_sklad/ws/TSD.1cws";
            //var _action = "http://adm-zheludkov/zheludkov_sklad/ws/TSD.1cws?wsdl";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            //Console.Write(soapEnvelopeXml.ToString());
            HttpWebRequest webRequest = CreateWebRequest(_url);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
            //Console.Write(webRequest.ToString());


            //var xd = new XDocument();
            //var response = (HttpWebResponse)webRequest.GetResponse();
            //using (var rgs = response.GetResponseStream())
            //using (XmlTextReader xtr = new XmlTextReader(rgs))
            //{
            //    xd = XDocument.Load(xtr);
            //}
            //return xd.ToString();


            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            //Console.Write(asyncResult.ToString());
            asyncResult.AsyncWaitHandle.WaitOne();
            //Console.Write(asyncResult.AsyncState.ToString());

            string soapResult;// = new String;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }

                //Console.Write(soapResult);
            }
            //Console.Write(soapResult);

            return soapResult;
        }

        private static HttpWebRequest CreateWebRequest(string url)
        {
            //"\nAccept: */*\nSOAPAction: \"\"\nContent-Type: text/xml; charset=utf-8"
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", "\"\"");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            //webRequest.AllowAutoRedirect = true;
            webRequest.AllowWriteStreamBuffering = true;
            webRequest.Credentials = new NetworkCredential("WebConnection", "951");
            //webRequest.PreAuthenticate = true;
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(String.Format(@"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""><soap:Header/><soap:Body>
                                            <m:updatefirmware xmlns:m=""http://www.dns-shop.tsd.ru"">
                                            <m:version xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""> 100</m:version>
                                            </m:updatefirmware>	</soap:Body>\n</soap:Envelope>", 125));
            return soapEnvelop;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            //var xbytes = Encoding.UTF8.GetBytes(soapEnvelopeXml.ToString());
            //webRequest.ContentLength = xbytes.Length;
           // webRequest.ContentLength = soapEnvelopeXml.ToString().Length;

            //using (instr)
            //{
            //    instr.Write(xbytes, 0, xbytes.Length);
            //}

            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
                //stream.Write(xbytes, 0, xbytes.Length);
            }
        }


        private static XDocument FormXml()
        {
            XDocument srcTree = new XDocument();
            return srcTree;

        }

    
    }
}