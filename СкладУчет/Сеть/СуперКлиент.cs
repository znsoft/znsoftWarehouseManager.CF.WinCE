using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace СкладскойУчет
{
    class СуперКлиент: СкладскойУчет.СсылкаНаСервис.forTSD
    {
 
            protected override System.Net.WebRequest GetWebRequest(Uri uri)
            {
                var request = base.GetWebRequest(uri);
                request.Headers.Add("Authorization", "Basic " + GetEncodedCredentialsString());

                return request;
            }

            /// <summary>
            /// Преобразует Credentials текущего клиента в строку а 
            /// </summary>
            /// <returns></returns>
            private string GetEncodedCredentialsString()
            {
                var netCred = (NetworkCredential)this.Credentials;
                var usernameAndPassword = netCred.UserName + ":" + netCred.Password;
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(usernameAndPassword));
            }
        


    }
}
