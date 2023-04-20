namespace AudioServer.WaveNative.Header;

public interface IWriteHeaderToFile
{
    #region Modules

    void WriteHeader(BinaryWriter sw);

    void RewriteHeader(BinaryWriter sw, int samplesWrote);

    #endregion
}