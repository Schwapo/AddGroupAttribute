using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    public class AddFoldoutGroupAttribute : AddGroupAttribute
    {
        public bool Expanded
        {
            get => _expanded;
            set { _expanded = value; HasDefinedExpanded = true; }
        }

        public bool HasDefinedExpanded { get; private set; }

        private bool _expanded;

        public AddFoldoutGroupAttribute(string groupId) : base(groupId) { }

#if UNITY_EDITOR
        public override void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var args = GetGroupArgs<FoldoutGroupArgs>(property);
            var attribute = new FoldoutGroupAttribute(GroupName);

            SetupDefaultArgs(attribute, args);

            if (args.HasDefinedExpanded || HasDefinedExpanded)
            {
                attribute.Expanded = args.HasDefinedExpanded
                    ? args.Expanded
                    : Expanded;
            }

            attributes.Add(attribute);
        }
#endif
    }
}
