using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class AddTabGroupAttribute : AddGroupAttribute
    {
        public string TabName;
        public bool UseFixedHeight;
        public bool Paddingless;
        public bool HideTabGroupIfTabGroupOnlyHasOneTab;

        public AddTabGroupAttribute(string groupId, string tabName) : base(groupId)
        {
            TabName = tabName;
        }

#if UNITY_EDITOR
        public override void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var args = GetGroupArgs<TabGroupArgs>(property);
            var attribute = new TabGroupAttribute(GroupName, TabName);

            SetupDefaultArgs(attribute, args);

            attribute.HideTabGroupIfTabGroupOnlyHasOneTab = args.HasDefinedHideTabGroupIfTabGroupOnlyHasOneTab
                ? args.HideTabGroupIfTabGroupOnlyHasOneTab
                : HideTabGroupIfTabGroupOnlyHasOneTab;

            attribute.UseFixedHeight = args.HasDefinedUseFixedHeight
                ? args.HasDefinedUseFixedHeight
                : UseFixedHeight;

            attribute.Paddingless = args.HasDefinedPaddingless
                ? args.Paddingless
                : Paddingless;

            attributes.Add(attribute);
        }
#endif
    }
}
