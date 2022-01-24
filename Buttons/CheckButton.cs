using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Engine
{
    public class CheckButton : ClassicButton
    {
        public CheckButton(Vector2f Resolution, Vector2f OriginalResolution, string message, Vector2f coords, Vector2f size, Color color, Color colorTitle, Vector2f hitbox, ButtonPressing whenPressed, ButtonAiming whenAimed,
            string font = "", uint fontSize = 20, uint delay = 120, byte center = 0, bool automaticalOptimisationSize = true)
            : base(Resolution, OriginalResolution, message, coords, size, color, colorTitle, hitbox, whenPressed, whenAimed, font, fontSize, delay, center, automaticalOptimisationSize) { }

        public CheckButton(Vector2f Resolution, Vector2f OriginalResolution, string message, Vector2f coords, Vector2f size, Color color, Color colorTitle, Vector2f hitbox,
            string font = "", uint fontSize = 20, uint delay = 120, byte center = 0, bool automaticalOptimisationSize = true)
            : base(Resolution, OriginalResolution, message, coords, size, color, colorTitle, hitbox, font, fontSize, delay, center, automaticalOptimisationSize) { }

        public override void Draw(RenderWindow rw)
        {
            base.Draw(rw);
        }

        public override void Update(RenderWindow rw)
        {
            this.click = Mouse.IsButtonPressed(Mouse.Button.Left);
            Vector2f mouse = new Vector2f(Mouse.GetPosition(rw).X, Mouse.GetPosition(rw).Y);

            if (this.delay == 0)
            {
                if (this.Find(new Vector2f(Mouse.GetPosition(rw).X, Mouse.GetPosition(rw).Y)))
                {
                    this.ButtonAimed = true;
                    this.aim();
                    if (this.click) this.buttonPressed = true;
                    else if (this.buttonPressed) this.buttonPressed = false; this.ButtonPressed = true; this.pressed(); return;
                }
            }
            else this.delay--;
            this.ButtonPressed = false;
        }
    }
}
