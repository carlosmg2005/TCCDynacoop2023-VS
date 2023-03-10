using Dynacoop.Logistics.SharedProject.Model;
using Microsoft.Xrm.Sdk;

namespace Dynacoop.Logistics.SharedProject.Controller
{
    public class OpportunityController
    {
        public IOrganizationService ServiceClient { get; set; }

        public Opportunity Opportunity { get; set; }

        public OpportunityController(IOrganizationService crmnServiceClient)
        {
            this.ServiceClient = crmnServiceClient;
            this.Opportunity = new Opportunity(ServiceClient);
        }

        public EntityCollection GetAllOpportunitys()
        {
            return Opportunity.GetAllOpportunitys();
        }

        public Entity CheckForDuplicity(string idAlfa)
        {
            return Opportunity.CheckForDuplicity(idAlfa);
        }
    }
}
