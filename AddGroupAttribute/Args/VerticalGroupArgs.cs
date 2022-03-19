namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class VerticalGroupArgs : GroupArgs
    {
        public float PaddingTop
        {
            get => _paddingTop;
            set { _paddingTop = value; HasDefinedPaddingTop = true; }
        }

        public float PaddingBottom
        {
            get => _paddingBottom;
            set { _paddingBottom = value; HasDefinedPaddingBottom = true; }
        }

        public bool HasDefinedPaddingTop { get; private set; }
        public bool HasDefinedPaddingBottom { get; private set; }

        private float _paddingTop;
        private float _paddingBottom;
    }
}
