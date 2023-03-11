using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Mapping
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> mapper = new(() =>
        {
            var conf = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });
            return conf.CreateMapper();
        });

        public static IMapper Mapper => mapper.Value;
    }
}
