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
    [Table("UserType")]
    public class UserType
    {
        public UserType()
        {

        }
        public UserType(Int32 usrtype)
        {
            UserTypeID = usrtype;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 UserTypeID { get; set; }
        public String Description { get; set; }

        public Collection<User> Users { get; set; }
    }
}
