using Confluent.Kafka;
using SampleCommon;
using SampleCommon.Model;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;


namespace PlayForm
{
    /// <summary>
    /// 简单性能测试
    /// </summary>
    public partial class Form1 : Form
    {
        IConsumer<Ignore, string> consumer;

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        public static extern void FreeConsole();//关闭控制台


        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        private string GroupID;

        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            if (Common.Topics.Count > 0)
            {
                txtTopic.Text = Common.Topics.FirstOrDefault().Name;
            }
            if (!string.IsNullOrEmpty(Common.BootstrapServers))
            {
                txtser.Text = Common.BootstrapServers;
            }
            if (Common.ListConsumerGroup.Count > 0)
            {
                GroupID = Common.ListConsumerGroup.FirstOrDefault();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            consumer?.Close();
            consumer?.Dispose();
        }

        private void btnpull_Click(object sender, EventArgs e)
        {
            int count = 0;
            var topic = txtTopic.Text;
            if (consumer == null) return;
            consumer.Subscribe(topic);
            while (true)
            {
                stopwatch.Start();
                ConsumeResult<Ignore, string> consumeResult = consumer.Consume(1000);

                if (consumeResult != null)
                {
                    count++;
                    Console.WriteLine($"Consumer message: {consumeResult.Message.Value} topic: {consumeResult.Topic} Partition: {consumeResult.Partition}");
                    if (consumeResult.Message.Value == "finish")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("无消息");
                    break;
                }

            }
            stopwatch.Stop();
            Console.WriteLine($"共:{count}条，用时:{stopwatch.ElapsedMilliseconds}");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = txtser.Text,
                GroupId = this.GroupID,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            List<string> lstopic = new List<string> { "test", "copy" };

            Console.WriteLine("Created Group:" + GroupID);
        }

        private void btnoffset_Click(object sender, EventArgs e)
        {
            ConsumByParam(txtTopic.Text, int.Parse(txtPartition.Text), int.Parse(txtoffset.Text));
        }

        private void btnParti_Click(object sender, EventArgs e)
        {
            ConsumByParam(txtTopic.Text, int.Parse(txtPartition.Text));
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            RunLinsener();
        }

        private async Task RunLinsener()
        {
            await Task<int>.Run(() =>
            {
                if (consumer == null)
                {
                    return 0;
                }
                int count = 0;
                Console.WriteLine("begin");
                var topic = txtTopic.Text;
                consumer.Subscribe(topic);
                while (true)
                {
                    ConsumeResult<Ignore, string> consumeResult = consumer.Consume(1000);
                    if (consumeResult != null)
                    {
                        count++;
                        Console.WriteLine($"Consumer message: {consumeResult.Message.Value} topic: {consumeResult.Topic} Partition: {consumeResult.Partition} offset:{consumeResult.Offset}");
                    }
                }

            });
        }


        /// <summary>
        /// 按指定参数拉取
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="partition"></param>
        /// <param name="offset">-1001即为不指定位置</param>
        private void ConsumByParam(string topic, int partition, int offset = -1001)
        {
            if (consumer == null) return;
            //按分区拉取，不指定offset就是从最后一个位置开始拉取
            if (offset != -1001)
            {
                var parti = new TopicPartition(topic, partition);

                if (consumer == null) return;

                consumer.Assign(new TopicPartitionOffset(parti, offset));
            }
            else
            {
                var parti = new TopicPartition(topic, partition);
                var ioffset = int.Parse(txtoffset.Text);//-1001; //最新
                if (consumer == null) return;

                consumer.Assign(parti);
            }

            double count = 0;
            while (true)
            {
                stopwatch.Start();
                ConsumeResult<Ignore, string> consumeResult = consumer.Consume(1000);
                if (consumeResult != null)
                {
                    count++;
                    //Console.WriteLine($"Consumer message: {consumeResult.Message.Value} topic: {consumeResult.Topic} Partition: {consumeResult.Partition}");
                }
                else
                {
                    Console.WriteLine("无消息");
                    break;
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"共:{count}条，用时:{stopwatch.Elapsed.TotalMilliseconds}");
            stopwatch.Reset();
        }
    }
}