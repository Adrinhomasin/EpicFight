using System;

namespace Week8_FunctionsWithReturns
{
    class Program
    {
        static void Main(string[] args)
        {
            string hero, villain;
            string heroWeapon, villainWeapon;
            hero = RandomHero();
            heroWeapon = RandomWeapon();
            villain = RandomVillain();
            villainWeapon = RandomWeapon();
            int heroHP = GenerateHP(hero);
            int villainHP = GenerateHP(villain);


            Console.WriteLine($"{hero} ({heroHP} HP) will fight {villain} ({villainHP} HP)");
            Console.WriteLine($"{hero} will fight with {heroWeapon}");
            Console.WriteLine($"{villain} will fight with {villainWeapon}");
            while (heroHP > 0 && villainHP > 0)
            {
                heroHP = heroHP - Hit(villain, hero, villainWeapon);
                villainHP = villainHP - Hit(hero, villain, heroWeapon);
            }

            if(heroHP >= 0)
            {
                Console.WriteLine("dark side won :(");
            }
            else
            {
                Console.WriteLine("hero saves the day :D");
            } 

            
        }

        private static int Hit(string characterOne, string characterTwo, string weapon)
        {
            Random rnd = new Random();
            int strike = rnd.Next(0, weapon.Length / 2);
            Console.WriteLine($"{characterOne} hit for {strike} HP.");
            
            if(strike == weapon.Length/2 - 1)
            {
                Console.WriteLine($"Awesome! {characterOne} made a critical hit!");
            }
            else if (strike == 0)
            {
                Console.WriteLine($"{characterTwo} dodged the attack");
            }
            
            return strike;
        }
        private static int GenerateHP(string somecharacter)
        {
            Random rnd = new Random();
            return rnd.Next(somecharacter.Length, somecharacter.Length + 10);
        }

        private static int RandomIndex(string[] someArray)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, someArray.Length);

            return randomIndex;
        }

        private static string RandomHero()
        {
            string[] heroes = { "Batman", "Iron Man", "Spiderman", "Thor", "Doctor Strange", "Hulk" };
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, heroes.Length);

            return heroes[RandomIndex(heroes)];
        }

        private static string RandomVillain()
        {
            string[] villains = { "Venom", "Carnage", "Thanos", "Joker", "Bane", "Darth Vader" };
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, villains.Length);

            string randomVillain = villains[randomIndex];
            return villains[RandomIndex(villains)];
        }

        private static string RandomWeapon()
        {
            string[] weapon = { "Frying Pan", "Keyboard", "Mouse", "Butter knife", "Shoe" };

            return weapon[RandomIndex(weapon)];
        }
    }
}
