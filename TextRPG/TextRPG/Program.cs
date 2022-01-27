using System;

namespace TextRPG
{
    class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }
        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;

            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    break;
                case "2":
                    choice = ClassType.Archer;
                    break;
                case "3":
                    choice = ClassType.Mage;
                    break;
            }
            return choice;
        }
        static void Main(string[] args)
        {
            ClassType choice = ClassType.None;
            /*
                변수를 while안에 선언할 때와 밖에 선언할 때의 차이
                while 괄호 안에 선언할 경우 , while문 바깥에서 사용할 경우 반복이 끝날 경우 생명이 끝남 -> while문 바깥에서 선언
            */
            while (true)
            {
                choice = ChooseClass();
                if (choice != ClassType.None)
                    break;//break는 가장 가까운 괄호를 탈출하기 때문에 switch 내부의 break는 switch 문장을 탈출한다.
            }
        }
    }
}
