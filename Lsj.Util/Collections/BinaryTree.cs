using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;



#if NETCOREAPP1_1
namespace Lsj.Util.Core.Collections
#else
namespace Lsj.Util.Collections
#endif
{
    public class BinaryTree<T> : BinaryTreeNode<T>
    {
        public BinaryTree(T val) : base(val)
        {
        }
        public bool IsEmpty => this.left == null && this.right == null;


    }

    public class BinaryTreeNode<T>
    {
        protected T val;
        protected BinaryTreeNode<T> parent;
        protected BinaryTreeNode<T> left;
        protected BinaryTreeNode<T> right;

        public BinaryTreeNode<T> Parent => this.parent;
        public BinaryTreeNode<T> Left
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
                this.left.parent = this;
            }
        }
        public BinaryTreeNode<T> Right
        {
            get
            {
                return this.right;
            }
            set
            {
                this.left = value;
                this.right.parent = this;
            }
        }


        public BinaryTreeNode(T val)
        {
            this.val = val;
        }



        public int Height
        {
            get
            {
                if (this.left == null && this.right == null)
                {
                    return 1;
                }
                else if (this.left == null)
                {
                    return this.right.Height + 1;
                }
                else if (this.right == null)
                {
                    return this.left.Height + 1;
                }
                else
                {
                    return Math.Max(this.left.Height, this.right.Height) + 1;
                }
            }
        }











        public IEnumerable<BinaryTreeNode<T>> TraverseDLRWithRecursion()
        {
            yield return this;
            if (this.left != null)
            {
                foreach (var x in this.left.TraverseDLRWithRecursion())
                {
                    yield return x;
                }
            }
            if (this.right != null)
            {
                foreach (var x in this.left.TraverseDLRWithRecursion())
                {
                    yield return x;
                }
            }
        }



        public IEnumerable<BinaryTreeNode<T>> TraverseDLRWithoutRecursion()
        {
            var stack = new MyStack<BinaryTreeNode<T>>();
            stack.Push(this);
            while (!stack.IsEmpty)
            {
                var current = stack.Pop();
                yield return current;
                if (current.right != null)
                {
                    stack.Push(current.right);
                }
                if (current.left != null)
                {
                    stack.Push(current.left);
                }
            }
        }





        public IEnumerable<BinaryTreeNode<T>> TraverseLDRWithRecursion()
        {

            if (this.left != null)
            {
                foreach (var x in this.left.TraverseLDRWithRecursion())
                {
                    yield return x;
                }
            }
            yield return this;
            if (this.right != null)
            {
                foreach (var x in this.left.TraverseLDRWithRecursion())
                {
                    yield return x;
                }
            }
        }
        public IEnumerable<BinaryTreeNode<T>> TraverseLDRWithoutRecursion()
        {
            var stack = new MyStack<BinaryTreeNode<T>>();
            stack.Push(this);
            while (!stack.IsEmpty)
            {
                var current = stack.Peek();
                if (current.left != null)
                {
                    stack.Push(current.left);
                    continue;
                }
                yield return current;
                if (current.right != null)
                {
                    stack.Push(current.right);
                    continue;
                }

            }
        }






        public IEnumerable<BinaryTreeNode<T>> TraverseLRDWithRecursion()
        {
            if (this.left != null)
            {
                foreach (var x in this.left.TraverseLRDWithRecursion())
                {
                    yield return x;
                }
            }
            if (this.right != null)
            {
                foreach (var x in this.left.TraverseLRDWithRecursion())
                {
                    yield return x;
                }
            }
            yield return this;
        }



    }
}
