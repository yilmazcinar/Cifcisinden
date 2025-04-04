using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifcisinden.Business.DataProtection
{
    public interface IDataProtection
    {

        string Protect(string text);

        string UnProtect(string protectedText);

    }
}
