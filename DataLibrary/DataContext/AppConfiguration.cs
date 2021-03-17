using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DataLibrary.DataContext
{
    public class AppConfiguration
    {
        //CONSTRUCTOR
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnectionString = appSetting.Value;
        }

        public string sqlConnectionString { get; set; }
    }
}
