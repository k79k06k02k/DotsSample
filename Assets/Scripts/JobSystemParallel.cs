using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class JobSystemParallel : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < 1000; i++)
        {
            NativeArray<float> values = new NativeArray<float>(500, Allocator.TempJob);
            var                job    = new JobParallel() {values = values, offset = 5};

            JobHandle jobHandle = job.Schedule(values.Length, 32);
            jobHandle.Complete();
            values.Dispose();
        }
    }
}