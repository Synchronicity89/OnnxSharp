﻿using System;

namespace Onnx
{
    public static class Thrower
    {
        public static void EnsureLittleEndian()
        {
            if (!BitConverter.IsLittleEndian)
            {
                var message = "Only little-endian systems are supported. " +
                    "This is due to raw data in onnx files being stored in little-endian order and " +
                    "conversion to big-endian has not implemented.";
                throw new NotSupportedException(message); 
            }
        }
    }
}
