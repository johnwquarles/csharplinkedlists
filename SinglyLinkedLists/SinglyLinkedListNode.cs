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
                // value below doesn't refer to a node's value, it refers to what's being passed into the setter (ie, a node instance).
                if (Object.ReferenceEquals(this, value) || value == null) { throw new ArgumentException(); }
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
        // CompateTo's signature is as written below according to the IComparable interface. Must use this signature.
        public int CompareTo(Object obj)
        {
            // obj is passed in as an Object, but we want to pull it down the hierarchy tree and
            // interface with it as a SinglyLinkedListNode. (downcasting).

            // if something that can't be casted is casted as below, it becomes null?
            // still compiles given that the method takes in an object, and we're putting in an object.
            // but if it can't be downcast to SinglyLinkedListNode --> null.

            // any defined variable is greater than null. "Something is greater than nothing"
            SinglyLinkedListNode other_node = obj as SinglyLinkedListNode;
            if (other_node == null)
            {
                return 1;
            }
            // remember that a node's value is a string.
            // strings are objects, so they have a CompareTo method.
            // we'll use it.
            else
            {
                return this.value.CompareTo(other_node.Value);
            }

            // same class but different instances; use getter/setter method.
            // equal is 0; if this is less than that, -1.
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

        public override bool Equals(object obj)
        {
            return this.CompareTo(obj) == 0;
        }
    }
}
