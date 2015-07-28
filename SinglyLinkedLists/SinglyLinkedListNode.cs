using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode next;
        public SinglyLinkedListNode Next
        {
            get { return next; }
            // can use keyword value for setter.
            set {
                if (value == this) { throw new ArgumentException(); }
                this.next = value;
            }
        }

        private string value; // same as this.value
        // setters and getters are for things outside of the class to access/set data in the class.
        // don't need to use them from within the class.
        public string Value 
        {
            get { return value; }
        }

        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        public SinglyLinkedListNode(string value)
        {
            // don't *need* to write "this"; linter may throw errors. But it's ok to.
            this.value = value;
            // undeclared data memebers default to null, but we need a getter to "see" their null-ness.
            //this.next = null;

            // Used by the visualizer:
            allNodes.Add(this);
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        // below is where we'll establish what equality even means in the case of these nodes.
        public int CompareTo(Object obj)
        {
            throw new NotImplementedException();
        }

        public bool IsLast()
        {
            return this.next == null;
        }

        public override string ToString()
        {
            return this.value;
        }
    }
}
