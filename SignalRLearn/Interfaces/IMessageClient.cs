using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRLearn.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> clients);
        Task UserJoined(string connectionId);
        Task UserLeaved(string connectionId);

        /// <summary>
        /// Burada Client tarafından çağıracağım metotları İnterface içerisinde tanımlıyorum bunun nedeni ise string olarak çalıştığım için hata alma lüksüm artacak ve bu  hatalar metinsel ifade olduğu için sürekli bir arama içerisinde kalmış olacağım.
        /// </summary>
    }
}
