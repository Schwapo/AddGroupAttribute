namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class ResponsiveButtonGroupArgs : GroupArgs
    {
        public ButtonSizes DefaultButtonSize
        {
            get => _defaultButtonSize;
            set { _defaultButtonSize = value; HasDefinedDefaultButtonSize = true; }
        }

        public bool UniformLayout
        {
            get => _uniformLayout;
            set { _uniformLayout = value; HasDefinedUniformLayout = true; }
        }

        public bool HasDefinedDefaultButtonSize { get; private set; }
        public bool HasDefinedUniformLayout { get; private set; }

        private ButtonSizes _defaultButtonSize;
        private bool _uniformLayout;
    }
}
