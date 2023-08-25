﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLib.Services
{
    internal class ObjectManagerWorker : BackgroundService
    {
        private readonly IObjectManager objectManager;

        public ObjectManagerWorker(IObjectManager objectManager)
        {
            this.objectManager = objectManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                await Task.Delay(700, stoppingToken);
            }
        }
    }
}
