using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class AddToggleGroupAttribute : AddGroupAttribute
    {
        public string ToggleGroupTitle;
        public bool CollapseOthersOnExpand;
        public string ToggleMemberName => GroupName;

        public AddToggleGroupAttribute(string groupId) : base(groupId) { }

#if UNITY_EDITOR
        public override void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var args = GetGroupArgs<ToggleGroupArgs>(property);
            var attribute = new ToggleGroupAttribute(GroupName);

            SetupDefaultArgs(attribute, args);

            attribute.CollapseOthersOnExpand = args.HasDefinedCollapseOthersOnExpand
                ? args.CollapseOthersOnExpand
                : CollapseOthersOnExpand;

            attribute.ToggleGroupTitle = args.HasDefinedToggleGroupTitle
                ? args.ToggleGroupTitle
                : ToggleGroupTitle;

            attributes.Add(attribute);
        }
#endif
    }
}
