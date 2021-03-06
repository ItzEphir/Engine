using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ActiveButton : ClassicButton
    {
        Color activeColor;
        Color activeColorTitle;

        public ActiveButton(Vector2f Resolution, Vector2f OriginalResolution, string message, Vector2f coords, Vector2f size,
            Color color, Color activeColor, Color colorTitle, Color activeColorTitle, Vector2f hitbox,
            ButtonAction whenPressed, ButtonAction whenAimed, ButtonAction whenReleased,
            string font = "", uint fontSize = 20, uint delay = 120, byte center = 0, bool automaticalOptimisationSize = true)
            :base(Resolution, OriginalResolution, message, coords, size, color, colorTitle, hitbox, whenPressed, whenAimed, whenReleased, font, fontSize, delay, center, automaticalOptimisationSize)
        { 
            this.activeColor = activeColor; 
            this.activeColorTitle = activeColorTitle; 
        }

        public ActiveButton(Vector2f Resolution, Vector2f OriginalResolution, string message, Vector2f coords, Vector2f size,
            Color color, Color activeColor, Color colorTitle, Color activeColorTitle, Vector2f hitbox,
            string font = "", uint fontSize = 20, uint delay = 120, byte center = 0, bool automaticalOptimisationSize = true)
            : base(Resolution, OriginalResolution, message, coords, size, color, colorTitle, hitbox, font, fontSize, delay, center, automaticalOptimisationSize)
        {
            this.activeColor = activeColor;
            this.activeColorTitle = activeColorTitle;
        }

        public override void Draw(RenderWindow rw)
        {
            if (this.Find(new Vector2f(Mouse.GetPosition(rw).X, Mouse.GetPosition(rw).Y)))
            {
                if (this.activeColor.A != 0)
                    Functions.Rectangle(rw, this.coords, this.size, this.activeColor);
            }
            else if (this.color.A != 0)
                Functions.Rectangle(rw, this.coords, this.size, this.color);

            if (this.Find(new Vector2f(Mouse.GetPosition(rw).X, Mouse.GetPosition(rw).Y)))
            {
                if (this.activeColorTitle.A != 0)
                    rw.PrintText(this.message, this.textCoords, this.fontSize, this.activeColorTitle, this.font);
            }
            else
                rw.PrintText(this.message, this.textCoords, this.fontSize, this.colorTitle, this.font);
        }

        public override void Update(RenderWindow rw)
        {
            base.Update(rw);
        }

        public void ChangeColor(Color color, Color activeColor, Color colorTitle)
        {
            this.color = color;
            this.activeColor = activeColor;
            this.colorTitle = colorTitle;
        }

        public void ChangeColor(Color color, Color activeColor, Color colorTitle, Color activeColorTitle)
        {
            this.color = color;
            this.activeColor = activeColor;
            this.colorTitle = colorTitle;
            this.activeColorTitle = activeColorTitle;
        }
    }
}
