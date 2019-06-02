using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    
    public class PersonService : IPersonService
    {
        public List<PersonerData> GetPersonList()// gör lista 
        {
            try
            {
                List<PersonerData> returData = new List<PersonerData>(); // anropar konstrukturn
                using (PersonModell db = new PersonModell()) //anropar databas
                {
                    var dbPersonLista = db.Personer.ToList(); // hämtar alla värden ifrån databsen
                    foreach (var dbPerson in dbPersonLista)
                    {
                        PersonerData returPerson = new PersonerData(); //kopierar alla Personer från databasen till en ny lista som skickas iväg
                        returPerson.Id = dbPerson.Id;
                        returPerson.Fornamn = dbPerson.Fornamn;
                        returPerson.Efternamn = dbPerson.Efternamn;
                        returPerson.Alder = dbPerson.Alder;
                        returData.Add(returPerson);

                    }
                }

                return returData; // returnerar den listan
            }

            catch
            {
                return null;
            }
        }
    }
}
