namespace AtomBot
{
   //Handles sending PING to Twitch server every five minutes to keep the connection alive
    public class Pinger
    {
        //vars
        public TwitchChatBot MyClient;
        public Thread PingSender;

        //constructor
        public Pinger(TwitchChatBot myClient)
        {
            MyClient = myClient;
            PingSender = new Thread(Run);
        }

        // Starts the thread
        public void Start()
        {
            PingSender.IsBackground = true;
            PingSender.Start();
        }

        // Send PING to irc server every 5 minutes
        public void Run()
        {
            while (true)
            {
                MyClient.SendPing();
                Thread.Sleep(300000); // 5 minutes
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}