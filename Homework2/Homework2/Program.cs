using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            InitTask(out input);
            bool flag = true;
            
            while (flag)
            {
                switch (input)
                {
                    case "1":
                        Task_1();
                        InitTask(out input);
                        break;
                    case "2":
                        Task_2();
                        InitTask(out input);
                        break;
                    case "3":
                        Task_3();
                        InitTask(out input);
                        break;
                    case "Q":
                    case "q":
                        flag = false;
                        break;
                    default:
                        Console.Write("键入字符格式错误！请从新输入：");
                        input = Console.ReadLine();
                        break;
                }
            }
        }
        
        //初始化
        private static void InitTask(out string input)
        {
            Console.Clear();
            Console.WriteLine("-----------------------CSharpHomework2-----------------------");
            Console.WriteLine("请键入冒号前对应字符选择操作：");
            Console.WriteLine("1 ：输出用户指定数据的所有素数因子");
            Console.WriteLine("2 ：求整数数组的最大值、最小值、平均值和所有数组元素的和。");
            Console.WriteLine("3 ：用“埃氏筛法”求用户指定数据以内的所有素数。");
            Console.WriteLine("q ：退出程序");
            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("请选择要查看的作业：");
            input = Console.ReadLine();
        }
        
        //判断整数输入是否正确
        private static bool JudgeInt(out int numInput)
        {
            bool flag;
            flag = int.TryParse(Console.ReadLine(), out numInput);
            if (flag == false) Console.Write("输入不合法！请重新输入一个正整数：");
            else flag = true;
            return flag;
        }
        
        //任务1：输出用户指定数据的所有素数因子
        private static void Task_1()
        {
            int numInput = 0;
            string result = "其所有素数因子为：";
            bool flag = false;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("任务1：输出用户指定数据的所有素数因子");
            Console.Write("请输入一个正整数：");
            while (!flag) flag = JudgeInt(out numInput);

            int max = Rooting(numInput);
            for (int i = 2; i <= max; i++)
            {
                while (numInput % i == 0)
                {
                    result += i + " ";
                    numInput /= i;
                }
            }
            if (numInput >= 2)
            {
                result += numInput + "";
            }

            Console.WriteLine(result);
            Console.WriteLine("------------------------键入回车继续-------------------------");
            Console.ReadLine();
        }
        
        //任务1附：求某数平方根
        private static int Rooting(int n)
        {
            int max;
            for (max = n / 2; max * max > n; max--) ;
            return max;
        }
        
        //任务2：求整数数组的最大值、最小值、平均值和所有数组元素的和
        private static void Task_2()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("任务2：求整数数组的最大值、最小值、平均值和所有数组元素的和。");
            Console.WriteLine("a ：自动生成数组");
            Console.WriteLine("b ：手动键入数组");
            Console.Write("请选择是自动生成数组还是手动键入数组(大小写敏感)：");
            string taskTwoInput1 = Console.ReadLine();
            
            while(taskTwoInput1!="a" && taskTwoInput1 != "b")
            {
                Console.Write("输入有误！请重新输入：");
                taskTwoInput1 = Console.ReadLine();
            }
            switch (taskTwoInput1)
            {
                case "a":
                    MyArray();
                    break;
                case "b":
                    YourArray();
                    break;
            }

            Console.WriteLine("------------------------键入回车继续-------------------------");
            Console.ReadLine();
        }
        
        //任务2附：数组计算
        private static void CalArray(int[] a, int n)
        {
            int aMax, aMin, aSum = 0;//计算
            float aAver;
            aMax = aMin = a[0];
            for (int i = 0; i < n; i++)
            {
                aSum += a[i];
                if (a[i] > aMax) aMax = a[i];
                if (a[i] < aMin) aMin = a[i];
            }
            aAver = (float)aSum / n;

            Console.Write("数组最大值为：{0}        ", aMax);
            Console.WriteLine("最小值为：{0}", aMin);
            Console.Write("平均值为：{0}            ", aAver);
            Console.WriteLine("数组和为：{0}", aSum);
        }
        
        //任务2附：随机生成数组
        private static void MyArray()
        {
            Random rd = new Random();
            int index = rd.Next(10,20);
            int[] a = new int[index];
            
            Console.Write("随机生成的数组为：");//生成、输出数组
            for (int j = 0; j < index; j++)
            {
                a[j] = rd.Next(1, 50);
                Console.Write(+ a[j] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("数组长度为：{0}", index);
            CalArray(a, a.Length);
        }
        
        //任务2附：手动输入数组
        private static void YourArray()
        {
            Console.Write("请键入整数数组，数值之间通过空格隔开(例：2 3 4)：");
            int[] yourArray = new int[20];//没有想到更好的办法，只能固定数组长度
            string input = Console.ReadLine(), temp="";
            int index=0; bool flag;
            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    flag = int.TryParse(temp, out yourArray[index]);
                    index++; temp = "";
                    if (flag == false)
                    {
                        Console.WriteLine("数组输入格式有误！请重新键入数组：");
                        input = Console.ReadLine();
                        i = 0; index = 0;
                    }
                }
                else temp += input[i];
            }

            if (temp != "") int.TryParse(temp, out yourArray[index]);
            index++;
            CalArray(yourArray, index);
        }
        
        //任务3：用“埃氏筛法”求用户指定数据以内的所有素数
        private static void Task_3()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("任务3：用“埃氏筛法”求用户指定数据以内的所有素数。");
            Console.Write("请输入一个正整数：");
            bool flag = false;
            int num = 0;
            while (!flag) flag = JudgeInt(out num);

            int[] myArray = new int[num+1];

            for (int i = 2; i <= Rooting(num); i++)
                for (int j = 2; i * j <= num; j++)
                    myArray[i * j] = 1;

            Console.Write("{0}以内的素数有：", num);

            for (int i = 2; i <= num; i++)
                if (myArray[i] == 0)
                    Console.Write("{0} ", i);
            Console.WriteLine();
            Console.WriteLine("------------------------键入回车继续-------------------------");
            Console.ReadLine();
        }
    }
}
