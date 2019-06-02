namespace WcfService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PersonModell : DbContext
    {
        public PersonModell()
            : base("name=PersonModell")
        {
        }

        public virtual DbSet<Personer> Personer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
