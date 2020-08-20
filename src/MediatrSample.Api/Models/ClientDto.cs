using MediatrSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrSample.Api.Models
{
    public class ClientDto
    {
        public ClientDto() { }
        public ClientDto(string id, string firstName, string lastName, bool isActive)
        {
            FirstName = firstName;
            LastName = lastName;
            IsActive = isActive;
            Id = id;
        }
        public ClientDto(Client client)
        {
            FirstName = client.FirstName;
            LastName = client.LastName;
            IsActive = client.IsActive;
            Id = client.Id.ToString();
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
