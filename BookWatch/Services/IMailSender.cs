namespace BookWatch.Services
{
    public interface IMailSender
    {
        void SendMessage(string to, string subject, string body);
    }
}