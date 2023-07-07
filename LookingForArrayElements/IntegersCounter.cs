using System;

namespace LookingForArrayElements
{
    public static class IntegersCounter
    {
        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[]? arrayToSearch, int[]? elementsToSearchFor)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (elementsToSearchFor == null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor));
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            return GetIntegersCount(arrayToSearch, elementsToSearchFor, 0, arrayToSearch.Length);
        }

        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements withing the range of elements in the <see cref="Array"/> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[]? arrayToSearch, int[]? elementsToSearchFor, int startIndex, int count)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (elementsToSearchFor == null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor));
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
                for (int k = 0; k < elementsToSearchFor.Length; k++)
                {
                    if (arrayToSearch[i + j] == elementsToSearchFor[k])
                    {
                        temp++;
                    }
                }
            }

            return temp;
        }
    }
}
