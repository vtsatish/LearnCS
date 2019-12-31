using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAdvancedCS
{
    public class Callee
    {
        private string _image = "Default";
        public Callee(string initString)
        {
            _image = initString;
        }
        public void ReverseImage()
        {
            char[] arr = _image.ToCharArray();
            Array.Reverse(arr);
            _image = new string(arr);
        }
        public void DoubleImage()
        {
            _image = _image + _image;
        }
        public string GetImage()
        {
            return _image;
        }

        public void ReplaceImage(string rpString)
        {
            _image = rpString;
        }
    }



    public class Delegator
    {
        public delegate void ImageDelegator();
        public void Process(ImageDelegator idg)
        {
            idg();
        }

        public void ActionProcess(string rpString, Action<string> adg)
        {
            adg(rpString);
        }
    }
}
