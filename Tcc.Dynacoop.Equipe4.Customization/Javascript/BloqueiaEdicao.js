if (typeof (Dynacoop) == "undefined") { Dynacoop = {} }
if (typeof (Dynacoop.Endereco) == "undefined") { Dynacoop.Endereco = {} }

Dynacoop.Opportunity = {
    OnLoad: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var isIntegration = formContext.getAttribute("dnc_integracao").getValue();
        if (isIntegration == true) {
            formContext.getControl("name").setDisabled(true);
            formContext.getControl("parentcontactid").setDisabled(true);
            formContext.getControl("parentaccountid").setDisabled(true);
            formContext.getControl("purchasetimeframe").setDisabled(true);
            formContext.getControl("transactioncurrencyid").setDisabled(true);
            formContext.getControl("budgetamount").setDisabled(true);
            formContext.getControl("purchaseprocess").setDisabled(true);
            formContext.getControl("msdyn_forecastcategory").setDisabled(true);
            formContext.getControl("description").setDisabled(true);
            formContext.getControl("currentsituation").setDisabled(true);
            formContext.getControl("customerneed").setDisabled(true);
            formContext.getControl("proposedsolution").setDisabled(true);
            formContext.getControl("customerneed").setDisabled(true);
            formContext.getControl("customerneed").setDisabled(true);
            formContext.getControl("customerneed").setDisabled(true);
        }
        else {
            formContext.getControl("name").setDisabled(false);
            formContext.getControl("parentcontactid").setDisabled(false);
            formContext.getControl("parentaccountid").setDisabled(false);
            formContext.getControl("purchasetimeframe").setDisabled(false);
            formContext.getControl("transactioncurrencyid").setDisabled(false);
            formContext.getControl("budgetamount").setDisabled(false);
            formContext.getControl("purchaseprocess").setDisabled(false);
            formContext.getControl("msdyn_forecastcategory").setDisabled(false);
            formContext.getControl("description").setDisabled(false);
            formContext.getControl("currentsituation").setDisabled(false);
            formContext.getControl("customerneed").setDisabled(false);
            formContext.getControl("proposedsolution").setDisabled(false);
            formContext.getControl("customerneed").setDisabled(false);
            formContext.getControl("customerneed").setDisabled(false);
            formContext.getControl("customerneed").setDisabled(false);
        }
    }
}