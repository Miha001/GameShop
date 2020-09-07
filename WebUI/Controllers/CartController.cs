using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private ICharacteristicRepository repository;

        public CartController(ICharacteristicRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
  

        public RedirectToRouteResult AddToCart(Cart cart,int CharacteristicId, string returnUrl)
        {
            Characteristic ch = repository.Characteristics.FirstOrDefault
                (b => b.CharacteristicId == CharacteristicId);
            if (ch != null)
            {
                cart.AddItem(ch, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int CharacteristicId, string returnUrl)
        {
            Characteristic ch = repository.Characteristics.FirstOrDefault(b => b.CharacteristicId == CharacteristicId);
            if (ch != null)
            {
                cart.RemoveLine(ch);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}