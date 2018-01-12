using System.Net.NetworkInformation;

namespace AgendaForro.Helpers
{
    public static class ConnectivityService
    {
        public static bool IsConnected()
        {
            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("google.com.br", 1000);
                if (reply != null)
                {
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (System.Exception e)
            {
                return false;
            }
            
            return false;
        }
    }
}
