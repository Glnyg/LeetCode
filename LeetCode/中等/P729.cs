namespace LeetCode.中等;

public class P729
{
    public static TheoryData<Tuple<int, int, bool>[]> GetCase()
    {
        var data = new TheoryData<Tuple<int, int, bool>[]>
        {
            new Tuple<int, int, bool>[]
            {
                new(10, 20, true),
                new(15, 25, false),
                new(20, 30, true),
            },
            new Tuple<int, int, bool>[]
            {
                new(47, 50, true),
                new(33, 41, true),
                new(39, 45, false),
                new(33, 42, false),
                new(25, 32, true),
                new(26, 35, false),
                new(19, 25, true),
                new(3, 8, true),
                new(8, 13, true),
                new(18, 27, false),
            },
            new Tuple<int, int, bool>[]
            {
                new(37, 50, true),
                new(33, 50, false),
                new(4, 17, true),
                new(35, 48, false),
                new(8, 25, false),
            },
            GetCaseItem(
                [
                    [20, 29], [13, 22], [44, 50], [1, 7], [2, 10], [14, 20], [19, 25], [36, 42], [45, 50], [47, 50],
                    [39, 45],
                    [44, 50], [16, 25], [45, 50], [45, 50], [12, 20], [21, 29], [11, 20], [12, 17], [34, 40], [10, 18],
                    [38, 44], [23, 32], [38, 44], [15, 20], [27, 33], [34, 42], [44, 50], [35, 40], [24, 31]
                ],
                [
                    true, false, true, true, false, true, false, true, false, false, false, false, false, false, false,
                    false,
                    false, false, false, false, false, false, false, false, false, false, false, false, false, false
                ])
        };

        return data;

        Tuple<int, int, bool>[] GetCaseItem(List<int[]> inputList, List<bool> expectedList) => inputList.Zip(expectedList)
            .Select(t => new Tuple<int, int, bool>(t.First[0], t.First[1], t.Second)).ToArray();
    }

    [Theory]
    [MemberData(nameof(GetCase))]
    public void LeetCodeTest(Tuple<int, int, bool>[] cases)
    {
        var calendar = new MyCalendar();

        foreach (var (startTime, endTime, expected) in cases)
        {
            Assert.Equal(calendar.Book(startTime, endTime), expected);
        }
    }

    private class MyCalendar
    {
        private readonly List<int> _books = new(1000);
        private readonly Dictionary<int, int> _booksDict = new();

        public bool Book(int startTime, int endTime)
        {
            if (_books.Count == 0)
            {
                _books.Add(startTime);
                _booksDict.Add(startTime, endTime);
                return true;
            }

            var startTimeOfBookIndex = BinarySearchSmallerAndLarger(_books, startTime);

            if (startTimeOfBookIndex.isEqual) return false;

            if (!StartTimeValid() || !EndTimeValid()) return false;

            _books.Insert(startTimeOfBookIndex.larger ?? _books.Count, startTime);
            _booksDict.Add(startTime, endTime);
            return true;

            bool EndTimeValid()
            {
                if (!startTimeOfBookIndex.larger.HasValue) return true;

                return endTime <= _books[startTimeOfBookIndex.larger.Value];
            }

            bool StartTimeValid()
            {
                if (!startTimeOfBookIndex.smaller.HasValue) return true;

                return startTime >= _booksDict[_books[startTimeOfBookIndex.smaller.Value]];
            }
        }

        private static (int? smaller, int? larger, bool isEqual) BinarySearchSmallerAndLarger(List<int> sortedList,
            int target)
        {
            var low = 0;
            var high = sortedList.Count - 1;
            int? smaller = null;
            int? larger = null;
            var isEqual = false;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                var midValue = sortedList[mid];

                if (midValue < target)
                {
                    smaller = mid;
                    low = mid + 1;
                }
                else if (midValue > target)
                {
                    larger = mid;
                    high = mid - 1;
                }
                else
                {
                    isEqual = true;
                    break;
                }
            }

            return (smaller, larger, isEqual);
        }
    }
}