using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAdvancedCS
{
    class Node
    {
        public int num;
        public Node next;
        public Node(int passvalue)
        {
            num = passvalue;
            next = null;
        }
    }
}
