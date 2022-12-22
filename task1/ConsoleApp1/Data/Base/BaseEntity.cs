using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Base
{
    public interface BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
