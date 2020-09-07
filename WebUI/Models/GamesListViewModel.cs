using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Models
{
    public class GamesListViewModel
    {
        public IEnumerable<GamesInOrder> Games { get; set; }
        public IEnumerable<Characteristic> Characteristics { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}