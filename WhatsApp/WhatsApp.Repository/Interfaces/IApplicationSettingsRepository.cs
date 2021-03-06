﻿using System;
using System.Collections.Generic;
using WhatsApp.Core.Dto.Appsettings;
namespace WhatsApp.Repository.Interfaces


{
    public interface IApplicationSettingsRepository
    {
        IEnumerable<ApplicationSettings> FindAll(int pageNum = 1, int pageSize = 10);
        void DeleteById(int id);
        ApplicationSettings FindById(int id); 
    }
}
