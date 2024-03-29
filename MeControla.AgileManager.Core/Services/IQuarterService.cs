﻿using MeControla.AgileManager.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface IQuarterService
    {
        Task<IList<QuarterDto>> LoadAllAsync(CancellationToken cancellationToken);
    }
}