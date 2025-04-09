public class AVLNode(int key)
{
    public readonly int Key = key;
    public AVLNode? Left;
    public AVLNode? Right;
    public int Height = 1;
}

public class AVLTree
{
    private AVLNode? _root;

    public void Insert(int key)
    {
        _root = Insert(_root, key);
    }

    public bool IsUnbalanced()
    {
        return Math.Abs(GetBalanceFactor(_root)) > 1;
    }

    public int GetHeight()
    {
        return Height(_root);
    }

    private static int Height(AVLNode? node)
    {
        return node?.Height ?? 0;
    }

    private static int GetBalanceFactor(AVLNode? node)
    {
        return node == null ? 0 : Height(node.Right) - Height(node.Left);
    }

    private static AVLNode RightRotate(AVLNode a)
    {
        var b = a.Left;
        var c = b?.Right;

        b.Right = a;
        a.Left = c;

        a.Height = Math.Max(Height(a.Left), Height(a.Right)) + 1;
        b.Height = Math.Max(Height(b.Left), Height(b.Right)) + 1;

        return b;
    }

    private static AVLNode LeftRotate(AVLNode a)
    {
        var b = a.Right;
        var c = b?.Left;

        b.Left = a;
        a.Right = c;

        a.Height = Math.Max(Height(a.Left), Height(a.Right)) + 1;
        b.Height = Math.Max(Height(b.Left), Height(b.Right)) + 1;

        return b;
    }

    private static AVLNode Insert(AVLNode? node, int key)
    {
        if (node == null)
        {
            return new AVLNode(key);
        }

        if (key < node.Key)
        {
            node.Left = Insert(node.Left, key);
        }
        else if (key > node.Key)
        {
            node.Right = Insert(node.Right, key);
        }
        else
        {
            return node;
        }

        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

        var balance = GetBalanceFactor(node);

        // Левое поддерево выше (перевес влево)
        if (balance < -1)
        {
            // Малое левое вращение
            if (Height(node.Left?.Left) >= Height(node.Left?.Right))
            {
                return RightRotate(node);
            }
            // Большое левое вращение
            else
            {
                node.Left = LeftRotate(node.Left!);
                return RightRotate(node);
            }
        }

        // Правое поддерево выше (перевес вправо)
        if (balance > 1)
        {
            // Малое правое вращение
            if (Height(node.Right?.Right) >= Height(node.Right?.Left))
            {
                return LeftRotate(node);
            }
            // Большое правое вращение
            else
            {
                node.Right = RightRotate(node.Right!);
                return LeftRotate(node);
            }
        }

        return node;
    }
}