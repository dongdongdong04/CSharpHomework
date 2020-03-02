using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Init(out int input, out int num);
            Shape[] myShape = new Shape[num];
            double areaSum = 0;

            switch (input)
            {
                case 1:
                    ManualInput(num, ref myShape);
                    for (int i = 0; i < num; i++)
                        areaSum += myShape[i].GetArea();
                    Console.WriteLine("这 {0} 个图形的面积之和为：{1}", num, areaSum);
                    Console.WriteLine("------------------------输 入 任 意 键 继 续--------------------------");
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("--------------------------随 机 生 成 图 形---------------------------");
                    for (int i = 0; i < num; i++)
                    {
                        ShapeFactory shapeFactory = new ShapeFactory();
                        Console.Write("第 {0} 个图形是", i);
                        myShape[i] = shapeFactory.RandomShape();
                        areaSum += myShape[i].GetArea();
                    }
                    Console.WriteLine("这 {0} 个图形的面积之和为：{1}", num, areaSum);
                    Console.WriteLine("------------------------输 入 任 意 键 继 续--------------------------");
                    break;
            }
            Console.ReadKey();
        }

        //初始化
        static void Init(out int input, out int num)
        {
            Console.WriteLine("---------------------------CSharpHomework3----------------------------");
            Console.WriteLine("功能：手动或随机生成若干长方形、正方形、三角形、圆形，并输出其面积和。");
            Console.WriteLine("1 - 人工输入      2 - 随机生成");
            Console.Write("请选择生成方式（请输入汉字前对应字符）：");
            while (!IsLegalInput(out input) || input != 1 && input != 2 && input != 0) ;
            Console.Write("请输入生成个数（请输入20以内的正整数）：");
            while (!IsLegalInput(out num) || num < 0 && num >= 20);
        }

        //判断输入合法性
        static bool IsLegalInput(out int numInput)
        {
            bool flag;
            flag = int.TryParse(Console.ReadLine(), out numInput);
            if (flag == false) Console.Write("输入不合法！请重新输入：");
            else flag = true;
            return flag;
        }
        static bool IsLegalInput(out double numInput)
        {
            bool flag;
            flag = double.TryParse(Console.ReadLine(), out numInput);
            if (flag == false) Console.Write("输入不合法！请重新输入：");
            else flag = true;
            return flag;
        }

        //手动输入过程
        static void ManualInput(int num, ref Shape[] shape)
        {
            Console.Clear();
            Console.WriteLine("--------------------------手 动 生 成 图 形---------------------------");
            Console.WriteLine("1 - 生成长方形    2 - 生成正方形    3 - 生成三角形    4 - 生成圆形");
            ShapeFactory shapeFactory = new ShapeFactory();
            int input = 0;
            for (int i = 0; i < num; i++)
            {
                Console.Write("这是生成的第 {0} 个图形，请选择生成图形形状：", i + 1);
                while (!IsLegalInput(out input) || input > 4 && input < 1) ;
                double[] edge= new double[3];
                switch (input)
                {
                    case 1:
                        Console.Write("请输入长方形的长：");
                        while (!IsLegalInput(out edge[0])) ;
                        Console.Write("请输入长方形的宽：");
                        while (!IsLegalInput(out edge[1])) ;
                        break;
                    case 2:
                        Console.Write("请输入正方形的长：");
                        while (!IsLegalInput(out edge[0])) ;
                        break;
                    case 3:
                        Console.Write("请输入三角形第一条边：");
                        while (!IsLegalInput(out edge[0])) ;
                        Console.Write("请输入三角形第二条边：");
                        while (!IsLegalInput(out edge[1])) ;
                        Console.Write("请输入三角形第三条边：");
                        while (!IsLegalInput(out edge[2])) ;
                        break;
                    case 4:
                        Console.Write("请输入圆的半径：");
                        while (!IsLegalInput(out edge[0])) ;
                        break;
                }
                shape[i] = shapeFactory.CreateShape(input - 1, edge);
            }
        }
    }

    class ShapeFactory
    {
        Random r = new Random();
        private Shape myShape = null;
        public Shape CreateShape(int type, double[] args)
        {
            switch (type)
            {
                case 0:
                    myShape = new Rectangle(args[0], args[1]);
                    break;
                case 1:
                    myShape = new Square(args[0]);
                    break;
                case 2:
                    myShape = new Triangle(args[0], args[1], args[2]);
                    break;
                case 3:
                    myShape = new Circle(args[0]);
                    break;
                default:
                    break;
            }
            return myShape;
        }
        public Shape RandomShape()
        {
            int flag = r.Next() % 4;
            double[] args = { r.Next(100), r.Next(100), r.Next(100) };
            switch (flag)
            {
                case 0:
                    myShape = new Rectangle(args[0], args[1]);
                    Console.WriteLine("长方形，长为{0}，宽为{1}", args[0], args[1]);
                    break;
                case 1:
                    myShape = new Square(args[0]);
                    Console.WriteLine("正方形，边长为{0}", args[0]);
                    break;
                case 2:
                    myShape = new Triangle(args[0], args[1], args[2]);
                    Console.WriteLine("三角形，三边边长为{0}，{1}，{2}", args[0], args[1], args[2]);
                    break;
                case 3:
                    myShape = new Circle(args[0]);
                    Console.WriteLine("圆形，半径为{0}", args[0]);
                    break;
                default:
                    break;
            }
            return myShape;
        }
    }

    abstract class Shape
    {
        public abstract double GetArea();
        public abstract bool IsLegal();
    }

    class Rectangle : Shape
    {
        public Rectangle(double width,double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea()
        {
            if (!IsLegal()) return -1;
            return Width * Height;
        }

        public override bool IsLegal()
        {
            return ((Width > 0) && (Height > 0)) ? true : false;
        }

        public double Width { get; set; }
        public double Height { get; set; }
    }

    class Square : Shape
    {
        public Square(double length)
        {
            Length = length;
        }

        public override double GetArea()
        {
            if (!IsLegal()) return -1;
            return Length * Length;
        }

        public override bool IsLegal()
        {
            return (Length > 0) ? true : false;
        }
        public double Length { get; set; }
    }

    class Triangle : Shape
    {
        private double[] edge = new double[3];
        //private double a, b, c;

        public Triangle(double a, double b, double c)
        {
            //this.a = a;
            //this.b = b;
            //this.c = c;
            edge[0] = a;
            edge[1] = b;
            edge[2] = c;
        }

        public override double GetArea()
        {
            if (!IsLegal()) return -1;
            double p = (edge[0] + edge[1] + edge[2]) / 2;
            return Math.Sqrt(p * (p - edge[0]) * (p - edge[1]) * (p - edge[2]));
        }

        public override bool IsLegal()
        {
            if (edge[0] > 0 && edge[1] > 0 && edge[2] > 0 && 
                edge[0] + edge[1] > edge[2] && edge[0] + edge[2] > edge[1] && edge[1] + edge[2] > edge[0]) return true;
            return false;
        }

        public double this[int num]
        {
            get => edge[num];
            set => edge[num] = value;
        }
    }

    class Circle : Shape
    {
        static double PI = 3.1415926;

        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double GetArea()
        {
            if (!IsLegal()) return -1;
            return Math.Pow(Radius, 2.0) * PI;
        }

        public override bool IsLegal()
        {
            return (Radius > 0) ? true : false;
        }
        public double Radius { get; set; }
    }
}
