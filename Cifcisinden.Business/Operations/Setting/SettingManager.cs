using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Data.Entities;
using Cifcisinden.Data.Repositories;
using Cifcisinden.Data.UnitOfWork;

namespace Cifcisinden.Business.Operations.Setting;

public class SettingManager : ISettingService
{
    private readonly IRepository<SettingEntity> _settingRepository;

    private readonly IUnitOfWork _unitOfWork;

    public SettingManager(IRepository<SettingEntity> settingRepository, IUnitOfWork unitOfWork)
    {
        _settingRepository = settingRepository;
        _unitOfWork = unitOfWork;
    }

    public bool GetMaintenenceMode()
    {
        var maintenenceState = _settingRepository.GetById(1).MaintenenceMode;

        return maintenenceState;
    }

    public async Task ToggleMaintenenceMode()
    {
        var setting =  _settingRepository.GetById(1);

        setting.MaintenenceMode = !setting.MaintenenceMode;

        _settingRepository.Update(setting);

        try
        {
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"{ex} Bakım durumu güncellenirken bir hata oluştu. ");
        }
    }
}
