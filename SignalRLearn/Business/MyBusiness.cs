using Microsoft.AspNetCore.SignalR;
using SignalRLearn.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLearn.Business
{
    public class MyBusiness 
    {
        //Hub'ın nesnesi oluşturulabilir fakat ilgili clientlara ileti gönderemeyiz.

        //Bu tanımlama sayesinde websocket işlemlerini gerçekleştirebileceğim.
        readonly IHubContext<MyHub> _hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            //MyHub sınfından değil _hubContext üzerinden sınıflara erişiyorum.
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);


        }
    }
}
