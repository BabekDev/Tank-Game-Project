namespace TankProject
{
    public class Point
    {
        public string Ip { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Point(string ip, int x, int y)
        {
            this.Ip = ip;
            this.X = x;
            this.Y = y;
        }

        public string GetCoor()
        {
            return $"{X}:{Y}";
        }

        public Point MoveUP()
        {
            this.Y--;
            return this;
        }
        public Point MoveDOWN()
        {
            this.Y++;
            return this;
        }
        public Point MoveLeft()
        {
            this.X--;
            return this;
        }
        public Point MoveRight()
        {
            this.X++;
            return this;
        }

        public override string ToString()
        {
            return $"{X}:{Y}:{Ip}";
        }
    }
}