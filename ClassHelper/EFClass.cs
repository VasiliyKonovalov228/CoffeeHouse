using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse9_14.DB;

namespace CoffeeHouse9_14.ClassHelper
{
    public class EFClass
    {
        public static Entities context { get;} = new Entities();
    }
}
