namespace SNT.ControlEquipmentStates
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base($"data source=DESKTOP-QUPN079\\SQLEXPRESS;initial catalog=SNT_SampleDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<ControlEquipmentState> ControlEquipmentState { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
