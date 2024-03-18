using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations;

namespace OptionsPattern
{
    public class MyOptions
    {
        [Required(AllowEmptyStrings = false)]
        public string MyKey { get; set; }
    }
}
