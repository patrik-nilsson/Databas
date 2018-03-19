using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Morters_Kundapp
{
    class SquareDrawer
    {
        Texture2D rectTex;
        Vector2 windowSize;
        public SquareDrawer(GraphicsDevice gd, Vector2 windowSize, Texture2D tex)
        {
            this.rectTex = tex;
            this.windowSize = windowSize;
        }

        public void Draw(SpriteBatch sb, Color color, Rectangle rectangle)
        {
            sb.Draw(rectTex, rectangle, color);
        }
    }
}