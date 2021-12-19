namespace MailContainerTest.Types
{
    [Flags]
    public enum MailType
    {
        StandardLetter = 1,
        LargeLetter = 2,
        SmallParcel = 4
    }
}
