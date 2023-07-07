using System;

namespace LookingForArrayElements
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart == null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("different", nameof(rangeStart));
            }

            for (int ii = 0; ii < rangeEnd.Length; ii++)
            {
                if (rangeEnd[ii] < rangeStart[ii])
                {
                    throw new ArgumentException(null, nameof(rangeStart));
                }
            }

            if (rangeStart.Length == 0 || arrayToSearch.Length == 0)
            {
                return 0;
            }

            return GetFloatsCount(arrayToSearch, rangeStart, rangeEnd, 0, arrayToSearch.Length);
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart == null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("different", nameof(rangeStart));
            }

            for (int ii = 0; ii < rangeEnd.Length; ii++)
            {
                if (rangeEnd[ii] < rangeStart[ii])
                {
                    throw new ArgumentException(null, nameof(rangeStart));
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
                for (int k = 0; k < rangeStart.Length; k++)
                {
                    if (arrayToSearch[i + j] >= rangeStart[k] && arrayToSearch[i + j] <= rangeEnd[k])
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
