using OpenTK.Audio.OpenAL;

namespace AudioServer.WaveNative.Utilities;

public class RecordToWaveFileUtilities
{
    #region Utilities

    public const ushort W_NUM_CHANNELS = 1; // Mono16 has 1 channel
    public const int DW_SAMPLING_RATE = 44100; // Samples per second
    public const ushort W_BITS_PER_SAMPLE = 16; // Mono16 has 16 bits per sample

    public const ALFormat AL_FORMAT = ALFormat.Mono16;

    public static readonly char[] RiffChunk = { 'R', 'I', 'F', 'F' };
    public static readonly char[] WaveChunk = { 'W', 'A', 'V', 'E' };
    public static readonly char[] FmtChunk = { 'f', 'm', 't', ' ' };
    public static readonly char[] DataChunk = { 'd', 'a', 't', 'a' };
    public const int TO_FILL_LATER = 0;
    public const int CHUNK_SIZE_IN_BYTES = 16;
    public const ushort W_FORMAT_TAG_PCM = 1;
    public const int BITS_IN_BYTE = 8;
    public const int CHUNK_ID_INDEX = 4;
    public const int SUB_CHUNK2_SIZE_INDEX = 40;
    public const int HEADER_SIZE_FROM_RIFF = 36;

    #endregion
}