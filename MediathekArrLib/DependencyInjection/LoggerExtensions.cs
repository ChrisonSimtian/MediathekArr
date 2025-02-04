using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediathekArr.Extensions;
using Microsoft.Extensions.Logging;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Microsoft.Extensions.DependencyInjection;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Extensions to inject MediathekArr Logger
/// </summary>
public static class LoggerExtensions
{
    public static ILoggingBuilder AddMediathekArrLogger(this ILoggingBuilder builder)
    {
        builder.ClearProviders();
        builder.AddProvider(new MediathekArrLoggerProvider(new ColourConsoleLoggerConfiguration()));
        return builder;
    }
}