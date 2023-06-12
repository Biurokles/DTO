using Microsoft.AspNetCore.Identity;

namespace DTO.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public virtual IList<LeapYearCheck> Checks { get; set; }
    }
}
