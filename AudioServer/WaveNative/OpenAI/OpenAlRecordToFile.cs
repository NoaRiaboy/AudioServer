using AudioServer.WaveNative.Utilities;
using OpenTK.Audio;

namespace AudioServer.WaveNative.OpenAI;
public class OpenAlRecordToFile : IOpenAlRecordToFile
{
    #region Modules

    private static void PrintRecordersAndSelected(IList<string> recorders, ushort recordingDeviceId)
    {
        foreach (var t in recorders)
        {
            Console.WriteLine(t);
        }

        Console.WriteLine($"Recording from: {recorders[recordingDeviceId]}");
    }

    public int Execute(BinaryWriter sw, ushort secondsToRecord, ushort recordingDeviceId)
    {
        var bufferLength = RecordToWaveFileUtilities.DW_SAMPLING_RATE * secondsToRecord;
        var samplesWrote = 0;


        var recorders = AudioCapture.AvailableDevices;
        using AudioCapture audioCapture = new AudioCapture(recorders[recordingDeviceId],
            RecordToWaveFileUtilities.DW_SAMPLING_RATE,
            RecordToWaveFileUtilities.AL_FORMAT, bufferLength);

        PrintRecordersAndSelected(recorders, recordingDeviceId);

        var buffer = new short[bufferLength];

        audioCapture.Start();
        for (var i = 0; i < secondsToRecord; ++i)
        {
            Thread.Sleep(1000);

            var samplesAvailable = audioCapture.AvailableSamples;
            audioCapture.ReadSamples(buffer, samplesAvailable);
            for (var x = 0; x < samplesAvailable; ++x)
            {
                sw.Write(buffer[x]);
            }

            samplesWrote += samplesAvailable;

            Console.WriteLine($"Wrote {samplesAvailable}/{samplesWrote} samples...");
        }

        audioCapture.Stop();

        return samplesWrote;
    }

    #endregion
}