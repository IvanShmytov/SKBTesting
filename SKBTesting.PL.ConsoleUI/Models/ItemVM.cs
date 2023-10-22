using SKBTesting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKBTesting.PL.ConsoleUI.Models
{
    public class ItemVM
    {
        public Guid Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Enter the correct name");
                }
                name = value;
            }
        }

        public int Priority { get; set; }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Enter the correct description");
                }
                description = value;
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Enter the correct status");
                }
                status = value;
            }
        }

        private ItemVM()
        {

        }
        public ItemVM(string name, int priority, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Priority = priority;
            Description = description;
            Status = "In progress";
        }

        public static implicit operator ItemDTO(ItemVM model)
        {
            return new ItemDTO()
            {
                Id = model.Id,
                Name = model.Name,
                Priority = model.Priority,
                Description = model.Description,
                Status = model.Status
            };

        }

        public static implicit operator ItemVM(ItemDTO model)
        {
            return new ItemVM()
            {
                Id = model.Id,
                Name = model.Name,
                Priority = model.Priority,
                Description = model.Description,
                Status = model.Status
            };
        }
        public override string ToString()
        {
            return $"Name of item: {Name}; Priority: {Priority}; Status of item: {Status}.";
        }
    }
}
