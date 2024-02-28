using System.ComponentModel.DataAnnotations;

namespace DesignPatternsAsp.Models.ViewModels
{
    public class FormViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Style { get; set; }
        public int? BrandId{ get; set; }

        [Display(Name = "Otra marca")]
        public string OtherBrand { get; set; }
    }
}
