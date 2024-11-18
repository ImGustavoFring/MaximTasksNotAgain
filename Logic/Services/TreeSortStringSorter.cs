using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class TreeSortStringSorter : IStringSorter
    {
        public string SortString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            var root = new TreeNode(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                root.Insert(input[i]);
            }

            var sortedBuilder = new StringBuilder();
            root.InOrderTraversal(sortedBuilder);
            return sortedBuilder.ToString();
        }

        private class TreeNode
        {
            public char Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(char value)
            {
                Value = value;
            }

            public void Insert(char value)
            {
                if (value <= Value)
                {
                    if (Left == null)
                        Left = new TreeNode(value);
                    else
                        Left.Insert(value);
                }
                else
                {
                    if (Right == null)
                        Right = new TreeNode(value);
                    else
                        Right.Insert(value);
                }
            }

            public void InOrderTraversal(StringBuilder builder)
            {
                Left?.InOrderTraversal(builder);
                builder.Append(Value);
                Right?.InOrderTraversal(builder);
            }
        }
    }
}
