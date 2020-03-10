using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("任务1：为泛型链表添加类似List<T>类的ForEach方法，");
            Console.WriteLine("并通过调用这个方法打印链表元素，求最大值、最小值");
            Console.WriteLine("和求和（使用lambda表达式实现）。");
            Console.WriteLine("-------------------- 任 务 一 --------------------");
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }

            int max = intlist.Head.Data;
            int min = intlist.Head.Data;
            int sum = 0;

            Console.Write("链表元素值分别为：");
            intlist.ForEach(x => Console.Write(x + "  "));
            Console.WriteLine();
            
            intlist.ForEach(x => max = x > max ? x : max);
            Console.WriteLine("链表元素最大值为：{0}", max);

            intlist.ForEach(x => min = x < min ? x : min);
            Console.WriteLine("链表元素最小值为：{0}", min);

            intlist.ForEach(x => sum += x);
            Console.WriteLine("链表元素之和为：{0}", sum);

            Console.WriteLine("-------------------键入回车继续-------------------");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("任务2：使用事件机制，模拟实现一个闹钟功能。闹钟可");
            Console.WriteLine("以有Tick事件和Alarm事件。在闹钟走时或者响铃时，在");
            Console.WriteLine("控制台显示提示信息。");
            Console.WriteLine("-------------------- 任 务 二 --------------------");
            Console.WriteLine("现在时间是：{0}", DateTime.Now);
            Console.Write("闹钟设定于（格式同上）：");
            string input = Console.ReadLine();
            DateTime alarmTime = DateTime.Parse(input); //此处没有设置异常处理，会直接中断

            Form form = new Form();
            form.myClock.ClockEvent(alarmTime);
        }
    }
}

//--------------------任务一---------------------
//节点类
public class Node<T>
{
    public Node<T> Next { get; set; }
    public T Data { get; set; }

    public Node(T t)
    {
        Next = null;
        Data = t;
    }
}

//泛型链表类
public class GenericList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public GenericList()
    {
        tail = head = null;
    }

    public Node<T> Head
    {
        get => head;
    }

    public void Add(T t)
    {
        Node<T> n = new Node<T>(t);
        if (tail == null)
        {
            head = tail = n;
        }
        else
        {
            tail.Next = n;
            tail = n;
        }
    }

    public void ForEach(Action<T> action)
    {
        Node<T> node = head;
        while(node != null)
        {
            action(node.Data);
            node = node.Next;
        }
    }
}

//--------------------任务二---------------------
public delegate void ClockHandler();

public class Clock
{
    //定义事件，相当于创建一个委托实例
    public event ClockHandler Tick;
    public event ClockHandler Alarm;

    public void ClockEvent(DateTime alarmTime)
    {
        bool flag = false;
        while (true)
        {
            if (alarmTime > DateTime.Now || flag)
            {
                Tick();
                Thread.Sleep(1000);
            }
            else
            {
                Alarm();
                flag = true;
                Thread.Sleep(1000);
            }
        }
    }
}

public class Form
{
    public Clock myClock = new Clock();

    public Form()
    {
        myClock.Tick += Tick;
        myClock.Alarm += Alarm;
    }

    void Tick()
    {
        Console.WriteLine("Tick - Tock.");
    }

    void Alarm()
    {
        Console.WriteLine("Rrrrrrrrrrrrrrrrrrrrrrrrrrrrrring.");
    }
}