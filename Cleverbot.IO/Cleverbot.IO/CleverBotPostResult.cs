namespace Cleverbot
{
    public class CleverBotPostResult
    {
        public string Status { get; set; }
        public string Nick { get; set; }

        public CleverBotPostResult(string Success, string Nick) {
            this.Status = Success;
            this.Nick = Nick;
        }
    }
}
