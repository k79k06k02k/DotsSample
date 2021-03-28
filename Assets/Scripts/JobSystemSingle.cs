using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class JobSystemSingle : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < 1000; i++)
        {
            NativeArray<float> values = new NativeArray<float>(500, Allocator.TempJob);
            var                job    = new Job() {values = values, offset = 5};

            JobHandle jobHandle = job.Schedule();
            jobHandle.Complete();
            values.Dispose();
        }
    }
}