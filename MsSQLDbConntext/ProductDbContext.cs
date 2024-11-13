using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.Extensions.Options;
using System.Xml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MsSQLDbConntext
{
    public class ProductsMsSqlDbContext : DbContext
    {

        public ProductsMsSqlDbContext(DbContextOptions<ProductsMsSqlDbContext> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            //Имитация подключения к базе данных
            //Создаётся локальная база данных, заполняется хардкодом
            List<Product> productsFromDb = new()
            {
                new Product { TitleName = "Скейт Joerex2 71*20,3см (кол PVC, кит. клён, пласт трак, 0795" },
                new Product { TitleName = "Скейт MINI Joerex 43*13см (кол PVC, кит. клён, пла 28305 -JSK" },
                new Product { TitleName = "Скейт балансир Joerex в чехле (кол PU 76мм, дека PP) 902 -JSK" },
                new Product { TitleName = "Коврик для ЙОГИ/фитн JOEREX с рисунк 173*61*0,6cм (ПВХ) J6588 Синий" },
                new Product { TitleName = "Медицинбол INDIGO, 9056 HKTB, Синий, 1 кг" },
                new Product { TitleName = "Полусфера для фитнеса BOSU с эспандерами и насосом, IN086, Зеленый" },
                new Product { TitleName = "Качели-гнездо подвесные d-100см 8804LW" },
                new Product { TitleName = "Гамак-кресло с подлокотниками HM-013" },
                new Product { TitleName = "Гамак-Кресло (сумка+ 2 подушки )HRHС-17" },
                new Product { TitleName = "Доска балансировочная INDIGO WORKOUT BOARD TWIST, IN128, Розовый" },
                new Product { TitleName = "Мяч футбольный №5 INDIGO POWER матчевый безшовный (PU PVC 1.4мм) Z02" },
            };

            Products.AddRange(productsFromDb);
            SaveChanges();
        }
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Product>().Property(x => x.TitleName).IsRequired(true);
        }

    }
}
