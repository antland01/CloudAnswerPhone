using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SimpleAnswerPhone;
using System;

[assembly: FunctionsStartup(typeof(FuncStartup))]
namespace SimpleAnswerPhone
{
        public class FuncStartup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                if (builder == null)
                    throw new ArgumentNullException(nameof(builder));

                builder.Services.AddSingleton<ITwillioService>(new TwillioService());

            }
        }
    }



