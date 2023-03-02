using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System.Linq;
using System;

namespace Tcc.Dynacoop.Equipe4.SharedProject.Model
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

        private Entity RetrieveOneAccount(QueryExpression queryAccount)
        {
            EntityCollection contas = this.ServiceClient.RetrieveMultiple(queryAccount);
            if (contas.Entities != null || contas.Entities.Count > 0)
                return contas.Entities.FirstOrDefault();
            else
                Console.WriteLine("Nenhuma conta encontrada com esse nome");

            return null;
        }

        public Entity GetAccountByCNPJ(string cnpj)
        {
            QueryExpression queryAccount = new QueryExpression(this.LogicalName);
            queryAccount.ColumnSet = new ColumnSet(true);
            queryAccount.Criteria.AddCondition("dnc_cnpj", ConditionOperator.Equal, cnpj);

            return RetrieveOneAccount(queryAccount);
        }
    }
}
