using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLib.Services
{
    public sealed class PulseWorker : BackgroundService
    {
        private readonly IObjectManager objectManager;

        public PulseWorker(IObjectManager objectManager)
        {
            this.objectManager = objectManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (objectManager.ShouldPulse)
                    objectManager.Refresh();
                await Task.Delay(700, stoppingToken);
            }
        }
    }
}
