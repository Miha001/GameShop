using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class UserData
    {

        [Key]
        public int UDId { get; set; }

        public string NameOfUser { get; set; }

        public string Addres { get; set; }

    }
}
