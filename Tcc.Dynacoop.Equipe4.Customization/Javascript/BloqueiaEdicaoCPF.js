if (typeof (Dynacoop) == "undefined") { Dynacoop = {} }
if (typeof (Dynacoop.BlockCpf) == "undefined") { Dynacoop.BlockCpf = {} }

Dynacoop.BlockEditionCpf = {
    OnLoad: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var cpf = formContext.getAttribute("dnc_cpf").getValue();
        if (cpf != null) {
            formContext.getControl("dnc_cpf").setDisabled(true);
        } else {
            formContext.getControl("dnc_cpf").setDisabled(false);
        }
    }
}