using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Collision_Detection
{
    class AABB
    {
        private float x;
        private float y;
        private float width;
        private float height;

        public AABB(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public bool Intersects(AABB r2)
        {
            if(x > r2.GetMaxX())
            {
                Console.WriteLine("1");
                return false;
            }
            if(x + width < r2.GetMinX())
            {
                Console.WriteLine("2");
                return false;
            }
            if(y > r2.GetMaxY())
            {
                Console.WriteLine("3");
                return false;
            }
            if(y + height < r2.GetMinY())
            {
                Console.WriteLine("4");
                return false;
            }
            Console.WriteLine("5");
            return true;

        }

        public float GetMinX()
        {
            return x;
        }
        public float GetMaxX()
        {
            return x + width;
        }
        public float GetMinY()
        {
            return y;
        }
        public float GetMaxY()
        {
            return y + height;
        }

        public float Getx()
        {
            return x;
        }
        public float Gety()
        {
            return y;
        }
        public float GetHeight()
        {
            return height;
        }
        public float GetWidth()
        {
            return width;
        }
    }
}
