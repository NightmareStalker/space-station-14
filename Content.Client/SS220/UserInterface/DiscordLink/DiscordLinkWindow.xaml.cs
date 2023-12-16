// © SS220, An EULA/CLA with a hosting restriction, full text: https://raw.githubusercontent.com/SerbiaStrong-220/space-station-14/master/CLA.txt

using Content.Client.UserInterface.Controls;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.SS220.UserInterface.DiscordLink;

[GenerateTypedNameReferences]
public sealed partial class DiscordLinkWindow : FancyWindow
{
    public DiscordLinkWindow()
    {
        RobustXamlLoader.Load(this);
    }

    public void SetLink(string? link)
    {
        if (string.IsNullOrWhiteSpace(link))
        {
            LinkPanel.Visible = false;
            LinkAlreadyExistPanel.Visible = true;
        }
        else
        {
            LinkText.Text = $"/привязать14  token:{link}";
        }
    }
}