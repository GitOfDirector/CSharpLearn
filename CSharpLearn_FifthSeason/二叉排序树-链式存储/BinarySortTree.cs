using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉排序树_链式存储
{
    class BSNode
    {
        public BSNode LeftNode;
        public BSNode RightNode;
        public BSNode Parent;

        public int data;

        public BSNode() { }

        public BSNode(int data) 
        {
            this.data = data;
        }    

    }

    class BinarySortTree
    {
        public int nodeCount = 0;

        BSNode root = null;

        public void AddRange(int[] arrItems) 
        {
            foreach (var item in arrItems)
            {
                Add(item);
            }
        }

        public void Add(int item) 
        {
            BSNode newNode = new BSNode(item);
            if (root == null)
            {
                root = newNode;
                nodeCount = 1;
            }
            else
            {
                //如果已经存在，则不进行插入
                if (SearchNode(root, item) != null)
                {
                    Console.WriteLine(item + " 已存在");
                    return;
                }

                BSNode tempNode = null;
                BSNode rootNode = root;//这里只是将root的指针传给了rootNode

                while (rootNode != null)
                {
                    tempNode = rootNode;

                    //这里只是更改了rootNode的指向，并不影响root
                    rootNode = rootNode.data > item ? rootNode.LeftNode : rootNode.RightNode;
                }

                //Console.WriteLine(tempNode.data + "~~~" + root.data);

                if (item < tempNode.data)
                    tempNode.LeftNode = newNode;
                else
                    tempNode.RightNode = newNode;

                nodeCount++;
            }
        }

        public BSNode SearchNode(BSNode root, int key) 
        {
            if (root == null)
                return null;

            if (key > root.data)
                return SearchNode(root.RightNode, key);
            else if (key < root.data)
                return SearchNode(root.LeftNode, key);
            else
                return root;
        }

        public void TreeTraversal() 
        {
            InorderTraversal(root);
        }

        private void InorderTraversal(BSNode root) 
        {
            if (root == null)
                return;

            InorderTraversal(root.LeftNode);
            Console.Write(root.data +"  ");
            InorderTraversal(root.RightNode);

        }



    }
}
