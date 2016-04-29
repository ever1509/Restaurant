using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.EntityLayer
{
    [Table("Orders")]
    public class Orders
    {
        public Orders()
        {

        }
        public Orders(Int32 ord)
        {
            OrderID = ord;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 OrderID { get; set; }
        public Int32 UserID { get; set; }
        public DateTime OrderTime { get; set; }

    }
}
