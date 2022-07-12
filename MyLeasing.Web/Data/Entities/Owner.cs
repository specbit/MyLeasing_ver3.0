using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLeasing.Web.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Display(Name = "Document*")]
        public string Document { get; set; }

        [Display(Name = "Owner Name*")]
        [NotMapped()] //for not generated to the database using entity framework
        //[HiddenInput(DisplayValue = false)]  //used when I generated the views automatically
        public string Fullname => $"{FirstName} {LastName}";

        [Required]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }

        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }

        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
