using Dynacoop.Logistics.Plugin.DynacoopISV;
using Microsoft.Xrm.Sdk;
using System;
using Dynacoop.Logistics.SharedProject.Controller;

namespace Dynacoop.Logistics.Plugin.Plugins.EnvironmentOne
{
    public class AccountManager : PluginCore
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            if (PluginBase.Validate(this.Context, PluginBase.MessageName.Create, PluginBase.Stage.PreValidation, PluginBase.Mode.Synchronous)
            || (PluginBase.Validate(this.Context, PluginBase.MessageName.Update, PluginBase.Stage.PreValidation, PluginBase.Mode.Synchronous)))
            {
                AccountController accountController = new AccountController(this.Service);
                Entity account = (Entity)this.Context.InputParameters["Target"];
                ValidateCnpj(accountController, account);
            }
        }

        protected void ValidateCnpj(AccountController accountController, Entity account)
        {
            var cnpj = account.GetAttributeValue<string>("dnc_cnpj");
            var accountFound = accountController.GetAccountByCnpj(cnpj);
            if (accountFound != null)
            {
                throw new InvalidPluginExecutionException("Cnpj já cadastrado no sistema, por favor, tente novamente!");
            }
        }
    }
}
