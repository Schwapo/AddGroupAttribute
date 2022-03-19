public class BoxGroupArgs : GroupArgs
{
    public string LabelText;

    public bool ShowLabel
    {
        get => _showLabel;
        set { _showLabel = value; HasDefinedShowLabel = true; }
    }

    public bool CenterLabel
    {
        get => _centerLabel;
        set { _centerLabel = value; HasDefinedCenterLabel = true; }
    }

    public bool HasDefinedShowLabel { get; private set; }
    public bool HasDefinedCenterLabel { get; private set; }

    private bool _showLabel;
    private bool _centerLabel;
}
