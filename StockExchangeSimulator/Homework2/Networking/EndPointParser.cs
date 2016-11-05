using System;
using System.Net;

namespace Networking
{
    /// <summary>
    /// This is a static class with some useful functions for working with IPEndPoints.
    /// </summary>
    public static class EndPointParser
    {
        /// <summary>
        /// This method creates an IPEndPoint from a host:port string
        /// </summary>
        /// <param name="hostnameAndPort">host:port string, like mymachine.usu.edu:12099 or 127.0.0.1:12099</param>
        /// <returns></returns>
        public static IPEndPoint Parse(string hostnameAndPort)
        {
            IPEndPoint result = null;
            if (!string.IsNullOrWhiteSpace(hostnameAndPort))
            {
                string[] tmp = hostnameAndPort.Split(':');
                if (tmp.Length == 2 && !string.IsNullOrWhiteSpace(tmp[0]) && !string.IsNullOrWhiteSpace(tmp[1]))
                    result = new IPEndPoint(ParseAddress(tmp[0]), ParsePort(tmp[1]));
            }
            return result;
        }

        /// <summary>
        /// This method returns the first IPv4 address for a hostname
        /// </summary>
        /// <param name="hostname">Hostname, like mymachine.usu.edu or 129.123.62.53</param>
        /// <returns></returns>
        public static IPAddress ParseAddress(string hostname)
        {
            IPAddress result = null;
            IPAddress[] addressList = Dns.GetHostAddresses(hostname);
            for (int i = 0; i < addressList.Length && result == null; i++)
                if (addressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    result = addressList[i];
            return result;
        }

        /// <summary>
        /// This method parse a string that represents a port number
        /// </summary>
        /// <param name="portStr">a string representation of a port number, like "12099"</param>
        /// <returns></returns>
        public static int ParsePort(string portStr)
        {
            int port = 0;
            if (!string.IsNullOrWhiteSpace(portStr))
                Int32.TryParse(portStr, out port);
            return port;
        }

        /// <summary>
        /// This method create an IPEndPoint using a host name and port
        /// </summary>
        /// <param name="host">Hostname, like mymachine.usu.edu or 129.123.62.53</param>
        /// <param name="port">A port number, like 12099</param>
        /// <returns></returns>
        public static IPEndPoint FormEndPoint(string host, int port)
        {
            IPEndPoint result = null;
            IPAddress address = ParseAddress(host);
            if (address != null)
                result = new IPEndPoint(address, port);
            return result;
        }
    }

}
