namespace AtomBot.DelayedCommands;

/// <summary>
/// Standard interface for a delayed command. These commands are triggered like normal commands, but will also have some
/// kind of response after some amount of time.
/// </summary>
public interface IDelayedCommand
{
    /// <summary>
    /// The response, if any, to the initial command. 
    /// </summary>
    /// <returns>A <see cref="string"/> response for the command</returns>
    public string CommandResponse();
    
    /// <summary>
    /// The time after which the command response should be posted.
    /// </summary>
    /// <returns>The <see cref="DateTime"/> after which the bot should post the response.</returns>
    public DateTime CommandResponsePostTime();
    
    /// <summary>
    /// The delayed message to post.
    /// </summary>
    /// <returns>A <see cref="string"/> message that happens after the delay.</returns>
    public string DelayedMessage();
    
    /// <summary>
    /// Returns true if the message triggers the command, false otherwise.
    /// </summary>
    /// <param name="message">The message that was posted in the chat.</param>
    /// <returns>A <see cref="bool"/> that represents if the command should be activated.</returns>
    public bool MatchesActivationCommand(string message);
    
    /// <summary>
    /// Returns true if the message is allowed to be added to the queue, false otherwise. Used as a control if only one
    /// is allowed to be added at once.
    /// </summary>
    /// <returns>a <see cref="bool"/> that represents if the command can be used.</returns>
    public bool CanQueue();
}