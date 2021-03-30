using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Jobs;
using UnityEngine;


public class BurstWithHeapObject : MonoBehaviour
{
    private void Start()
    {
        var test   = new BurstHeap();
        var handle = test.Schedule();
        handle.Complete();
    }
}
