using System;

namespace DragAndDropRows {
    public class Person {
        string firstName;
        string lastName;
        string country;

        public Person() {  }
        public Person(string firstName, string lastName, string country) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.country = country;
        }
        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }
        
        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Country {
            get { return country; }
            set { country = value; }
        }

    }

    public class PersonEx : Person {
        int id;
        int parentID;
        static int counter = 1;
        public PersonEx() { }
        public PersonEx(string firstName, string lastName, string country, int parentID)
            : base(firstName, lastName, country) {
            this.parentID = parentID;
            id = counter++;
        }

        public PersonEx(Person person, int parentID)
            : this(person.FirstName, person.LastName, person.Country, parentID) {
        }

        public int ID {
            get { return id; }
            set { id = value; }
        }
        public int ParentID {
            get { return parentID; }
            set { parentID = value; }
        }
        public Object[] ToArray() {
            return new Object[] {ID, ParentID, FirstName, LastName, Country };
        }
    }
}