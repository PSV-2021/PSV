using Compression.Service;
using Drugstore.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore.Compression.Controller
{
    class BackgroundCompressionController: ScheduledProcessor
    {
        FileCompressionService fileCompressionServie = new FileCompressionService();
        public BackgroundCompressionController(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {

        }

        protected override string Schedule => "*/1 * * * *"; // every 2 min 

        public override async Task ProcessInScope(IServiceProvider scopeServiceProvider)
        {

            fileCompressionServie.CompressOldFiles();

            await Task.Run(() => {
                return Task.CompletedTask;
            });
        }
    }
}
