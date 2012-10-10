using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3D1
{
    class Dalek : Entity3D
    {
        //Vector3 centre;
        float spin = 0.0f;

        public override void LoadContent()
        {
            base.LoadContent();

            speed = 100.0f;
            Alive = true;

            model = Game1.Instance.Content.Load<Model>("dalek");

            //centre.X = model.Width / 2;
            //centre.Y = model.Height / 2;
            //centre.Z = model.Depth / 2;
        }

        public override void Update(GameTime gameTime)
        {
            float timeDelta = gameTime.ElapsedGameTime.Seconds;

            KeyboardState keyState = Keyboard.GetState();

            // Calculate the orientation vector for the tank
            //look.X = (float)Math.Sin(rotation);
            //look.Y = (float)-Math.Cos(rotation);
            //look.Z = (float)-Math.Cos(rotation);

            spin += timeDelta;
        }

        public override void Draw(GameTime gameTime)
        {
            world = Matrix.CreateRotationY(spin) * Matrix.CreateTranslation(pos);
            view = Matrix.CreateLookAt(cPos, cPos + cLook, cUp);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 800.0f / 400.0f, 1.0f, 1000.0f);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = world;
                    effect.Projection = projection;
                    effect.View = view;
                }
                mesh.Draw();
            }
            //Game1.Instance.spriteBatch.Draw(model, pos, null, Color.White, look, centre, Vector3.One, SpriteEffects.None, 1);
        }
    }
}
