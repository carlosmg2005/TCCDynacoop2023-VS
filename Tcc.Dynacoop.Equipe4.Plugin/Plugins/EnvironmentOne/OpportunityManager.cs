using Microsoft.Xrm.Sdk;
using System;
using Tcc.Dynacoop.Equipe4.Plugin.DynacoopISV;
using Tcc.Dynacoop.Equipe4.Plugin.Plugins.Connection;
using Tcc.Dynacoop.Equipe4.SharedProject.Controller;

namespace Tcc.Dynacoop.Equipe4.Plugin.Plugins.EnvironmentOne
{
    public class OpportunityManager : PluginCore
    {
        EnvironmentConnectionTwo ambienteDois = new EnvironmentConnectionTwo();

        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            OpportunityController opportunityController = new OpportunityController(this.Service);
            if (PluginBase.Validate(this.Context, PluginBase.MessageName.Create, PluginBase.Stage.PreOperation, PluginBase.Mode.Synchronous))
            {
                Entity opportunity = (Entity)this.Context.InputParameters["Target"];
                if (opportunity.Contains("dnc_opportunitynumber") && opportunity["dnc_opportunitynumber"] != null)
                {
                    var idAlfa = opportunity.GetAttributeValue<string>("dnc_opportunitynumber");
                    var oppFound = opportunityController.VerificaDuplicidade(idAlfa);
                    if (oppFound != null)
                    {
                        throw new InvalidPluginExecutionException("DUPLICIDADE: " +
                                                                  "Não é possivel cadastrar um registro duplicado no sistema.");
                    }
                    else
                    {
                        opportunity["dnc_integracao"] = true;
                        ambienteDois.GetService().Create(opportunity);
                    }
                }
            }
        }
    }
}
