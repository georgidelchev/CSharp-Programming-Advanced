namespace P01._DrawingShape_After.Contracts
{
    public interface IRenderer
    {
        void Render(IDrawingContext drawingContext, IShape shape);
    }
}
