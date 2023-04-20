namespace AudioServer.WaveNative.OpenAI;

public interface IOpenAlRecordToFile
{
    #region Modules

    int Execute(BinaryWriter sw, ushort secondsToRecord, ushort recordingDeviceId);

    #endregion
}