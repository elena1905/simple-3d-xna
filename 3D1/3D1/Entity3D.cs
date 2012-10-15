using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3D1
{
    public class Entity3D
    {
        // Class members
        // 3D model variables
        public Vector3 pos;
        public Vector3 look;

        // Camera variables
        public Vector3 cameraPos, cameraLook, cameraUp, cameraRight;

        public float speed;

        public Model model;
        public Matrix world, view, projection;

        // Indicate if the entity is alive
        public bool Alive { get; set; }

        public virtual void Initialize()
        {
            Alive = true;

            pos = new Vector3(0, 0, -20);
            
            cameraPos = new Vector3(0, 6, 0);
            cameraLook = new Vector3(0, 0, -1);
            cameraRight = new Vector3(1, 0, 0);
            cameraUp = new Vector3(0, 1, 0);
        }

        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
    }
}
