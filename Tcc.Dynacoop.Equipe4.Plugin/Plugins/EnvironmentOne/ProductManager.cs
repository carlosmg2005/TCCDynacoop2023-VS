using Microsoft.Xrm.Sdk;
using System;
using Tcc.Dynacoop.Equipe4.Plugin.DynacoopISV;
using Tcc.Dynacoop.Equipe4.Plugin.Plugins.Connection;

namespace Tcc.Dynacoop.Equipe4.Plugin.Plugins.EnvironmentOne
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
