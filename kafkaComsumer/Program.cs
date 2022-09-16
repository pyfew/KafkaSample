// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using SampleCommon;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        //string topic = "IDGTestTopic";
        //Uri uri = new Uri("http://localhost:9092");
        //var options = new KafkaOptions(uri);
        //var router = new BrokerRouter(options);
        //var consumer = new Consumer(new ConsumerOptions(topic, router));
        //foreach (var message in consumer.Consume())
        //{
        //    Console.WriteLine(Encoding.UTF8.GetString(message.Value));
        //}
        //Console.ReadLine();
       // Console.WriteLine("Hello World kafka consumer !");

        var config = new ConsumerConfig
        {
            BootstrapServers = Common.BootstrapServers,
            GroupId = Common.ListConsumerGroup.FirstOrDefault(),
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        var cancel = false;

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            var topic = "test";
            List<string> lstopic = new List<string> { "test","copy"};
            //订阅主题，可以用
            consumer.Subscribe(lstopic);


            while (!cancel)
            {
                ConsumeResult<Ignore,string> consumeResult = consumer.Consume(CancellationToken.None);
                consumeResult.Offset = 0;
                Console.WriteLine($"Consumer message: {consumeResult.Message.Value} topic: {consumeResult.Topic} Partition: {consumeResult.Partition}");
            }

            consumer.Close();
        }
    }
}