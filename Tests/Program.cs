using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {

        public static void Main()
        {

            // TESTS SUR DES PERSONNES

            // Creation
            TestsPersonnes.ClientCreatedWithoutLastName();
            TestsPersonnes.ClientCreatedWithoutFirstName();
            TestsPersonnes.ClientCreatedWithPhone01();
            TestsPersonnes.ClientCreatedWithPhone09();
            TestsPersonnes.ClientCreatedOK();

            // Mise a jour
            TestsPersonnes.ClientUpdatedWithoutLastName();
            TestsPersonnes.ClientUpdatedWithValidLastName();
            TestsPersonnes.ClientUpdatedWithoutFirstName();
            TestsPersonnes.ClientUpdatedWithValidFirstName();
            TestsPersonnes.ClientUpdatedWithPhone01();
            TestsPersonnes.ClientUpdatedWithPhone09();
            TestsPersonnes.ClientUpdatedWithValidPhone();


            // TESTS SUR DES PRODUITS

            // Creation
            TestsProducts.ProductCreatedWithoutBrand();
            TestsProducts.ProductCreatedWithSize0();
            TestsProducts.ProductCreatedWithPrice0();
            TestsProducts.ProductCreatedWithVAT0();
            TestsProducts.ProductCreatedWithDiscount0();
            TestsProducts.ProductCreatedWithWeight0();
            TestsProducts.ProductCreatedOK();
            TestsProducts.ComputerCreatedWithRAM0();
            TestsProducts.PhoneCreatedWithoutOS();
            TestsProducts.TabletCreatedWithScreenSize0();
            TestsProducts.TVCreatedWithResolution0();

            // Mise a jour
            TestsProducts.ComputerUpdatedWithoutBrand();
            TestsProducts.ComputerUpdatedWithValidBrand();
            TestsProducts.ComputerUpdatedWithSize0();
            TestsProducts.ComputerUpdatedWithValidSize();
            TestsProducts.ComputerUpdatedWithPrice0();
            TestsProducts.ComputerUpdatedWithValidPrice();
            TestsProducts.ComputerUpdatedWithDiscount0();
            TestsProducts.ComputerUpdatedWithValidDiscount();
            TestsProducts.ComputerUpdatedWithWeight0();
            TestsProducts.ComputerUpdatedWithValidWeight();
            TestsProducts.ComputerUpdatedWithRAM0();
            TestsProducts.ComputerUpdatedWithValidRAM();
            TestsProducts.PhoneUpdatedWithoutOS();
            TestsProducts.PhoneUpdatedWithValidOS();
            TestsProducts.TabletUpdatedWithScreen0();
            TestsProducts.TabletUpdatedWithValidScreenSize();
            TestsProducts.TVUpdatedWithResolution0();
            TestsProducts.TVUpdatedWithValidResolution();
        }
    }
}
