// See https://aka.ms/new-console-template for more information
using KafkaNet.Model;
using KafkaNet.Protocol;
using KafkaNet;
using static System.Net.Mime.MediaTypeNames;
using Confluent.Kafka;
using System.Net;
using SampleCommon;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {
        //string payload = "Welcome to Kafka!";
        //string topic = "IDGTestTopic";
        //Message msg = new Message(payload);
        //Uri uri = new Uri("http://localhost:9092");
        //var options = new KafkaOptions(uri);
        //var router = new BrokerRouter(options);
        //var client = new Producer(router);
        //client.SendMessageAsync(topic, new List<Message> { msg }).Wait();
        //Console.ReadLine();


        Console.WriteLine("Hello World Producer!");
        string topic = Common.Topics.FirstOrDefault().Name;
        while (true)
        {
            try
            {
                Console.WriteLine(":c=[num] to create message");
                var re = Console.ReadLine();

                if (!string.IsNullOrEmpty(re) && re.Contains("="))
                {
                    var lsCmd = re.Split('=');
                    string cmd1 = lsCmd[1];
                    string cmd0 = lsCmd[0];
                    if (cmd0 == "c")
                    {
                        int outc = 0;
                        if (int.TryParse(cmd1, out outc))
                        {
                            Console.WriteLine("Create Mesaage:" + cmd1);
                            if (lsCmd.Length > 2 && lsCmd[2] == "a")
                            {
                                int argCount = outc / 2;
                                Create(argCount, topic, firstProducer);
                                Create(argCount, topic, secProducer);
                            }
                            else
                            {
                                await Create(outc, topic, firstProducer);
                            }

                        }
                        else
                        {
                            Console.WriteLine("wrong commnd");
                        }
                    }
                    else if (cmd0 == "t")
                    {
                        string cmdc = re.Split("=")[1];
                        topic = cmdc;
                        Console.WriteLine("topic now is " + topic);
                    }
                }

                else if (re == "exit")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("wrong commnd");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        firstProducer?.Dispose();
        secProducer?.Dispose();
    }

    private static IProducer<Null, string> firstProducer;

    private static IProducer<Null, string> secProducer;

    static async Task Create(int cCount, string topic, IProducer<Null, string> producer)
    {
        if (producer == null)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = Common.BootstrapServers,
                ClientId = Dns.GetHostName(),
                //BatchSize = 1000000,
                LingerMs = 5,
                //BatchNumMessages = 100,
                CompressionType = CompressionType.Gzip,

            };
            producer = new ProducerBuilder<Null, string>(config).Build();
        }

        if (cCount > 0)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();


            ParallelOptions options = new ParallelOptions();
            CancellationTokenSource cancellationSource = new CancellationTokenSource();
            options.MaxDegreeOfParallelism = 20; // 最大并行度，并行的任务有几个
            options.CancellationToken = cancellationSource.Token;

            stopwatch.Start();
            for (int i = 0; i < cCount; i++)
            {
                var msg = "message " + i;
                // Console.WriteLine($"Send message:   value {msg}");
                producer.ProduceAsync(topic, new Message<Null, string> { Value = msg });

                // Console.WriteLine($"Result: key {result.Key} value {result.Value} partition:{result.TopicPartition} offset: {result.Offset}");
                //Thread.Sleep(100);
            }

            //Parallel.For(0, cCount, options, (i) =>
            //{
            //    var msg = "message " + i;
            //    kaProducer.ProduceAsync(topic, new Message<Null, string> { Value = msg });

            //});

            stopwatch.Stop();
            //var rs = await producer.ProduceAsync(topic, new Message<Null, string> { Value = "finish" });
            //Console.WriteLine($"Result: key {rs.Key} value {rs.Value} partition:{rs.TopicPartition} offset: {rs.Offset}");
            Console.WriteLine($"总数:{cCount} Topic:{topic},用时:{stopwatch.Elapsed.TotalMilliseconds}ms");
            stopwatch.Reset();


            //stopwatch.Start();
            //producer.Flush();
            //stopwatch.Stop();
            //Console.WriteLine($"Flush用时:{stopwatch.Elapsed.TotalMilliseconds}ms");
            //stopwatch.Reset();

        }
    }
}
