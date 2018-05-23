namespace StationLogWebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EquipmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string EquipmentName { get; set; }

        public int StationId { get; set; }

        public DateTime LastDateUsed { get; set; }

        public virtual Station Station { get; set; }
    }
}
