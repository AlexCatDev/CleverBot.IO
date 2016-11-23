namespace Cleverbot
{
    public class CleverBotResponse
    {
        public string Status { get; set; }
        public string Response { get; set; }

        public CleverBotResponse(string Status, string Response) {
            this.Status = Status;
            this.Response = Response;
        }
    }

}
