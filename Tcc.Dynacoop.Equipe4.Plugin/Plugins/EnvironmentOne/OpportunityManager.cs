using Dynacoop.Logistics.Plugin.DynacoopISV;
using Dynacoop.Logistics.Plugin.Plugins.Connection;
using Dynacoop.Logistics.SharedProject.Controller;
using Microsoft.Xrm.Sdk;
using System;

namespace Dynacoop.Logistics.Plugin.Plugins.EnvironmentOne
{
    public class OpportunityManager : PluginCore
    {
        EnvironmentConnectionTwo ambienteDois = new EnvironmentConnectionTwo();

        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            AccountController accountController = new AccountController(this.Service);
            ContactController contactController = new ContactController(this.Service);
            OpportunityController opportunityController = new OpportunityController(this.Service);

            if (PluginBase.Validate(this.Context, PluginBase.MessageName.Create, PluginBase.Stage.PreOperation, PluginBase.Mode.Synchronous))
            {
                Entity opportunity = (Entity)this.Context.InputParameters["Target"];
                accountController.AddAccount(opportunity);
                contactController.AddContact(opportunity);

                if (opportunity.Contains("dnc_opportunitynumber") && opportunity["dnc_opportunitynumber"] != null)
                {
                    var idAlfa = opportunity.GetAttributeValue<string>("dnc_opportunitynumber");
                    var oppFound = opportunityController.CheckForDuplicity(idAlfa);
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
