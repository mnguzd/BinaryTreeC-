using BinaryTree_Lab10.BinaryTree;
using static System.Console;

namespace BinaryTree_Lab10
{
    class Program
    {
        static void Main()
        {
            ExpressionTree exp = new ExpressionTree();
            DataService dataService = new DataService();
            Node Tree = exp.BuildTree(dataService.Expression);  //or exp.BuildTree("your expression"), like exp.BuildTree("(1+2*3)")
            WriteLine("Expression is : " + dataService.Expression);
            Write("Preorder traversal (KLP) is : ");
            exp.PreOrder(Tree);
            Write("\nInorder traversal (LKP) is : ");
            exp.InOrder(Tree);
            Write("\nPostorder traversal (LPK) is : ");
            exp.PostOrder(Tree);
            WriteLine("\nThe result of the calculation is : " + exp.Calculate(Tree));
            WriteLine("Tree height is : " + exp.Height(Tree));
        }
    }
}
