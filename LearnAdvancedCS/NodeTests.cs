using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearnAdvancedCS
{
    public class NodeTests
    {
        [Fact]
        public void reverseList()
        {
            Node headOfList = createList();
            Xunit.Assert.Equal(0, headOfList.num);
            Node current = headOfList;
            while (current.next != null)
            {
                current = current.next;
            }
            Xunit.Assert.Equal(5, current.num);

        }

        internal Node createList()
        {
            Node Head = new Node(0);
            Node current = Head;
            for (int i = 1; i <= 5; i++)
            {
                current.next = new Node(i);
                current = current.next;
            }
            return Head;
        }

    }
}
