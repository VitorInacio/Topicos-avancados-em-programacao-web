using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Entities
{
    internal class Entity : IEquatable<Entity>
    {
        public int Id { get; set; }

        public bool Equals(Entity? other)
        {
            return other?.Id == Id;

            //if (other?.Id == Id)
            //{
            //    return true;
            //}
            //return false;
        }
    }
}
