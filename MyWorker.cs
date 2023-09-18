namespace Example.PrerenderingWithWorkers;

public class MyWorker : IMyWorker
{
    public async Task<int> Add(int a, int b)
    {
        return a + b;
    }
}