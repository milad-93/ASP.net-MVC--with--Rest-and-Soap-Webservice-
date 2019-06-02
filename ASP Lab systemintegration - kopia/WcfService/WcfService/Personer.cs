namespace WcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personer")]
    public partial class Personer
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Fornamn { get; set; }

        [StringLength(50)]
        public string Efternamn { get; set; }

        public int? Alder { get; set; }
    }
}
