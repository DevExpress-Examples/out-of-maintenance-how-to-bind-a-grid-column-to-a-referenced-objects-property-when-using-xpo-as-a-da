using System;
using DevExpress.Xpo;

 
	
	public class Address : XPObject {
		public Address(Session session) : base(session) { }

        string city;
        public string City {
            get { return city; }
            set { SetPropertyValue("City", ref city, value); }
        }
    }

