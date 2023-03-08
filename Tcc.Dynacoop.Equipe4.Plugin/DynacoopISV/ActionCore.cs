using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace Dynacoop.Logistics.Plugin.DynacoopISV
{
    public abstract class ActionCore : CodeActivity
    {
        public IWorkflowContext WorkflowContext { get; set; }
        public IOrganizationServiceFactory ServiceFactory { get; set; }
        public IOrganizationService Service { get; set; }   

        protected override void Execute(CodeActivityContext context)
        {
            this.WorkflowContext = context.GetExtension<IWorkflowContext>();
            this.ServiceFactory = context.GetExtension<IOrganizationServiceFactory>();
            Service = this.ServiceFactory.CreateOrganizationService(WorkflowContext.UserId);

            ExecuteAction(context);
        }

        public abstract void ExecuteAction(CodeActivityContext context);
    }
}
