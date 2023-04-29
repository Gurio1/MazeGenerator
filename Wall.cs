namespace MazeGenerator
{
    public class Wall
    {
        public bool IsBroken { get; private set; }

        public void Destroy()
        {
            IsBroken = true;
        }
    }
}