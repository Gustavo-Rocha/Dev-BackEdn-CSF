using RabbitMQ.Client;
using RestauranteService.Dtos;
using System.Text;
using System.Text.Json;

namespace RestauranteService.RabbitMqClient
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private IConfiguration _configuration;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMqClient(IConfiguration configuration)
        {
            _configuration= configuration;
            _connection = new ConnectionFactory() { HostName = _configuration["RabbitMqHost"], Port = int.Parse( _configuration["RabbitMqPort"]) }.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
        }
        public void PublicaRestaurante(RestauranteReadDto restauranteReadDto)
        {
            var msg = JsonSerializer.Serialize(restauranteReadDto);
            var body = Encoding.UTF8.GetBytes(msg);
            _channel.BasicPublish(exchange: "trigger",
                routingKey: "",
                basicProperties: null,
                body: body
                );

            

        }
    }
}
