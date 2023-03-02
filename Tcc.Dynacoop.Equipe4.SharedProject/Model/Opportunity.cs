using Microsoft.Xrm.Sdk;
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
    }
}
