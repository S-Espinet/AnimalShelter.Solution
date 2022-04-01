using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Type = "Cat", Name = "Link", Age = 2, Gender = "Female" },
          new Animal { AnimalId = 2, Type = "Cat", Name = "Zelda", Age = 2, Gender = "Female" },
          new Animal { AnimalId = 3, Type = "Cat", Name = "Ganon", Age = 3, Gender = "Male" },
          new Animal { AnimalId = 4, Type = "Dog", Name = "Merry", Age = 4, Gender = "Female" }
        );
    }
  }
}