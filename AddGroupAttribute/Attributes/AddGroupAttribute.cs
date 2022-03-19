using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
#endif

namespace Sirenix.OdinInspector.AdditionalAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public abstract class AddGroupAttribute : PropertyGroupAttribute
    {
        public string[] To
        {
            get => _to;
            set { _to = value; HasDefinedTo = true; }
        }

        public string If
        {
            get => _if;
            set { _if = value; HasDefinedIf = true; }
        }

        public string Args
        {
            get => _args;
            set { _args = value; HasDefinedArgs = true; }
        }

        public bool HasDefinedTo { get; private set; }
        public bool HasDefinedIf { get; private set; }
        public bool HasDefinedArgs { get; private set; }

        private string[] _to;
        private string _if;
        private string _args;

        public AddGroupAttribute(string groupId) : base(groupId) { }

#if UNITY_EDITOR
        public abstract void CreateGroupAndAddToAttributes(InspectorProperty property, List<Attribute> attributes);

        protected T GetGroupArgs<T>(InspectorProperty property) where T : GroupArgs, new()
        {
            if (HasDefinedArgs)
            {
                var argsResolver = ValueResolver.Get<T>(property, Args);

                if (argsResolver.HasError)
                {
                    Debug.LogException(new Exception(argsResolver.ErrorMessage));
                    return new T();
                }

                return argsResolver.GetValue();
            }
            else
            {
                return new T();
            }
        }

        protected void SetupDefaultArgs(PropertyGroupAttribute attribute, GroupArgs args)
        {
            attribute.GroupID = args.GroupID ?? GroupID;
            attribute.GroupName = args.GroupName ?? GroupName;
            attribute.VisibleIf = args.VisibleIf ?? VisibleIf;

            attribute.Order = args.HasDefinedOrder
                ? args.Order
                : Order;

            attribute.AnimateVisibility = args.HasDefinedAnimateVisibility
                ? args.AnimateVisibility
                : AnimateVisibility;

            attribute.HideWhenChildrenAreInvisible = args.HasDefinedHideWhenChildrenAreInvisible
                ? args.HideWhenChildrenAreInvisible
                : HideWhenChildrenAreInvisible;
        }
#endif
    }
}
