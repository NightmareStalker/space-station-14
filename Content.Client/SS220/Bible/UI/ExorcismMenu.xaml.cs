// © SS220, An EULA/CLA with a hosting restriction, full text: https://raw.githubusercontent.com/SerbiaStrong-220/space-station-14/master/CLA.txt
using Content.Client.UserInterface.Controls;
using Content.Shared.SS220.Bible;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Utility;

namespace Content.Client.SS220.Bible.UI;

[GenerateTypedNameReferences]
public sealed partial class ExorcismMenu : FancyWindow
{
    public int LengthMin { get; set; }
    public int LengthMax { get; set; }
    public event Action<string>? ReadClicked;

    public ExorcismMenu()
    {
        IoCManager.InjectDependencies(this);
        RobustXamlLoader.Load(this);

        var loc = IoCManager.Resolve<ILocalizationManager>();
        MessageInput.Placeholder = new Rope.Leaf(loc.GetString("bible-exorcism-menu-message-placeholder"));

        MessageInput.OnTextChanged += (args) =>
        {
            var len = GetLength();
            if (len < LengthMin)
            {
                ReadButton.Disabled = true;
                ReadButton.ToolTip = Loc.GetString("bible-exorcism-message-too-short");
            }
            else if (len > LengthMax)
            {
                ReadButton.Disabled = true;
                ReadButton.ToolTip = Loc.GetString("bible-exorcism-message-too-long");
            }
            else
            {
                ReadButton.Disabled = false;
                ReadButton.ToolTip = null;
            }
            RefreshLengthCounter(len);
        };

        RefreshLengthCounter();

        ReadButton.OnPressed += _ => ReadClicked?.Invoke(Rope.Collapse(MessageInput.TextRope));
        ReadButton.Disabled = true;
    }

    public override void Close()
    {
        base.Close();
    }

    public void RefreshLengthCounter()
    {
        RefreshLengthCounter(GetLength());
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }

    private void RefreshLengthCounter(int length)
    {
        LengthLabel.Text = $"{length}/{LengthMin}";
    }

    private int GetLength()
    {
        return ExorcismUtils.GetSanitazedMessageLength(Rope.Collapse(MessageInput.TextRope));
    }
}
