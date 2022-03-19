namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class HideIfGroupArgs : GroupArgs
    {
        public string Condition;

        public object Value
        {
            get => _value;
            set { _value = value; HasDefinedValue = true; }
        }

        public bool Animate
        {
            get => _animate;
            set { _animate = value; HasDefinedAnimate = true; }
        }

        public bool HasDefinedValue { get; private set; }
        public bool HasDefinedAnimate { get; private set; }

        private object _value;
        private bool _animate;
    }
}
