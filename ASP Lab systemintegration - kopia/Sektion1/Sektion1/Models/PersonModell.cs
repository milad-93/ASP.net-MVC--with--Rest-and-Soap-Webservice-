using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Sektion1.Models
{
    public partial class PersonModell
    {
        public int Id { get; set; }

        public string Fornamn { get; set; }

        public string Efternamn { get; set; }

        public int Alder { get; set; }
    }
}