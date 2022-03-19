using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class AddBoxGroupAttribute : AddGroupAttribute
    {
        public string LabelText;
        public bool ShowLabel = true;
        public bool CenterLabel;

        public AddBoxGroupAttribute(string groupId) : base(groupId) { }

#if UNITY_EDITOR
        public override void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var args = GetGroupArgs<BoxGroupArgs>(property);
            var attribute = new BoxGroupAttribute();

            SetupDefaultArgs(attribute, args);

            attribute.LabelText = args.LabelText ?? LabelText;

            attribute.ShowLabel = args.HasDefinedShowLabel
                ? args.ShowLabel
                : ShowLabel;

            attribute.CenterLabel = args.HasDefinedCenterLabel
                ? args.CenterLabel
                : CenterLabel;

            attributes.Add(attribute);
        }
#endif
    }
}
