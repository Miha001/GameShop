using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class GamesInOrder
    {
        [Key]
        public int GamesInOrderId { get; set; }

        public int CharacteristicsId { get; set; }

        public int CountOfSoldGames { get; set; }

        public int PriceOfSoldGame { get; set; }

    }
}
