using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboration_2.Model
{
    public class Medlem
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedDate { get; }

        public Medlem(int age, string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Namn får inte vara tomt");

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email får inte vara tom");

            if (age <= 0)
                throw new Exception("Ålder måste vara större än 0");

            Age = age;
            Name = name;
            Email = email;

            IsActive = true;
            CreatedDate = DateTime.Now;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        // LINQ - Filtrering
        public static List<Medlem> GetActiveMembers(List<Medlem> members)
        {
            return members.Where(m => m.IsActive).ToList();
        }

        public override string ToString()
        {
            return $"{Name} ({(IsActive ? "Aktiv" : "Inaktiv")})";
        }
    }
}
