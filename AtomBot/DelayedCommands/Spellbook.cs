namespace AtomBot.DelayedCommands;

public class Spellbook : IDelayedCommand
{
    private bool _spellbookIsRecharging;
    public string CommandResponse()
    {
        _spellbookIsRecharging = true;
        return "The spellbook's magic is about to be used up. The recharge bar says 4 minutes.";
    }

    public DateTime CommandResponsePostTime()
    {
        return DateTime.Now.AddMinutes(4);
    }

    public string DelayedMessage()
    {
        _spellbookIsRecharging = false;
        return "The spellbook has recharged! Use command !spellbook to cast a spell!";
    }

    public bool MatchesActivationCommand(string message)
    {
        return message == "!spellbook" && !_spellbookIsRecharging;
    }

    public bool CanQueue()
    {
        return !_spellbookIsRecharging;
    }
}