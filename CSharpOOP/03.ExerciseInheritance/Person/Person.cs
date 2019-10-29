﻿using System;
using System.Text;

namespace Person
{
    public class Person
    {
        public int age;
        private string name;
        public int Age {
            get { return this.age; }
            set
            {
                if (value < 0) throw new ArgumentException("Person age cannot be negative");
                this.age = value;
            }
        }
        public string Name {
            get { return this.name; }
            set { this.name = value; }
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }
    }
}
