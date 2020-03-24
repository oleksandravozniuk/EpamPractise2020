using DAL_EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL_EF.EF
{
    public class StoreContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(new StoreDbInitializer());
        }
        public StoreContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext db)
        {

            db.Tickets.Add(new Ticket { Name = "Занадто одружений таксист", Author = "Рей Куні", Genre = "Комедія", Type = "Балкон", Number = 100, Price = 200, Date = new DateTime(2020, 1, 20, 18, 30, 0) });
            db.Tickets.Add(new Ticket { Name = "Занадто одружений таксист", Author = "Рей Куні", Genre = "Комедія", Type = "Партер", Number = 120, Price = 250, Date = new DateTime(2020, 1, 20, 18, 30, 0) });

            db.Tickets.Add(new Ticket { Name = "Любов не за сценарієм", Author = "Тетяна Єдемська", Genre = "Комедія", Type = "Балкон", Number = 50, Price = 150, Date = new DateTime(2020, 2, 18, 17, 0, 0) });
            db.Tickets.Add(new Ticket { Name = "Любов не за сценарієм", Author = "Тетяна Єдемська", Genre = "Комедія", Type = "Партер", Number = 60, Price = 160, Date = new DateTime(2020, 2, 18, 17, 0, 0) });


            db.Tickets.Add(new Ticket { Name = "Прийшов чоловік до жінки", Author = "Семен Злотников", Genre = "Комедія", Type = "Балкон", Number = 90, Price = 190, Date = new DateTime(2020, 3, 9, 17, 30, 0) });
            db.Tickets.Add(new Ticket { Name = "Прийшов чоловік до жінки", Author = "Семен Злотников", Genre = "Комедія", Type = "Партер", Number = 100, Price = 200, Date = new DateTime(2020, 3, 9, 17, 30, 0) });


            db.Tickets.Add(new Ticket { Name = "Чоловік моєї дружини", Author = "Миро Гавран", Genre = "Трагедія", Type = "Балкон", Number = 120, Price = 80, Date = new DateTime(2020, 4, 8, 19, 0, 0) });
            db.Tickets.Add(new Ticket { Name = "Чоловік моєї дружини", Author = "Миро Гавран", Genre = "Трагедія", Type = "Партер", Number = 150, Price = 110, Date = new DateTime(2020, 4, 8, 19, 0, 0) });


            db.Tickets.Add(new Ticket { Name = "Лючія, таємниця падаючих зірок", Author = "Сергій Остапчук", Genre = "Дитяча", Type = "Балкон", Number = 300, Price = 90, Date = new DateTime(2020, 5, 3, 18, 30, 0) });
            db.Tickets.Add(new Ticket { Name = "Лючія, таємниця падаючих зірок", Author = "Сергій Остапчук", Genre = "Дитяча", Type = "Партер", Number = 320, Price = 130, Date = new DateTime(2020, 5, 3, 18, 30, 0) });


            db.Tickets.Add(new Ticket { Name = "Коза-дереза", Author = "Іван Теліга", Genre = "Дитяча", Type = "Балкон", Number = 170, Price = 130, Date = new DateTime(2020, 6, 6, 16, 30, 0) });
            db.Tickets.Add(new Ticket { Name = "Коза-дереза", Author = "Іван Теліга", Genre = "Дитяча", Type = "Партер", Number = 190, Price = 150, Date = new DateTime(2020, 6, 6, 16, 30, 0) });


            db.Tickets.Add(new Ticket { Name = "Богдан Хмельницький", Author = "Олег Корнійчук", Genre = "Історична", Type = "Балкон", Number = 110, Price = 150, Date = new DateTime(2020, 7, 23, 18, 30, 0) });
            db.Tickets.Add(new Ticket { Name = "Богдан Хмельницький", Author = "Олег Корнійчук", Genre = "Історична", Type = "Партер", Number = 130, Price = 120, Date = new DateTime(2020, 7, 23, 18, 30, 0) });


            db.Tickets.Add(new Ticket { Name = "Дорога до раю", Author = "Дмитро Кешеля", Genre = "Історична", Type = "Балкон", Number = 200, Price = 220, Date = new DateTime(2015, 8, 17, 18, 30, 0) });
            db.Tickets.Add(new Ticket { Name = "Дорога до раю", Author = "Дмитро Кешеля", Genre = "Історична", Type = "Партер", Number = 210, Price = 230, Date = new DateTime(2015, 8, 17, 18, 30, 0) });

            db.SaveChanges();

        }
    }
}
}
