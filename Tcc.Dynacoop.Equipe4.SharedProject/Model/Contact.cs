using Dynacoop.Logistics.Plugin.Plugins.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;

namespace Dynacoop.Logistics.SharedProject.Model
{
    public class Contact
    {
        public IOrganizationService ServiceClient { get; set; }

        EnvironmentConnectionTwo ambienteDois = new EnvironmentConnectionTwo();

        public string LogicalName { get; set; }

        public Contact(IOrganizationService crmServiceClient)
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

        public void AddContact(Entity opportunity)
        {
            var contact = opportunity.GetAttributeValue<EntityReference>("parentcontactid").Id;
            var contactFound = ServiceClient.Retrieve(this.LogicalName, contact, new ColumnSet(true));
            var cpf = contactFound.GetAttributeValue<string>("dnc_cpf");

            QueryExpression queryExpression = new QueryExpression(this.LogicalName);
            queryExpression.ColumnSet = new ColumnSet(true);
            queryExpression.Criteria.AddCondition("dnc_cpf", ConditionOperator.Equal, cpf);

            var environmentTwoResponse = ambienteDois.GetService().RetrieveMultiple(queryExpression).Entities.FirstOrDefault();
            if (environmentTwoResponse == null)
            {
                ambienteDois.GetService().Create(contactFound);
            }
            else
            {
                contactFound["parentcontactid"] = environmentTwoResponse.Id;
            }
        }
    }
}
