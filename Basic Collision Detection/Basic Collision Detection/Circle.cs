using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Basic_Collision_Detection
{
    class Circle
    {
        private float radius;
        private float x;
        private float y;

        public Circle (float x, float y, float radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        // Returns true if the passed in circle intersects with this circle
        public bool Intersects(Circle c2)
        {
            Vector2 dist = new Vector2(c2.Getx() - x, c2.Gety() - y);
            float distSquared = dist.LengthSquared();
            float radiiSum = c2.Getradius() + radius;
            radiiSum = radiiSum * radiiSum;
            if(radiiSum > distSquared)
            {
                return true;
            }
            return false;
        }

        public float Getx()
        {
            return x;
        }
        public float Gety()
        {
            return y;
        }
        public float Getradius()
        {
            return radius;
        }
    }
}
