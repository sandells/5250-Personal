using System;

namespace App1.Models
{
    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }

        public void Update(Character newCh)
        {
            if (newCh == null)
            {
                return;
            }

            // Update all the fields in the Item, except for the Id
            this.Name = newCh.Name;
            this.Description = newCh.Description;
            this.Age = newCh.Age;
            return;
        }
    }
}