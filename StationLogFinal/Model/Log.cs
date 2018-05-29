using StationLogWebApplication1.Models;

namespace StationLogWebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Log()
        {
            Comments = new HashSet<Comment>();
            Measurements = new HashSet<Measurement>();
            Messages = new HashSet<Message>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LogId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public int UserId { get; set; }

        public int StationId { get; set; }

        public int MeasurementId { get; set; }

        public int CommentId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual User User { get; set; }

        public virtual Station Station { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Measurement> Measurements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
