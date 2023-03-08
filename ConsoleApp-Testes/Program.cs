using Dynacoop.Logistics.Plugin.Plugins.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Linq;

namespace ConsoleApp_Testes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "org246c61e6";
            string clientId = "4d61825c-c15b-4b65-b4bf-1a90e43b8d1e";
            string clientSecret = "8xh8Q~o6uvKuOLL3bJ025XWbX7mv-lHQC__Yxbdd";

            CrmServiceClient serviceClient = new CrmServiceClient($"AuthType=ClientSecret;Url=https://{url}.crm2.dynamics.com/;AppId={clientId};ClientSecret={clientSecret};");

            EnvironmentConnectionTwo conexao = new EnvironmentConnectionTwo();

            var id = new Guid("{a09c2889-a016-eb11-a813-002248029f77}");

            QueryExpression queryExpression = new QueryExpression("opportunity");
            queryExpression.ColumnSet = new ColumnSet(true);
            queryExpression.Criteria.AddCondition("opportunityid", ConditionOperator.Equal, id);
            var oppFound = serviceClient.RetrieveMultiple(queryExpression).Entities.FirstOrDefault();
            if (oppFound != null)
            {
                oppFound["name"] += " - Clonado";
                oppFound.Id = Guid.Empty;
                oppFound.Attributes.Remove("opportunityid");
                oppFound.Attributes.Remove("dnc_opportunitynumber");

                try
                {
                    serviceClient.Create(oppFound);
                }
                catch (Exception ex)
                {
                    var te = 1; 
                }
            }
        }
    }
}
