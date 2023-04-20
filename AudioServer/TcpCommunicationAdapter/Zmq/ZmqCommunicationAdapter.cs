using NetMQ;
using NetMQ.Sockets;

namespace AudioServer.TcpCommunicationAdapter.Zmq;

public class ZmqCommunicationAdapter : IZmqCommunicationAdapter<string, string>
{
    #region Ctor

    public ZmqCommunicationAdapter(RequestSocket requestSocket)
    {
        RequestSocket = requestSocket;
    }

    #endregion

    #region Methods

    public void Send(string input)
    {
        try
        {
            RequestSocket.SendFrame(input);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public string Receive()
    {
        string receivedString ;
        try
        {
            receivedString = RequestSocket.ReceiveFrameString();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return receivedString;
    }

    #endregion

    #region Properties

    public RequestSocket RequestSocket { get; set; }

    #endregion
}