namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class TabGroupArgs : GroupArgs
    {
        public bool UseFixedHeight
        {
            get => _useFixedHeight;
            set { _useFixedHeight = value; HasDefinedUseFixedHeight = true; }
        }

        public bool Paddingless
        {
            get => _paddingless;
            set { _paddingless = value; HasDefinedPaddingless = true; }
        }

        public bool HideTabGroupIfTabGroupOnlyHasOneTab
        {
            get => _hideTabGroupIfTabGroupOnlyHasOneTab;
            set { _hideTabGroupIfTabGroupOnlyHasOneTab = value; HasDefinedHideTabGroupIfTabGroupOnlyHasOneTab = true; }
        }

        public bool HasDefinedUseFixedHeight { get; private set; }
        public bool HasDefinedPaddingless { get; private set; }
        public bool HasDefinedHideTabGroupIfTabGroupOnlyHasOneTab { get; private set; }

        private bool _useFixedHeight;
        private bool _paddingless;
        private bool _hideTabGroupIfTabGroupOnlyHasOneTab;
    }
}
