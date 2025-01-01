namespace LeetCode.简单;

public class P3402
{
    public static TheoryData<int[][], int> GetCase()
    {
        var data = new TheoryData<int[][], int>();
        data.Add([[3, 2], [1, 3], [3, 4], [0, 1]], 15);
        data.Add([[3, 2, 1], [2, 1, 0], [1, 2, 3]], 12);
        return data;
    }

    [Theory]
    [MemberData(nameof(GetCase))]
    public void LeetCodeTest(int[][] arr, int expected)
    {
        Assert.Equal(MinimumOperations(arr), expected);
    }


    private int MinimumOperations(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var result = 0;

        for (int j = 0; j < n; j++)
        {
            for (int i = 1, init = grid[0][j] + 1; i < m; i++)
            {
                var temp = init - grid[i][j];
                init = grid[i][j] + 1;
                if (temp < 0) continue;
                init += temp;
                result += temp;
            }
        }

        return result;
    }
}