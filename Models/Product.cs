using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDtest.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName="nvarchar(1500)")]
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
