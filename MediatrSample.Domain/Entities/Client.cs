using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrSample.Domain.Entities
{
    public class Client
    {
        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; private set; }

        public void Activate()
        {
            IsActive = true;
        }
        
        public void Archive()
        {
            IsActive = false;
        }
    }
}
