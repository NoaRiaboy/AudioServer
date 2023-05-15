namespace AudioServer.Repository;

public interface IAudioRepository
{
    void Record(string path, ushort secondToRecord);
}