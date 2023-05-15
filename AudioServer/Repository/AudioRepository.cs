using AudioServer.Constants;
using AudioServer.TcpCommunicationAdapter.Zmq;
using AudioServer.WaveNative;
using AudioServer.WaveNative.Header;
using AudioServer.WaveNative.OpenAI;
using NetMQ.Sockets;

namespace AudioServer.Repository;

public class AudioRepository : IAudioRepository
{
    private readonly RecordToWaveFile _recordToFile;
    private readonly IZmqCommunicationAdapter<string, string> _communicationAdapter;
    
    public AudioRepository()
    {
        _recordToFile = new RecordToWaveFile(new WriteHeaderToFile(), new OpenAlRecordToFile());
        _communicationAdapter = new ZmqCommunicationAdapter(new RequestSocket(ZmqConstants.ConnectionString));

    }

    public void Record(string path,ushort secondToRecord)
    {
        try
        {
            _recordToFile.Execute(secondToRecord,path ,MkConstants.RecordingDeviceId);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}