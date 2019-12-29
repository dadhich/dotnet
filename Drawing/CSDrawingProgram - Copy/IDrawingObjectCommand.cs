namespace CSDrawingProgram
{
    public interface IDrawingObjectCommand
    {
        void DrawMe();
        IDrawingObjectCommand ValidateInputReturnObject(string[] input);
    }
}