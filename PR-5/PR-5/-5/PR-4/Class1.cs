using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_4
{
    class Sort<T>
    {
        /// <summary>
        /// Метод сортировки пузырьком
        /// </summary>
        public T[] Buble(T[] _my_array)
        {
            for (int i = 0; i < _my_array.Length; i++)
            {
                for (int j = 0; j < _my_array.Length - 1; j++)
                {
                    dynamic d_my_arraySort = _my_array[j], d_my_arraySort1 = _my_array[j + 1];
                    if (d_my_arraySort > d_my_arraySort1)
                    {
                        T temp = _my_array[j];
                        _my_array[j] = _my_array[j+1];
                        _my_array[j+1] = temp;
                    }
                }
            }
            return _my_array;
        }
        /// <summary>
        /// Метод сортировки выбором
        /// </summary>
        public T[] Select(T[] _my_array)
        {
            for (int i = 0; i < _my_array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < _my_array.Length; j++)
                {
                    dynamic d_my_arraySortMin = _my_array[min], d_my_arraySortJ = _my_array[j];
                    if (d_my_arraySortJ < d_my_arraySortMin)
                    {
                        min = j;
                    }
                }
                T temp = _my_array[min];
                _my_array[min] = _my_array[i];
                _my_array[i] = temp;
            }
            return _my_array;
        }
        /// <summary>
        /// Метод сортировки слиянием
        /// </summary>
        static void Merge(T[] my_array, int l, int m, int r)
        {
            int i, j, k;

            int n1 = m - l + 1;
            int n2 = r - m;

            T[] left1 = new T[n1 + 1];
            T[] right1 = new T[n2 + 1];
            dynamic a = my_array, MaxValue = 2147483647, left = left1, right = right1;
            for (i = 0; i < n1; i++)
            {
                left[i] = a[l + i];
            }

            for (j = 1; j <= n2; j++)
            {
                right[j - 1] = a[m + j];
            }
            left[n1] = MaxValue;
            right[n2] = MaxValue;

            i = 0;
            j = 0;

            for (k = l; k <= r; k++)
            {
                if (left[i] < right[j])
                {
                    a[k] = left[i];
                    i += 1;
                }
                else
                {
                    a[k] = right[j];
                    j += 1;
                }
            }
        }
        /// <summary>
        /// Рекурсивный вызов метода слияния
        /// </summary>
        public T[] MergeSort(T[] a, int l, int r)
        {
            int q;
            if (l < r)
            {
                q = (l + r) / 2;
                MergeSort(a, l, q);
                MergeSort(a, q + 1, r);
                Merge(a, l, q, r);
            }
            return a;
        }
    }
}
