using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
    class Player1Ship : IUpdateable, IColideable
    {
        #region Variables
        public Vector2 Pos { get { return ShipSprite.position; } }
        SpriteText SpriteName;
        SpriteTexture ShipSprite;
        float TopSpeed = 5;
        float Acceleration = 0.1f;
        float Deceleration = 0.05f;
        Vector2 Velocity = new Vector2(0, 0);

                #region Propertys
                public float Radius
                {
                    get
                    {
                        if (ShipSprite.srcrectangle.HasValue)
                            return (float)Math.Sqrt(ShipSprite.srcrectangle.Value.Height + ShipSprite.srcrectangle.Value.Width);
                        else
                            return (float)Math.Sqrt(ShipSprite.Texture.Height + ShipSprite.Texture.Width);
                    }
                }
                #endregion

        #endregion


        #region Constructor
                /// <summary>
        /// Constructor, requires the texture for the ship and the font it will use
        /// </summary>
        /// <param name="ShipSprite"></param>
        /// <param name="Name"></param>
        public Player1Ship(SpriteTexture ShipSprite, SpriteText Name)
        {
            this.ShipSprite = ShipSprite;
            SpriteName = Name.SetText("Player");

        }
                #endregion


        #region update
        public void Update(Microsoft.Xna.Framework.GameTime gameTime, GameCore game1)
        {
            #region Movement
            bool movingY = false;
            if (game1.CurrentKeyState(Keys.W)!= KeyEventStates.Up)
            {
                var movement = new Vector2((float)(-Acceleration * Math.Sin(ShipSprite.rotation)), (float)(Acceleration * Math.Cos(ShipSprite.rotation)));
                if ((Velocity - movement).Length() < TopSpeed)
                {
                    Velocity -= movement;
                }
                else
                {
                    Velocity = -1 * new Vector2((float)(-TopSpeed * Math.Sin(ShipSprite.rotation)), (float)(TopSpeed * Math.Cos(ShipSprite.rotation)));
                }
                movingY = true;
            }
            if (game1.CurrentKeyState(Keys.S) != KeyEventStates.Up)
            {
                var movement = new Vector2((float)(-Acceleration * Math.Sin(ShipSprite.rotation)), (float)(Acceleration * Math.Cos(ShipSprite.rotation)));
                if ((Velocity + movement).Length() < TopSpeed)
                {
                    Velocity += movement;
                }
                else
                {
                    Velocity = new Vector2((float)(-TopSpeed * Math.Sin(ShipSprite.rotation)), (float)(TopSpeed * Math.Cos(ShipSprite.rotation)));
                }
                movingY = true;
            }

            SpriteName.position = Pos - new Vector2(ShipSprite.origin.X / 2, ShipSprite.origin.Y) - SpriteName.TextSize + new Vector2(SpriteName.TextWidth / 2, 0);
            ShipSprite.position += Velocity;
            #endregion
            #region rotation
            ShipSprite.rotation = LibTranslation.LookAtPoint(ShipSprite.position, new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y));
            #endregion

            #region Drag
            if (Velocity.Y != 0 && !movingY)
            {
                if (Velocity.Y > 0)
                {
                    Velocity.Y -= Deceleration;
                }
                else
                {
                    Velocity.Y += Deceleration;
                }
            }
            if (Velocity.X != 0 && !movingY)
            {
                if (Velocity.X > 0)
                {
                    Velocity.X -= Deceleration;
                }
                else
                {
                    Velocity.X += Deceleration;
                }
            }
        }
            #endregion

        #endregion


    }
}
