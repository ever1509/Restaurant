using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.EntityLayer
{
    [Table("Categories")]
    public class Categories
    {
        public Categories()
        {

        }
        public Categories(Int32 categoryID)
        {
            CategoryID = categoryID;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 CategoryID { get; set; }
        public String CategoryName { get; set; }
        public Boolean CategoryStatus { get; set; }
    }
}
