using System;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// BinaryTree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : BinaryTreeNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="val">value</param>
        public BinaryTree(T val) : base(val)
        {
        }

        /// <summary>
        /// Is Empty
        /// </summary>
        public bool IsEmpty => this.left == null && this.right == null;
    }
    /// <summary>
    /// BinaryTreeNode
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T>
    {
        /// <summary>
        /// Value
        /// </summary>
        protected T val;
        /// <summary>
        /// Parent
        /// </summary>
        protected BinaryTreeNode<T> parent;
        /// <summary>
        /// Left Child
        /// </summary>
        protected BinaryTreeNode<T> left;
        /// <summary>
        /// Right Child
        /// </summary>
        protected BinaryTreeNode<T> right;

        /// <summary>
        /// Parent
        /// </summary>
        public BinaryTreeNode<T> Parent => this.parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.BinaryTreeNode{T}"/> class.
        /// </summary>
        /// <param name="val"></param>
        public BinaryTreeNode(T val)
        {
            this.val = val;
        }

        /// <summary>
        /// Left Child
        /// </summary>
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

        /// <summary>
        /// Right Child
        /// </summary>
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

        /// <summary>
        /// Height
        /// </summary>
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

        /// <summary>
        /// TraverseDLRWithRecursion
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// TraverseDLRWithoutRecursion
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// TraverseLDRWithRecursion
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// TraverseLDRWithoutRecursion
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// TraverseLRDWithRecursion
        /// </summary>
        /// <returns></returns>
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
