namespace WinFormsApp1
{
    public interface IMessage{}

    public interface INetworkWriter<in T> where T : IMessage
    {
        public void Write<U>(U value) where U : IMessage;
    }

    public class PingMessage : IMessage
    {
        
    }

    public class PingWriter : INetworkWriter<PingMessage>
    {
        public void Write(PingMessage value)
        {
            throw new System.NotImplementedException();
        }
    }

    class Main1
    {
        public static void Main(string[] args)
        {
            INetworkWriter<IMessage> writer = new PingWriter();
        }
    }
}