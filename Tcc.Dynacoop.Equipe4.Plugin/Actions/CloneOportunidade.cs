using Dynacoop.Logistics.Plugin.DynacoopISV;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Linq;

namespace Tcc.Dynacoop.Equipe4.Plugin.Actions
{
    public class CloneOportunidade : ActionCore
    {
        [Input("OpportunityId")]
        public InArgument<string> OpportunityId { get; set; }

        public override void ExecuteAction(CodeActivityContext context)
        {
            CloneOpportunity(context);
        }

        protected void CloneOpportunity(CodeActivityContext context)
        {
            var id = new Guid(OpportunityId.Get(context));

            QueryExpression queryExpression = new QueryExpression("opportunity");
            queryExpression.ColumnSet = new ColumnSet(true);
            queryExpression.Criteria.AddCondition("opportunityid", ConditionOperator.Equal, id);
            var oppFound = this.Service.RetrieveMultiple(queryExpression).Entities.FirstOrDefault();
            if (oppFound != null)
            {
                oppFound["name"] += " - Clonado";
                oppFound.Id = Guid.Empty;
                oppFound.Attributes.Remove("opportunityid");
                oppFound.Attributes.Remove("dnc_opportunitynumber");

                try
                {
                    this.Service.Create(oppFound);
                }
                catch (InvalidPluginExecutionException ex)
                {
                    throw new InvalidPluginExecutionException(ex.Message);
                }
            }
        }
    }
}
