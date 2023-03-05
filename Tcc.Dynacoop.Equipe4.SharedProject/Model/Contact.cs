using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System.Linq;

namespace Tcc.Dynacoop.Equipe4.SharedProject.Model
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
            QueryExpression busca = new QueryExpression(LogicalName);
            busca.ColumnSet.AddColumn("dnc_cpf");
            busca.Criteria.AddCondition("dnc_cpf", ConditionOperator.Equal, contactCPF);
            EntityCollection contact = ServiceClient.RetrieveMultiple(busca);

            return contact.Entities.FirstOrDefault();
        }
    }
}
