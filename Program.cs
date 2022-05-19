using System;

namespace Task19BossFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxPlayerHealth = 1000;
            int maxPlayerMana = 1000;
            int bossHealth = 1000;
            int bossMana = 1000;
            int maxFireballDamage = 150;
            int minFireballDamage = 50;
            int minBossDamage = 50;
            int maxBossDamage = 150;
            int fireballManaConsumption = 100;
            int enhanceManaConsumption = 200;
            int playerManaRegeneration = 300;
            int veilHealthRegeneration = 300;
            int veilManaConsumption = 400;
            int bossManaConsumption = 100;
            int bossManaRegeneration = 400;
            int playerHealth = maxPlayerHealth;
            int playerMana = maxPlayerMana;
            int damage;
            string playerName = "Маг потухшей спички (Игрок)";
            string bossName = "Фактуросмингон-Грохо-Унгмос-Лорд";
            bool hasFireBall = false;
            bool hasEnhance = false;
            bool hasFireVeil = false;
            bool hasPlayerAction;
            char commandKey;

            Random random = new Random();  
            Console.WriteLine("Выход из старого склепа вам преградил могущественный король-лич " + bossName);

            while(bossHealth > 0 && playerHealth >0)
            {
                Console.SetCursorPosition(0, 2);
                Console.Write(playerName);
                Console.SetCursorPosition(70, 2);
                Console.Write(bossName);
                Console.SetCursorPosition(0, 3);
                Console.Write("Health: " + playerHealth);
                Console.SetCursorPosition(70, 3);
                Console.Write("Health: " + bossHealth);
                Console.SetCursorPosition(0, 4);
                Console.Write("Mana: " + playerMana);
                Console.SetCursorPosition(70, 4);
                Console.Write("Mana: " + bossMana);
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("Ваши действия:");

                if (hasFireBall)
                {
                    Console.WriteLine("2.Бросить огненный шар");
                }
                else
                {
                    if (fireballManaConsumption <= playerMana) 
                        Console.WriteLine("1.Призвать огненный шар");
                    if (veilManaConsumption <= playerMana)
                        Console.WriteLine("3.Закрыться огненной вуалью");
                }

                if (hasEnhance == false && enhanceManaConsumption <= playerMana)
                    Console.WriteLine("4.Усилить чары");

                Console.WriteLine("5.Восстановить ману");
                commandKey = Console.ReadKey().KeyChar;
                Console.Clear();
                hasPlayerAction = false;

                switch (commandKey)
                {
                    case '1':
                        if (hasFireBall == false && fireballManaConsumption <= playerMana)
                        {
                            hasFireBall = true;
                            playerMana -= fireballManaConsumption;
                            Console.Write("Вы кастуете огненный шар. ");
                            hasPlayerAction = true;
                        }
                        break;
                    case '2':
                        if (hasFireBall)
                        {
                            damage = random.Next(minFireballDamage, maxFireballDamage);
                            damage += Convert.ToInt32(damage * random.NextDouble()) * Convert.ToInt32(hasEnhance);
                            bossHealth -= damage;
                            hasEnhance = false;
                            hasFireBall = false;
                            Console.Write("Вы наносите " + damage + " урона. ");
                            hasPlayerAction = true;
                        }
                        break;
                    case '3':
                        if (hasFireBall == false && veilManaConsumption <= playerMana)
                        {
                            playerHealth += veilHealthRegeneration;
                            hasFireVeil = true;
                            playerMana -= veilManaConsumption;
                            if(playerHealth > maxPlayerHealth)
                                playerHealth = maxPlayerHealth;
                            Console.Write("Вы закрываетесь огненной вуалью и восстанавливаете " + veilHealthRegeneration + " хп. ");
                            hasPlayerAction = true;
                        }
                        break;
                    case '4':
                        if(hasEnhance == false && enhanceManaConsumption <= playerMana)
                        {
                            hasEnhance = true;
                            playerMana -= enhanceManaConsumption;
                            Console.Write("Вы усиливаете свою атакующую магию. ");
                            hasPlayerAction = true;
                        }
                        break;
                    case '5':
                        playerMana += playerManaRegeneration;
                        Console.Write("Вы восстанавливаете себе " + playerManaRegeneration + " маны. ");

                        if (playerMana > maxPlayerMana)
                            playerMana = maxPlayerMana;
                        hasPlayerAction = true;
                        break;
                }

                if (bossMana >= bossManaConsumption && hasPlayerAction)
                {
                    damage = random.Next(minBossDamage, maxBossDamage);

                    if (hasFireVeil)
                    {
                        hasFireVeil = false;
                        damage = 0;
                    }

                    playerHealth -= damage;
                    bossMana -= bossManaConsumption;
                    Console.WriteLine(bossName + " наносит вам " + damage + " ответного урона.");
                }
                else if (hasPlayerAction)
                {
                    bossMana += bossManaRegeneration;
                    Console.WriteLine(bossName + " восстанавливает себе " + bossManaRegeneration + " маны.");
                }
            }

            Console.Clear();
            Console.SetCursorPosition(50, 3);

            if (playerHealth > bossHealth && playerHealth > 0)
                Console.WriteLine("Вы победили!");
            else if (playerHealth < bossHealth && bossHealth > 0)
                Console.WriteLine("Вы проиграли!");
            else
                Console.WriteLine("Ничья!");
        }
    }
}
