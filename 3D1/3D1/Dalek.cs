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
        
        float spin = 0.0f;      // Spin speed

        public override void LoadContent()
        {
            base.LoadContent();

            speed = 100.0f;     // Movement speed

            // Load 3D model
            model = Game1.Instance.Content.Load<Model>("dalek");
        }

        public override void Update(GameTime gameTime)
        {
            // Get elapsed time in seconds
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Get key pressed
            KeyboardState keyState = Keyboard.GetState();

            spin += timeDelta;
        }

        public override void Draw(GameTime gameTime)
        {
            // Calculate matrices of world, view and projection
            world = Matrix.CreateRotationY(spin) * Matrix.CreateTranslation(pos);
            view = Matrix.CreateLookAt(cameraPos, cameraPos + cameraLook, cameraUp);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 800.0f / 400.0f, 1.0f, 1000.0f);

            // Draw each part object in the model mesh
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
        }
    }
}
