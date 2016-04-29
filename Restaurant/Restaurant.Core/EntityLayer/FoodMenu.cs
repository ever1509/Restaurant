using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.EntityLayer
{
    [Table("FoodMenu")]
    public class FoodMenu
    {
        public FoodMenu()
        {

        }
        public FoodMenu(Int32 foodmenu)
        {
            FoodMenuID = foodmenu;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 FoodMenuID { get; set; }
        public Int32 CategoryID { get; set; }
        public String FoodName { get; set; }
        public String DescriptionFood { get; set; }
        public Decimal? Price { get; set; }
        public DateTime? PreparationTime { get; set; }
        public Boolean? FoodStatus { get; set; }

        public virtual  Categories fkCategories { get; set; }
        public virtual Collection<SaleControl> SaleControl { get; set; }
    }
}
