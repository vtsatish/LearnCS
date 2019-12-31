using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearnAdvancedCS
{
    public class Video
    {
        public string Title { get; set; }
        public DateTime ReleaseDate;
        public Video(string input, DateTime dt)
        {
            Title = input;
            ReleaseDate = dt;

        }
        public void Encode()
        {
            this.Title = this.Title + " Encoded on " + this.ReleaseDate.ToString();
            OnVideoEncoded();
        }

        public delegate void NotifyEventHandler(object source, VideoEventArgs args);
        public event NotifyEventHandler VideoEncodedNotification;
        public event EventHandler<VideoEventArgs> VideoGenericNotification;

        protected virtual void OnVideoEncoded()
        {
            if(VideoEncodedNotification != null && VideoGenericNotification != null)
            {
                VideoEncodedNotification(this, new VideoEventArgs() { VideoType = this.Title });
                Thread.Sleep(3000);
                VideoGenericNotification(this, new VideoEventArgs());
                Thread.Sleep(3000);
            }

        }
    }

    public class MailService
    {
        public void OnVideoEncoded(object src, VideoEventArgs evg)
        {
            Debug.WriteLine("Mail Sent for\t"+ evg.VideoType + " \n\n\n");
            VideoEventArgs.count++;
        }

        public void OnGenericEncoded(object src, VideoEventArgs evg)
        {
            Debug.WriteLine("Mail Sent for\t" + evg.VideoType + " \n\n\n");
            VideoEventArgs.count++;

        }
    }

    public class MessageService
    {
        public void OnVideoEncoded(object src, VideoEventArgs evg)
        {
            Debug.WriteLine("Message Sent for\t" + evg.VideoType + " \n\n\n");
            VideoEventArgs.count++;
        }
        public void OnGenericEncoded(object src, VideoEventArgs evg)
        {
            Debug.WriteLine("Message Sent for\t" + evg.VideoType + " \n\n\n");
            VideoEventArgs.count++;

        }

    }

    public class VideoEventArgs : EventArgs
    {
        public string VideoType = "Deafult Type";
        public static int count;
    }

}
