using System;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;


public class JobSystemOtherDataParallel : MonoBehaviour
{
    private void Start()
    {
        NativeArray<int> array = new NativeArray<int>(new int[] {0, 1, 2, 3}, Allocator.TempJob);
        NativeQueue<int> queue = new NativeQueue<int>(Allocator.TempJob);

        var job = new JobOtherDataParallel() {array = array, queue = queue.AsParallelWriter()};
        job.Run(array.Length);
        array.Dispose();
        queue.Dispose();
    }
}