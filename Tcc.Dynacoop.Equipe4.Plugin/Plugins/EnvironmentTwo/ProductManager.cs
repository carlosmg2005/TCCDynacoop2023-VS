using Microsoft.Xrm.Sdk;
using System;
using Tcc.Dynacoop.Equipe4.Plugin.DynacoopISV;

namespace Tcc.Dynacoop.Equipe4.Plugin.Plugins.EnvironmentTwo
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
                        throw new InvalidPluginExecutionException("Não é possivel realizar cadastro de Produto nesse ambiente!");
                    }
                }
            }
        }
    }
}
