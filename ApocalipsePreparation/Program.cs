namespace ApocalipsePreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int patchResourses = 30;
            const int bangdageResousres = 40;
            const int medKitResourse = 100;


            Queue<int> textile = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> medicaments = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> medKit = new();
            bool areOver = false;
            while (!areOver)
            {
                int currentMedicament = medicaments.Pop();
                int currentHealtItem = textile.Dequeue() * currentMedicament;
                int remainingMedicament = 0;
                string currentHealingItemName = String.Empty;
                if (currentHealtItem >= patchResourses && currentHealtItem < bangdageResousres)
                {
                    remainingMedicament = currentHealtItem - patchResourses;
                    currentHealingItemName = "Patch";

                }
                else if (currentHealtItem >= bangdageResousres && currentHealtItem < medKitResourse)
                {
                    remainingMedicament = currentHealtItem - bangdageResousres;
                    currentHealingItemName = "Bandage";
                }
                else if (currentHealtItem >= medKitResourse)
                {
                    remainingMedicament = currentHealtItem - medKitResourse;
                    currentHealingItemName = "MedKit";
                }

                if (currentHealingItemName != "")
                {
                    if (remainingMedicament > 0)
                    {
                        medicaments.Push(remainingMedicament);
                        if (!medKit.ContainsKey(currentHealingItemName))
                        {
                            medKit.Add(currentHealingItemName, 0);
                        }
                        medKit[currentHealingItemName]++;
                    }
                }
                else
                {
                    medicaments.Push(currentMedicament + 10);
                }
                if (textile.Count == 0 || medicaments.Count == 0)
                {
                    areOver = true;
                }
            }

            if (textile.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (textile.Count > 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }
            else if (textile.Count == 0 && medicaments.Count > 0)
            {
                Console.WriteLine("Textiles are empty.");
            }
            foreach(var med in medKit.OrderByDescending(x => x.Value).ThenBy(x=> x.Key))
            {
                Console.WriteLine($"{med.Key} - {med.Value}");
            }

            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {String.Join(", ", medicaments)}");
            }
            if (textile.Any())
            {
                Console.WriteLine($"Textiles left: {String.Join(", ", textile)}");
            }
    }
}
}