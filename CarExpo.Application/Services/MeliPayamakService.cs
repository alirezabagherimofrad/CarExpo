using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace CarExpo.Application.Services
{
    public class MeliPayamakService(string username, string password)
    {
        private const string Endpoint = "https://rest.payamak-panel.com/api/SendSMS/";
        private const string SendOp = "SendSMS";

        private const string GetDeliveryOp = "GetDeliveries2";
        private const string GetMessagesOp = "GetMessages";
        private const string GetCreditOp = "GetCredit";
        private const string GetBasePriceOp = "GetBasePrice";
        private const string GetUserNumbersOp = "GetUserNumbers";
        private const string SendByBaseNumberOp = "BaseServiceNumber";

        private async Task<RestResponse> MakeRequestAsync(Dictionary<string, string> values, string op)
        {
            var content = new FormUrlEncodedContent(values);

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(Endpoint + op, content);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RestResponse>(responseString)!;
        }


        public async Task<RestResponse> SendAsync(string to, string from, string message, bool isflash)
        {
            var values = new Dictionary<string, string>
        {
            { "username", username },
            { "password", password },
            { "to", to },
            { "from", from },
            { "text", message },
            { "isFlash", isflash.ToString() }
        };

            return await MakeRequestAsync(values, SendOp);
        }

        public async Task<RestResponse> SendByBaseNumberAsync(string text, string to, int bodyId)
        {
            var values = new Dictionary<string, string>
        {
            { "username", username },
            { "password", password },
            { "text", text },
            { "to", to },
            { "bodyId", bodyId.ToString() }
        };

            return await MakeRequestAsync(values, SendByBaseNumberOp);
        }

        public async Task<RestResponse> GetDeliveryAsync(long recid)
        {
            var values = new Dictionary<string, string>
        {
            { "UserName", username },
            { "PassWord", password },
            { "recID", recid.ToString() }
        };

            return await MakeRequestAsync(values, GetDeliveryOp);
        }


        public async Task<RestResponse> GetMessagesAsync(int location, string from, string index, int count)
        {
            var values = new Dictionary<string, string>
        {
            { "UserName", username },
            { "PassWord", password },
            { "Location", location.ToString() },
            { "From", from },
            { "Index", index },
            { "Count", count.ToString() }
        };

            return await MakeRequestAsync(values, GetMessagesOp);
        }

        public async Task<RestResponse> GetCreditAsync()
        {
            var values = new Dictionary<string, string>
        {
            { "UserName", username },
            { "PassWord", password }
        };

            return await MakeRequestAsync(values, GetCreditOp);
        }

        public async Task<RestResponse> GetBasePriceAsync()
        {
            var values = new Dictionary<string, string>
        {
            { "UserName", username },
            { "PassWord", password }
        };

            return await MakeRequestAsync(values, GetBasePriceOp);
        }

        public async Task<RestResponse> GetUserNumbersAsync()
        {
            var values = new Dictionary<string, string>
        {
            { "UserName", username },
            { "PassWord", password }
        };

            return await MakeRequestAsync(values, GetUserNumbersOp);
        }
    }
    //response class
    public class RestResponse
    {
        public string Value { get; set; }
        public int RetStatus { get; set; }
        public string StrRetStatus { get; set; }
    }
}
