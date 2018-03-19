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
        public SquareDrawer(GraphicsDevice gd, Texture2D tex)
        {
            this.rectTex = tex;
        }

        public void Draw(SpriteBatch sb, Color color, Rectangle rectangle)
        {
            sb.Draw(rectTex, rectangle, color);
        }
    }
}