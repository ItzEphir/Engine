using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace Engine
{
    public static class Functions
    {
        public static void PrintText(this RenderWindow rw, string message, Vector2f coords, uint size, Color color, Font font, uint mode = 0)
        {
            Font font_type;
            if (font != null)
            {
                font_type = new Font(font);
            }
            else
            {
                font_type = new Font("files/font/ArialRegular.ttf");
            }

            Text text = new Text(message, font_type);
            text.CharacterSize = size;
            float textLength = text.GetLocalBounds().Width;


            switch (mode)
            {
                case 0:
                    text.Position = coords;
                    break;
                case 1:
                    text.Position = new Vector2f(coords.X - textLength / 2, coords.Y);
                    break;
                case 2:
                    text.Position = new Vector2f(coords.X - textLength, coords.Y);
                    break;
                default: throw new ArgumentOutOfRangeException("mode can be only 0, 1 or 2 what means right, center or left");
            }
            text.FillColor = color;

            rw.Draw(text);
        }

        public static float Distance(this Vector2f a, Vector2f b) // найти расстояние от одного вектора до другого по теореме Пифагора
        {
            Vector2f diff = a - b;
            return MathF.Sqrt(MathF.Pow(diff.X, 2) + MathF.Pow(diff.Y, 2));
        }

        public static float Distance(this Vector2f a) // найти длину вектора
        {
            return MathF.Sqrt(MathF.Pow(a.X, 2) + MathF.Pow(a.Y, 2));
        }

        public static Vector2f Normalise(this Vector2f a) // вычисляем вектор направления
        {
            float length = a.Distance();
            Vector2f dir = a / length;
            return dir;
        }

        public static Vector2f Normalise(this Vector2f a, Vector2f b) // вектор направления двух векторов
        {
            float length = a.Distance(b);
            Vector2f dir = (a - b) / length;
            return dir;
        }

        public static string Load(string filename)
        {
            using(FileStream fs = new FileStream(filename, FileMode.Open))
            {
                string info;
                byte[] text = new byte[fs.Length];
                fs.Read(text, 0, text.Length);
                info = System.Text.Encoding.Default.GetString(text);
                return info;
            }
        }

        public static void Save(string filename, string info)
        {
            using(FileStream fs = new FileStream(filename, FileMode.Truncate))
            {
                byte[] text = System.Text.Encoding.Default.GetBytes(info);
                fs.Write(text, 0, text.Length);
            }
        }

        public static void Rectangle(RenderWindow rw, Vector2f coords, Vector2f size, Color color)
        {
            RectangleShape rect = new RectangleShape();
            rect.Position = coords;
            rect.Size = size;
            rect.FillColor = color;
            rw.Draw(rect);
        }

        public static void NormalFloat(this ref float numb, float accuracy)
        {
            float multiplier = 1 / accuracy;
            numb += accuracy;
            numb *= multiplier;
            numb = (float)((int)numb) / multiplier;
        }
    }
}
