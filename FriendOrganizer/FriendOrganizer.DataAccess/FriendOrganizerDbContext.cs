using FriendOrganizer.Model;
using System.Data.Entity;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        public FriendOrganizerDbContext():base("FriendOrganizerDb")
        {

        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
