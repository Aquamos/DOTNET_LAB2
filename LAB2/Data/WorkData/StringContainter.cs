
namespace Data
{
    public abstract class StringContainter
    {
        protected StringContainter(string value) { Value = value; }
        public string Value { get; private set; }
    }
}
