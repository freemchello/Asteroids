using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Iterator.Scripts.Coroutines
{
    public class ForeachExample : MonoBehaviour
    {
        [ContextMenu("TestForeachLoopWithExplicitEnumerator")]
        private void TestForeachLoopWithExplicitEnumerator()
        {
            foreach (var element in GetNumbersEnumerator())
            {
                Debug.Log($"ForeachExample.TestForeachLoopWithExplicitEnumerator: {element}");
            }
        }

        private IEnumerable GetNumbersEnumerator()
        {
            yield return 3;
            yield return 5;
            yield return 8;
        }

        [ContextMenu("TestEndlessList")]
        private void TestEndlessList()
        {
            var protection = 0;
            foreach (var element in EndlessList())
            {
                protection += 1;
                if (protection == 10)
                    return;

                Debug.Log($"ForeachExample.TestEndlessList: element = {element}");
            }
        }

        private IEnumerable EndlessList()
        {
            var i = 0;
            while (true)
            {
                i += 1;
                yield return i;
            }
        }

        [ContextMenu("TestNotSoEndlessList")]
        private void TestNotSoEndlessList()
        {
            foreach (var element in NotSoEndlessList(3))
            {
                Debug.Log($"ForeachExample.TestNotSoEndlessList: element = {element}");
            }
        }

        private IEnumerable NotSoEndlessList(int count)
        {
            var i = 0;
            while (i < count)
            {
                i += 1;
                yield return i;
            }
        }

        [ContextMenu("TestFibonacci")]
        private void TestFibonacci()
        {
            foreach (var element in Fibonacci().Take(10))
            {
                Debug.Log($"ForeachExample.TestFibonacci: element = {element}");
            }
        }

        private IEnumerable<int> Fibonacci()
        {
            yield return 0;
            yield return 1;

            var i = 0;
            var j = 1;
            int next;
            while (true)
            {
                next = i + j;

                i = j;
                j = next;

                yield return next;
            }
        }
    }
}