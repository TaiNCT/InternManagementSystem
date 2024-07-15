namespace IMSServices
{
    public interface IMailServices
    {
        Task SendAsync(string template, List<string> toAddress, List<string> ccAddresses, Dictionary<string, string> param);
    }
}
