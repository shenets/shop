using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Core.Abstraction.Containers;


namespace Site.Models
{
    public class Shop : IShopBunch
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [AllowHtml]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [AllowHtml]
        [Display(Name = "Режим работы")]
        public string Shedule { get; set; }
    }

    public static class ArticleExtensions
    {
        public static Shop Convert(this IShopBunch article)
        {
            if (article == null)
                return null;

            Shop target = new Shop();
            target.Id = article.Id;
            target.Name = article.Name;
            target.Address = article.Address;
            target.Shedule = article.Shedule;

            return target;
        }

        public static List<Shop> Convert(this IEnumerable<IShopBunch> collection)
        {
            if (collection == null)
                return null;

            return collection.Select(item => item.Convert()).ToList();
        }
    }
}