using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class AddResponsiveButtonGroupAttribute : AddGroupAttribute
    {
        public ButtonSizes DefaultButtonSize = ButtonSizes.Medium;
        public bool UniformLayout;

        public AddResponsiveButtonGroupAttribute(string groupId) : base(groupId) { }

#if UNITY_EDITOR
        public override void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var args = GetGroupArgs<ResponsiveButtonGroupArgs>(property);
            var attribute = new ResponsiveButtonGroupAttribute(GroupName);

            SetupDefaultArgs(attribute, args);

            attribute.DefaultButtonSize = args.HasDefinedDefaultButtonSize
                ? args.DefaultButtonSize
                : DefaultButtonSize;

            attribute.UniformLayout = args.HasDefinedUniformLayout
                ? args.UniformLayout
                : UniformLayout;

            attributes.Add(attribute);
        }
#endif
    }
}
