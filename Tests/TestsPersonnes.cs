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
    public class TestsPersonnes
    {


        // ****** CREATION ******


        // Verifier qu'on ne peut pas creer un client sans lastname
        [Test]
        public static void ClientCreatedWithoutLastName()
        {
            Client c = null;
            try
            {
                c = new Client("", "Prénom", 0612345678);
            }
            catch (Exception)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'on ne peut pas creer un client sans firstname
        [Test]
        public static void ClientCreatedWithoutFirstName()
        {
            Client c = null;
            try
            {
                c = new Client("Nom", "", 0612345678);
            }
            catch (Exception)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'on ne peut pas creer un client avec un numero de telephone inferieur a 01 00 00 00 00
        [Test]
        public static void ClientCreatedWithPhone01()
        {
            Client c = null;
            try
            {
                c = new Client("Nom", "Prénom", 0012345678);
            }
            catch (Exception)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'on ne peut pas creer un client avec un numero de telephone superieur a 09 99 99 99 99
        [Test]
        public static void ClientCreatedWithPhone09()
        {
            Client c = null;
            try
            {
                c = new Client("Nom", "Prénom", 1999999999);
            }
            catch (Exception)
            {

            }
            Assert.IsNull(c);
        }

        // Verifier qu'avec des donnees valides le client est bien cree
        [Test]
        public static void ClientCreatedOK()
        {
            Client c = null;
            try
            {
                c = new Client("Nom", "Prénom", 0123456789);
            }
            catch (Exception)
            {

            }
            Assert.IsNotNull(c);
        }


        // ****** MISE A JOUR ******

        // Verifier qu'on ne peut pas updater un client sans lastname
        [Test]
        public static void ClientUpdatedWithoutLastName()
        {
            Client c = new Client("Nom", "Prénom", 0123456789);
            try
            {
                c.UpdateLastName("");
            }
            catch (Exception)
            {

            }
            Assert.False(c.LastName.Equals(""));
        }

        // Verifier qu'avec un lastname valide le client est bien mis a jour
        [Test]
        public static void ClientUpdatedWithValidLastName()
        {
            Client c = new Client("Nom", "Prénom", 0123456789);
            string n = "NouveauNom";
            try
            {
                c.UpdateLastName(n);
            }
            catch (Exception)
            {

            }
            Assert.True(c.LastName.Equals(n));
        }

        // Verifier qu'on ne peut pas updater un client sans firstname
        [Test]
        public static void ClientUpdatedWithoutFirstName()
        {
            Client c = new Client("Nom", "Prénom", 0612345678);
            try
            {
                c.UpdateFirstName("");
            }
            catch (Exception)
            {

            }
            Assert.False(c.FirstName.Equals(""));
        }

        // Verifier qu'avec un firstname valide le client est bien mis a jour
        [Test]
        public static void ClientUpdatedWithValidFirstName()
        {
            Client c = new Client("Nom", "Prénom", 0123456789);
            string p = "NouveauPrénom";
            try
            {
                c.UpdateFirstName(p);
            }
            catch (Exception)
            {

            }
            Assert.True(c.FirstName.Equals(p));
        }

        // Verifier qu'on ne peut pas updater un client avec un numero de telephone inferieur a 01 00 00 00 00
        [Test]
        public static void ClientUpdatedWithPhone01()
        {
            int validPhone = 0123456789;
            Client c = new Client("Nom", "Prénom", validPhone);
            try
            {
                c.UpdatePhone(0012345678);
            }
            catch (Exception)
            {

            }
            Assert.True(c.Phone == validPhone);
        }

        // Verifier qu'on ne peut pas updater un client avec un numero de telephone superieur a 09 99 99 99 99
        [Test]
        public static void ClientUpdatedWithPhone09()
        {
            int validPhone = 0123456789;
            Client c = new Client("Nom", "Prénom", validPhone);
            try
            {
                c.UpdatePhone(1999999999);
            }
            catch (Exception)
            {

            }
            Assert.True(c.Phone == validPhone);
        }

        // Verifier qu'avec un numero de telephone valide le client est bien mis a jour
        public static void ClientUpdatedWithValidPhone()
        {
            int validPhone = 0123456789;
            int newValidPhone = 0600000000;
            Client c = new Client("Nom", "Prénom", validPhone);
            try
            {
                c.UpdatePhone(newValidPhone);
            }
            catch (Exception)
            {

            }
            Assert.True(c.Phone == newValidPhone);
        }

    }
}
