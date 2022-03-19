namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class GroupArgs
    {
        public string GroupID;
        public string GroupName;
        public string VisibleIf;

        public float Order
        {
            get => _order;
            set { _order = value; HasDefinedOrder = true; }
        }

        public bool HideWhenChildrenAreInvisible
        {
            get => _hideWhenChildrenAreInvisible;
            set { _hideWhenChildrenAreInvisible = value; HasDefinedHideWhenChildrenAreInvisible = true; }
        }

        public bool AnimateVisibility
        {
            get => _animateVisibility;
            set { _animateVisibility = value; HasDefinedAnimateVisibility = true; }
        }

        public bool HasDefinedOrder { get; private set; }
        public bool HasDefinedAnimateVisibility { get; private set; }
        public bool HasDefinedHideWhenChildrenAreInvisible { get; private set; }

        private float _order;
        private bool _hideWhenChildrenAreInvisible;
        private bool _animateVisibility;
    }
}
