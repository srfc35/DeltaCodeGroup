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
        private int id;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private int phone;

        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private List<Command> listcommand;

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
    }
}
