using Microsoft.AspNetCore.Identity;

namespace tourismApp.Models.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public decimal UserAvailableTime { get; set; }
        public int UserPreferredAttractionTypeId { get; set; }
        public decimal UserBudget { get; set; }
    }
}
