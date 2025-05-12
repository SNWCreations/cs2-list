using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;

namespace cs2_list;

public class ListPlugin : BasePlugin
{
    public override string ModuleName => "list";
    public override string ModuleVersion => "1.0.0";
    public override string ModuleAuthor => "SNWCreations";
    public override string ModuleDescription => "Add 'list' command to list players in the server.";

    [ConsoleCommand("css_list", "List the online players (excluding bots)")]
    [CommandHelper(whoCanExecute: CommandUsage.CLIENT_AND_SERVER)]
    public void OnCmdList(CCSPlayerController? caller, CommandInfo info)
    {
        var players = Utilities.GetPlayers().FindAll(it => it is { IsBot: false });
        var nameConcat = string.Join(", ", players.ConvertAll(it => it.PlayerName));
        var response = "There are " + players.Count + " players online: " + nameConcat;
        info.ReplyToCommand(response);
    }
}
