using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace JokesWebApp.Models
{
    public class BookModel
    {
        [DataType(DataType.DateTime)]
        [Display(Name ="Choose date and time")]
        public string MyField { get; set; }
        public int Id { get; set; }
        [StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage="Please Enter the title for your book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter the Author for your book")]
        public string Author { get; set; }
        [StringLength(500,MinimumLength =30)]
        public string Description { get; set; }
        public string Category { get; set; }
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "Please Enter Total pages")]
        public int? TotalPages { get; set; }
        public string CoverImageUrl { get; set; }

        [Display(Name ="Choose the cover photo of your file")]
        public IFormFile CoverPhoto { get; set; }

        //for selecting multiple images
        [Display(Name = "Choose gallery images of your book")]
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }

        //For pdf files
        [Display(Name = "Upload your book pdf")]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }


    }
}
