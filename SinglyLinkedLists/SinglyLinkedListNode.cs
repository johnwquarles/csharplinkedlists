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
                if (Object.ReferenceEquals(this, value)) { throw new ArgumentException(); }
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

        public static bool operator ==(SinglyLinkedListNode left, SinglyLinkedListNode right)
        {
            // 2 things are equal when CompareTo equals 0.
            // note that this can be done because operators are just methods! == is just the name of a method.
            // C# knows now that when dealing with == between two instances of SinglyLinkedLists, use this operator;
            // knows this by the signature.
            return left.CompareTo(right) == 0;
        }

        public static bool operator !=(SinglyLinkedListNode left, SinglyLinkedListNode right)
        {
            return !(left == right);
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
        // CompateTo's signature is as written below according to the IComparable interface. Must use this signature.
        public int CompareTo(Object obj)
        {
            // obj is passed in as an Object, but we want to pull it down the hierarchy tree and
            // interface with it as a SinglyLinkedListNode. (downcasting).

            //SinglyLinkedListNode other_node = obj as SinglyLinkedListNode;

            // same class but different instances; use getter/setter method.
            // equal is 0; if this is less than that, -1.

            //if (this.value == other_node.Value) return 0;
            //if ((int)this.value > (int)other_node.Value) return 1;
            //return 1;
            throw new NotImplementedException();
        }

        public bool IsLast()
        {
            // this makes 6 pass (7 too I guess); idea is to not use == here
            // since, for one, I haven't implemented it, but also because I dunno how this class' ==
            // works with null (since null isn't a member of SinglyLinkedListNode or even an object),
            // so use object's Equals method.
            return object.Equals(this.next, null);
        }

        public override string ToString()
        {
            return this.value;
        }
    }
}
