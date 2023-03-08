using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System.Linq;

namespace Dynacoop.Logistics.SharedProject.Model
{
    public class Account
    {
        public IOrganizationService ServiceClient { get; set; }

        public string LogicalName { get; set; }

        public Account(IOrganizationService crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "account";
        }

        public Account(CrmServiceClient crmServiceClient)
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
    }
}
