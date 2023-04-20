using AudioServer.WaveNative.Header;
using AudioServer.WaveNative.OpenAI;

namespace AudioServer.WaveNative;

public class RecordToWaveFile
{
    #region Constructor

    public RecordToWaveFile(IWriteHeaderToFile writeHeaderToFile, IOpenAlRecordToFile openAlRecordToFile)
    {
        _writeHeaderToFile = writeHeaderToFile;
        _openAlRecordToFile = openAlRecordToFile;
    }

    #endregion

    #region Modules

    public void Execute(ushort secondsToRecord, string pathToFile, ushort recordingDeviceId)
    {
        using var f = File.OpenWrite(pathToFile);
        using var sw = new BinaryWriter(f);
        _writeHeaderToFile.WriteHeader(sw);
        var samplesWrote =
            _openAlRecordToFile.Execute(sw, secondsToRecord, recordingDeviceId);
        _writeHeaderToFile.RewriteHeader(sw, samplesWrote);
        sw.Close();
        f.Close();
    }

    #endregion

    #region Feilds

    private readonly IWriteHeaderToFile _writeHeaderToFile;
    private readonly IOpenAlRecordToFile _openAlRecordToFile;

    #endregion
}