using AutoMapper;
using TryMLearning.Persistence.Configuration;

namespace TryMLearning.WebAPI
{
    public partial class Startup
    {
        public void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.RegisterDtoMaps();
            });
        }
    }
}
