using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

[BurstCompile]
public struct Job : IJob
{
    public NativeArray<float> values;
    public float              offset;
    
    public void Execute()
    {
        for (var i = 0; i < values.Length; i++)
        {
            values[i] = i / offset;
        }
    }
}

[BurstCompile]
public struct JobParallel : IJobParallelFor
{
    [WriteOnly]
    public NativeArray<float> values;
    
    [ReadOnly]
    public float              offset;
    
    public void Execute(int index)
    {
        values[index] = index / offset;
    }
}

[BurstCompile]
public struct JobOtherDataParallel : IJobParallelFor
{
    [ReadOnly]
    public NativeArray<int> array;
    
    [WriteOnly]
    public NativeQueue<int>.ParallelWriter queue;
    
    public void Execute(int index)
    {
        queue.Enqueue(array[index]);
    }
}


public class TestData
{
    public int value;
}

[BurstCompile]
public struct BurstHeap : IJob
{
    public void Execute()
    {
        DiscardMethod();
    }

    [BurstDiscard]
    private void DiscardMethod()
    {
        var test = new TestData() {value = 1};
    }
}
