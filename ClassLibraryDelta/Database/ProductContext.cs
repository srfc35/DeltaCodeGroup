using ClassLibraryDelta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Database
{
    public class ProductContext : DbContext

    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Client> Clients { get; set; }
        //public DbSet<Person> Persons { get; set; }

        //creer la chaine de connexion

        public ProductContext() : base("DefaultConnection")
        {
            if (this.Database.CreateIfNotExists())
            {

                // Creer 10 clients
                for (int i = 0; i < 10; i++)
                {
                    Client client = new Client();
                    client.FirstName = "F.name client " + i;
                    client.LastName = "L.name client " + i;
                    client.Phone = i;
                    client.Email = i.ToString() + "@client.com";
                    client.ClientAccount = 10 * i;
                    this.Clients.Add(client);
                    this.SaveChanges();
                }

                // Creer 3 vendeurs
                for (int i = 0; i < 3; i++)
                {
                    Seller seller = new Seller();
                    seller.FirstName = "F.name seller" + i;
                    seller.LastName = "L.name seller " + i;
                    seller.Phone = i;
                    seller.Email = i.ToString() + "@seller.com";
                    seller.Login = i.ToString();
                    seller.Password = (100000*i).ToString();
                    seller.SellerAccount = 10 * i;
                    this.Sellers.Add(seller);
                    this.SaveChanges();
                }

                // Creer 3 ordinateurs
                for (int i = 1; i < 4; i++)
                {
                    Computer computer = new Computer();
                    computer.NameProduct = "Computer" + i;
                    computer.Brand = "Dell " + i;
                    computer.RamMemory = 4 + i;
                    computer.UnitPriceHT = 100 * i;
                    computer.VatRate = 0.2f;
                    this.Products.Add(computer);
                    this.SaveChanges();
                }

                // Creer 3 teles
                for (int i = 1; i < 4; i++)
                {
                    TV tv = new TV();
                    tv.NameProduct = "Tv" + i;
                    tv.Brand = "Samsung" + i;
                    tv.Resolution = 120;
                    tv.UnitPriceHT = 150 * i;
                    tv.VatRate = 0.2f;
                    this.Products.Add(tv);
                    this.SaveChanges();
                }

                // Creer 3 tablettes
                for (int i = 1; i < 4; i++)
                {
                    Tablet tablet = new Tablet();
                    tablet.NameProduct = "Tablet" + i;
                    tablet.Brand = "Ipad" + i;
                    tablet.ScreenSize = 7 + i;
                    tablet.UnitPriceHT = 100 * i;
                    tablet.VatRate = 0.2f;
                    this.Products.Add(tablet);
                    this.SaveChanges();
                }

                // Creer 3 telephones
                for (int i = 1; i < 4; i++)
                {
                    Phone phone = new Phone();
                    phone.NameProduct = "Phone" + i;
                    phone.Brand = "Iphone" + i;
                    phone.Os = "IOS";
                    phone.UnitPriceHT = 200 * i;
                    phone.VatRate = 0.2f;
                    this.Products.Add(phone);
                    this.SaveChanges();
                }

                // Creer 2 commandes
                for (int i = 1; i < 3; i++)
                {
                    Command c = new Command(this.Clients.Find(i), this.Sellers.Find(i));
                    c.DateCommand = DateTime.Today;
                    this.Products.Find(i).AddToOrder(c);
                    this.Commands.Add(c);
                    this.SaveChanges();
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Exception "ListCommand est declaré sur le type Person" -> j'ai passé ListCommand dans Client et Seller
            // WillCascadeOnDelete() : sans ça il y avait une exception 
            modelBuilder.Entity<Command>().HasRequired(c => c.Client).WithMany(cl => cl.ListCommand);
            modelBuilder.Entity<Command>().HasRequired(c => c.Seller).WithMany(s => s.ListCommand).WillCascadeOnDelete(false);
            modelBuilder.Entity<Product>().HasOptional(p => p.Order);

            base.OnModelCreating(modelBuilder);
        }
    }
}