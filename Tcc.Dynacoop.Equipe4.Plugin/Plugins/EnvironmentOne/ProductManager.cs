using Dynacoop.Logistics.Plugin.DynacoopISV;
using Dynacoop.Logistics.Plugin.Plugins.Connection;
using Microsoft.Xrm.Sdk;
using System;

namespace Dynacoop.Logistics.Plugin.Plugins.EnvironmentOne
{
    public class ProductManager : PluginCore
    {
        EnvironmentConnectionTwo ambienteDois = new EnvironmentConnectionTwo();
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            ClonaProdutoCriadoParaAmbiente2();
        }

        protected void ClonaProdutoCriadoParaAmbiente2()
        {
            if (PluginBase.Validate(this.Context, PluginBase.MessageName.Create, PluginBase.Stage.PostOperation, PluginBase.Mode.Asynchronous))
            {
                try
                {
                    Entity product = (Entity)this.Context.InputParameters["Target"];
                    if (product != null)
                    {
                        product["dnc_integracao"] = true;
                        ambienteDois.GetService().Create(product);
                    }
                    else
                    {
                        return;
                    }
                }
                catch (InvalidPluginExecutionException er)
                {
                    throw new InvalidPluginExecutionException(er.Message);
                }
            }
        }
    }
}
