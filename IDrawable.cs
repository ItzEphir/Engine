using SFML.Graphics;

namespace Engine
{
    public interface IDrawable
    {
        public void Draw(RenderWindow rw);

        public void Update(RenderWindow rw);
    }
}
