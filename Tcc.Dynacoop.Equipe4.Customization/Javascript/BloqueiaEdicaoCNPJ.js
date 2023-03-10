if (typeof (Dynacoop) == "undefined") { Dynacoop = {} }
if (typeof (Dynacoop.BlockCnpj) == "undefined") { Dynacoop.BlockCnpj = {} }

Dynacoop.BlockEditionCnpj = {
    OnLoad: function (executionContext) {
        var formContexrt = executionContext.getFormContext();
        var cnpj = formContexrt.getAttribute("dnc_cnpj").getValue();
        if (cnpj != null) {
            formContexrt.getControl("dnc_cnpj").setDisabled(true);
        } else {
            formContexrt.getControl("dnc_cnpj").setDisabled(false);
        }
    }
}