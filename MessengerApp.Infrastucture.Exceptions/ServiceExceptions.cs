namespace MessengerApp.Infrastcuture.Exceptions
{
    using Exception = Exception;

    public class ServiceExceptions : Exception
    {

        public ServiceExceptions(string message) : base(message)
        {
        }

    }
}
