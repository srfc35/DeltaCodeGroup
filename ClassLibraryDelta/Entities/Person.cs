using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Entities
{
    public abstract class Person
    {
        #region Attributes
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;

        [Required]
        private string lastname;

        [Required]
        private int phone;

        [Required]
        private List<Command> listcommand;

        #endregion

        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }        

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        [Required]
        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }        

        public List<Command> ListCommand
        {
            get { return listcommand; }
            set { listcommand = value; }
        }

        #endregion

        #region Constructors

        public Person()
        {

        }

        public Person(string lastname, string firstname, int phone)
        {
            LastName = lastname;
            FirstName = firstname;
            Phone = phone;
            ListCommand = new List<Command>();
        }

        #endregion

        #region Methods

        public void UpdateLastName(string lastname)
        {
            if (!lastname.Equals(""))
            {
                LastName = lastname;
            }
        }

        public void UpdateFirstName(string firstname)
        {
            if (!firstname.Equals(""))
            {
                FirstName = firstname;
            }
        }

        public void UpdatePhone(int phone)
        {
            Phone = phone;
        }

        public void AddCommand(Command command)
        {
            ListCommand.Add(command);
        }
        #endregion
    }
}
