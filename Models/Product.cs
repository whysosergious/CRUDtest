using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CRUDtest.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName="nvarchar(MAX)")]
        [Required(ErrorMessage="Can not be empty.")]
        [DisplayName("Html String")]
        public string Html { get; set; }

        [Column(TypeName="datetime")]
        [DisplayName("Created/Edited")]
        public DateTime Created { get; set; }

        [Column(TypeName="nvarchar(250)")]
        [DisplayName("User")]
        public string User { get; set; }
    }
}
