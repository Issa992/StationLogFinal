namespace StationLogWebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommentId { get; set; }

        public DateTime CommentDate { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
