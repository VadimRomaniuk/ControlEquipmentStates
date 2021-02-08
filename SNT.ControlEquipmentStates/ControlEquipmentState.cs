namespace SNT.ControlEquipmentStates
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ControlEquipmentState")]
    public partial class ControlEquipmentState
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string IDState { get; set; }

        public DateTime Time { get; set; }

        public string Flag { get; set; }

    }
}
