namespace AtomBot
{
    public static class Program
    {
        //credentials (suppressed for privacy)
        private const string LoginName = "<LOGIN_NAME>";
        private static readonly string Token = Environment.GetEnvironmentVariable("Token") ?? throw new InvalidOperationException();  //Token should be stored in a safe place
        private static readonly List<string> ChannelsToJoin = new(new[] { "<CHANNEL_1>", "<CHANNEL_2>" });

        //main function
        static void Main()
        {
            //Testing writing to line
            Console.WriteLine("Hello World!");

            //New up a List of TwitchChatBot objects
            //add each channel to the list
            List<TwitchChatBot> chatBots = ChannelsToJoin.Select(t => new TwitchChatBot(LoginName, Token, t)).ToList();

            //for each chatBot...
            foreach (var chatBot in chatBots)
            {
                //Connect to Twitch IRC
                chatBot.Connect();

                //Start Pinger
                Pinger pinger = new Pinger(chatBot);
                pinger.Start();
            }

            //Read message until we quit
            while (true)
            {
                //for each chatBot...
                foreach (var chatBot in chatBots)
                {
                    //if we get disconnected, reconnect
                    if (chatBot.Client is { Connected: false })
                    {
                        chatBot.Connect();
                    }
                    //else we're connected
                    else
                    {
                        //get the message that just came through
                        string? msg = chatBot.ReadMessage();

                        //did we receive a message?
                        if (!string.IsNullOrEmpty(msg))
                        {
                            //write the raw message to the console
                            Console.WriteLine(msg);

                            //response string
                            string toRespond = "";

                            //If PING respond with PONG
                            if (msg.Length >= 4 && msg.Substring(0, 4) == "PING")
                                chatBot.SendPong();

                            //Trim the message to just the chat message piece
                            string msgTrimmed = TrimMessage(msg);

                            //Handling commands
                            if (msgTrimmed.Length >= 6 && msgTrimmed.Substring(0, 6) == "!8ball")
                                toRespond = chatBot.Command_MagicEightBall();
                            else if (msgTrimmed == "!age")
                                toRespond = chatBot.Command_Age();
                            else if (msgTrimmed == "!discord")
                                toRespond = chatBot.Command_Discord();

                            //Write response to console and send message to chat
                            Console.WriteLine(toRespond);

                            //Send the message to chat
                            chatBot.SendMessage(toRespond);
                        }

                    }
                }
            }

            // ReSharper disable once FunctionNeverReturns
        }

        #region Helper methods
        /// <summary>
        /// Trims an IRC message from chat to just the message that was sent in the chat
        /// </summary>
        /// <param name="message"></param>
        /// <returns>string</returns>
        private static string TrimMessage(string message)
        {
            int indexOfSecondColon = GetNthIndex(message, ':', 2);
            var result = message.Substring(indexOfSecondColon + 1);
            return result;
        }

        /// <summary>
        /// Gets the second colon, which is the separator before the chat message
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="n"></param>
        /// <returns>string</returns>
        private static int GetNthIndex(string s, char t, int n)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        #endregion


    }
}
