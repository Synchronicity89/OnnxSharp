using System.IO;

namespace Onnx.Formatting
{
    public static class TextWriterExtensions
    {
        public static void WriteAligned(this TextWriter writer, 
            string columnName, Align alignment, char pad, int width)
        {
            var padCount = width - columnName.Length;
            if (alignment == Align.Right)
            {
                writer.Write(pad, padCount);
            }
            writer.Write(columnName);
            if (alignment == Align.Left)
            {
                writer.Write(pad, padCount);
            }
        }

        public static void Write(this TextWriter writer, char value, int repeatCount)
        {
            for (int i = 0; i < repeatCount; i++)
            {
                writer.Write(value);
            }
        }
    }
}
