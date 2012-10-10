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
        public Vector3 pos;
        public Vector3 look;
        public Vector3 cPos, cLook, cUp, cRight;

        public float speed;

        public Model model;
        public Matrix world, view, projection;

        public bool Alive { get; set; }

        public virtual void Initialize()
        {
            Alive = true;

            pos = new Vector3(0, 0, -20);
            
            cPos = new Vector3(0, 6, 0);
            cLook = new Vector3(0, 0, -1);
            cRight = new Vector3(1, 0, 0);
            cUp = new Vector3(0, 1, 0);
        }

        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
    }
}
