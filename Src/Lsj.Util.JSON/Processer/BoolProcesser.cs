using Lsj.Util.JSON.Processer.Interfaces;

namespace Lsj.Util.JSON.Processer
{
    class BoolProcesser : IBoolProcesser
    {
        private readonly JSONParser _parser;
        private bool _result = false;

        public BoolProcesser(JSONParser jsonParser) => _parser = jsonParser;

        public object GetResult() => _result;

        public void SetValue(bool value)
        {
            _result = value;
        }

        public void SetValue(object? value)
        {
            if (value is bool val)
            {
                SetValue(val);
            }
            else
            {
                throw _parser.Error("Value must be bool.");
            }
        }
    }
}
