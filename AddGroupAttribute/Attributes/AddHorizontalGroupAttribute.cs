using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class AddHorizontalGroupAttribute : AddGroupAttribute
    {
        public float Width;
        public float MarginLeft;
        public float MarginRight;
        public float PaddingLeft;
        public float PaddingRight;
        public float MinWidth;
        public float MaxWidth;
        public string Title;
        public float LabelWidth;

        public AddHorizontalGroupAttribute(string groupId) : base(groupId) { }

#if UNITY_EDITOR
        public override void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var args = GetGroupArgs<HorizontalGroupArgs>(property);
            var attribute = new HorizontalGroupAttribute();

            SetupDefaultArgs(attribute, args);

            attribute.Title = args.Title ?? Title;

            attribute.Width = args.HasDefinedWidth
                ? args.Width
                : Width;

            attribute.MarginLeft = args.HasDefinedMarginLeft
                ? args.MarginLeft
                : MarginLeft;

            attribute.MarginRight = args.HasDefinedMarginRight
                ? args.MarginRight
                : MarginRight;

            attribute.PaddingLeft = args.HasDefinedPaddingLeft
                ? args.PaddingLeft
                : PaddingLeft;

            attribute.PaddingRight = args.HasDefinedPaddingRight
                ? args.PaddingRight
                : PaddingRight;

            attribute.MinWidth = args.HasDefinedMinWidth
                ? args.MinWidth
                : MinWidth;

            attribute.MaxWidth = args.HasDefinedMaxWidth
                ? args.MaxWidth
                : MaxWidth;

            attribute.LabelWidth = args.HasDefinedLabelWidth
                ? args.LabelWidth
                : LabelWidth;

            attributes.Add(attribute);
        }
#endif
    }
}
