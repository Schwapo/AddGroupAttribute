# AddGroupAttribute

#### Adds attributes to members via Odin's attribute processors which can reduce the amount of code needed and cleans up the class. (Requires [Odin Inspector])

---

### Installation
Simply put the downloaded AddGroupAttribute folder in your project and start using the attribute as shown in the examples.

---

### Examples
Using Odin's default way:
```csharp
public class AddGroupExample : MonoBehaviour
{
    [BoxGroup("Box")]
    public string SomeField;
}
```
Using one of the AddGroupAttributes:
```csharp
using Sirenix.OdinInspector.AdditionalAttributes;

[AddBoxGroup("Box", To = new[] { "SomeField" })
public class AddGroupExample : MonoBehaviour
{
    public string SomeField;
}
```
Now that's hardly better, but it will start to show once it gets more complex.
It's also possible to add the attributes to members based on a condition instead of a name.
```csharp
using Sirenix.OdinInspector.AdditionalAttributes;

[AddBoxGroup("Box", If = "MemberIsMethod")]
public class AddGroupExample : MonoBehaviour
{
    // These won't be boxed
    public string SomeField1;
    public string SomeField2;
    public string SomeField3;

    // These will be boxed
    [Button]
    private void SomeMethod1() { }

    [Button]
    private void SomeMethod2() { }

    [Button]
    private void SomeMethod3() { }

    private bool MemberIsMethod(MemberInfo member) => member is MethodInfo;
}
```
These conditions use Odin's [Value Resolver] system which resolves a string into a desired value, in this case into a boolean.
Odin can pass values to these resolvers which can then be used inside the string by referring to them by their name.
They can also be passed to a method if the string refers to one.

These are the possible named values that you have access to:
Name                    | Description                                                                                    
----------------------- | -----------------------------------------------------------------
$attributes             | The attribute list of the currently processed member.
$memberInfo             | The MemberInfo instance of the currently processed member.
$memberNames            | The member names that where passed in by the **_To_** parameter.
$parentProperty         | The InspectorProperty instance of the member's parent.
$type                   | The type of the field.

---

Here's a more complex example which better shows how it can reduce visual complexity.

Using Odin's default way:
```csharp
public class AddGroupExample : MonoBehaviour
{
    [BoxGroup("Box")]
    [FoldoutGroup("Box/Foldout")]
    public string SomeField1;

    [BoxGroup("Box")]
    [FoldoutGroup("Box/Foldout")]
    public string SomeField2;

    [BoxGroup("Box")]
    [FoldoutGroup("Box/Foldout")]
    public string SomeField3;

    [BoxGroup("Box")]
    [ToggleGroup("Box/Toggle")]
    public bool Toggle;

    [Button]
    [BoxGroup("Box")]
    [ToggleGroup("Box/Toggle")]
    private void SomeMethod1() { }

    [Button]
    [BoxGroup("Box")]
    [ToggleGroup("Box/Toggle")]
    private void SomeMethod2() { }

    [Button]
    [BoxGroup("Box")]
    [ToggleGroup("Box/Toggle")]
    private void SomeMethod3() { }

    private bool MemberIsMethod(MemberInfo member) => member is MethodInfo;
}
```

Using some of the AddGroupAttributes:
```csharp
using Sirenix.OdinInspector.AdditionalAttributes;

// Add a box group around all members
[AddBoxGroup("Box", If = "@true")]

// Add a foldout group to all the specified fields and nest them inside the previous box group.
[AddFoldoutGroup("Box/Foldout", To = new[] { "SomeField1", "SomeField2", "SomeField3" })] 

// Add a toggle group to all members that are methods and nest them inside the previous groups.
[AddToggleGroup("Box/Toggle", If = "MemberIsMethod")]
public class AddGroupExample : MonoBehaviour
{
    public string SomeField1;
    public string SomeField2;
    public string SomeField3;
    public bool Toggle;

    [Button]
    private void SomeMethod1() { }

    [Button]
    private void SomeMethod2() { }

    [Button]
    private void SomeMethod3() { }

    private bool MemberIsMethod(MemberInfo member) => member is MethodInfo;
}
```

[Odin Inspector]: https://odininspector.com/
[Value Resolver]: https://odininspector.com/tutorials/value-and-action-resolvers/using-value-resolvers
