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
    

        SpriteText SpriteName;
        SpriteTexture ShipSprite;
        float TopSpeed = 5;
        float Acceleration = 0.1f;
        Vector2 Velocity = new Vector2(0, 0);
        Vector2 direction;
        public float drag = 0.03f;
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
        public Vector2 Pos { get { return ShipSprite.position; } }
        public float Rotation { get { return ShipSprite.rotation; } }

        public Rectangle? BoundingBox { get { return null; } }
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
            SpriteName = Name.SetText("Sprite");


        }
        #endregion


        #region update
        public void Update(Microsoft.Xna.Framework.GameTime gameTime, GameCore game1)
        {
          
            #region rotation
            Vector2 Target = game1.CurentMousePos();//new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            float? TRotation = LibTranslation.LookAtPoint(ShipSprite.position, Target);
            if (TRotation.HasValue)
                ShipSprite.rotation = TRotation.Value;

            #endregion

            #region Movement

            direction = new Vector2(0, 0);
            //key handeler
            if (game1.CurrentKeyState(Keys.W) != KeyEventStates.Up)
            { direction.Y += 1; }

            if (game1.CurrentKeyState(Keys.S) != KeyEventStates.Up)
            { direction.Y -= 1; }
            //workout velocity
            Vector2 movementDirection = new Vector2((float)Math.Sin(ShipSprite.rotation), -(float)Math.Cos(ShipSprite.rotation));
            Velocity += Acceleration * direction.Y * movementDirection;
            //limit top speed
            if (!(Velocity.Length() < 5))
            {
                Velocity.Normalize();
                Velocity *= TopSpeed;

            }
            //set pos of sprite           
            ShipSprite.position += Velocity;
            //set the text position
            SpriteName.position = Pos - new Vector2(ShipSprite.origin.X / 2, ShipSprite.origin.Y) - SpriteName.TextSize + new Vector2(SpriteName.TextWidth / 2, 0);

            #endregion




            #region Drag
            if (direction.Y == 0 && Velocity.LengthSquared() != 0)
            {

                float dragforcemag = Velocity.Length() * (1 - drag);
                Velocity.Normalize();
                Velocity = dragforcemag * Velocity;

            }
            #endregion



        }


        public void Colision(IColideable C)
        {

        }

       public bool IsColiding(IColideable a)
        {
            return Lib.LibCollision.CircleColiding(a, this);
        }

        #endregion

    }
}
