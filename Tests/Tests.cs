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
    public class Tests
    {

        [Test]
        public void ClientCreatedWithoutLastName()
        {
            Client c = new Client();
            Assert.IsNull(c);
        }
    }
}
