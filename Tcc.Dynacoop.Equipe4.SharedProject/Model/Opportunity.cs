using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace Tcc.Dynacoop.Equipe4.SharedProject.Model
{
    public class Opportunity
    {
        public IOrganizationService ServiceClient { get; set; }

        public string LogicalName { get; set; }

        public Opportunity(IOrganizationService crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "opportunity";
        }

        public Opportunity(CrmServiceClient crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "opportunity";
        }

        public EntityCollection GetAllOpportunitys()
        {
            QueryExpression queryExpression = new QueryExpression(this.LogicalName);
            queryExpression.ColumnSet = new ColumnSet(true);

            EntityCollection listOpportunitys = this.ServiceClient.RetrieveMultiple(queryExpression);
            if (listOpportunitys.Entities != null && listOpportunitys.Entities.Count > 0)
            {
                return listOpportunitys;
            }

            return null;
        }
    }
}
