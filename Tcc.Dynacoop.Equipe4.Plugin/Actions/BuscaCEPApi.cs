using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Dynacoop.Equipe4.Plugin.DynacoopISV;

namespace Tcc.Dynacoop.Equipe4.Plugin.Actions
{
    public class BuscaCEPApi : ActionCore
    {

        [Input("Cep")]

        public InArgument<string> Cep { get; set; }


        public override void ExecuteAction(CodeActivityContext context)
        {

        }
    }
}
