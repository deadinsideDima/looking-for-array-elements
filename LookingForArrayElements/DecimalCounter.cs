using System;

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            for (int ii = 0; ii < ranges.Length; ii++)
            {
                if (ranges[ii] == null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                if (ranges[ii].Length == 2)
                {
                    if (ranges[ii][1] < ranges[ii][0])
                    {
                        throw new ArgumentException(null, nameof(ranges));
                    }
                }
                else
                {
                    if (ranges[ii].Length != 0)
                    {
                        throw new ArgumentException(null, nameof(ranges));
                    }
                }
            }

            return GetDecimalsCount(arrayToSearch, ranges, 0, arrayToSearch.Length);
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges, int startIndex, int count)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            for (int jj = 0; jj < ranges.Length; jj++)
            {
                if (ranges[jj] == null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }
            }

            for (int ii = 0; ii < ranges.Length; ii++)
            {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                if (ranges[ii].Length == 2)
                {
                    if (ranges[ii][1] < ranges[ii][0])
                    {
                        throw new ArgumentException(null, nameof(ranges));
                    }
                }
                else
                {
                    if (ranges[ii].Length != 0)
                    {
                        throw new ArgumentException(null, nameof(ranges));
                    }
                }
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (startIndex + count > arrayToSearch.Length || startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            int i = startIndex;
            int temp = 0;
            for (int j = 0; j < count; j++)
            {
                for (int k = 0; k < ranges.Length; k++)
                {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                    if (ranges[k].Length == 0)
                    {
                        continue;
                    }

                    if (arrayToSearch[i + j] >= ranges[k][0] && arrayToSearch[i + j] <= ranges[k][1])
                    {
                        temp++;
                        break;
                    }
                }
            }

            return temp;
        }
    }
}
