using leetCode;
using System.Numerics; //used in list node problem


/* Roman to Integer
 * Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
 * Symbol       Value
 * I             1
 * V             5
 * X             10
 * L             50
 * C             100
 * D             500
 * M             1000 For example, 2 is written as II in Roman numeral, just two ones added together.
 * 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
 * Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII.
 * Instead, the number four is written as IV. Because the one is before the five we subtract it making four.
 * The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
 * I can be placed before V (5) and X (10) to make 4 and 9. X can be placed before L (50) and C (100) to make 40 and 90. 
 * C can be placed before D (500) and M (1000) to make 400 and 900.
 * Given a roman numeral, convert it to an integer.
 * Example 1:Input: s = "III" Output: 3 Explanation: III = 3.
 * Example 2:Input: s = "LVIII" Output: 58 Explanation: L = 50, V= 5, III = 3.
 * Example 3: Input: s = "MCMXCIV" Output: 1994 Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
 * Constraints:1 <= s.length <= 15   s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
 * It is guaranteed that s is a valid roman numeral in the range [1, 3999].
 */
static int RomanToInt(string s)
{
    Dictionary<char, int> numerals = new Dictionary<char, int>()
        {{'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}};
    int converted = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (i == s.Length - 1)
        {
            converted += numerals[s[i]];
        }
        else if (s[i] == 'I' && (s[i + 1] == 'V' || s[i + 1] == 'X'))
        {
            converted -= 1;
        }
        else if (s[i] == 'X' && (s[i + 1] == 'L' || s[i + 1] == 'C'))
        {
            converted -= 10;
        }
        else if (s[i] == 'C' && (s[i + 1] == 'D' || s[i + 1] == 'M'))
        {
            converted -= 100;
        }
        else
        {
            converted += numerals[s[i]];
        }
    }
    return converted;
}
//vvvv Gave better runtime, worse memory usage vvvv
static int RomanToInt2(string s)
{
    Dictionary<char, int> numerals = new Dictionary<char, int>()
        {{'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}};
    int converted = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (i == s.Length - 1)
        {
            converted += numerals[s[i]];
        }
        else if ((s[i] == 'I' && (s[i + 1] == 'V' || s[i + 1] == 'X')) ||
               (s[i] == 'X' && (s[i + 1] == 'L' || s[i + 1] == 'C')) ||
               (s[i] == 'C' && (s[i + 1] == 'D' || s[i + 1] == 'M')))
        {
            converted -= numerals[s[i]];
        }
        else
        {
            converted += numerals[s[i]];
        }
    }
    return converted;
}


/*Valid Sudoku
 * Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
 * Each row must contain the digits 1-9 without repetition. Each column must contain the digits 1-9 without repetition.
 * Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
 * Note: A Sudoku board (partially filled) could be valid but is not necessarily solvable.
 * Only the filled cells need to be validated according to the mentioned rules. Example 1: Input: board = 
 * [["5","3",".",".","7",".",".",".","."]
 * ,["6",".",".","1","9","5",".",".","."]
 * ,[".","9","8",".",".",".",".","6","."]
 * ,["8",".",".",".","6",".",".",".","3"]
 * ,["4",".",".","8",".","3",".",".","1"]
 * ,["7",".",".",".","2",".",".",".","6"]
 * ,[".","6",".",".",".",".","2","8","."]
 * ,[".",".",".","4","1","9",".",".","5"]
 * ,[".",".",".",".","8",".",".","7","9"]] Output: true
 * Example 2: Input: board = 
 * [["8","3",".",".","7",".",".",".","."]
 * ,["6",".",".","1","9","5",".",".","."]
 * ,[".","9","8",".",".",".",".","6","."]
 * ,["8",".",".",".","6",".",".",".","3"]
 * ,["4",".",".","8",".","3",".",".","1"]
 * ,["7",".",".",".","2",".",".",".","6"]
 * ,[".","6",".",".",".",".","2","8","."]
 * ,[".",".",".","4","1","9",".",".","5"]
 * ,[".",".",".",".","8",".",".","7","9"]] Output: false
 * Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8.
 * Since there are two 8's in the top left 3x3 sub-box, it is invalid.
 * Constraints: board.length == 9 board[i].length == 9 board[i][j] is a digit 1-9 or '.'.
 */
static bool IsValidSudoku(char[][] board)
{
    bool valid = true;
    string check = "";
    for (int row = 0; row < board.GetLength(0); row++)
    {
        for (int column = 0; column < board[row].Length; column++)
        {
            check += board[row][column];
        }
        foreach (char c in check)
        {
            if (check.IndexOf(c) != check.LastIndexOf(c) && c != '.')
            {
                return false;
            }
        }
        check = "";
    }
    for (int column = 0; column < board.GetLength(0); column++)
    {
        for (int row = 0; row < board[column].Length; row++)
        {
            check += board[row][column];
        }
        foreach (char c in check)
        {
            if (check.IndexOf(c) != check.LastIndexOf(c) && c != '.')
            {
                return false;
            }
        }
        check = "";
    }
    for (int boxRow = 0; boxRow < 3; boxRow++)
    {
        for (int boxColumn = 0; boxColumn < 3; boxColumn++)
        {
            for (int row = 3 * boxRow; row < 3 * (boxRow + 1); row++)
            {
                for (int column = 3 * boxColumn; column < 3 * (boxColumn + 1); column++)
                {
                    check += board[row][column];
                }
            }
            foreach (char c in check)
            {
                if (check.IndexOf(c) != check.LastIndexOf(c) && c != '.')
                {
                    return false;
                }
            }
            check = "";
        }
    }
    return valid;
}
//better solution
bool IsValidSudoku2(char[][] board)
{
    bool valid = true;
    char[] column = new char[9];
    char[] box = new char[9];
    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            if (Array.IndexOf(board[i], board[i][j]) != Array.LastIndexOf(board[i], board[i][j]) && board[i][j] != '.')
            {
                return false;
            }
            column[j] = board[j][i];
            int r = ((i / 3) * 3) + (j / 3);
            int c = ((i % 3) * 3) + (j % 3);
            box[j] = board[r][c];
        }
        for (int j = 0; j < 9; j++)
        {
            if (Array.IndexOf(column, column[j]) != Array.LastIndexOf(column, column[j]) && column[j] != '.')
            {
                return false;
            }
            if (Array.IndexOf(box, box[j]) != Array.LastIndexOf(box, box[j]) && box[j] != '.')
            {
                return false;
            }
        }
    }
    return valid;
}


/* Two Sum
 * Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
 * You may assume that each input would have exactly one solution, and you may not use the same element twice.
 * You can return the answer in any order.  Example 1: Input: nums = [2,7,11,15], target = 9  Output: [0,1]
 * Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
 * Example 2: Input: nums = [3,2,4], target = 6 Output: [1,2]
 * Example 3: Input: nums = [3,3], target = 6 Output: [0,1]
 * Constraints: 2 <= nums.length <= 104  -109 <= nums[i] <= 109  -109 <= target <= 109  Only one valid answer exists.
 * Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
 */
static int[] TwoSum(int[] nums, int target)
{
    int index1 = 0;
    int index2 = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (index1 != index2)
        {
            break;
        }
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[i] + nums[j] == target)
            {
                index1 = i;
                index2 = j;
                break;
            }
        }
    }
    return new int[] { index1, index2 };
}


/*Add Two Numbers
 * You are given two non-empty linked lists representing two non-negative integers. 
 * The digits are stored in reverse order, and each of their nodes contains a single digit. 
 * Add the two numbers and return the sum as a linked list.
 * You may assume the two numbers do not contain any leading zero, except the number 0 itself.
 * Example 1: Input: l1 = [2,4,3], l2 = [5,6,4] Output: [7,0,8] Explanation: 342 + 465 = 807.
 * Example 2: Input: l1 = [0], l2 = [0] Output: [0]
 * Example 3: Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9] Output: [8,9,9,9,0,0,0,1]
 * Constraints: The number of nodes in each linked list is in the range [1, 100]. 0 <= Node.val <= 9
 * It is guaranteed that the list represents a number that does not have leading zeros.
 */
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
//Listnode is its own class imported with using statement using leetCode
static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    string num1 = l1.val.ToString();
    string num2 = l2.val.ToString();
    while (l1.next != null)
    {
        num1 += l1.next.val.ToString();
        l1 = l1.next;
    }
    while (l2.next != null)
    {
        num2 += l2.next.val.ToString();
        l2 = l2.next;
    }
    num1 = ReverseString(num1);
    num2 = ReverseString(num2);
    int intNum = 0;
    //BigInteger is from using System.Numerics
    BigInteger num = (BigInteger.Parse(num1)) + (BigInteger.Parse(num2));
    num1 = num.ToString();
    char[] chars = num1.ToCharArray();
    intNum = int.Parse(chars[0].ToString());
    ListNode node = new ListNode(intNum, null);
    ListNode next = node;
    for (int i = 1; i < chars.Length; i++)
    {
        intNum = int.Parse(chars[i].ToString());
        next = new ListNode(intNum, node);
        node = next;
    }
    return next;
}
static string ReverseString(string num)
{
    char[] reverse = num.ToCharArray();
    Array.Reverse(reverse);
    num = new string(reverse);
    return num;
}


