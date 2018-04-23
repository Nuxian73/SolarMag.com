using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nom de produit requit")]
        [MaxLength(40, ErrorMessage = " maximum 40 caractères")]
        public string Nom { get; set; }

        public string NoReference { get; set; }

        public string Fabricant { get; set; }

        public string Description { get; set; }

        public decimal Poids { get; set; }

        public string Garantie { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "La valeur décimale est de 2 chiffres après le point")]
        [Range(0,5,ErrorMessage = "La valeur maximun est 5 chiffres")]
        public decimal Prix { get; set; }

        //Pour identifer les sous- produits  genre piles, panneau, accessoires et kit
        public enum Categories
        {
            [Display(Name ="Pile de stockage")]
            Pile,

            [Display(Name = "Panneau solaire")]
            PanneauSolaire,

            [Display(Name = "Accessoire divers")]
            Accessoire,

            [Display(Name = "Convertiseur électrique")]
            Convertiseur,

            [Display(Name = "Ensemble / kit")]
            Kit
        }

        [ReadOnly(true)]
        public Categories Categorie;

        public Item()
        {
        }
    }
}