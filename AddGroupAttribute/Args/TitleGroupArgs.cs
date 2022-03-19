using Sirenix.OdinInspector;

public class TitleGroupArgs : GroupArgs
{
    public string Subtitle;

    public TitleAlignments Alignment
    {
        get => _alignment;
        set { _alignment = value; HasDefinedAlignment = true; }
    }

    public bool HorizontalLine
    {
        get => _horizontalLine;
        set { _horizontalLine = value; HasDefinedHorizontalLine = true; }
    }

    public bool BoldTitle
    {
        get => _boldTitle;
        set { _boldTitle = value; HasDefinedBoldTitle = true; }
    }

    public bool Indent
    {
        get => _indent;
        set { _indent = value; HasDefinedIndent = true; }
    }

    public bool HasDefinedAlignment { get; private set; }
    public bool HasDefinedHorizontalLine { get; private set; }
    public bool HasDefinedBoldTitle { get; private set; }
    public bool HasDefinedIndent { get; private set; }

    private TitleAlignments _alignment;
    private bool _horizontalLine;
    private bool _boldTitle;
    private bool _indent;
}
