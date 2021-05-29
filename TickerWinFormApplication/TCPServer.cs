using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace TickerWinFormApplication
{
    class TCPServer
    {
        private TcpListener server;

        public List<TcpClient> ConnectedClients = new List<TcpClient> { };
        public List<Thread> ClientThreads = new List<Thread> { };

        public TCPServer()
        {
            int port = 9999;
            IPAddress local = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(local, port);

            DataFeedFactory.OnNewTrade += broadcastTrade;
            DataFeedFactory.OnNewOrderBook += broadcastTrade;
        }


        public void Start()
        {
            try
            {
                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread recvThread = new Thread(RecvData);

                    ClientThreads.Add(recvThread);
                    ConnectedClients.Add(client);

                    recvThread.Start(client);
                }
            }
            catch (SocketException ex)
            {
            }
            finally
            {
                server.Stop();
            }
        }

        public void RecvData(object clientObj)
        {
            var client = clientObj as TcpClient;
            byte[] bytes = new byte[4096];
            while (true)
            {
                int i = 0;
                try
                {
                    NetworkStream stream = client.GetStream();
                    while (( i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        string data = Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine(data);

                        //string response = PendingResponse(data);
                        //sendData(client, response);

                        //Thread.Sleep(2000);
                        string response = FinishedResponse(data);
                        sendData(client, response);

                    }
                }
                catch (Exception ex)
                {
                    client.Close();
                    ConnectedClients.Remove(client);
                    break;
                }
                

            }
        }


        public string PendingResponse(string data)
        {
            string[] tokens = data.Split('|');
            string symbol = tokens[1];
            string orderType = tokens[2];
            string orderDirection = tokens[3];
            string cost = tokens[4];
            string qty = tokens[5];

            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            string msgString = "140222890190592 PV=1|1=331021|60={0}|37=877|48={1}|54={2}|39={3}|44=0.243|38=80000|31={4}|32={5}|448=9747|58=N/A|URef=18287101|";
            string responseString = string.Format(msgString, currentTime, symbol, orderDirection, "0", cost, qty);
            return responseString;
        }

        public string FinishedResponse(string data)
        {
            string[] tokens = data.Split('|');
            string symbol = tokens[1];
            string orderType = tokens[2];
            string orderDirection = tokens[3];
            string cost = tokens[4];
            string qty = tokens[5];

            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string msgString = "140222890190592 PV=1|1=331021|60={0}|37=877|48={1}|54={2}|39={3}|44=0.243|38=80000|31={4}|32={5}|448=9747|58=N/A|URef=18287101|";
            string responseString = string.Format(msgString, currentTime, symbol, orderDirection, "2", cost, qty);
            return responseString;
        }

        public void broadcastTrade(string msg)
        {
            Debug.WriteLine(msg);
            foreach (var client in ConnectedClients)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    sendData(client, msg);
                }
                catch (Exception ex)
                {
                    client.Close();
                    ConnectedClients.Remove(client);
                    break;
                }

            }
        }

        public void sendData(TcpClient client, string data)
        {
            NetworkStream stream = client.GetStream();
            byte[] array = Encoding.ASCII.GetBytes(data + "\r\n");
            stream.Write(array, 0, array.Length);
        }
    }
}
