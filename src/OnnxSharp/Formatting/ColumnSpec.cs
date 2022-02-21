using System;

namespace Onnx.Formatting
{
    public record ColumnSpec(string Name, Align Align);
    public record ColumnSpec<T>(string Name, Align Align, Func<T, string> Get) : ColumnSpec(Name, Align);
}

// https://stackoverflow.com/questions/64749385/predefined-type-system-runtime-compilerservices-isexternalinit-is-not-defined
namespace System.Runtime.CompilerServices
{
    public static class IsExternalInit { }
}

