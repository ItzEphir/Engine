using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace Engine
{
    public abstract class Button : IDrawable
    {
        public bool ButtonPressed { get; protected set; }
        public bool ButtonAimed { get; protected set; }

        public delegate void ButtonPressing();
        public event ButtonPressing ButtonEventPressed;

        public delegate void ButtonAiming();
        public event ButtonAiming ButtonEventAimed;

        protected Vector2f coords;
        protected Vector2f textCoords;
        protected Vector2f size;
        protected Color color;
        protected Color colorTitle;
        protected Vector2f hitbox;
        protected Font font = new("files/font/ArialRegular.ttf");
        protected string message = "";
        protected uint fontSize;
        protected uint delay;
        protected bool buttonPressed;
        protected float textLength;
        protected float letterLength;

        protected Button(Vector2f Resolution, Vector2f OriginalResolution, string message, Vector2f coords, Vector2f size, Color color, Color colorTitle, Vector2f hitbox, ButtonPressing whenPressed, ButtonAiming whenAimed,
            string font = "", uint fontSize = 20, uint delay = 120, byte center = 0, bool automaticalOptimizationSize = true)
        {
            this.message = message;

            if (!(font == "")) this.font = new(font);

            if (automaticalOptimizationSize) this.fontSize = (uint)(Resolution.Y * fontSize / OriginalResolution.Y);
            else this.fontSize = fontSize;

            this.textLength = new Text(this.message, this.font, this.fontSize).GetLocalBounds().Width;
            this.letterLength = new Text("A", this.font, this.fontSize).GetLocalBounds().Width;

            if (hitbox == new Vector2f(0, 0)) this.hitbox = new Vector2f(-this.letterLength, 0);
            else this.hitbox = hitbox;

            if (size == new Vector2f(0, 0)) this.size = new Vector2f(this.textLength, this.fontSize * 2);
            else this.size = size;

            switch (center)
            {
                case 0: this.coords = coords; break;
                case 1: this.coords = new Vector2f(coords.X - this.size.X / 2, coords.Y); break;
                case 2: this.coords = new Vector2f(coords.X - this.size.X, coords.Y); break;
                default: throw new ArgumentException("Centered can be 0, 1 or 2 what means left, center, and right");
            }

            this.textCoords = new Vector2f(this.coords.X, this.coords.Y);

            this.coords += this.hitbox;
            this.size -= 2 * this.hitbox;

            this.color = color;
            this.colorTitle = colorTitle;
            this.delay = delay;
            this.buttonPressed = false;
            this.ButtonPressed = false;

            this.ButtonEventPressed += whenPressed;
            this.ButtonEventAimed += whenAimed;
        }
        protected Button(Vector2f Resolution, Vector2f OriginalResolution, string message, Vector2f coords, Vector2f size, Color color, Color colorTitle, Vector2f hitbox,
            string font = "", uint fontSize = 20, uint delay = 120, byte center = 0, bool automaticalOptimizationSize = true)
        {
            this.message = message;

            if (!(font == "")) this.font = new(font);

            if (automaticalOptimizationSize) this.fontSize = (uint)(Resolution.Y * fontSize / OriginalResolution.Y);
            else this.fontSize = fontSize;

            this.textLength = new Text(this.message, this.font, this.fontSize).GetLocalBounds().Width;
            this.letterLength = new Text("A", this.font, this.fontSize).GetLocalBounds().Width;

            if (hitbox == new Vector2f(0, 0)) this.hitbox = new Vector2f(-this.letterLength, 0);
            else this.hitbox = hitbox;

            if (size == new Vector2f(0, 0)) this.size = new Vector2f(this.textLength, this.fontSize * 2);
            else this.size = size;

            switch (center)
            {
                case 0: this.coords = coords; break;
                case 1: this.coords = new Vector2f(coords.X - this.size.X / 2, coords.Y); break;
                case 2: this.coords = new Vector2f(coords.X - this.size.X, coords.Y); break;
                default: throw new ArgumentException("Centered can be 0, 1 or 2 what means left, center, and right");
            }

            this.textCoords = new Vector2f(this.coords.X, this.coords.Y);

            this.coords += this.hitbox;
            this.size -= 2 * this.hitbox;

            this.color = color;
            this.colorTitle = colorTitle;
            this.delay = delay;
            this.buttonPressed = false;
            this.ButtonPressed = false;

            this.ButtonEventPressed += () => { };
            this.ButtonEventAimed += () => { };
        }

        public abstract void Draw(RenderWindow rw);

        public abstract void Update(RenderWindow rw);

        protected bool Find(Vector2f mouse)
        {
            if(this.coords.X < mouse.X && mouse.X < this.coords.X + this.size.X && this.coords.Y < mouse.Y && mouse.Y < this.coords.Y + this.size.Y)
            {
                return true;
            }
            return false;
        }

        public void ChangeColor(Color color)
        {
            this.color = color;
        }

        public void ChangeColor(Color color, Color colorTitle)
        {
            this.color = color;
            this.colorTitle = colorTitle;
        }

        protected void aim()
        {
            this.ButtonEventAimed?.Invoke();
        }

        protected void pressed()
        {
            this.ButtonEventPressed?.Invoke();
        }
    }
}
