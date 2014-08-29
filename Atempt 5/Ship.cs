using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
    class Player1Ship:IUpdateable
    {

       SpriteTexture ShipSprite;
       float TopSpeed= 5;
       float Acceleration = 0.1f;
       float Deceleration = 0.05f;
      // float RotationSpeed = 0.1f;
       Vector2 Velocity= new Vector2(0,0);
       
        
        public Player1Ship(SpriteTexture ShipSprite,Game1 game)
        {
         this.ShipSprite = ShipSprite;
        // var rec = ShipSprite.CreateRectangle(new Vector2(0, 0));              
        // ShipSprite.srcrectangle = rec;
         // ShipSprite.origin = 
         
         //window.Updatable.Add(Name,this);
        }
        
        public void Update(Microsoft.Xna.Framework.GameTime gameTime, Game1 game1)
        {
            var keys=Keyboard.GetState();
            bool movingY = false;
           if (keys.IsKeyDown(Keys.W))
           { var movement =  new Vector2((float)(-Acceleration * Math.Sin(ShipSprite.rotation)), (float)(Acceleration * Math.Cos(ShipSprite.rotation)));
              if ((Velocity-movement).Length()< TopSpeed)
              {
                  Velocity -=movement;
              }
              else
              {
                  Velocity =-1* new Vector2((float)(-TopSpeed * Math.Sin(ShipSprite.rotation)), (float)(TopSpeed * Math.Cos(ShipSprite.rotation)));
              }
               movingY = true;
           }
           if (keys.IsKeyDown(Keys.S))
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

           //if (keys.IsKeyDown(Keys.D))
           //{
           //    ShipSprite.rotation += RotationSpeed;

           //}
           //if (keys.IsKeyDown(Keys.A))
           //{
           //    ShipSprite.rotation -= RotationSpeed;

           //}
           ShipSprite.rotation = SpriteTexture.LookAtPoint(ShipSprite.position,new Vector2( Mouse.GetState().Position.X,Mouse.GetState().Position.Y));

           ShipSprite.position += Velocity;
            if (Velocity.Y !=0 && !movingY)
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



       
       
    }
}
