using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifcisinden.Business.Types;

public class ServiceMassage
{

    public bool IsSucceed { get; set; }

    public string Message { get; set; }
}


public class ServiceMassage<T> : ServiceMassage
{
    public T? Data { get; set; }

    public bool IsSucceed { get; set; }

    public string Message { get; set; }
}