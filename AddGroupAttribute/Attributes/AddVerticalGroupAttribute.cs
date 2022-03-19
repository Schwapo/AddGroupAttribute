using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class AddVerticalGroupAttribute : AddGroupAttribute
    {
        public float PaddingTop;
        public float PaddingBottom;

        public AddVerticalGroupAttribute(string groupId) : base(groupId) { }

#if UNITY_EDITOR
        public override void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var args = GetGroupArgs<VerticalGroupArgs>(property);
            var attribute = new VerticalGroupAttribute();

            SetupDefaultArgs(attribute, args);

            attribute.PaddingTop = args.HasDefinedPaddingTop
                ? args.PaddingTop
                : PaddingTop;

            attribute.PaddingBottom = args.HasDefinedPaddingBottom
                ? args.PaddingBottom
                : PaddingBottom;

            attributes.Add(attribute);
        }
#endif
    }
}
