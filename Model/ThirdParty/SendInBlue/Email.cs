namespace AZF2S_Backend.Model.ThirdParty.SendInBlue 
{
    public class Email 
    {
        public required string From { get; set; }
        public required string To { get; set; }
        public required string Subject { get; set; }
        public required string Html { get; set; }
    }
}
