using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.config
{
    public class bookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book() { Id = 1 , Title = "olasılıksız" , Price = 1250},
                new Book() { Id = 2 , Title = "Budala" , Price = 212},
                new Book() { Id = 3 , Title = "Kumarbaz" , Price = 4321}
                );
        }

    }
}
