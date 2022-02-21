using System;

namespace Onnx
{
    public static class Ops
    {
        public static class Reshape
        {
            public const int InputDataIndex = 0;
            public const int InputShapeIndex = 1;

            // Reshape op supports only one dimension in shape to be dynamic,
            // which is defined as -1.
            public const int DynamicReshapeValue = -1;

            public static readonly OpSpec Spec = new OpSpec(nameof(Reshape), 2, 1);
        }

        public readonly struct OpSpec
        {
            public OpSpec(string opType, int inputs, int outputs)
            {
                OpType = opType ?? throw new ArgumentNullException(nameof(opType));
                Inputs = inputs;
                Outputs = outputs;
            }

            public string OpType { get; }
            public int Inputs { get; }
            public int Outputs { get; }
        }
    }
}
