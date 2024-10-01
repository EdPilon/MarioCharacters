using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioCharacters
{
    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty;

        public string Display()
            {
                return $"Id: {Id}\nName: {Name}\nRelationship: {Relationship}\n";
            }
    }
}