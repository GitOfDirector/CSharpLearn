using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树_顺序存储
{
    class BinaryTree<T>
    {

        public enum TraversalType 
        {
            Preorder,
            Inorder,
            Postorder,
            Layer,
        }

        /* 
         * 对于非完全二叉树，其空节点设置为 -1
         */
        private int defaultValue = -1;

        private T[] data;
        private int count = 0;

        public BinaryTree(int capacity) 
        {
           data = new T[capacity];
        }

        public bool Add(T item)
        {
            if (count >= data.Length)
                return false;

            data[count] = item;
            count++;
            return true;
        }

        public void TreeTraversal(TraversalType tt = TraversalType.Preorder) 
        {
            switch (tt)
            {
                case TraversalType.Preorder:
                    PreorderTraversal(0);                 
                    break;
                case TraversalType.Inorder:
                    InorderTraversal(0);
                    break;
                case TraversalType.Postorder:
                    PostorderTraversal(0);
                    break;
                case TraversalType.Layer:
                    LayerTraversal();
                    break;
                default:
                    break;
            }
        }

        void PreorderTraversal(int index) 
        {
            if (index >= count)
                return;

            if (data[index].Equals(defaultValue))
                return;

            //从根节点按层级，以1开始编号

            int number = index + 1;//其所在位置为下标 + 1

            Console.Write(data[index] + "  ");
        
            //得到左右子节点
            int leftNumber = number * 2;
            int rightNumber = number * 2 + 1;

            PreorderTraversal(leftNumber - 1);
            PreorderTraversal(rightNumber - 1);
        }

        void InorderTraversal(int index)
        {
            if (index >= count)
                return;

            if (data[index].Equals(defaultValue))
                return;

            //从根节点按层级，以1开始编号

            int number = index + 1;//其所在位置为下标 + 1
           
            //得到左右子节点
            int leftNumber = number * 2;
            int rightNumber = number * 2 + 1;

            InorderTraversal(leftNumber - 1);

            Console.Write(data[index] + "  ");

            InorderTraversal(rightNumber - 1);
        }

        void PostorderTraversal(int index)
        {
            if (index >= count)
                return;

            if (data[index].Equals(defaultValue))
                return;

            //从根节点按层级，以1开始编号

            int number = index + 1;//其所在位置为下标 + 1

            //得到左右子节点
            int leftNumber = number * 2;
            int rightNumber = number * 2 + 1;

            PostorderTraversal(leftNumber - 1);
            PostorderTraversal(rightNumber - 1);
            Console.Write(data[index] + "  ");

        }

        void LayerTraversal() 
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(defaultValue))
                    continue;

                Console.Write(data[i] + "  ");
            }
        }
    }
}
