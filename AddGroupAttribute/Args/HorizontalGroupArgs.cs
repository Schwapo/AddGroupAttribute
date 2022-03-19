namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class HorizontalGroupArgs : GroupArgs
    {
        public string Title;

        public float Width
        {
            get => _width;
            set { _width = value; HasDefinedWidth = true; }
        }

        public float MarginLeft
        {
            get => _marginLeft;
            set { _marginLeft = value; HasDefinedMarginLeft = true; }
        }

        public float MarginRight
        {
            get => _marginRight;
            set { _marginRight = value; HasDefinedMarginRight = true; }
        }

        public float PaddingLeft
        {
            get => _paddingLeft;
            set { _paddingLeft = value; HasDefinedPaddingLeft = true; }
        }

        public float PaddingRight
        {
            get => _paddingRight;
            set { _paddingRight = value; HasDefinedPaddingRight = true; }
        }

        public float MinWidth
        {
            get => _minWidth;
            set { _minWidth = value; HasDefinedMinWidth = true; }
        }

        public float MaxWidth
        {
            get => _maxWidth;
            set { _maxWidth = value; HasDefinedMaxWidth = true; }
        }

        public float LabelWidth
        {
            get => _labelWidth;
            set { _labelWidth = value; HasDefinedLabelWidth = true; }
        }


        public bool HasDefinedWidth { get; private set; }
        public bool HasDefinedMarginLeft { get; private set; }
        public bool HasDefinedMarginRight { get; private set; }
        public bool HasDefinedPaddingLeft { get; private set; }
        public bool HasDefinedPaddingRight { get; private set; }
        public bool HasDefinedMinWidth { get; private set; }
        public bool HasDefinedMaxWidth { get; private set; }
        public bool HasDefinedLabelWidth { get; private set; }

        private float _width;
        private float _marginLeft;
        private float _marginRight;
        private float _paddingLeft;
        private float _paddingRight;
        private float _minWidth;
        private float _maxWidth;
        private float _labelWidth;
    }
}
