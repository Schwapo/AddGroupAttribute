public class ToggleGroupArgs : GroupArgs
{
    public string ToggleGroupTitle
    {
        get => _toggleGroupTitle;
        set { _toggleGroupTitle = value; HasDefinedToggleGroupTitle = true; }
    }

    public bool CollapseOthersOnExpand
    {
        get => _collapseOthersOnExpand;
        set { _collapseOthersOnExpand = value; HasDefinedCollapseOthersOnExpand = true; }
    }

    public bool HasDefinedToggleGroupTitle { get; private set; }
    public bool HasDefinedCollapseOthersOnExpand { get; private set; }

    private string _toggleGroupTitle;
    private bool _collapseOthersOnExpand;
}
