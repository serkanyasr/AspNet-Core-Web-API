using Microsoft.EntityFrameworkCore;
using bsStoreApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bsStoreApp.Models.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Olasılıksız", Price = 223 },
                new Book { Id = 2, Title = "deneme", Price = 2223 },
                new Book { Id = 3, Title = "deneme2", Price = 43}
                );
        }
    }
}
