using System;
using static System.Console;

namespace BinaryTree_Lab10.BinaryTree
{
    public class ExpressionTree
    {
        byte Priority(char x)
        {
            switch (x)
            {
                case '+': case '-': return 1;
                case '*': case '/': return 2;
                default: return 10;
            }
        }

        public int Height(Node Tree)
        {
            if (Tree == null)
                return -1;
            else
            {
                int left = Height(Tree.LeftNode);
                int right = Height(Tree.RightNode);
                return 1 + Math.Max(left, right);
            }
        }

        public double Calculate(Node Tree)
        {
            if (Tree.LeftNode == null)
                return Convert.ToDouble(Tree.Value);
            double l = Calculate(Tree.LeftNode);
            double r = Calculate(Tree.RightNode);
            switch (Tree.Value)
            {
                case "+": return l + r;
                case "-": return l - r;
                case "*": return l * r;
            }
            return l / r;
        }

        #region Output
        public void PreOrder(Node Tree)
        {
            if (Tree == null)
                return;
            Write(Tree.Value + " ");
            PreOrder(Tree.LeftNode);
            PreOrder(Tree.RightNode);
        }
        public void InOrder(Node Tree)
        {
            if (Tree == null)
                return;
            InOrder(Tree.LeftNode);
            Write(Tree.Value + " ");
            InOrder(Tree.RightNode);
        }
        public void PostOrder(Node Tree)
        {
            if (Tree == null)
                return;
            PostOrder(Tree.LeftNode);
            PostOrder(Tree.RightNode);
            Write(Tree.Value + " ");
        }
        #endregion

        public Node BuildTree(string exp)
        {
            byte minPriority = 10; int brackets = 0; int index = new int();
            Node Tree = new Node();
            exp = exp?.Replace(" ", "");
            if (exp.Length == 1)
            {
                Tree.Value = exp;
                return Tree;
            }
            for (int i = 0; i < exp.Length; i++)
            {
                switch (exp[i])
                {
                    case '(': brackets++; continue;
                    case ')': brackets--; continue;
                }
                if (brackets != 0)
                    continue;
                if (Priority(exp[i]) <= minPriority)
                {
                    minPriority = Priority(exp[i]);
                    index = i;
                }
            }
            if (minPriority == 10)
            {
                if (exp.StartsWith('(') && exp.EndsWith(')'))
                    return BuildTree(exp[1..^1]);
                else
                {
                    Tree.Value += exp;
                    return Tree;
                }
            }
            Tree.Value = exp[index].ToString();
            Tree.LeftNode = BuildTree(exp.Substring(0, exp.Substring(0, index).Length));
            Tree.RightNode = BuildTree(exp.Substring(index + 1, exp.Substring(index + 1).Length));
            return Tree;
        }
    }
}