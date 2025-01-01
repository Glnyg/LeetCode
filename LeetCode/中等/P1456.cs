namespace LeetCode.中等;

public class P1456
{
    public static TheoryData<string, int, int> GetCase()
    {
        var data = new TheoryData<string, int, int>
        {
            { "abciiidef", 3, 3 },
            { "aeiou", 2, 2 },
            { "leetcode", 3, 2 },
            { "rhythms", 4, 0 },
            { "tryhard", 4, 1 },
            { "weallloveyou", 7, 4 },
            { "abciiidef", 3, 3 },
        };
        return data;
    }

    [Theory]
    [MemberData(nameof(GetCase))]
    public void LeetCodeTest(string s, int k, int expected)
    {
        Assert.Equal(MaxVowels(s, k), expected);
    }

    private const int VOWER = 1 + (1 << ('e' - 'a')) + (1 << ('i' - 'a')) + (1 << ('o' - 'a')) + (1 << ('u' - 'a'));
    
    private static bool IsVowel(char c) => ((1 << (c - 'a')) & VOWER) != 0;

    public int MaxVowels(string s, int k) {
        
        var maxVowels = 0;
        var prevVowels = maxVowels;
        var index = 0;
        
        if (s.Length == k) return s[..k].Count(IsVowel);
        
        do
        {
            if (IsVowel(s[index])) prevVowels++;
            
            if (index >= k && IsVowel(s[index - k])) prevVowels--;
            
            if (++index < k) continue;
            
            maxVowels = Math.Max(maxVowels, prevVowels);
            
            
        } while (index < s.Length);
        
        return maxVowels;
    }
}