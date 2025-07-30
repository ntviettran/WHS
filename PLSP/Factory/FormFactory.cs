using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WHS.Core.Factory
{
    public static class FormFactory
    {
        public static T CreateForm<T>() where T : Form
        {
            return (T)Program.ServiceProvider!.GetRequiredService(typeof(T));
        }

        public static T CreateUserControl<T>() where T : UserControl
        {
            return (T)Program.ServiceProvider!.GetRequiredService(typeof(T));
        }
    }
}
