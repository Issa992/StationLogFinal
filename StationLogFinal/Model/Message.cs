namespace StationLogWebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageId { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        [Required]
        public string Messages { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsRead { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public override string ToString()
        {
            return $"{CreationTime} message from {User.Name}";
        }
    }
}
