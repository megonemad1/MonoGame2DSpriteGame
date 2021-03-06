﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
    public class SpriteTexture : IDrawable
    {

        Vector2 SpriteWH;
        public Texture2D Texture;
        public Microsoft.Xna.Framework.Vector2 position;
        public Microsoft.Xna.Framework.Color hue;
        public Microsoft.Xna.Framework.Rectangle? srcrectangle;
        public float rotation;
        public Microsoft.Xna.Framework.Vector2 origin;
        public Vector2 Scale;
        public float ScaleF
        {
            set { Scale = new Vector2(value, value); }
        }
        public SpriteEffects effect;
        public int SpriteID;
        public float Depth;

        public static Microsoft.Xna.Framework.Rectangle CreateRectangle(Vector2 Frame, Texture2D texture, Vector2 SpriteSheetSize)
        {
            int TH = texture.Height;
            int TW = texture.Width;
            int SH = (int)SpriteSheetSize.Y;
            int SW = (int)SpriteSheetSize.X;
            return new Rectangle((int)Frame.X, (int)Frame.Y, TW / SW, TH / SH);

        }
        public SpriteTexture SetDefaultRectangle(Vector2 Frame)
        {
            srcrectangle = CreateRectangle(Frame);
            return this;
        }
        public Microsoft.Xna.Framework.Rectangle CreateRectangle(Vector2 Frame)
        {
            int TH = Texture.Height;
            int TW = Texture.Width;
            int SH = (int)SpriteWH.Y;
            int SW = (int)SpriteWH.X;
            return new Rectangle((int)Frame.X, (int)Frame.Y, TW / SW, TH / SH);

        }
        public void Draw(SpriteBatch SB)
        {
            if (Texture != null)
            {

                SB.Draw(this.Texture, this.position, this.srcrectangle, this.hue, this.rotation, this.origin, this.Scale, this.effect, this.Depth);


            }
            else
            {


                Console.WriteLine("texture " + SpriteID + " is null");

            }

        }
        public SpriteTexture(int SpriteID, Texture2D texture, Vector2 SpriteHW)
        {
            this.hue = Color.White;
            this.position = new Vector2(0, 0);
            this.Depth = 0.5f;
            this.SpriteID = SpriteID;
            rotation = 0f;
            srcrectangle = null;
            origin = new Vector2(0, 0);
            ScaleF = 1;
            effect = SpriteEffects.None;
            Texture = texture;
            this.SpriteWH = SpriteHW;
        }
        public SpriteTexture SetDepth(float Depth)
        {
            this.Depth = Depth;
            return this;
        }
        public SpriteTexture SetPosition(Vector2 Position)
        {
            this.position = Position;
            return this;
        }



        internal SpriteTexture SetOrigenCenter()
        {
            if (srcrectangle.HasValue)
            {
                Rectangle rec = this.srcrectangle.Value;
                origin = new Vector2((float)(rec.X * rec.Width + rec.Width / 2), (float)(rec.Y * rec.Height + rec.Height / 2));
            }
            else
            {
                origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            }
            return this;
        }
    }

}
