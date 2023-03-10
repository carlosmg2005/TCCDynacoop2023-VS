using Dynacoop.Logistics.Plugin.Plugins.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;

namespace Dynacoop.Logistics.SharedProject.Model
{
    public class Account
    {
        public IOrganizationService ServiceClient { get; set; }

        public string LogicalName { get; set; }

        EnvironmentConnectionTwo ambienteDois = new EnvironmentConnectionTwo();

        public Account(IOrganizationService crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "account";
        }

        public Entity GetAccountByCNPJ(string cnpj)
        {
            QueryExpression queryAccount = new QueryExpression(this.LogicalName);
            queryAccount.ColumnSet = new ColumnSet(true);
            queryAccount.Criteria.AddCondition(this.LogicalName, "dnc_cnpj", ConditionOperator.Equal, cnpj);
            EntityCollection accounts = ServiceClient.RetrieveMultiple(queryAccount);

            return accounts.Entities.FirstOrDefault();
        }

        public void AddAccount(Entity opportunity)
        {
            var account = opportunity.GetAttributeValue<EntityReference>("parentaccountid").Id;
            var accountFound = ServiceClient.Retrieve(this.LogicalName, account, new ColumnSet(true));
            var cnpj = accountFound.GetAttributeValue<string>("dnc_cnpj");

            QueryExpression queryExpression = new QueryExpression(this.LogicalName);
            queryExpression.ColumnSet = new ColumnSet(true);
            queryExpression.Criteria.AddCondition("dnc_cnpj", ConditionOperator.Equal, cnpj);

            var environmentTwoResponse = ambienteDois.GetService().RetrieveMultiple(queryExpression).Entities.FirstOrDefault();
            if (environmentTwoResponse == null)
            {
                ambienteDois.GetService().Create(accountFound);
            }
            else
            {
                accountFound["parentaccountid"] = environmentTwoResponse.Id;
            }
        }
    }
}
