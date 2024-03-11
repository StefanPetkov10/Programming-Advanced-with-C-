using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Registry = new List<Child>();
        }
        public string Name { get; set; }

        public int Capacity { get; private set; }

        public List<Child> Registry { get; private set; }

        public int ChildrenCount => this.Registry.Count;

        public bool AddChild(Child child)
        {
            if (this.ChildrenCount == this.Capacity)
            {
                return false;
            }
            this.Registry.Add(child);
            return true;
        }

        public bool RemoveChild(string fullName) =>
         Registry.Remove(Registry.FirstOrDefault(fn => fn.FirstName == fullName.Split(" ")[0] && fn.LastName == fullName.Split(" ")[1]));

        public int GetCount() => Registry.Count;

        public Child GetChild(string childFullName) =>
            Registry.FirstOrDefault(fn => fn.FirstName == childFullName.Split(" ")[0] && fn.LastName == childFullName.Split(" ")[1]);

        public string RegistryReport()
        {
            var sortedChildren = Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();

            StringBuilder sb = new();

            sb.AppendLine($"Registered children in {Name}:");

            foreach (var child in sortedChildren)
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
