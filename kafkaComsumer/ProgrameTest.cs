using Confluent.Kafka;
using SampleCommon;



namespace kafkaComsumer
{
    internal class ProgrameTest
    {
        [STAThread]
        static void Main()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = Common.BootstrapServers,
                GroupId = "kl",// Common.ListConsumerGroup.FirstOrDefault(),
                //在auto.offset.reset=earliest情况下，新的消费者（消费者二）将会从头开始消费Topic下的消息，即从offset=0的位置开始消费。
                //在auto.offset.reset = latest情况下，新的消费者将会从其他消费者最后消费的offset处开始消费Topic下的消息，比如上一个消费者提交的offset是40，
                //则另一个消费组会开始从offset为40的位置开始消费。
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            var cancel = false;

            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                var topic = "test";
                //订阅多个主题
                List<string> lstopic = new List<string> { "test", "copy" };
                //订阅主题
                consumer.Subscribe(topic);

                //消费指定主题指定分区
                //var parti = new TopicPartition(topic, 0);

                //consumer.Assign(parti);

                ////seek从topic的分区的某个offset开始消费，需要先执行一次poll行为：
                //consumer.Consume(new TimeSpan(100));
                //consumer.Seek(new TopicPartitionOffset(parti, 0));

                while (!cancel)
                {
                    //拉流
                    ConsumeResult<Ignore, string> consumeResult = consumer.Consume(CancellationToken.None);
                    Console.WriteLine($"Consumer message: {consumeResult.Message.Value} topic: {consumeResult.Topic} Partition: {consumeResult.Partition} offset:{consumeResult.Offset}");
                }

                consumer.Close();
            }
        }
    }
}
