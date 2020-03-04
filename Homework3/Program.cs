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
            bool flag = true;

            while (flag)
            {
                Console.Clear();
                Console.WriteLine("---------------------------CSharpHomework3----------------------------");
                Console.WriteLine("功能：手动或随机生成若干长方形、正方形、三角形、圆形，并输出其面积和。");
                Console.WriteLine("1 - 人工输入      2 - 随机生成     0 - 退出程序");
                Console.Write("请选择生成方式（请输入汉字前对应字符）：");
                string input = Console.ReadLine();
                int num = 0; double areaSum = 0;
                Shape[] myShape = null;
                switch (input)
                {
                    case "1":
                        Console.Write("请选择生成图形数目（最多生成20个）：");
                        while (!IsLegalInput(out num, 0, 20)) ;
                        myShape = new Shape[num];
                        ManualInput(num, ref myShape);
                        int fail = 0;
                        for (int i = 0; i < num; i++)
                        {
                            if (myShape[i].GetArea() == -1) fail++;
                            else areaSum += myShape[i].GetArea();
                        }
                        Console.WriteLine("目标生成{0}个图形，其中{1}个图形创建失败，其余图形的面积之和为：{2}", num, fail, areaSum);
                        Console.WriteLine("------------------------输 入 任 意 键 继 续--------------------------");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("--------------------------随 机 生 成 图 形---------------------------");
                        Console.Write("请选择生成图形数目（最多生成20个）：");
                        while (!IsLegalInput(out num, 0, 20)) ;
                        myShape = new Shape[num];
                        for (int i = 0; i < num; i++)
                        {
                            ShapeFactory shapeFactory = new ShapeFactory();
                            Console.Write("第 {0} 个图形是", i + 1);
                            myShape[i] = shapeFactory.RandomShape();
                            areaSum += myShape[i].GetArea();
                            System.Threading.Thread.Sleep(100);
                        }
                        Console.WriteLine("这 {0} 个图形的面积之和为：{1}", num, areaSum);
                        Console.WriteLine("------------------------输 入 任 意 键 继 续--------------------------");
                        Console.ReadKey();
                        break;
                    case "0":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("请重新选择！");
                        break;
                }
            }
        }

        //判断输入合法性
        static bool IsLegalInput(out int numInput, int min, int max)
        {
            bool flag;
            flag = int.TryParse(Console.ReadLine(), out numInput);
            if (flag == false || numInput < min || numInput > max)
            {
                flag = false;
                Console.Write("输入不合法！请重新输入：");
            }
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
        static void ManualInput(int num, ref Shape[] myShape)
        {
            Console.WriteLine("--------------------------手 动 生 成 图 形---------------------------");
            Console.WriteLine("1 - 生成长方形    2 - 生成正方形    3 - 生成三角形    4 - 生成圆形");
            ShapeFactory shapeFactory = new ShapeFactory();
            int input = 0;
            for (int i = 0; i < num; i++)
            {
                Console.Write("这是生成的第 {0} 个图形，请选择生成图形形状：", i + 1);
                while (!IsLegalInput(out input, 0, 4)) ;
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
                myShape[i] = shapeFactory.CreateShape(input - 1, edge);
                if (!myShape[i].IsLegal()) Console.WriteLine("创建失败！");
                else Console.WriteLine("创建成功！该图形面积为：" + myShape[i].GetArea());
            }
        }
    }

    class ShapeFactory
    {
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
            Random r = new Random();
            int type = r.Next() % 4;
            switch (type)
            {
                case 0:
                    double width, height;
                    do
                    {
                        width = 10 * r.NextDouble();
                        height = 10 * r.NextDouble();
                        myShape = new Rectangle(width, height);
                    } while (!myShape.IsLegal());
                    Console.WriteLine("长方形，长为{0}，宽为{1}", width, height);
                    break;
                case 1:
                    double edge;
                    do
                    {
                        edge = 10 * r.NextDouble();
                        myShape = new Square(edge);
                    } while (!myShape.IsLegal());
                    Console.WriteLine("正方形，边长为{0}", edge);
                    break;
                case 2:
                    double a, b, c;
                    do
                    {
                        a = 10 * r.NextDouble();
                        b = 10 * r.NextDouble();
                        c = 10 * r.NextDouble();
                        myShape = new Triangle(a, b, c);
                    } while (!myShape.IsLegal());
                    Console.WriteLine("三角形，三边边长为{0}，{1}，{2}", a, b, c);
                    break;
                case 3:
                    double radius;
                    do
                    {
                        radius = 10 * r.NextDouble();
                        myShape = new Circle(radius);
                    }while (!myShape.IsLegal());
                    Console.WriteLine("圆形，半径为{0}", radius);
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
