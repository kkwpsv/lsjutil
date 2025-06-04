using Lsj.Util.JSON.Processer.Interfaces;

namespace Lsj.Util.JSON.Processer
{
    class StringProcesser : IStringProcesser, INullableProcesser
    {
        private string? _result;

        public object? GetResult() => _result;

        public void SetNull() => _result = null;

        public void SetValue(string value) => _result = value;

        public void SetValue(object? value) => _result = value?.ToString();
    }
}
