using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRAS.Models.ViewModels.New
{
    public class NewViewModel
    {
        
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "NameRequired")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("ImagePath")]
        public string ImagePath { get; set; }

        [DisplayName("ImageFile")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Text")]
        [Required(ErrorMessage = "TextRequired")]
        public string Text { get; set; }

        public string HeaderText { get; set; }

        public string SubmitText { get; set; }

    }
}
