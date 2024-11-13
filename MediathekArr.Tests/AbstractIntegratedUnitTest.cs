using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediathekArr.Tests.Fixtures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediathekArr.Tests;

public abstract class AbstractIntegratedUnitTest(TestWebApplicationFactory factory) : IClassFixture<TestWebApplicationFactory>
{
    #region Properties
    public virtual TestWebApplicationFactory Factory { get; } = factory;
    public virtual IConfiguration Configuration => Factory.Services.GetRequiredService<IConfiguration>();

    public virtual IServiceScope Scope => Factory.Services.CreateScope();
    public virtual IServiceProvider ScopedServiceProvider => Scope.ServiceProvider;
    #endregion
}
