using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Exceptions
{
    [Serializable]
    public class IdNotFoundException : Exception
    {
        public int Id { get; }
        public IdNotFoundException() { }
        public IdNotFoundException(string message) : base(message) { }
        public IdNotFoundException(string message, Exception inner) : base(message, inner) { }
        public IdNotFoundException(string message, int id) : this(message)
        {
            Id = id;
        }
    }
}
