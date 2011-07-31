using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Db4objects.Db4o;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.Linq;
using System.Collections;

namespace Db4oServer.Test
{
    public class Human
    {
        public string Name { get; set; }
        public string Hobby { get; set; }

    }


    [TestFixture]
    public class Db4oServiceTest
    {
        [Test]
        public void can_start_multiple_sessions() {

           IObjectContainer client1 = 
           Db4oClientServer.OpenClient(Db4oClientServer.NewClientConfiguration(),
                  "localhost", 4433, "db4o", "db4o");
           
           IObjectContainer client2 = 
             Db4oClientServer.OpenClient(Db4oClientServer.NewClientConfiguration(),
                "localhost", 4433, "db4o", "db4o");

           var humans = from Human persons in client1 select persons;
           client1.Delete(humans);

           Human b = new Human { Hobby = "Cycling", Name = "Joe" };
           Human t = new Human { Hobby = "Doing Nothing", Name = "Trudy" };
       
           client1.Store(b);
           client2.Store(t);
           client1.Commit();
           client2.Commit(); 

           Human thePerson = (from Human p in client1 where p.Name == "Trudy" select p).FirstOrDefault();
           //Assert.NotNull(thePerson);
           StringAssert.Contains("Q", thePerson.Hobby); 
        } 
    }
}
