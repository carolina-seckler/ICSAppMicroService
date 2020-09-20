using System.ComponentModel.DataAnnotations;

namespace ICSApp.IS4.STS.Identity.ViewModels.Manage
{
    public class DeletePersonalDataViewModel
    {
        public bool RequirePassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}






