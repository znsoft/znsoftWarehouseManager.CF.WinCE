using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SmartDeviceProject2
{
    class CreateXML
    {


        public static XmlDocument CreateXMLUpdate(int version)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(String.Format(@"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""><soap:Header/><soap:Body>
                                            <m:updatefirmware xmlns:m=""http://www.dns-shop.tsd.ru"">
                                            <m:version xmlns:xs=""http://www.w3.org/2001/XMLSchema""	xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">                                    {0}</m:version>	</m:updatefirmware>	</soap:Body>\n</soap:Envelope>", version));
            return soapEnvelop;
        }


        private static XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema""><SOAP-ENV:Body><HelloWorld xmlns=""http://tempuri.org/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><int1 xsi:type=""xsd:integer"">12</int1><int2 xsi:type=""xsd:integer"">32</int2></HelloWorld></SOAP-ENV:Body></SOAP-ENV:Envelope>");
            return soapEnvelop;
        }



        /*
         * 	memset(wzData, 0, BUFSIZE);
	wcscpy(wzData, L"<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Header/><soap:Body><m:ОбменТСД xmlns:m=\"http://www.dns-shop.tsd.ru\"><m:ВидОперации xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"  xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
	wcscat(wzData, Operation);
	wcscat(wzData, L"</m:ВидОперации><m:Список xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"	xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
	wcscat(wzData, L"<m:Номенклатура><m:Код>");
	wcscat(wzData, code);
	wcscat(wzData, L"</m:Код><m:Наименование>");
	wcscat(wzData, name);
	wcscat(wzData, L"</m:Наименование><m:Количество>");
	wcscat(wzData, kolvo);
	wcscat(wzData, L"</m:Количество></m:Номенклатура>");
	if (sendmetric)
	{
		getbat(info);
		wcscat(wzData, L"<m:Номенклатура><m:Код>");
		wcscat(wzData, ipadr);
		wcscat(wzData, L"</m:Код><m:Наименование>");
		wcscat(wzData, info);
		wcscat(wzData, L"</m:Наименование><m:Количество>");
		wcscat(wzData, VERSION);
		wcscat(wzData, L"</m:Количество></m:Номенклатура>");
	}
	wcscat(wzData, L"</m:Список></m:ОбменТСД></soap:Body></soap:Envelope>");
         */







    }
}
