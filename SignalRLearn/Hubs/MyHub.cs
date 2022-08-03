using Microsoft.AspNetCore.SignalR;
using SignalRLearn.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLearn.Hubs
{
    public class MyHub : Hub<IMessageClient>
    {

        static List<string> clients = new List<string>();
        //Client' Hub'a mesaj gönderecek server bu mesajı alacak ve hub üzerinden diğer clientlara bu mesaj gönderilecek.
        //public async Task SendMessageAsync(string message)
        //{
        //    //diğer clientlara mesaj gönderme için hub içerisindeki propertyler kullanılacak.

        //    //Client'a subscribe olan bütün clientlara mesajı gönder.
        //    //Clientta receiveMessage diye bir fonksiyon bekletiyorum o fonksiyonu tetikle ve tetiklerkende clienttın gönderdiği mesajları diğer clientlara gönder

        //    //Ekstra işlemlerde olabilir.
        //    await Clients.All.SendAsync("receiveMessage",message);

        //    //.net core websocket ve hangi endpoint kullancapını bildirmem lazım.

        //    //Sisteme farklı bir client dahil olduğu zaman tetiklenen olay : OnConnectedAsync 'dir. Hub'a client bağlatı olduğu zaman

        //    //Client Hub'tan bağlantısını bozduğu zaman OnDisconnectedAsync event'i çalıştırılır.

        //}

        public override async Task OnConnectedAsync()
        {
            //Bir client bağlantı gerçekleştiği anda çalışır.Loglama için çok başarılı bir işlemlerdir.

            //Kullanıcı giriş yaptıpı zaman userJoined fonksiyonu tetiklenecek
            clients.Add(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);

            
            //static olarak tutmuş olduğum clients listesini bütün clientlara gönderdim.
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined",Context.ConnectionId);
       
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //Client'ın bağlantısı koptuğu anda gerçekleşecek olan kısım.
            //Kullanıcı ayrıldığı zaman userLeaved fonksiyonu tetiklenecek
            clients.Remove(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }

        //ConnectionId : Hub'a bağlantı gerçekleştiren clientlara sistem tarafından unique olarak verilen bir değerdir.Amaç clientları birbirinden ayırmaktır.
    }
}
