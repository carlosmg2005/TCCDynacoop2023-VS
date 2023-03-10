if (typeof (Dynacoop) == "undefined") { Dynacoop = {} }
if (typeof (Dynacoop.CloneOpportunity) == "undefined") { Dynacoop.CloneOpportunity = {} }

Dynacoop.CloneOpportunity = {
	Clone: function () {
		var Id = Xrm.Page.data.entity.getId();

		var execute_dnc_CloneOportunidade_Request = {
			// Parameters
			entity: { entityType: "opportunity", id: Id }, // entity
			Opportunityid: Id, // Edm.String

			getMetadata: function () {
				return {
					boundParameter: "entity",
					parameterTypes: {
						entity: { typeName: "mscrm.opportunity", structuralProperty: 5 },
						Opportunityid: { typeName: "Edm.String", structuralProperty: 1 }
					},
					operationType: 0, operationName: "dnc_CloneOportunidade"
				};
			}
		};

		Xrm.WebApi.execute(execute_dnc_CloneOportunidade_Request).then(
			function success(response) {
				debugger;
				if (response.ok)
				{
					Dynacoop.CloneOpportunity.DynamicsAlert("Oportunidade clonada com sucesso", "Sucesso");
					console.log("Success");
				}
			}
		).catch(function (error) {
			debugger;
			console.log(error.message);
		});
	},
	DynamicsAlert: function (alertText, alertTitle) {
		var alertStrings = {
			confirmButtonLabel: "OK",
			text: alertText,
			title: alertTitle
		};

		var alertOptions = {
			height: 120,
			width: 200
		};

		Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
	}
}