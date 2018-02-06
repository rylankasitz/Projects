﻿/* LeftistTree.cs
 * Author: Rod Howell */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.Sort
{
    /// <summary>
    /// An immutable generic leftist tree node that can draw itself.
    /// </summary>
    /// <typeparam name="T">The type of the elements stored in the tree.</typeparam>
    public class LeftistTree<T> : ITree
    {
        /// <summary>
        /// The data stored in this node.
        /// </summary>
        private T _data;

        /// <summary>
        /// Gets the data stored in this node.
        /// </summary>
        public T Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// This nodes left child.
        /// </summary>
        private LeftistTree<T> _leftChild;

        /// <summary>
        /// Gets this node's left child.
        /// </summary>
        public LeftistTree<T> LeftChild
        {
            get
            {
                return _leftChild;
            }
        }

        /// <summary>
        /// This node's right child.
        /// </summary>
        private LeftistTree<T> _rightChild;

        /// <summary>
        /// Gets this node's right child.
        /// </summary>
        public LeftistTree<T> RightChild
        {
            get
            {
                return _rightChild;
            }
        }

        /// <summary>
        /// The null path length of this tree.
        /// </summary>
        private int _nullPathLength;

        /// <summary>
        /// Constructs a BinaryTreeNode with the given data, left child, and right child.
        /// </summary>
        /// <param name="data">The data stored in the node.</param>
        /// <param name="left">One child.</param>
        /// <param name="right">The other child.</param>
        public LeftistTree(T data, LeftistTree<T> left, LeftistTree<T> right)
        {
            _data = data;
            if (NullPathLength(left) > NullPathLength(right))
            {
                _leftChild = left;
                _rightChild = right;
            }
            else
            {
                _leftChild = right;
                _rightChild = left;
            }
            _nullPathLength = 1 + NullPathLength(_rightChild);
        }

        /// <summary>
        /// Finds the null path length of the given tree.
        /// </summary>
        /// <param name="t">The given tree.</param>
        /// <returns>The null path length of t.</returns>
        public static int NullPathLength(LeftistTree<T> t)
        {
            if (t == null)
            {
                return 0;
            }
            else
            {
                return t._nullPathLength;
            }
        }

        #region Code used for drawing trees

        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        ITree[] ITree.Children
        {
            get 
            {
                ITree[] children = new ITree[2];
                children[0] = _leftChild;
                children[1] = _rightChild;
                return children;
            }
        }

        /// <summary>
        /// Gets whether this node is empty. Because empty trees will be represented by
        /// null, it always returns false.
        /// </summary>
        bool ITree.IsEmpty
        {
            get 
            { 
                return false; 
            }
        }

        /// <summary>
        /// Gets the object to be drawn as the contents of this node.
        /// </summary>
        object ITree.Root
        {
            get 
            { 
                return _data; 
            }
        }

        #endregion
    }
}
