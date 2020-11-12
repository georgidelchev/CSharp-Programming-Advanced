namespace P02._Worker_After
{
    using Contracts;

    public class Manager
    {
        private readonly IWorker worker;

        public Manager(IWorker worker)
        {
            this.worker = worker;
        }

        public void Manage()
        {
            this.worker.Work();
        }
    }
}
