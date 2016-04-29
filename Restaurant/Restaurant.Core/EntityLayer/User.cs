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
    [Table("User")]
    public class User
    {
        public User()
        {

        }
        public User(Int32 usr)
        {
            UserID = usr;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 UserID { get; set; }
        public Int32 UserTypeID { get; set; }
        public String UserName { get; set; }        
        public String NickName { get; set; }
        public String Password { get; set; }
        public Boolean? ActiveStatus { get; set; }
        public Boolean? OrderStatus { get; set; }
        public Int32 OrderQuantityPerson { get; set; }

        public virtual UserType fkUserType { get; set; }

        public virtual Collection<Orders> Orders { get; set; }

    }
}
