namespace AudioServer.WaveNative;

public interface IRecordToFile
{
    #region Modules

    void Execute(ushort secondsToRecord, string pathToFile, ushort recordingDeviceId);

    #endregion
}