using System.Net.Sockets;

namespace AtomBot
{
    public class TwitchChatBot
    {
        //Props
        public TcpClient? Client;
        public StreamReader? Reader;
        public StreamWriter? Writer;
        private string LoginName { get; set; }
        private string Token { get; set; }
        private string ChannelToJoin { get; set; }

        //constructor
        public TwitchChatBot(string l, string t, string c)
        {
            LoginName = l;
            Token = t;
            ChannelToJoin = c;
        }

        #region IRC
        /// <summary>
        /// Makes an IRC connection to Twitch
        /// </summary>
        /// <returns>void</returns>
        public void Connect()
        {
            Client = new TcpClient("irc.twitch.tv", 6667);
            Reader = new StreamReader(Client.GetStream());
            Writer = new StreamWriter(Client.GetStream());

            Writer.WriteLine("PASS " + Token);
            Writer.WriteLine("NICK " + LoginName);
            Writer.WriteLine("USER " + LoginName + " 8 * :" + LoginName);
            Writer.WriteLine("JOIN #" + ChannelToJoin);
            Writer.Flush();
        }

        /// <summary>
        /// Reads a message from the chat of the channel you're joined to
        /// </summary>
        /// <returns>string</returns>
        public string? ReadMessage()
        {
            string? chatMessage = Reader?.ReadLine();
            return chatMessage;
        }

        /// <summary>
        /// Sends a message in the chat of the channel you're joined to
        /// </summary>
        /// <param name="message"></param>
        /// <returns>void</returns>
        public void SendMessage(string message)
        {
            string toSend = (":" + LoginName + "!" + LoginName + "@" + LoginName +
            ".tmi.twitch.tv PRIVMSG #" + ChannelToJoin + " :" + message);
            Writer?.WriteLine(toSend);
            Writer?.Flush();
        }

        /// <summary>
        /// Sends a ping periodically to keep the connection alive
        /// </summary>
        /// <returns>void</returns>
        public void SendPing()
        {
            Console.WriteLine("Sending PING....");
            Writer?.WriteLine("PING :irc.twitch.tv");
            Writer?.Flush();
        }

        /// <summary>
        /// Sends a pong in response to a PING to keep the connection alive
        /// </summary>
        /// <returns>void</returns>
        public void SendPong()
        {
            Console.WriteLine("Sending PONG....");
            Writer?.WriteLine("PONG :irc.twitch.tv");
            Writer?.Flush();
        }

        #endregion

        #region Command Handlers
        /// <summary>
        /// Handles the !age command. Returns info on the streamer's age.
        /// </summary>
        /// <returns>string</returns>
        public string Command_Age()
        {
            string s = "Streamer is X years old";
            return s;
        }

        /// <summary>
        /// Handles the !8ball command. Returns a Magic Eight Ball phrase
        /// </summary>
        /// <returns>string</returns>
        public string Command_MagicEightBall()
        {
            string s;
            Random random = new Random();
            int randomNumber = random.Next(0, 8);
            switch (randomNumber)
            {
                case 0:
                    s = "Signs point to yes";
                    break;
                case 1:
                    s = "My intuition says no";
                    break;
                case 2:
                    s = "Definitely, probably";
                    break;
                case 3:
                    s = "Doubtful, but hold out hope";
                    break;
                case 4:
                    s = "Absolutely not";
                    break;
                case 5:
                    s = "It's unclear right now. Ask again later.";
                    break;
                case 6:
                    s = "Chances are good";
                    break;
                default:
                    s = "That's a silly question. Ask something else";
                    break;
            }

            return s;
        }

        /// <summary>
        /// Handles the !discord command. Responds with a link to the streamer's discord.
        /// </summary>
        /// <returns>string</returns>
        public string Command_Discord()
        {
            string s = "Come join the Discord! <link>";

            return s;
        }

        public string Command_Berry(string berryName)
        {
            string berryInfo = "No info for this berry";

            if (Constants.BerryLookup.ContainsKey(berryName))
            {
                berryInfo = Constants.BerryLookup[berryName];
            }
            
            return berryInfo;
        }
        #endregion
    }
}
