namespace P01._FileStream_After
{
    using Contracts;

    public  class Music : IResult
    {
        public int Length { get; set; }

        public int Sent { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }
    }
}
