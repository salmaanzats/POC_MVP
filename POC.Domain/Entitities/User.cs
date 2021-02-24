using System;
using System.Collections.Generic;
using System.Text;
using static POC.Utility.BaseEnums;

namespace POC.Domain.Entitities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string School { get; private set; }
        public Gender Gender { get; private set; }


        public User Create(string firstName, string lastName, string address, string school, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            School = school;
            Gender = gender;

            return this;
        }
    }
}
