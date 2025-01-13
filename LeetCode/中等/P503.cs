namespace LeetCode.中等;

public class P503
{
    public static TheoryData<int[], int[]> GetCase()
    {
        var data = new TheoryData<int[], int[]>
        {
            { [1, 2, 1], [2, -1, 2] },
            { [1, 2, 3, 4, 3], [2, 3, 4, -1, 4] }
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
        var sortNumsDic = new SortedDictionary<int, List<int>>();
        var result = new int[nums.Length];
        result.AsSpan().Fill(-1);

        for (int i = 0; i < nums.Length; i++)
        {
            var currentNum = nums[i];

            if (sortNumsDic.TryGetValue(currentNum, out var list))
            {
                list.Add(i);
            }
            else
            {
                sortNumsDic.Add(currentNum, [i]);
            }
            
            if (sortNumsDic.Count == 1) continue;
            
            if (sortNumsDic.First().Key >= currentNum) continue;

            foreach (var (key, value) in sortNumsDic.TakeWhile(x => x.Key < currentNum))
            {
                value.ForEach(valueIndex => result[valueIndex] = currentNum);
            }
            
            foreach (var removeKey in sortNumsDic.Keys.TakeWhile(x => x < currentNum).ToArray())
            {
                sortNumsDic.Remove(removeKey);  
            }
        }
        
        if (sortNumsDic.Count == 0) return result;

        foreach (var currentNum in nums)
        {
            if (sortNumsDic.First().Key >= currentNum) continue;

            var num = currentNum;
            foreach (var (key, value) in sortNumsDic.TakeWhile(x => x.Key < num))
            {
                value.ForEach(valueIndex => result[valueIndex] = currentNum);
            }
            
            foreach (var removeKey in sortNumsDic.Keys.TakeWhile(x => x < currentNum).ToArray())
            {
                sortNumsDic.Remove(removeKey);
            }
        }
        
        return result;
    }
}