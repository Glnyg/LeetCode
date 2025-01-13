namespace LeetCode;

public class P0
{
    public static TheoryData<int[], int[]> GetCase()
    {
        var data = new TheoryData<int[], int[]>
        {
            { [1, 2, 1], [1, 2, 1] },
            { [1, 2, 3, 4, 3], [1, 2, 3, 4, 3] }
        };
        return data;
    }

    [Theory]
    [MemberData(nameof(GetCase))]
    public void LeetCodeTest(int[] nums, int[] expected)
    {
        Assert.Equal(NextGreaterElements(nums), expected);
    }

    public int[] NextGreaterElements(int[] nums)
    {
        return nums;
    }
}