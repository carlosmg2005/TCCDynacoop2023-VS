using Microsoft.Xrm.Sdk;

namespace Dynacoop.Logistics.Plugin.Plugins
{
    public static class PluginBase
    {
        #region [ Enums ]

        public enum MessageName
        {
            AddItem,
            AddListMembers,
            AddMember,
            AddMembers,
            AddPrivileges,
            AddProductToKit,
            AddRecurrence,
            AddToQueue,
            AddUserToRecordTeam,
            Assign,
            AssignUserRoles,
            Associate,
            BackgroundSend,
            Book,
            Cancel,
            CheckIncoming,
            CheckPromote,
            Clone,
            Close,
            CopyDynamicListToStatic,
            CopySystemForm,
            Create,
            CreateException,
            CreateInstance,
            Delete,
            DeleteOpenInstances,
            DeliverIncoming,
            DeliverPromote,
            DetachFromQueue,
            Disassociate,
            Execute,
            ExecuteById,
            Export,
            ExportAll,
            ExportCompressed,
            ExportCompressedAll,
            GenerateSocialProfile,
            GrantAccess,
            Handle,
            Import,
            ImportAll,
            ImportCompressedAll,
            ImportCompressedWithProgress,
            ImportWithProgress,
            LockInvoicePricing,
            LockSalesOrderPricing,
            Lose,
            Merge,
            ModifyAccess,
            Publish,
            PublishAll,
            QualifyLead,
            Recalculate,
            RemoveItem,
            RemoveMember,
            RemoveMembers,
            RemovePrivilege,
            RemoveProductFromKit,
            RemoveRelated,
            RemoveUserFromRecordTeam,
            RemoveUserRoles,
            ReplacePrivileges,
            Reschedule,
            Retrieve,
            RetrieveExchangeRate,
            RetrieveFilteredForms,
            RetrieveMultiple,
            RetrievePersonalWall,
            RetrievePrincipalAccess,
            RetrieveRecordWall,
            RetrieveSharedPrincipalsAndAccess,
            RetrieveUnpublished,
            RetrieveUnpublishedMultiple,
            RevokeAccess,
            Route,
            Send,
            SetState,
            SetStateDynamicEntity,
            TriggerServiceEndpointCheck,
            UnlockInvoicePricing,
            UnlockSalesOrderPricing,
            Update,
            ValidateRecurrenceRule,
            Win
        }

        public enum Stage
        {
            PreValidation = 10,
            PreOperation = 20,
            PostOperation = 40
        }

        public enum Mode
        {
            Asynchronous = 1,
            Synchronous = 0
        }

        #endregion

        #region [ Validate ]

        public static bool Validate(IPluginExecutionContext context, MessageName message)
        {
            return (MessageName)System.Enum.Parse(typeof(MessageName), context.MessageName) == message;
        }

        public static bool Validate(IPluginExecutionContext context, MessageName message, Stage stage)
        {
            return (MessageName)System.Enum.Parse(typeof(MessageName), context.MessageName) == message
                && (Stage)context.Stage == stage;
        }

        public static bool Validate(IPluginExecutionContext context, MessageName message, Stage stage, Mode mode)
        {
            return (MessageName)System.Enum.Parse(typeof(MessageName), context.MessageName) == message
                && (Stage)context.Stage == stage
                && (Mode)context.Mode == mode;
        }

        public static bool ValidateTarget(IPluginExecutionContext context, bool exists = false)
        {
            if (context == null) return false;
            if (exists) return context.InputParameters.Contains("Target");

            return context.InputParameters.Contains("Target") && (context.InputParameters["Target"] is Entity);
        }

        public static bool ValidatePreImage(IPluginExecutionContext context, string imageName)
        {
            if (string.IsNullOrEmpty(imageName) || context == null) return false;

            return context.PreEntityImages.Contains(imageName) && (context.PreEntityImages[imageName] is Entity);
        }

        public static bool ValidatePostImage(IPluginExecutionContext context, string imageName)
        {
            if (string.IsNullOrEmpty(imageName) || context == null) return false;

            return context.PostEntityImages.Contains(imageName) && (context.PostEntityImages[imageName] is Entity);
        }

        public static void ThrowException(string message)
        {
            string javascript = "<img src=\"/\" onerror=\"function alterInfo() { " +
                              "      if (!document.getElementById('ErrorTitle')) setTimeout('alterInfo()', 1000); " +
                              "      document.getElementById('ErrorTitle').innerText = 'Aviso';" +
                              "      document.getElementById('ErrorImage').src = '/_imgs/error/info_52.gif'; " +
                              "   } alterInfo();\" style=\"display: none\"/>" +
                              "</script>";

            throw new InvalidPluginExecutionException(string.Format("{0}<br/><span style='font-size:16px;'>{1}</span>", javascript, message));
        }

        #endregion
    }
}

