using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASPMVC_Session.Models
{
    public class LoginFormModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
