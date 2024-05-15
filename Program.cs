int manticoreHealth = 10;
int cityHealth = 15;
int roundNumber = 1;
int roundCannonDamage;
int cannonShotDistance;
int manticoreDistance;
Random manticoreDistanceRandom = new Random();
Console.WriteLine("Натиснiть будь-яку клавiшу, щоб почати...");
Console.ReadKey(true);
Console.Clear();
Console.WriteLine("Гравець! Ви - оператор ЗРК Патрiот.");
Console.WriteLine("Наша цiль - росiйський ворожий бомбардирувальник.");
Console.Write("Вiн знаходиться у повiтрi на випадковiй висотi "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("вiд 1 до 100 "); Console.ResetColor(); Console.WriteLine("кiлометрiв вiд землi.");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Ваше завдання: визначити висоту ворожого лiтака та знищити його за один боєзапас.");
Console.ResetColor();
Console.WriteLine("Натиснiть будь-яку клавiшу, щоб почати...");
Console.ReadKey(true);
Console.Clear();
manticoreDistance = manticoreDistanceRandom.Next(1, 101);
Console.Clear();
while (manticoreHealth > 0 && cityHealth > 0)
{
    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("СТАТУС: Номер залпу: " + roundNumber + " Боєзапас: " + cityHealth + "/" + 15 + " Росiйський бомбардирувальник: " + manticoreHealth + "/" + 10);
    roundCannonDamage = CannonDamageCalculation();
    int CannonDamageCalculation()
    {
        if (roundNumber % 3 == 0 && roundNumber % 5 == 0)
        {
            roundCannonDamage = 10;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Цього разу використовуємо спецiальний снаряд.\nЦей залп завдасть " + roundCannonDamage + " шкоди.");
            Console.ResetColor();
            return roundCannonDamage;
            
        }
        else if (roundNumber % 3 == 0 || roundNumber % 5 == 0)
        {
            roundCannonDamage = 3;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Цього разу використовуємо спецiальний снаряд.\nЦей залп завдасть " + roundCannonDamage + " шкоди.");
            Console.ResetColor();
            return roundCannonDamage;

        }
        else if (roundNumber % 3 != 0 || roundNumber % 5 != 0)
        {
            roundCannonDamage = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Цей залп завдасть " + roundCannonDamage + " шкоди.");
            Console.ResetColor();
            return roundCannonDamage;
        }
        return roundNumber;
    }
    Console.Write("ЗРК Патрiот готов вiдкрити вогонь! Введiть ймовiрну дистанцiю до цiлi: ");
    cannonShotDistance = Convert.ToInt32(Console.ReadLine());
    if (cannonShotDistance == manticoreDistance)
    {
        manticoreHealth -= roundCannonDamage;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Є пряме влучення!\nВорожий лiтак пошкоджено!");
        Console.ResetColor();
    }
    else if (cannonShotDistance < manticoreDistance)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Дистанцiя до цiлi ЗАМАЛА. Коректуйте.");
        Console.ResetColor();
    }
    else if (cannonShotDistance > manticoreDistance)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Дистанцiя до цiлi ЗАВЕЛИКА. Коректуйте.");
        Console.ResetColor();
    }
    if (manticoreHealth > 0)
        cityHealth -= 1;
    roundNumber++;
}
if (manticoreHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Росiйський лiтак знищено. Перемога!.");
    Console.ResetColor();
}
else if (cityHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Боєзапас закiнчився. Ми не встигли знищити літак. Чекаємо на ракети.");
    Console.ResetColor();
}
    