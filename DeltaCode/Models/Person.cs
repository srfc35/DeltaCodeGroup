using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaCode.Models
{
    public abstract class Person
    {
        #region Attributes
        private int id;
        private string lastname;
        private string firstname;
        private int phone;
        private List<Command> listcommand;
        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

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
        public List<Command> ListCommand
        {
            get { return listcommand; }
            set { listcommand = value; }
        }

        #endregion

        #region Constructors

        public Person()
        {
            this.listcommand = new List<Command>();
        }

        public Person(string lastname, string firstname, int phone)
        {
            if (lastname.Equals("") || firstname.Equals("") || phone < 0100000000 || phone > 0999999999)
            {
                throw new Exception("Données manquantes (nom, prénom ou téléphone)");
            }
            else
            {
                this.listcommand = new List<Command>();
                LastName = lastname;
                FirstName = firstname;
                Phone = phone;
                ListCommand = new List<Command>();
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

        public void AddCommand(Command command)
        {
            ListCommand.Add(command);
        }
        #endregion
    }
}
