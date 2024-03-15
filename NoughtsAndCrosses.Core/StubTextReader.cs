
namespace NoughtsAndCrosses.Core
{
    public class StubTextReader : TextReader
    {
        private string _buffer = "";
        private int _position = 0;

        public void WriteLine(string text)
        {
            _buffer += text + Environment.NewLine;
        }

        public override string ReadLine()
        {
            var length = _buffer.IndexOf(Environment.NewLine, _position) - _position;
            if (length < 0)
                return "";

            var result = _buffer.Substring(_position, length);
            _position += length + Environment.NewLine.Length;
            return result;
        }
    }
}
