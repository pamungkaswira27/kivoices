using System.Collections.Generic;
using UnityEngine;

namespace Kivoices.Scripts.Utility
{
    public static class ListExtension<T>
    {
        public static List<T> ShuffleList(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                T temp = list[i];
                int randomIndex = Random.Range(0, i + 1);

                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }

            return list;
        }
    }
}