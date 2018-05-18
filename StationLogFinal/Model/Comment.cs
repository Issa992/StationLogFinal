namespace StationLogWebApplication1
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

        [Required]
        public string Description { get; set; }

        public int UserId { get; set; }

        public int? LogId { get; set; }

        public virtual User User { get; set; }

        public virtual Log Log { get; set; }

        public override string ToString()
        {
            return $"comment: {Description} added on {CommentDate} by {User.UserId}";
        }
    }
}
