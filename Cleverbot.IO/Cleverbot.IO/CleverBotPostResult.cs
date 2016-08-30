using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
