using System;
using DevExpress.Xpo;

	public class Person : XPObject {
		public Person(Session session) : base(session) { }

        string name;
        public string Name {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }

        Address address;
        // If a reference property (Address) is aggregated, its subproperties 
        // can be editted along with the parent object's properties.
        [Aggregated]
        public Address Address {
            get { return address; }
            set { SetPropertyValue("Address", ref address, value); }
        }

        // if a Person is supposed to have an address by default, 
        // you can create it within the AfterConstruction method
        public override void AfterConstruction() {
            base.AfterConstruction();
            Address = new Address(Session);
        }
	}

