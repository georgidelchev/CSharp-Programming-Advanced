namespace P02._DrawingShape_After
{
    using Contracts;

    public class RectangleDrawingManger : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var rectangle = shape as Rectangle;

            // Draw Rectangle
        }
    }
}
