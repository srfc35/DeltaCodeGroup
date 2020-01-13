using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Entities
{
    public abstract class Person
    {
        #region Attributes
        private int id;
        private string lastname;
        private string firstname;
        private int phone;
        private string email;
        #endregion

        #region Properties

        [PrimaryKey,AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [StringLength(30)]
        [Required]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        [StringLength(30)]
        [Required]
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        [Required]
        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        [Required]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        #endregion

        #region Constructors

        public Person()
        {

        }

        public Person(string lastname, string firstname, int phone, string email)
        {
            if (lastname.Equals("") || firstname.Equals("") || phone < 0100000000 || phone > 0999999999)
            {
                throw new Exception("Données manquantes (nom, prénom ou téléphone)");
            }
            else
            {
                LastName = lastname;
                FirstName = firstname;
                Phone = phone;
                Email = email;
            }
        }

        #endregion

        #region Methods

        public void UpdateLastName(string lastname)
        {
            if (!lastname.Equals(""))
            {
                LastName = lastname;
            }
            else
            {
                throw new Exception("Le nom fourni n'est pas valide");
            }
        }

        public void UpdateFirstName(string firstname)
        {
            if (!firstname.Equals(""))
            {
                FirstName = firstname;
            }
            else
            {
                throw new Exception("Le prénom fourni n'est pas valide");
            }
        }

        public void UpdatePhone(int phone)
        {
            if (!(phone > 0100000000 || phone > 0999999999))
            {
                Phone = phone;
            }

            else
            {
                throw new Exception("Le numéro fourni n'est pas valide");
            }
        }

        #endregion
    }
}
