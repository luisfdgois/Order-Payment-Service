namespace Infrastructure.Shared.Settings
{
    public class RabbitMQProperties
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public string Port { get; set; }
        public string HostName { get; set; }

        public string Uri { get { return $"amqp://{UserName}:{Password}@{HostName}:{Port}/{VirtualHost}"; } }
    }
}
