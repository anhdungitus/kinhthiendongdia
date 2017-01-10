using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LTHD.Web.Infrastructure.Identity
{
    public class StoreIdentityDbContext : IdentityDbContext<StoreUser>
    {
        static StoreIdentityDbContext()
        {
            Database.SetInitializer<StoreIdentityDbContext>(new StoreIdentityDbInitializer());
        }
        public StoreIdentityDbContext()
            : base("Name=LTHD_IdentityDb")
        {
        }
        public static StoreIdentityDbContext Create()
        {
            return new StoreIdentityDbContext();
        }
    }
}