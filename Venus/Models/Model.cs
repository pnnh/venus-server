namespace Venus.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class BloggingContext : DbContext
{
    public DbSet<PictureTable> PicturesTable => Set<PictureTable>();
    public DbSet<PictureFileModel> PictureFilesTable => Set<PictureFileModel>();

    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
    {
    }
}
