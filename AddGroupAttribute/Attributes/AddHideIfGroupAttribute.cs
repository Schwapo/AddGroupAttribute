using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class AddHideIfGroupAttribute : AddGroupAttribute
    {
        public object Value;

        public bool Animate
        {
            get => AnimateVisibility;
            set => AnimateVisibility = value;
        }

        public string ShowIfCondition
        {
            get => string.IsNullOrEmpty(VisibleIf) ? GroupName : VisibleIf;
            set => VisibleIf = value;
        }

        public AddHideIfGroupAttribute(string groupId) : base(groupId) { }

#if UNITY_EDITOR
        public override void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var args = GetGroupArgs<HideIfGroupArgs>(property);
            var value = args.HasDefinedValue ? args.Value : Value;
            var attribute = new HideIfGroupAttribute(GroupName, value);

            SetupDefaultArgs(attribute, args);

            attribute.Animate = args.HasDefinedAnimate
                ? args.Animate
                : Animate;

            attribute.Condition = args.Condition ?? ShowIfCondition;

            attributes.Add(attribute);
        }
#endif
    }
}
