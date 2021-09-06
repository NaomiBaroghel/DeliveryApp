namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BE;
    using System.Collections.Generic;

    public partial class DS2 : DbContext
    {
        public DS2()
            : base("name=DS2")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Client> clientList { get; set; }
        public virtual DbSet<Distribution> distributionList { get; set; }
        public virtual DbSet<DeliveryMan> DManList { get; set; }
        public virtual DbSet<Address> AddressList { get; set; }
        public virtual DbSet<Configuration> ConfigList { get; set; }
    }
}
