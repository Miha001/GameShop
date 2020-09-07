using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Car
    {
        [HiddenInput(DisplayValue = false)]
        public int CarId { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название авто")]
        public string Category { get; set; }

        [Display(Name = "Пробег")]
        [Required(ErrorMessage = "Пожалуйста, введите название авто")]
        public int MileageCar { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание авто")]
        public string Description { get; set; }

        [Display(Name = "Количество владельцев")]
        [Required(ErrorMessage = "Пожалуйста, введите количество владельцкв")]
        public int NumberOfOwners { get; set; }

        [Display(Name = "Год производства")]
        [Required(ErrorMessage = "Пожалуйста, введите год производства")]   
        public string YearOfManufacture { get; set; }

        [Display(Name = "Цена (руб)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public int Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }


    }
}
