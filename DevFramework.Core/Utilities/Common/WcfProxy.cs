using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utilities.Common
{
    /// <summary>
    /// Tüm UI lerin kullanıcağı bir proxy yapacağız.
    /// CreateChannel ile generic bir yapı olustuyoruz.
    /// 3 şey ihtiyacımız var birisi. Bunlara servisin ABC si denir.
    /// A=Address B= Binding  C= Contract
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WcfProxy<T>
    {
        ////http://localhost:63614/{0}.svc
        /// Service contract uzerinden erişilir
        /// Mesela IproductSErvice
        public static T CreateChannel()
        {
            string baseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            string address = string.Format(baseAddress, typeof(T).Name.Substring(1));

            var binding = new BasicHttpBinding();
            // Channel dediğimiz şey AddService Reference denildiğinde oluşturulan proxy gibi proxy oluşturur
            var channel = new ChannelFactory<T>(binding,address);
            return channel.CreateChannel();
        }
    }
}
