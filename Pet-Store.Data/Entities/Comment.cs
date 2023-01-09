﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Store.Data.Entities
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Content { get; set; }
    }
}