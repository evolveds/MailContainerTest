using MailContainerTest.Data;
using MailContainerTest.Types;
using System.Configuration;

namespace MailContainerTest.Services
{
    public class MailTransferService : IMailTransferService
    {
        public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
        {
            string? dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];

            MailContainer mailContainer;
            IMailContainerDataStore mailContainerDataStore = new MailContainerDataStore();

            // Only need to change the type of container store if the DataStoreType contains Backup or some other non-default string.
            switch(dataStoreType)
            {
                case "Backup":
                    mailContainerDataStore = new BackupMailContainerDataStore();
                    break;
            }

            mailContainer = mailContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);

            MakeMailTransferResult result = TryTranserRequest(mailContainer, request, mailContainerDataStore);

            return result;
        }

        private MakeMailTransferResult TryTranserRequest(MailContainer mailContainer, MakeMailTransferRequest request, IMailContainerDataStore mailContainerDataStore)
        {
            MakeMailTransferResult result = IsRequestValid(mailContainer, request);
            if(result.Success)
            {
                mailContainer.Capacity -= request.NumberOfMailItems;
                mailContainerDataStore.UpdateMailContainer(mailContainer);
            }
            return result;
        }

        private MakeMailTransferResult IsRequestValid(MailContainer mailContainer, MakeMailTransferRequest request)
        {
            bool success = mailContainer != null;
            success &= mailContainer.AllowedMailType.HasFlag(request.MailType);
            success &= mailContainer.Capacity < request.NumberOfMailItems;
            success &= mailContainer.Status == MailContainerStatus.Operational;
            return new MakeMailTransferResult()
            {
                Success = success
            };
        }
    }
}
