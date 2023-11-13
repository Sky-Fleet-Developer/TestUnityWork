using System.Threading.Tasks;
using UnityEngine;

namespace TASK_Realisation.Utilities
{
    public static class AsyncAwaitExt
    {
        public static async Task WaitForSeconds(float seconds)
        {
            float f = Time.time + seconds;
            while (Time.time < f)
            {
                await Task.Yield();
            }
        }
    }
}