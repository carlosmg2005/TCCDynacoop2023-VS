using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Dynacoop.Equipe4.Plugin.DynacoopISV;
using Tcc.Dynacoop.Equipe4.SharedProject.Controller;
using Tcc.Dynacoop.Equipe4.SharedProject.Model;

namespace Tcc.Dynacoop.Equipe4.Plugin.Plugins.EnvironmentOne
{
    public class ContactManager : PluginCore
    {
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
