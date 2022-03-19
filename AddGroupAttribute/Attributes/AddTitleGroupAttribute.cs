using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class AddTitleGroupAttribute : AddGroupAttribute
    {
        public string Subtitle;
        public TitleAlignments Alignment = TitleAlignments.Left;
        public bool HorizontalLine = true;
        public bool BoldTitle = true;
        public bool Indent;

        public AddTitleGroupAttribute(string groupId) : base(groupId) { }

#if UNITY_EDITOR
        public override void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var args = GetGroupArgs<TitleGroupArgs>(property);
            var attribute = new TitleGroupAttribute(GroupName);

            SetupDefaultArgs(attribute, args);

            attribute.Subtitle = args.Subtitle ?? Subtitle;

            attribute.Alignment = args.HasDefinedAlignment
                ? args.Alignment : Alignment;

            attribute.HorizontalLine = args.HasDefinedHorizontalLine
                ? args.HorizontalLine : HorizontalLine;

            attribute.BoldTitle = args.HasDefinedBoldTitle
                ? args.BoldTitle : BoldTitle;

            attribute.Indent = args.HasDefinedIndent
                ? args.Indent : Indent;

            attributes.Add(attribute);
        }
#endif
    }
}
