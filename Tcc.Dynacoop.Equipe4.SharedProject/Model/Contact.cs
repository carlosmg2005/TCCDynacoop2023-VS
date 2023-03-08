using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System.Linq;

namespace Dynacoop.Logistics.SharedProject.Model
{
    public class Contact
    {
        public IOrganizationService ServiceClient { get; set; }

        public string LogicalName { get; set; }

        public Contact(IOrganizationService crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "contact";

        }
        public Contact(CrmServiceClient crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "contact";

        }

        public Entity GetContactByCPF(string contactCPF)
        {
            QueryExpression queryExpression = new QueryExpression(LogicalName);
            queryExpression.ColumnSet.AddColumn("dnc_cpf");
            queryExpression.Criteria.AddCondition(this.LogicalName, "dnc_cpf", ConditionOperator.Equal, contactCPF);
            EntityCollection contacts = ServiceClient.RetrieveMultiple(queryExpression);

            return contacts.Entities.FirstOrDefault();
        }
    }
}
