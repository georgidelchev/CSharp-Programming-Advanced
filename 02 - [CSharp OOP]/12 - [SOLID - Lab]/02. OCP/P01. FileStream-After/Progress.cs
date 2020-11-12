namespace P01._FileStream_After
{
    using Contracts;
    public class Progress
    {
        private readonly IResult result;

        public Progress(IResult result)
        {
            this.result = result;
        }

        public int CurrentPercent()
        {
            return this.result.Sent * 100 / this.result.Length;
        }
    }
}
