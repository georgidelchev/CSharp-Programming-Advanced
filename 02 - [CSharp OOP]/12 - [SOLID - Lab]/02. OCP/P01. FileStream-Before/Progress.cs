namespace P01._FileStream_Before
{
    public class Progress
    {
        private readonly File file;

        public Progress(File file)
        {
            this.file = file;
        }

        public int CurrentPercent()
        {
            return this.file.Sent * 100 / this.file.Length;
        }
    }
}
