using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
namespace Topshelf
{
    internal class configure
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<service>(service =>
                {
                    service.ConstructUsing(g => new service());
                    service.WhenStarted(g => g.Start());
                    service.WhenStopped(g => g.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("WinServiceWithTopshelf");
                configure.SetDisplayName("WinServiceWithTopshelf");
                configure.SetDescription("WinService With Topshelf");
            });
        }
    }
}
