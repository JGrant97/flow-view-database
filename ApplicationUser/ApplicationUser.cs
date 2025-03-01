using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.ApplicationUser;

public class ApplicationUser : IdentityUser<Guid>
{
    [Required]
    [MaxLength(50)]
    [MinLength(3)]
    public required string DisplayName { get; set; }
}
