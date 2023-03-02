using Microsoft.Xrm.Sdk;
using System;
using System.Security.Cryptography;
using System.Text;
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
                    opportunity["dnc_opportunitynumber"] = GeradorNumeroRandomico();

                    this.Service.Update(opportunity);
                }
            }
        }

        public string GeradorNumeroRandomico()
        {
            Random rd = new Random();
            int num = rd.Next(99999);

            Guid newGuid = Guid.NewGuid();

            var sha256 = SHA256.Create();
            var secretBytes = Encoding.UTF8.GetBytes(newGuid.ToString());
            var secretHash = sha256.ComputeHash(secretBytes);

            foreach (var item in secretHash)
            {
                num += item;
            }

            var numTemp = string.Empty;
            if (num.ToString().Length > 5)
            {
                numTemp = num.ToString().Substring(5);
            }
            else
            {
                numTemp = num.ToString();
            }
            var numfinal = $"OPP-{numTemp}-A1A2";

            return numfinal;
        }
    }
}
