public class FoldoutGroupArgs : GroupArgs
{
    private bool _expanded;

    public bool Expanded
    {
        get => _expanded;
        set { _expanded = value; HasDefinedExpanded = true; }
    }

    public bool HasDefinedExpanded { get; private set; }
}
