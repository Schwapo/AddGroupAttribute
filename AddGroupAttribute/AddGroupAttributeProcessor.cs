#if UNITY_EDITOR
using Sirenix.OdinInspector.AdditionalAttributes;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class AddGroupAttributeProcessor : OdinAttributeProcessor
{
    public override bool CanProcessChildMemberAttributes(InspectorProperty parentProperty, MemberInfo member)
    {
        return parentProperty.Attributes.HasAttribute<AddGroupAttribute>();
    }

    public override void ProcessChildMemberAttributes(InspectorProperty parentProperty, MemberInfo member, List<Attribute> attributes)
    {
        foreach (var group in parentProperty.GetAttributes<AddGroupAttribute>())
        {
            if (group.HasDefinedIf)
            {
                var ifResolver = ValueResolver.Get<bool>(parentProperty, group.If, new NamedValue[]
                {
                    new NamedValue("attributes", typeof(List<Attribute>), attributes),
                    new NamedValue("memberInfo", typeof(MemberInfo), member),
                    new NamedValue("memberNames", typeof(string[]), group.To ?? Array.Empty<string>()),
                    new NamedValue("parentProperty", typeof(InspectorProperty), parentProperty),
                    new NamedValue("type", typeof(Type), GetMemberType(member)),
                });

                if (ifResolver.HasError)
                {
                    Debug.LogException(new Exception(ifResolver.ErrorMessage));
                }
                else if (ifResolver.GetValue())
                {
                    group.CreateGroupAndAddToAttributes(parentProperty, attributes);
                }
            }

            if (group.HasDefinedTo && group.To.Contains(member.Name))
            {
                group.CreateGroupAndAddToAttributes(parentProperty, attributes);
            }

            if (group is AddToggleGroupAttribute toggleGroup && toggleGroup.ToggleMemberName == member.Name)
            {
                group.CreateGroupAndAddToAttributes(parentProperty, attributes);
            }
        }
    }

    private Type GetMemberType(MemberInfo memberInfo)
    {
        switch (memberInfo)
        {
            case FieldInfo info: return info.FieldType;
            case MethodInfo info: return info.ReturnType;
            case PropertyInfo info: return info.PropertyType;
            default: return default;
        }
    }
}
#endif