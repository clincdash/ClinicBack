using clinicteo.Models.User;
using Microsoft.EntityFrameworkCore;

namespace clinicteo.Context;

public class ClinicTeoContext: DbContext
{
    public ClinicTeoContext( DbContextOptions dbContextOptions ) : base( dbContextOptions ) { }

    public DbSet<User> Users { get; set; }
}
