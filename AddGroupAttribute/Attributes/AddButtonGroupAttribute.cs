using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class AddButtonGroupAttribute : AddGroupAttribute
    {
        public AddButtonGroupAttribute(string groupId) : base(groupId) { }

#if UNITY_EDITOR
        public override void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var args = GetGroupArgs<ButtonGroupArgs>(property);
            var attribute = new ButtonGroupAttribute(GroupName);

            SetupDefaultArgs(attribute, args);

            attributes.Add(attribute);
        }
#endif
    }
}
