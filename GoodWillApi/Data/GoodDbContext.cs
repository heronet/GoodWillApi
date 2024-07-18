using GoodWillApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodWillApi.Data;

public class GoodDbContext(DbContextOptions<GoodDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<BloodRequest> BloodRequests { get; set; }
    public DbSet<BloodDonation> BloodDonations { get; set; }
    public DbSet<ManpowerRequest> ManpowerRequests { get; set; }
}
