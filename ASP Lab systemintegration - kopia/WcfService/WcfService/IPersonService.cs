using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPersonService
    {

        [OperationContract]

        List<PersonerData> GetPersonList();

      
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public  class PersonerData
    {
        [DataMember]// frågar va vi ska skicka med när vi frågar webbservicen
        public int Id { get; set; }
        [DataMember]
        public string Fornamn { get; set; }
        [DataMember]
        public string Efternamn { get; set; }
        [DataMember]
        public int? Alder { get; set; }
    }

}
