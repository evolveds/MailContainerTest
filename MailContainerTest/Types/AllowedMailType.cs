namespace MailContainerTest.Types
{
    [Flags]
    public enum AllowedMailType
    {
        StandardLetter = 1 ,
        LargeLetter = 2,   
        SmallParcel = 4,

        Default = StandardLetter | SmallParcel | LargeLetter
    }
}