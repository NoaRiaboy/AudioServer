namespace AudioServer.TcpCommunicationAdapter.Zmq;

public interface IZmqCommunicationAdapter<out TOutput, in TInput>
{
    void Send(TInput input);
    TOutput Receive();
}