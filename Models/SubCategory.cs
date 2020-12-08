using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplicationCore3.Models
{
    public class SubCategory
    {
        
        public int Id { get; set; }
        [Display (Name="Name :")]
        //application test la validation coté client ("champs rquis")
        [Required]
        //[MaxLength(10),MinLength(5)]
        public string Name { get; set; }
        
        public int CategoryId { get; set; }

        //naviagation property
        [ForeignKey("CategoryId")]
        //Vous pouvez naviguer à l'interieur  de n'importe  quel élément 
        public virtual Category Category { get; set; }
    }
}
