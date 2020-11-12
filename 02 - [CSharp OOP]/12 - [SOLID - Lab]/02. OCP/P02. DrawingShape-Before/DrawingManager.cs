namespace P02._DrawingShape_Before
{
    using Contracts;

    class DrawingManager : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            if (shape is Circle)
            {
                this.DrawCircle(shape as Circle);
            }
            else if (shape is Rectangle)
            {
                this.DrawRectangle(shape as Rectangle);
            }
        }

        public void DrawCircle(Circle circle)
        {
            // Draw Circle
        }

        public void DrawRectangle(Rectangle rectangle)
        {
            // Draw Rectangle
        }
    }
}
