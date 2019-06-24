using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P110_EF.Model
{
    public partial class Department
    {
        public override string ToString()
        {
            return Name;
        }
    }

    public partial class Position
    {
        public override string ToString()
        {
            return Name;
        }
    }
}
