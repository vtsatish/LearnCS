using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearnAdvancedCS
{
    class SyncClass
    {
        public int counter = 0;
        WebClient wclgoogle = new WebClient();
        WebClient wclapple = new WebClient();

        public SyncClass()
        {
            counter++;
        }
        public void RunParallelTests()
        {
                GetWebRequest();
                IncreaseCounter();
            while (counter <= 10)
            {
                counter++;
                Debug.WriteLine("main Counter value" + counter);

            }
            Debug.WriteLine("\n\nmain completed");
        }

        public async Task GetWebRequest()
        {
            Debug.WriteLine("\n\nThread1 starting");
            string str = await wclgoogle.DownloadStringTaskAsync("http://msdn.microsoft.com");
            Debug.WriteLine("\n\nThread1 ending.." + str.Substring(0,100));
        }

        public async Task IncreaseCounter()
        {
            Debug.WriteLine("\n\nThread2 starting");
            string str = await wclapple.DownloadStringTaskAsync("http://apple.com");
            Debug.WriteLine("\n\nThread2 ending" + str.Substring(0,100));
            Debug.WriteLine("\n\nThread2 sleeping");
            Thread.Sleep(1000);
        }
    }
}
