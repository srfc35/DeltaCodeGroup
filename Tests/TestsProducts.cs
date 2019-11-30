using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ClassLibraryDelta.Entities;

namespace Tests
{
    [TestFixture]
    public class TestsProducts
    {

        // Definition de variables valides qu'on pourra utiliser pendant les tests
        public static int ID = 1;
        public static string name = "blabla";
        public static string brand = "Asus";
        public static int size = 16;
        public static float unitPriceHT = 700;
        public static float vatRate = 0.20f;
        public static float discount = 0;
        public static float weight = 2;
        public static string color = "black";
        public static int ram = 8;


        // ****** CREATION ******

        // Verifier qu'on ne peut pas creer un produit sans marque
        [Test]
        public static void ProductCreatedWithoutBrand()
        {
            Computer c = null;
            try
            {
                c = new Computer(ram, ID, name, "", size, unitPriceHT, vatRate, discount, weight, color);
            }
            catch (Exception e)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'on ne peut pas creer un produit de taille <= 0
        [Test]
        public static void ProductCreatedWithSize0()
        {
            Computer c = null;
            try
            {
                c = new Computer(ram, ID, name, brand, 0, unitPriceHT, vatRate, discount, weight, color);
            }
            catch (Exception e)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'on ne peut pas creer un produit de prix < 0
        [Test]
        public static void ProductCreatedWithPrice0()
        {
            Computer c = null;
            try
            {
                c = new Computer(ram, ID, name, brand, size, -0.5f, vatRate, discount, weight, color);
            }
            catch (Exception e)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'on ne peut pas creer un produit de TVA < 0
        [Test]
        public static void ProductCreatedWithVAT0()
        {
            Computer c = null;
            try
            {
                c = new Computer(ram, ID, name, brand, size, unitPriceHT, -0.5f, discount, weight, color);
            }
            catch (Exception e)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'on ne peut pas creer un produit de remise < 0
        [Test]
        public static void ProductCreatedWithDiscount0()
        {
            Computer c = null;
            try
            {
                c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, -0.5f, weight, color);
            }
            catch (Exception e)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'on ne peut pas creer un produit de poids < 0
        [Test]
        public static void ProductCreatedWithWeight0()
        {
            Computer c = null;
            try
            {
                c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, -0.5f, color);
            }
            catch (Exception e)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'avec des donnees valides, le produit est bien cree
        [Test]
        public static void ProductCreatedOK()
        {
            Computer c = null;
            try
            {
                c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            }
            catch (Exception e)
            {

            }
            Assert.IsNotNull(c);
        }

        // Verifier qu'on ne peut pas creer un ordinateur de RAM < 0
        [Test]
        public static void ComputerCreatedWithRAM0()
        {
            Computer c = null;
            try
            {
                c = new Computer(0, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            }
            catch (Exception e)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'on ne peut pas creer un telephone sans OS
        [Test]
        public static void PhoneCreatedWithoutOS()
        {
            Phone p = null;
            try
            {
                p = new Phone(ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color, "");
            }
            catch (Exception e)
            {

            }
            Assert.IsNull(p);
        }

        // Verifier qu'on ne peut pas creer une tablette avec une taille d'ecran <= 0
        [Test]
        public static void TabletCreatedWithScreenSize0()
        {
            Tablet t = null;
            try
            {
                t = new Tablet(0, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            }
            catch (Exception e)
            {

            }
            Assert.IsNull(t);
        }

        // Verifier qu'on ne peut pas creer une TV de resolution <= 0
        [Test]
        public static void TVCreatedWithResolution0()
        {
            TV t = null;
            try
            {
                t = new TV(ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color, 0);
            }
            catch (Exception e)
            {

            }
            Assert.IsNull(t);
        }


        // ****** MISE A JOUR ******

        // Verifier qu'on ne peut pas updater un produit avec une marque vide
        [Test]
        public static void ComputerUpdatedWithoutBrand()
        {
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdateBrand("");
            }
            catch (Exception e)
            {

            }
            Assert.True(c.Brand == brand);
        }

        // Verifier qu'avec une marque valide le produit est bien mis a jour
        public static void ComputerUpdatedWithValidBrand()
        {
            string validBrand = "newBrand";
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdateBrand(validBrand);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.Brand == validBrand);
        }

        // Verifier qu'on ne peut pas updater un produit avec une taille <= 0
        [Test]
        public static void ComputerUpdatedWithSize0()
        {
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdateSize(0);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.Size == size);
        }

        // Verifier qu'avec une marque valide le produit est bien mis a jour
        public static void ComputerUpdatedWithValidSize()
        {
            int validSize = 18;
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdateSize(validSize);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.Size == validSize);
        }

        // Verifier qu'on ne peut pas updater un produit avec un prix < 0
        [Test]
        public static void ComputerUpdatedWithPrice0()
        {
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdatePrice(-1);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.UnitPriceHT == unitPriceHT);
        }

        // Verifier qu'avec un prix valide le produit est bien mis a jour
        public static void ComputerUpdatedWithValidPrice()
        {
            int validPrice = 1000;
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdatePrice(validPrice);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.UnitPriceHT == validPrice);
        }

        // Verifier qu'on ne peut pas updater un produit avec une remise < 0
        [Test]
        public static void ComputerUpdatedWithDiscount0()
        {
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdateDiscount(-1);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.Discount == discount);
        }

        // Verifier qu'avec une marque valide le produit est bien mis a jour
        public static void ComputerUpdatedWithValidDiscount()
        {
            float validDiscount = 18;
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdateDiscount(validDiscount);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.Discount == validDiscount);
        }

        // Verifier qu'on ne peut pas updater un produit avec une remise < 0
        [Test]
        public static void ComputerUpdatedWithWeight0()
        {
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdateWeight(0);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.Weight == weight);
        }

        // Verifier qu'avec une marque valide le produit est bien mis a jour
        public static void ComputerUpdatedWithValidWeight()
        {
            float validWeight = 18;
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdateDiscount(validWeight);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.Weight == validWeight);
        }


        // Verifier qu'on ne peut pas updater un ordinateur avec une RAM < 0
        [Test]
        public static void ComputerUpdatedWithRAM0()
        {
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdateRamMemory(0);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.RamMemory == ram);
        }

        // Verifier qu'avec une RAM valide l'ordinateur est bien mis a jour
        public static void ComputerUpdatedWithValidRAM()
        {
            int validRAM = 4;
            Computer c = new Computer(ram, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                c.UpdateRamMemory(validRAM);
            }
            catch (Exception e)
            {

            }
            Assert.True(c.RamMemory == validRAM);
        }

        // Verifier qu'on ne peut pas updater un telephone avec un OS vide
        [Test]
        public static void PhoneUpdatedWithoutOS()
        {
            string validOS = "Android";
            Phone p = new Phone(ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color, validOS);
            try
            {
                p.UpdateOS("");
            }
            catch (Exception e)
            {

            }
            Assert.True(p.Os.Equals(validOS));
        }

        // Verifier qu'avec un OS valide le telephone est bien mis a jour
        public static void PhoneUpdatedWithValidOS()
        {
            string validOS = "Android";
            Phone p = new Phone(ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color, validOS);
            string validOS2 = "WindowsPhone";
            try
            {
                p.UpdateOS(validOS2);
            }
            catch (Exception e)
            {

            }
            Assert.True(p.Os.Equals(validOS2));
        }

        // Verifier qu'on ne peut pas updater une tablette avec une taille d'ecran < 0
        [Test]
        public static void TabletUpdatedWithScreen0()
        {
            int validScreenSize = 12;
            Tablet t = new Tablet(validScreenSize, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                t.UpdateScreenSize(0);
            }
            catch (Exception e)
            {

            }
            Assert.True(t.ScreenSize == validScreenSize);
        }

        // Verifier qu'avec une taille d'ecran valide la tablette est bien mise a jour
        public static void TabletUpdatedWithValidScreenSize()
        {
            int validScreenSize = 12;
            int validScreenSize2 = 10;
            Tablet t = new Tablet(validScreenSize, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                t.UpdateScreenSize(validScreenSize2);
            }
            catch (Exception e)
            {

            }
            Assert.True(t.ScreenSize == validScreenSize2);
        }

        // Verifier qu'on ne peut pas updater une tele avec une resolution < 0
        [Test]
        public static void TVUpdatedWithResolution0()
        {
            float validResolution = 1400;
            TV t = new TV(ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color, validResolution);
            try
            {
                t.UpdateResolution(0);
            }
            catch (Exception e)
            {

            }
            Assert.True(t.Resolution == validResolution);
        }

        // Verifier qu'avec une taille d'ecran valide la tablette est bien mise a jour
        public static void TVUpdatedWithValidResolution()
        {
            int validResolution = 1400;
            int validResolution2 = 1500;
            Tablet t = new Tablet(validResolution, ID, name, brand, size, unitPriceHT, vatRate, discount, weight, color);
            try
            {
                t.UpdateScreenSize(validResolution2);
            }
            catch (Exception e)
            {

            }
            Assert.True(t.ScreenSize == validResolution2);
        }

    }
}
