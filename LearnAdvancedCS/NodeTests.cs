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
        internal Node ReverseList(Node argNode)
        {
            Node headOfList = argNode;
            Node prevNode = null;
            Node tmpNode = null;
            Node current = headOfList;

            while (current.next != null)
            {
                tmpNode = current.next;
                current.next = prevNode;
                prevNode = current;
                current = tmpNode;
            }
            current.next = prevNode;
            headOfList = current;

            return headOfList;
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

        [Fact]
        public void TestNodeList()
        {
            Node headOfList = createList();
            Xunit.Assert.Equal(0, headOfList.num);

            headOfList = ReverseList(headOfList);

            Xunit.Assert.Equal(5, headOfList.num);
            Xunit.Assert.Equal(4, headOfList.next.num);

        }

    }
}
