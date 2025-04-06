using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifcisinden.Business.Operations.Setting
{
    public interface ISettingService
    {

        Task ToggleMaintenenceMode();

        bool GetMaintenenceMode();
    }
}
