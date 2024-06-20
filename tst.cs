using System;

public class TernarySearchTree
{
    public class Node
    {
        public char data;
        public bool isEndOfString;
        public Node left, eq, right;

        public Node(char data)
        {
            this.data = data;
            this.isEndOfString = false;
            this.left = this.eq = this.right = null;
        }
    }
    private Node root;
    public TernarySearchTree() { this.root = null; }
    public void Insert(string word)
    {
        if (string.IsNullOrEmpty(word))
            return;

        this.root = InsertHelper(this.root, word, 0);
    }
    private Node InsertHelper(Node node, string word, int index)
    {
        if (node == null)
        {
            node = new Node(word[index]);
        }
        if (word[index] < node.data)
        {
            node.left = InsertHelper(node.left, word, index);
        }
        else if (word[index] > node.data)
        {
            node.right  = InsertHelper(node.right, word, index);
        }
        else
        {
            if (index < word.Length - 1)
            {
                node.eq = InsertHelper(node.eq, word, index + 1);
            }
            else
            {
                node.isEndOfString = true;
            }
        }
        return node;
    }
    public bool Search(string word)
    {
        if (string.IsNullOrEmpty(word))
        { return false; }
        return SearchHelper(this.root, word, 0);
    }
    private bool SearchHelper(Node node, string word, int index)
    {
        if (node == null)
            return false;
        if (word[index] < node.data)
        {
            return SearchHelper(node.left, word, index);
        }
        else if (word[index] > node.data)
        {
            return SearchHelper(node.right, word, index);
        }
        else
        {
            if (index == word.Length - 1)
            {
                return node.isEndOfString;
            }
            else
            {
                return SearchHelper(node.eq, word, index + 1);
            }
        }
    }
}
public class Program
{
    static void Main(string[] args)
    {
        TernarySearchTree tst = new TernarySearchTree();
        tst.Insert("дом");
        tst.Insert("дочь");
        tst.Insert("день");
        tst.Insert("кот");
        tst.Insert("код");
        tst.Insert("кора");

        Console.WriteLine(tst.Search("дом"));
        Console.WriteLine(tst.Search("дерево"));
        Console.WriteLine(tst.Search("котенок"));
        Console.WriteLine(tst.Search("кор"));
        Console.WriteLine(tst.Search("кора"));
        Console.WriteLine(tst.Search("ребро"));
    }
}