using System.Collections.Generic;
using System.Linq;

namespace TankProject
{
    public class Service1 : IService1
    {
        static List<Point> points = new List<Point>();

        public string MoveUP(string value)
        {
            return points.First(x => x.Ip == value).MoveUP().GetCoor();
        }

        public string MoveLeft(string value)
        {
            return points.First(x => x.Ip == value).MoveLeft().GetCoor();
        }

        public string MoveRight(string value)
        {
            return points.First(x => x.Ip == value).MoveRight().GetCoor();
        }

        public string MoveDOWN(string value)
        {
            return points.First(x => x.Ip == value).MoveDOWN().GetCoor();
        }

        public string Start(string value)
        {
            if (points.Count < 30)
            {
                if (!points.Any(x => x.Ip == value))
                {
                    if (points.Count == 0)
                    {
                        points.Add(new Point(value, 0, 0));
                    }
                    else
                    {
                        points.Add(new Point(value, points.Last().X + (GetSize() * 3), points.Last().Y + 25));
                    }
                }
            }
            else
            {
                return null;
            }

            return points.First(x => x.Ip == value).GetCoor();
        }

        public List<string> GetPoints()
        {
            return points.ConvertAll<string>(x => x.ToString());
        }

        public int GetSize()
        {
            return 25;
        }
    }
}