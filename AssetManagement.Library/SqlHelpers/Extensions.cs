using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Library.SqlHelpers
{
    internal static class Extensions
    {
        public static IEnumerable<TFirst> MapChild<TFirst, TSecond, TKey>
            (
            this SqlMapper.GridReader reader,
            List<TFirst> parent,
            List<TSecond> child,
            Func<TFirst, TKey> firstKey,
            Func<TSecond, TKey> secondKey,
            Action<TFirst, IEnumerable<TSecond>> addChildren
            )
        {
            var childMap = child
                .GroupBy(secondKey)
                .ToDictionary(g => g.Key, g => g.AsEnumerable());
            foreach (var item in parent)
            {
                IEnumerable<TSecond> children;
                if (childMap.TryGetValue(firstKey(item), out children))
                {
                    addChildren(item, children);
                }
            }
            return parent;
        }
    }
}
