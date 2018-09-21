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

                //Console.WriteLine("rootNode：" + (rootNode == null) + "===" + tempNode.data + "~~~" + root.data);

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

        private BSNode SearchMinNode(BSNode root) 
        {
            if (root == null)
                return null;

            if (root.LeftNode == null)
                return root;
            else
                return SearchMinNode(root.LeftNode);
        }

        private BSNode SearchMaxNode(BSNode root)
        {
            if (root == null)
                return null;

            if (root.RightNode == null)
                return root;
            else
                return SearchMaxNode(root.RightNode);
        }

        public void TreeTraversal()
        {
            BreadthFirstTravel(this.root);
        }

        public void TreeTraversalBySort()
        {
            InorderTraversal(root);
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        private void InorderTraversal(BSNode root)
        {
            if (root == null)
                return;

            InorderTraversal(root.LeftNode);
            Console.Write(root.data + "  ");
            InorderTraversal(root.RightNode);

        }

        private void BreadthFirstTravel(BSNode root) 
        {
            Queue<BSNode> que = new Queue<BSNode>();
            que.Enqueue(root);

            while (que.Count != 0)
            {
               root =  que.Peek();
               Console.Write(root.data + "  ");

               que.Dequeue();
               if (root.LeftNode != null)
               {
                   que.Enqueue(root.LeftNode);
               }

               if (root.RightNode != null)
               {
                   que.Enqueue(root.RightNode);
               }

            }

        }

        public  void Delete(int data)
        {
            Delete(this.root, data);
        }

        private void Delete(BSNode root, int data)
        {
            BSNode tempRoot = root;

            if (root == null)
                return;

            //如果找到了指定节点
            if (data == tempRoot.data)
            {
                //如果node是叶子节点
                if (tempRoot.LeftNode == null && tempRoot.RightNode == null)
                {
                    tempRoot = null;
                }
                else
                {
                    //如果左右节点都不为空
                    if (tempRoot.LeftNode != null && tempRoot.RightNode != null)
                    {
                        //method1：以右子树内的最小节点取代该节点
                        BSNode mimimum = SearchMinNode(tempRoot.RightNode);
                        //Console.WriteLine("右子树最小：" + mimimum.data);
                        tempRoot.data = mimimum.data;
                        mimimum = null;
                        //node = null;
                        
                        //method2：以左子树内的最大节点取代该节点
                        //BSNode greatest = SearchMaxNode(node.LeftNode);
                        //tempRoot.data = greatest.data;
                        //greatest = null;

                    }
                    //如果左节点不为空
                    else if (tempRoot.LeftNode != null && tempRoot.RightNode == null)
                    {
                        tempRoot = tempRoot.LeftNode;
                        //node = null;
                    }
                    //如果右节点不为空
                    else if (tempRoot.LeftNode == null && tempRoot.RightNode != null)
                    {
                        tempRoot = tempRoot.RightNode;
                        //node = null;
                    }
                }
            }
            else if (data > tempRoot.data)
            {
                Delete(tempRoot.RightNode, data);
            }
            else if (data < tempRoot.data)
            {
                Delete(tempRoot.LeftNode, data);
            }
        }

    }
}
