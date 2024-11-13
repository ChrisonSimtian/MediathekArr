using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace MediathekArr.Tests.Fixtures;

public class AbstractTestWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
{
    // Do some setting up here if needed

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        /* We inject the appsettings from the Web API project to be able to test our settings */
        builder.ConfigureAppConfiguration((context, config) => 
        { 
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); 
        });
    }
}
