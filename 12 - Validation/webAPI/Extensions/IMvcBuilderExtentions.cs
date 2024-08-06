using webAPI.utilities.AutoMapper.Formatters;

namespace webAPI.Extensions
{
    public static class IMvcBuilderExtentions
    {
        public static IMvcBuilder AddCostumCsvFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(conf =>
            conf.OutputFormatters.Add(new CsOutputFormatter())
            );

    }
}
