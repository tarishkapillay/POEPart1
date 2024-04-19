using System;
namespace RecipeApp
{
    // The code defines a class called Recipe with three properties: Ingredients, OriginalIngredients, and Steps.
    // It also includes three methods: DisplayRecipe(), ScaleRecipe(double factor), and ResetRecipe().

    class Recipe
    {
        public string[] Ingredients { get; set; }
        public string[] OriginalIngredients { get; set; }
        public string[] Steps { get; set; }

        //The DisplayRecipe() method is called to display the ingredients and steps of the recipe.

        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (string ingredient in Ingredients)
            {
                Console.WriteLine("- " + ingredient);
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + Steps[i]);
            }
        }

        public void ScaleRecipe(double factor)
        {
            Console.WriteLine("\nScaled Recipe:");
            foreach (string ingredient in Ingredients)
            {
                string[] parts = ingredient.Split(' ');
                double quantity = Convert.ToDouble(parts[0]) * factor;
                Console.WriteLine("- " + quantity + " " + parts[1] + " " + parts[2]);
            }
        }

        public void ResetRecipe()
        {
            Ingredients = OriginalIngredients;
        }
    }

    class Program
    {
        //The Main() method is the entry point of the program.
        //It creates an instance of the Recipe class and prompts the user to input the number of ingredients and steps.
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = Convert.ToInt32(Console.ReadLine());
            string[] ingredients = new string[numIngredients];
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter ingredient " + (i + 1) + ": ");
                string ingredient = Console.ReadLine();

                Console.Write("Enter the quantity " + (i + 1) + ": ");
                string quantity = Console.ReadLine();

                Console.Write("Enter the measurement " + (i + 1) + " (cup, Kg, ml, L, g): ");
                string measurement = Console.ReadLine();

                ingredients[i] = quantity + " " + measurement + " " + ingredient;
            }
            recipe.Ingredients = ingredients;
            recipe.OriginalIngredients = ingredients;

            Console.Write("\nEnter the number of steps: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());
            string[] steps = new string[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write("Enter step " + (i + 1) + ": ");
                steps[i] = Console.ReadLine();
            }
            recipe.Steps = steps;

            recipe.DisplayRecipe();

            //The user is then prompted to enter a scaling factor (0.5, 2, or 3)
            //to scale the recipe by multiplying the quantities of each ingredient by the factor.
            //The ScaleRecipe() method is called with the factor as an argument to display the scaled recipe.

            Console.Write("\nEnter a scaling factor (0.5, 2, or 3): ");
            double factor = Convert.ToDouble(Console.ReadLine());
            recipe.ScaleRecipe(factor);

           // The user is given the option to reset the recipe to its original scale by inputting "Y".
           // If selected, the ResetRecipe() method is called to revert the ingredients property back to the original ingredients input.
            Console.WriteLine("\nDo you want to reset to the original scale? (Y/N)");
            string resetInput = Console.ReadLine();
            if (resetInput.ToLower() == "y")
            {
                recipe.ResetRecipe();
                Console.WriteLine("\nRecipe has been reset to the original scale:");
                recipe.DisplayRecipe();
            }

            Console.WriteLine("\nPress any key to clear recipe and enter a new one...");
            Console.ReadKey();
            Console.Clear();

            Main(args);
        }
    }
}
