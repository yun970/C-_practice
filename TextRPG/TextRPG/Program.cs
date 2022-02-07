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
        struct Player
        {
            public int hp;
            public int attack;
        }
        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skelton =3
        }

        struct Monster
        {
            public int hp;
            public int attack;
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


        static void CreatePlayer(out Player player, ClassType choice)
        {
            
            player.hp = 0;
            player.attack = 0;
            switch (choice)
            {
                case ClassType.Archer:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Knight:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 15;
                    break; 
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }

        }
        static void EnterGame(ref Player player)
        {
            Console.WriteLine("게임에 접속했습니다!");
            Console.WriteLine("[1] 필드로 간다");
            Console.WriteLine("[2] 로비로 돌아간다");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    EnterField(ref player);
                    break;
                case "2":
                    return;
            }
        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(1, 4);
            switch (randMonster)
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임이 스폰되었습니다1");
                    monster.hp = 20;
                    monster.attack = 2;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine("오크가 스폰되었습니다!");
                    monster.hp = 40;
                    monster.attack = 4;
                    break;
                case (int)MonsterType.Skelton:
                    Console.WriteLine("스켈레톤이 스폰되었습니다!");
                    monster.hp = 60;
                    monster.attack = 6;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }

        static void EnterField(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("필드에 접속했습니다!");

                Monster monster;
                CreateRandomMonster(out monster);

                Console.WriteLine("[1] 전투모드로 돌입");
                Console.WriteLine("[2] 일정 확률로 마을로 도망");

                string input = Console.ReadLine();
                if(input == "1")
                {
                    Fight(ref player,ref monster);
                }
                else if (input == "2")
                {
                    Random random = new Random();
                    int randValue = random.Next(0, 101);
                    if (randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다!");
                        break;
                    }
                    else
                    {
                        Fight(ref player, ref monster);
                    }
                }
            }
        }
        static void Fight(ref Player player,ref Monster monster)
        {
            while (true)
            {
                Console.WriteLine($"내 체력{player.hp} 몬스터 체력{monster.hp}");
                monster.hp -= player.attack;
                if(monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다!");
                    break;
                }

                player.hp -= monster.attack;
                if(player.hp <= 0)
                {
                    Console.WriteLine("패배했습니다!");
                    break;

                }
            }
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
                {
                    Player player;

                    CreatePlayer(out player, choice);

                    Console.WriteLine($"HP{player.hp} ATTACK{player.attack}");
                    EnterGame(ref player);

                    //break; break는 가장 가까운 괄호를 탈출하기 때문에 switch 내부의 break는 switch 문장을 탈출한다.
                }
            }
        }
    }
}
