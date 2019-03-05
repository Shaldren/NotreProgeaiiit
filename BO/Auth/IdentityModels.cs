using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BO.Auth
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public partial class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<POI>().HasRequired(c => c.Category).WithMany(p => p.POIs);
            modelBuilder.Entity<POI>().HasMany(r => r.Inscriptions).WithMany();
            modelBuilder.Entity<Inscription>().HasMany(s => s.Positions).WithMany(c => c.Inscriptions);
            modelBuilder.Entity<Inscription>().HasRequired(a => a.Race).WithMany(z => z.Inscriptions);
            modelBuilder.Entity<Race>().HasMany(a => a.Inscriptions).WithRequired(z => z.Race);
            modelBuilder.Entity<Inscription>().HasRequired(a => a.ApplicationUser).WithMany(z => z.Inscriptions);
            modelBuilder.Entity<ApplicationUser>().HasMany(a => a.Inscriptions).WithRequired(z => z.ApplicationUser);
            modelBuilder.Entity<ApplicationUser>().HasOptional(a => a.DisplayConfiguration).WithRequired(z => z.ApplicationUser);
            modelBuilder.Entity<Inscription>().HasMany(a => a.Positions).WithMany(z => z.Inscriptions);

        }

        public System.Data.Entity.DbSet<BO.Category> Categories { get; set; }

		public System.Data.Entity.DbSet<BO.DisplayConfiguration> DisplayConfigurations { get; set; }

		public System.Data.Entity.DbSet<BO.POI> POIs { get; set; }

		public System.Data.Entity.DbSet<BO.Inscription> Inscriptions { get; set; }

		public System.Data.Entity.DbSet<BO.Race> Races { get; set; }
        
	}
}