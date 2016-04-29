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
    [Table("SaleControl")]
    public class SaleControl
    {
        public SaleControl()
        {

        }
        public SaleControl(Int32 sctrl)
        {
            SaleControlID = sctrl;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 SaleControlID { get; set; }
        public Int32 FoodMenuID { get; set; }
        public Int32 OrderID { get; set; }
        public Int32 Quantity { get; set; }
        public Boolean? ServiceStatus { get; set; }

        public virtual Orders fkOrders { get; set; }
        public virtual FoodMenu fkFoodMenu { get; set; }        


    }
}
