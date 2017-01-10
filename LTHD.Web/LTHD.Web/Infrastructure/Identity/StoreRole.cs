using Microsoft.AspNet.Identity.EntityFramework;

namespace LTHD.Web.Infrastructure.Identity
{
    public class StoreRole : IdentityRole
    {
        public StoreRole() : base() { }
        public StoreRole(string name) : base(name) { }
    }
}