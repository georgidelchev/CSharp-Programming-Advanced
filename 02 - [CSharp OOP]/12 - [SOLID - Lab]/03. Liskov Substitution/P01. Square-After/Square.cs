namespace P01._Square_After
{
    public class Square : Shape
    {
        public double Side { get; set; }

        public override double Area => this.Side * this.Side;
    }
}