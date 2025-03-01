using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flow_view_database.ApplicationUser;
public class ApplicationUserDTO
{
    public required Guid Id { get; set; }
    public string? Email { get; set; }
    public required string UserName { get; set; }
    public bool EmailConfirmed { get; set; }
    public required List<string> Roles { get; set; }
}
