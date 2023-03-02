using Microsoft.Xrm.Sdk;
using System;
using Tcc.Dynacoop.Equipe4.Plugin.DynacoopISV;

namespace Tcc.Dynacoop.Equipe4.Plugin.Plugins.EnvironmentOne
{
    public class OpportunityManager : PluginCore
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            if (PluginBase.Validate(this.Context, PluginBase.MessageName.Create, PluginBase.Stage.PostOperation, PluginBase.Mode.Asynchronous))
            {
                Entity opportunity = (Entity)this.Context.InputParameters["Target"];
                if (opportunity.Contains("dnc_opportunitynumber") && opportunity["dnc_opportunitynumber"] != null)
                {
                    Random rd = new Random();
                    int num = rd.Next(10000, 99999);

                    Entity opp = new Entity("opportunity", opportunity.Id);
                    opp["dnc_opportunitynumber"] = $"OPP-{num}-A1A2";

                    this.Service.Update(opp);
                }
            }
        }
    }
}
