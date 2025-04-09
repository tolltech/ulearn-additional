using FluentAssertions;

namespace AvlTree;

public class Tests
{
    [Test]
    public void Test1()
    {
        var avlTree = new AVLTree();
        avlTree.Insert(1);
        avlTree.IsUnbalanced().Should().BeFalse();

        avlTree.Insert(2);
        avlTree.IsUnbalanced().Should().BeFalse();

        avlTree.Insert(3);
        avlTree.IsUnbalanced().Should().BeFalse();
    }

    [Test]
    public void Test2()
    {
        var avlTree = new AVLTree();
        avlTree.Insert(1);
        avlTree.IsUnbalanced().Should().BeFalse();

        avlTree.Insert(1);
        avlTree.IsUnbalanced().Should().BeFalse();

        avlTree.Insert(3);
        avlTree.IsUnbalanced().Should().BeFalse();

        avlTree.Insert(2);
        avlTree.IsUnbalanced().Should().BeFalse();

        avlTree.Insert(2);
        avlTree.IsUnbalanced().Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(GetRandomCombinations))]
    public void RandomCases(int[] inputs)
    {
        var avlTree = new AVLTree();

        foreach (var i in inputs)
        {
            avlTree.Insert(i);
        }

        avlTree.GetHeight().Should().Be(4);
    }

    public static IEnumerable<TestCaseData> GetRandomCombinations()
    {
        var random = new Random();
        for (int i = 0; i < 10000; i++)
        {
            var sequence = Enumerable.Range(0, 100)
                .OrderBy(x => random.Next())
                .Take(8)
                .ToArray();

            yield return new TestCaseData(sequence)
                .SetName($"TestRandomSequence_{string.Join(',', sequence)}");
        }
    }
}