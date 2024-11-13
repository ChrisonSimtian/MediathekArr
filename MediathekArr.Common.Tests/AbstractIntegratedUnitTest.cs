using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediathekArr.Tests.Fixtures;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediathekArr.Tests;

public abstract class AbstractIntegratedUnitTest<TWebApplicationFactory, TEntryPoint>(TWebApplicationFactory factory) : IClassFixture<TWebApplicationFactory> 
    where TEntryPoint : class
    where TWebApplicationFactory : AbstractTestWebApplicationFactory<TEntryPoint>
{
    #region Properties
    public virtual TWebApplicationFactory Factory { get; } = factory;
    public virtual IConfiguration Configuration => Factory.Services.GetRequiredService<IConfiguration>();

    public virtual IServiceScope Scope => Factory.Services.CreateScope();
    public virtual IServiceProvider ScopedServiceProvider => Scope.ServiceProvider;
    #endregion
}
