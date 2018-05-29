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

        public DateTimeOffset DateOffset
        {
            get { return DateTime.SpecifyKind(CommentDate, DateTimeKind.Utc); }
            set { CommentDate = value.DateTime; }
        }

        [Required]
        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Comment(int commentId, DateTime commentDate, string description, int userId)
        {
            CommentId = commentId;
            CommentDate = commentDate;
            Description = description;
            UserId = userId;
            


        }

        public Comment()
        {
            
        }

        public override string ToString()
        {
            return $"comment: {Description} added on {CommentDate}";
        }
    }
}
