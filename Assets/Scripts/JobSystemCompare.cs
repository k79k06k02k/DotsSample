using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;
using Unity.Jobs;
using UnityEngine.Profiling;



public class JobSystemCompare : MonoBehaviour
{
    private void Update()
    {
        // Normal
        Profiler.BeginSample("Normal");
        float[] normal = new float[1000000];
        for (int i = 0; i < normal.Length; i++)
        {
            normal[i] = 1 / 5f;
        }
        Profiler.EndSample();
        
        
        // Job
        Profiler.BeginSample("Job");
        NativeArray<float> values = new NativeArray<float>(1000000, Allocator.TempJob);

        // 傳入資料
        var       job       = new Job() {values = values, offset = 5f};
        JobHandle jobHandle = job.Schedule();
        
        // 等 job 計算完畢
        jobHandle.Complete();
        
        // 釋放
        values.Dispose();
        
        Profiler.EndSample();
    }
}
    
