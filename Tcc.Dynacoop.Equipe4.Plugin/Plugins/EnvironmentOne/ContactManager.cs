using Microsoft.Xrm.Sdk;
using System;
using Dynacoop.Logistics.Plugin.DynacoopISV;
using Dynacoop.Logistics.SharedProject.Controller;
using Dynacoop.Logistics.Plugin.Plugins.Connection;

namespace Dynacoop.Logistics.Plugin.Plugins.EnvironmentOne
{
    public class ContactManager : PluginCore
    {
        EnvironmentConnectionTwo ambienteDois = new EnvironmentConnectionTwo();

        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            if (PluginBase.Validate(this.Context, PluginBase.MessageName.Create, PluginBase.Stage.PreValidation, PluginBase.Mode.Synchronous)
            || (PluginBase.Validate(this.Context, PluginBase.MessageName.Update, PluginBase.Stage.PreValidation, PluginBase.Mode.Synchronous)))
            {
                ContactController contactController = new ContactController(this.Service);
                Entity contact = (Entity)this.Context.InputParameters["Target"];
                ValidateCpf(contactController, contact);
            }
        }

        protected void ValidateCpf(ContactController contactController, Entity contact)
        {
            var cpf = contact.GetAttributeValue<string>("dnc_cpf");
            var accountFound = contactController.GetContactByCPF(cpf);
            if (accountFound != null)
            {
                throw new InvalidPluginExecutionException("Cpf já cadastrado no sistema, por favor, tente novamente!");
            }
        }
    }
}
