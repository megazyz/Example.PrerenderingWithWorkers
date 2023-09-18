namespace Example.PrerenderingWithWorkers
{
    public interface IMyWorker
    {
        public Task<int> Add(int a, int b);
    }
}
