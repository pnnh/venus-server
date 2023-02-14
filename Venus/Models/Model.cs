namespace Venus.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class VenusDatabaseContext : DbContext
{
    public DbSet<PictureTable> Pictures => Set<PictureTable>(); 

    public VenusDatabaseContext(DbContextOptions<VenusDatabaseContext> options) : base(options)
    {
    }
}
