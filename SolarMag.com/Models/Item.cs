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

        [Display(Name ="Produit")]
        [Required(ErrorMessage = "Nom de produit requis")]
        [StringLength(40, ErrorMessage = "Maximum 40 caractères")]
        public string Nom { get; set; }

        [Display(Name ="Référence")]
        [Required(ErrorMessage = "Numéro de référence requis")]
        [StringLength(40, ErrorMessage = "Maximum 40 caractères")]
        public string NoReference { get; set; }

        [Required(ErrorMessage = "Nom du fabricant requis")]
        [StringLength(40, ErrorMessage = " Maximum 40 caractères")]
        public string Fabricant { get; set; }

        [StringLength(200, ErrorMessage = "Maximum 200 caractères")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Valeur de poids requise")]
        [Range(0, 1000000, ErrorMessage = "Valeur de 0,00 à 1000000,00")]
        [Display(Name = "Poids en KG")]
        public double Poids { get; set; }

        [StringLength(40, ErrorMessage = " Maximum 40 caractères")]
        public string Garantie { get; set; }

        [Required(ErrorMessage = "Valeur du produit requise")]
        [Range(0, 1000000, ErrorMessage = "Valeur de 0,00 à 1000000,00")]
        public decimal Prix { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "Quantité du produit requise")]
        [Range(0, 1000000, ErrorMessage = "Valeur de 0 à 1000000")]
        public int QuantiteStock { get; set; }

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