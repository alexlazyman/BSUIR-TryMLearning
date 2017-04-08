using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TryMLearning.Model;
using TryMLearning.Persistence.Configuration;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Configuration
{
    public static class AutoMapperConfig
    {
        public static void RegisterCommonMaps(this IMapperConfigurationExpression cfg)
        {
            cfg.RegisterDtoMaps();
        }
    }
}
