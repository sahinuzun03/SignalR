using Microsoft.AspNetCore.SignalR;
using SignalRLearn.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SignalRLearn.Hubs
{
    public class MessageHub : Hub
    {

        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        //{
        //    #region Caller
        //    Sadece server'a bildirim gönderen client ile iletişim kurar.Yani kendim gönderdiğim bilgiyi almak istiyorsam.
        //    await Clients.Caller.SendAsync("receivedMessage", message);
        //    #endregion

        //    #region All
        //    //Server'a bağlı olan tüm clientlarla iletişim kurar.
        //    await Clients.Caller.SendAsync("receivedMessage", message);
        //    #endregion

        //    #region Other
        //    //Sadece server'a bildiri gönderen kişi dışında server'a bağlı olan tüm clientlara mesaj gönderilir.
        //    await Clients.Others.SendAsync("receivedMessage", message);
        //    #endregion
        //    #region  Hub Clients Metotları
        //    #region AllExcept
        //    Belirtilen clientlar hariç server'a bağlı olan tüm clientlara bildiride bulunur.
        //    3.overload'u metotun bağlı olamyan clientların connectionId lerini beklemektedir.
        //    await Clients.AllExcept(connectionIds).SendAsync("receivedMessage", message);
        //    #endregion
        //    #region Client
        //    Server'a bağlı olan clientlar arasından sadece seçilen client'a bilgi gönderilmesidir.
        //    await Clients.Clients(connectionIds.First()).SendAsync("receivedMessage", message);
        //    #endregion
        //    #region Clients
        //    Belirtilen clientlara mesajlar gönderiliri.AllExcept sınıfının tam tersini ifade eder.
        //    await Clients.Clients(connectionIds).SendAsync("receivedMessage", message);
        //    #endregion
        //    #region Group
        //    Belirtilen grouptaki bütün clientlara bildiride bulunan fonksiyondur sadece bu işlevi gerçekleştirir.
        //    Önce gruplar oluşturulmalı ve ardından clientlar gruplara subscribe olmalıdır.

        //    #endregion
        //    #endregion
        //}
        public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds,IEnumerable<string> groups)
        {
            //#region Caller
            ////Sadece server'a bildirim gönderen client ile iletişim kurar.Yani kendim gönderdiğim bilgiyi almak istiyorsam.
            //await Clients.Caller.SendAsync("receivedMessage", message);
            //#endregion
            ////#region All
            //////Server'a bağlı olan tüm clientlarla iletişim kurar.
            ////await Clients.Caller.SendAsync("receivedMessage", message);
            ////#endregion
            ////#region Other
            //////Sadece server'a bildiri gönderen kişi dışında server'a bağlı olan tüm clientlara mesaj gönderilir.
            ////await Clients.Others.SendAsync("receivedMessage", message);
            ////#endregion
            //#region  Hub Clients Metotları
            //#region AllExcept
            ////Belirtilen clientlar hariç server'a bağlı olan tüm clientlara bildiride bulunur.
            ////3. overload'u metotun bağlı olamyan clientların connectionId lerini beklemektedir.
            //await Clients.AllExcept(connectionIds).SendAsync("receivedMessage", message);
            //#endregion
            //#region Client
            ////Server'a bağlı olan clientlar arasından sadece seçilen client'a bilgi gönderilmesidir.
            //await Clients.Clients(connectionIds.First()).SendAsync("receivedMessage", message);
            //#endregion
            //#region Clients
            ////Belirtilen clientlara mesajlar gönderiliri.AllExcept sınıfının tam tersini ifade eder.
            //await Clients.Clients(connectionIds).SendAsync("receivedMessage", message);
            //#endregion
            //#region Group
            ////Belirtilen grouptaki bütün clientlara bildiride bulunan fonksiyondur sadece bu işlevi gerçekleştirir.
            ////Önce gruplar oluşturulmalı ve ardından clientlar gruplara subscribe olmalıdır.
            //await Clients.Group(groupName).SendAsync("receivedMessage", message);
            //#endregion
            //#region GroupExcept
            ////Belirtilen gruptaki belirtilen clientlar dışındaki tüm clientlara mesaj iletmemizi sağlayan bir fonksiyondur.
            ////Group exceptte hem group ismini vereceğm hende göndermek istemediğim groupları parametre olarak vereceğim.
            //await Clients.GroupExcept(groupName, connectionIds).SendAsync("receivedMessage", message);
            //#endregion
            //#region Groups
            ////birden çok gruptaki clientlara bildiride bulunmamızı sağlayan fonksiyondur.
            //await Clients.Groups(groups).SendAsync("receivedMessage",message);
            //#endregion
            //#region OtherInGroups
            ////Bildiride bulunan client haricinde gruptaki tüm clientlara bildiride bulunan fonksiyondur.
            //await Clients.OthersInGroup(groupName).SendAsync("receivedMessage",message);//iletiyi gönderen client haricinde grup içindeki clientlara gidecek olan bildiri.
            //#endregion
            //#endregion
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        //Clientta radio butondan seçilen group'un bilgisi gelecek.
        public async Task addGroup(string connectionId, string groupName)
        {
            //İlgili grubu oluşturacak ve o gruba açık olan client'ın connectionId'sini ekleyecek.
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
