using Microsoft.Xrm.Sdk;
using System;
using Dynacoop.Logistics.Plugin.DynacoopISV;

namespace Dynacoop.Logistics.Plugin.Plugins.EnvironmentTwo
{
    public class ProductManager : PluginCore
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            if (PluginBase.Validate(this.Context, PluginBase.MessageName.Create, PluginBase.Stage.PreOperation, PluginBase.Mode.Synchronous))
            {
                Entity product = (Entity)this.Context.InputParameters["Target"];
                if (product.Contains("dnc_integracao"))
                {
                    if (product != null && product.GetAttributeValue<bool>("dnc_integracao") == false)
                    {
                        throw new InvalidPluginExecutionException("Não é possivel realizar o cadastro de Produto diretamente nesse ambiente. " +
                                                                  "O cadastro de produto é somente permitido no ambiente 1");
                    }
                }
            }
        }
    }
}
