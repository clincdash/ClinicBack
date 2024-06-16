
using clinicteo.Models.Base;
using clinicteo.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace clinicteo.Context;

public class ClinicTeoContext: DbContext
{
    public ClinicTeoContext( DbContextOptions dbContextOptions ) : base( dbContextOptions ) { }

    public DbSet<User> Users { get; set; }
}
