using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime DateOfOrder { get; set; }

        public int GamesInOrderId { get; set; }

        public int UDId { get; set; }

        public bool StatusOfOrder { get; set; }
    }
}
