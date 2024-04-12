using System;

class Recipe
{
    public string[] Ingredients { get; set; }
    public string[] Steps { get; set; }

    public Recipe()
    {
        Ingredients = new string[30];
        Steps = new string[0];
    }

    public void AddIngredient(string ingredient)
    {
        Array.Resize(ref Ingredients, Ingredients.Length + 1);
        Ingredients[Ingredients.Length - 1] = ingredient;
    }

    public void AddStep(string step)
    {
        Array.Resize(ref Steps, Steps.Length + 1);
        Steps[Steps.Length - 1] = step;
    }

    public void ClearRecipe()
    {
        Ingredients = new string[0];
        Steps = new string[0];
    }

    class Program
    {
        static void Main()
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("Enter ingredient name:");
                string ingredientName = Console.ReadLine();
                Console.WriteLine("Enter quantity:");
                string quantity = Console.ReadLine();
                Console.WriteLine("Enter unit of measurement:");
                string unit = Console.ReadLine();

                string ingredient = $"{quantity} {unit} of {ingredientName}";
                recipe.AddIngredient(ingredient);
            }

            Console.WriteLine("Enter the number of steps:");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }

            // Display the recipe
            Console.WriteLine("Recipe:");
            foreach (string ingredient in recipe.Ingredients)
            {
                Console.WriteLine(ingredient);
            }

            foreach (string step in recipe.Steps)
            {
                Console.WriteLine(step);
            }
        }
    }
}

