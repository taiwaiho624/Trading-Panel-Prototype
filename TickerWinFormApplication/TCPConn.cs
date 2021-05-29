using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

public class TCPConn
{
    private string m_connName = "";
    private const int BUFFER_SIZE = 4096;
    private const int PACKET_SIZE = 32;
    private Socket m_socket = null;
    private IPAddress m_ip = null;
    private IPEndPoint m_remotEP = null;
    public bool ConnStatus = false;
    private string m_serverIP = "";
    private int m_serverPort = 0;
    private bool m_isReconnecting = false;
    private DateTime m_lastRespTime = DateTime.Now;
    private const int MAX_TRIAL_COUNT = 30;

    public TCPConn(Socket s)
    {
        m_socket = s;
    }

    private byte[] KeepAlive(int onOff, int keepAliveTime, int keepAliveInterval)
    {
        byte[] buffer = new byte[12];
        BitConverter.GetBytes(onOff).CopyTo(buffer, 0);
        BitConverter.GetBytes(keepAliveTime).CopyTo(buffer, 4);
        BitConverter.GetBytes(keepAliveInterval).CopyTo(buffer, 8);
        return buffer;
    }


    public TCPConn(string serverIP, int serverPort, string connName)
    {
        m_serverIP = serverIP;
        m_serverPort = serverPort;
        m_connName = connName;
        m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        m_socket.IOControl(IOControlCode.KeepAliveValues, KeepAlive(1, 3000, 3000), null);

        m_ip = IPAddress.Parse(serverIP);
        m_remotEP = new IPEndPoint(m_ip, serverPort);

        m_socket.Blocking = true;

        IAsyncResult ar = m_socket.BeginConnect(m_remotEP, null, null);
        System.Threading.WaitHandle wh = ar.AsyncWaitHandle;

        if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2), false))
        {
            m_socket.Close();
            throw new TimeoutException();
        }
        m_socket.EndConnect(ar);
        ConnStatus = true;
    }

    ~TCPConn()
    {

    }

    public void Close()
    {
        if (m_socket != null)
            m_socket.Close();
    }

    public void Reconnect()
    {
        //MsgBoxWriter.Write("Network Disconnection Found ... Try to Reconnect after 5 secs", MsgBoxType.ERROR);
        // m_form.BackColor = Color.Pink;
        ConnStatus = false;
        System.Threading.Thread.Sleep(5000);
        for (int i = 0; i < MAX_TRIAL_COUNT; ++i)
        {
            // MsgBoxWriter.Write("Trying to Reconnect ... Trial Count: " + i.ToString() + "/" + MAX_TRIAL_COUNT, MsgBoxType.ERROR);

            try
            {
                m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                m_socket.IOControl(IOControlCode.KeepAliveValues, KeepAlive(1, 3000, 3000), null);

                m_ip = IPAddress.Parse(m_serverIP);
                m_remotEP = new IPEndPoint(m_ip, m_serverPort);

                IAsyncResult ar = m_socket.BeginConnect(m_remotEP, null, null);
                System.Threading.WaitHandle wh = ar.AsyncWaitHandle;

                if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3), false))
                {
                    m_socket.Close();
                    throw new TimeoutException();
                }
                m_socket.EndConnect(ar);
            }
            catch (Exception ex)
            {
                System.Threading.Thread.Sleep(3000);
                // MsgBoxWriter.Write("Failure in Reconnection", MsgBoxType.ERROR);
                goto Exit;
            }

            ConnStatus = true;
            m_isReconnecting = false;
            //UI2ServerMsgSender.SendSessionID();
            //m_form.BackColor = Color.White;
            // MsgBoxWriter.Write("Success in Reconnection", MsgBoxType.INFO);
            return;
        Exit:
            continue;
        }

        MessageBox.Show(m_connName + " Disconnection | Abort after Multiple Reconnections");
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

    public void SendMsg(string msg)
    {
        while (!ConnStatus)
            return;
        //System.Windows.Forms.Application.DoEvents();
        try
        {
            lock (this)
            {
                m_socket.Send(System.Text.Encoding.ASCII.GetBytes(msg + "\r\n"));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(m_connName + " Disconnection");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            /*
            if (!m_isReconnecting)
            {
                m_isReconnecting = true;
                Reconnect();
            }
            */
        }
    }



    public string GettingDataStream()
    {
        byte[] messageReceived = new byte[BUFFER_SIZE];
        string responseMsg = "";
        string lastMsg = "";

        int packetSize = 0;
        do
        {
            try
            {
                packetSize = m_socket.Receive(messageReceived, 0, BUFFER_SIZE, SocketFlags.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(m_connName + " Disconnection");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            lastMsg = System.Text.Encoding.UTF8.GetString(messageReceived, 0, packetSize);
            responseMsg += lastMsg;
        }
        while (packetSize == BUFFER_SIZE || !lastMsg.EndsWith("\r\n"));
        m_lastRespTime = DateTime.Now;
        return responseMsg;
    }
}
