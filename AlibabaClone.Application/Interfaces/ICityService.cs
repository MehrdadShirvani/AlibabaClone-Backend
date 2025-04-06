using AlibabaClone.Application.DTOs.City;
using AlibabaClone.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Application.Interfaces
{
    public interface ICityService
    {
        Task<Result<IEnumerable<CityDto>>> GetCitiesAsync();
    }
}
