using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Characteristic
    {
        [Key]
        public int CharacteristicId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Year { get; set; }
        public int PurchaseId { get; set; }
        public int PlatformId { get; set; }
        public int CategoryId { get; set; }
        public int SellingPrice { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
