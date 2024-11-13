using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediathekArr.Controllers;
using MediathekArr.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;

namespace MediathekArr.Tests;

public class UnitTests(TestWebApplicationFactory factory) : AbstractIntegratedUnitTest(factory)
{
    [Fact]
    public async Task BasicTest()
    {
        var controller = Factory.Services.GetRequiredService<DownloadController>();
    }
}