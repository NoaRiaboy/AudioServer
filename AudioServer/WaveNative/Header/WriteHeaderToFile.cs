using AudioServer.WaveNative.Utilities;

namespace AudioServer.WaveNative.Header;

  public class WriteHeaderToFile : IWriteHeaderToFile
    {
        #region Modules

        public void WriteHeader(BinaryWriter sw)
        {
            sw.Write(RecordToWaveFileUtilities.RiffChunk);
            sw.Write(RecordToWaveFileUtilities.TO_FILL_LATER);
            sw.Write(RecordToWaveFileUtilities.WaveChunk);

            sw.Write(RecordToWaveFileUtilities.FmtChunk);
            sw.Write(RecordToWaveFileUtilities.CHUNK_SIZE_IN_BYTES);
            sw.Write(RecordToWaveFileUtilities.W_FORMAT_TAG_PCM);
            sw.Write(RecordToWaveFileUtilities.W_NUM_CHANNELS);
            sw.Write(RecordToWaveFileUtilities.DW_SAMPLING_RATE);
            const int dwAvgBytesPerSec = RecordToWaveFileUtilities.DW_SAMPLING_RATE *
                                         RecordToWaveFileUtilities.W_NUM_CHANNELS *
                                         (RecordToWaveFileUtilities.W_BITS_PER_SAMPLE /
                                          RecordToWaveFileUtilities.BITS_IN_BYTE);
            sw.Write(dwAvgBytesPerSec);
            const ushort wBlockAlign = RecordToWaveFileUtilities.W_NUM_CHANNELS *
                                       (RecordToWaveFileUtilities.W_BITS_PER_SAMPLE /
                                        RecordToWaveFileUtilities.BITS_IN_BYTE);
            sw.Write(wBlockAlign);
            sw.Write(RecordToWaveFileUtilities.W_BITS_PER_SAMPLE);

            sw.Write(RecordToWaveFileUtilities.DataChunk);
            sw.Write(RecordToWaveFileUtilities.TO_FILL_LATER);
        }

        public void RewriteHeader(BinaryWriter sw, int samplesWrote)
        {
            sw.Seek(RecordToWaveFileUtilities.CHUNK_ID_INDEX, SeekOrigin.Begin);
            sw.Write(RecordToWaveFileUtilities.HEADER_SIZE_FROM_RIFF + samplesWrote *
                (RecordToWaveFileUtilities.W_BITS_PER_SAMPLE / RecordToWaveFileUtilities.BITS_IN_BYTE) *
                RecordToWaveFileUtilities.W_NUM_CHANNELS);
            sw.Seek(RecordToWaveFileUtilities.SUB_CHUNK2_SIZE_INDEX, SeekOrigin.Begin);
            sw.Write(samplesWrote * (RecordToWaveFileUtilities.W_BITS_PER_SAMPLE /
                                     RecordToWaveFileUtilities.BITS_IN_BYTE)
                                  * RecordToWaveFileUtilities.W_NUM_CHANNELS);
        }

        #endregion
    }