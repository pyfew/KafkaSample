using SampleCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommon
{
    /// <summary>
    /// 管理topic与消费组
    /// </summary>
    public static class Common
    {
        static Common()
        {
            Topics = new List<Topic>
             {
                 new Topic{ 
                     Name="dog",
                     PartitionsCount=0
                 }
               
             };

            ListConsumerGroup = new List<string>
            {
                "foo"
            };

            BootstrapServers = "192.168.10.73:9092";
        }


        /// <summary>
        /// 可用topic
        /// </summary>
        public static List<Topic> Topics { get; }
        /// <summary>
        /// 卡夫卡服务地址
        /// </summary>
        public static string BootstrapServers { get; }
        /// <summary>
        /// 可用消费者组
        /// </summary>
        public static List<string> ListConsumerGroup { get; }
    }
}
