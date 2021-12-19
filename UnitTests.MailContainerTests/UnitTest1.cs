using MailContainerTest.Data;
using MailContainerTest.Services;
using MailContainerTest.Types;
using Moq;
using Xunit;

namespace UnitTests.MailContainerTests
{
    public class UnitTest1
    {
        public (MakeMailTransferRequest, MailTransferService) Setup()
        {
            return  (new MakeMailTransferRequest(), new MailTransferService());
        }

        [Fact]
        public void SmallParcel()
        {
            (MakeMailTransferRequest makeMailTransferRequest, MailTransferService mailTransferService) = Setup();
            makeMailTransferRequest.MailType = AllowedMailType.SmallParcel;
            makeMailTransferRequest.NumberOfMailItems = 1;
            makeMailTransferRequest.DestinationMailContainerNumber = "001";
            makeMailTransferRequest.SourceMailContainerNumber = "002";
            MakeMailTransferResult result = mailTransferService.MakeMailTransfer(makeMailTransferRequest);

            Assert.True(result.Success);
        }

        [Fact]
        public void LargeLetter()
        {
            (MakeMailTransferRequest makeMailTransferRequest, MailTransferService mailTransferService) = Setup();
            makeMailTransferRequest.MailType = AllowedMailType.LargeLetter;
            makeMailTransferRequest.NumberOfMailItems = 1;
            makeMailTransferRequest.DestinationMailContainerNumber = "001";
            makeMailTransferRequest.SourceMailContainerNumber = "002";
            MakeMailTransferResult result = mailTransferService.MakeMailTransfer(makeMailTransferRequest);

            Assert.True(result.Success);
        }

        [Fact]
        public void StandardLetter()
        {
            (MakeMailTransferRequest makeMailTransferRequest, MailTransferService mailTransferService) = Setup();
            makeMailTransferRequest.MailType = AllowedMailType.StandardLetter;
            makeMailTransferRequest.NumberOfMailItems = 1;
            makeMailTransferRequest.DestinationMailContainerNumber = "001";
            makeMailTransferRequest.SourceMailContainerNumber = "002";
            MakeMailTransferResult result = mailTransferService.MakeMailTransfer(makeMailTransferRequest);

            Assert.True(result.Success);
        }


    }
}