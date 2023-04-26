//========= ========= ˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗====== BEGINNING OF FILE ======˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗ ========= =========
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace st10190203StevenChen_PROG6221_POE_P1.Classes
{
    internal class MenuClass
    {
        /// <summary>
        /// the two common variable reply for menu
        /// </summary>
        private int num_reply = 0;
        private string reply = string.Empty;

        /// <summary>
        /// recipe name
        /// </summary>
        string recipe = string.Empty;

        /// <summary>
        /// ingredient name
        /// </summary>
        string name = string.Empty;

        /// <summary>
        /// ingredient quantity
        /// </summary>
        double quantity = 0.0;

        /// <summary>
        /// ingredient unit of measurement
        /// </summary>
        string unitOfMeasurement = string.Empty;

        /// <summary>
        /// total amount of ingredients within the recipe
        /// </summary>
        int ingredients_total = 0;


        /// <summary>
        /// total amount of steps needed to produce the recipe
        /// </summary>
        private int steps_total = 0;

        /// <summary>
        /// array for storing the ingredient OBJ that would created
        /// </summary>
        IngredientClass[] arr_ingredients;

        /// <summary>
        /// array for storing each step it needed to replicate the recipe
        /// </summary>
        string[] arr_steps;

        /// <summary>
        /// a variable for storing all the values that needed to be stored as integer.
        /// </summary>
        string value;

        /// <summary>
        /// List to store the Recipe (recipe name + ingredient arr + step arr)
        /// </summary>
        List<RecipeClass> RecipeTable = new List<RecipeClass>();

        IngredientClass ingredientClassHere;

        RecipeClass recipeClassHere;



        /// <summary>
        /// getters setters
        /// </summary>
        public int Num_reply { get => num_reply; set => num_reply = value; }
        public string Reply { get => reply; set => reply = value; }
        public string Recipe { get => recipe; set => recipe = value; }
        public int Steps_total { get => steps_total; set => steps_total = value; }
        public IngredientClass[] Arr_ingredients { get => arr_ingredients; set => arr_ingredients = value; }
        public string[] Arr_steps { get => arr_steps; set => arr_steps = value; }
        public string Name { get => name; set => name = value; }
        public string UnitOfMeasurement { get => unitOfMeasurement; set => unitOfMeasurement = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public int Ingredients_total { get => ingredients_total; set => ingredients_total = value; }
        public string Value { get => value; set => this.value = value; }
        internal List<RecipeClass> RecipeTable1 { get => RecipeTable; set => RecipeTable = value; }


        /// <summary>
        /// the menu that shows if no recipe is stored.
        /// </summary>
        public void Menu_input()
        {

            Console.WriteLine("Would you like to store a recipe?  (Y/N)");
            reply = Console.ReadLine();


            if (reply == "Y")
            {
                IngredientInput();

                StepsInput();

                SaveRecipe();

                PrintRecipes(this.RecipeTable1.Count-1);
                return;
            }
            else if (reply == "N") 
            {
                Console.WriteLine("tHaNk yOu fOr uSiNg tHe ApPliCaTiOn!");
                System.Environment.Exit(0); 
                return; 
            }
            else
            {
                Console.WriteLine("=== Recipe Book is empty ===\n");
                Menu_input();
                return;
            }

        }


        /// <summary>
        /// the menu that shows when there is a stored recipe, this menu allows the users to change/update/delete (interact) with the recipe
        /// the menu option will include (part 1: clear the recipe storage, change the scale of the ingredient by 0.5/2/3/original)
        /// </summary>
        public void Menu_interactive()
        {

            Console.WriteLine("Choose An Option");
            Console.WriteLine("1) Clear Recipe ");
            Console.WriteLine("2) Scale the ingredients ");
            Console.WriteLine("3) Enter new Recipe ");
            Console.WriteLine("4) Exit ");

            int switchOption = IntegerValidation(Console.ReadLine(), 1, 4);

            // 1 clear, 2 scale ,3 enter new recipe, 4 exit
            switch (switchOption)
            {
                case 1:
                    DisplayRecipe();
                    Console.WriteLine("Enter the recipe number to delete");

                    int DeleteIndex = IntegerValidation(Console.ReadLine(), 0, RecipeTable.Count);

                    DeleteRecipe(DeleteIndex);

                    break;

                case 2:
                      
                    ScaleMenu();


                    break;

                case 3: Menu_input(); break;

                case 4: System.Environment.Exit(0); break;

                default: Console.WriteLine("xxxxx   Enter strictly options   xxxxx"); break;

            }

        }

        public void ScaleMenu()
        {
            DisplayRecipe();
            int RecipeSelection = IntegerValidation(Console.ReadLine(), 0, RecipeTable.Count);


            Console.WriteLine("Enter the amount you would like to scale");
            Console.WriteLine("1) {0}\t 2) {1}\t 3) {2}\t 4) {3}\t 5){4}", 0.5, 2, 3, "Reset to original", "scale any amount from 1~99");
            int ScaleOption = IntegerValidation(Console.ReadLine(), 1, 5);

            double scale_amount = 0;

            //options are   1) x0.5;      2) x2;        3) x3;      4) back to original;      5) scale 1~99
            switch (ScaleOption)
            {
                case 1: scale_amount = 0.5; break;
                case 2: scale_amount = 2; break;
                case 3: scale_amount = 3; break;
                case 4:

                    foreach (IngredientClass ingredientClassHere in arr_ingredients)
                    {
                        ingredientClassHere.ResetValue();

                    }

                    break;
                case 5:
                    Console.WriteLine("Enter a number 1-99 to scale by.");
                    scale_amount = IntegerValidation(Console.ReadLine(), 1, 99); break;
                default: Console.WriteLine("xxxxx   Enter strictly options   xxxxx"); break;
            }

            if (scale_amount != 0)
            {

                foreach (var ingredient in RecipeTable[RecipeSelection].Ingredients1)
                {
                    ingredient.ScaleValue(scale_amount);
                    
                }


                scale_amount = 0;
            }
            PrintRecipes(RecipeSelection);
        }


        /// <summary>
        /// this method ask for the ingredient info-> creates ingredient->stores it in the array-> repeat untill all ingredient is stored
        /// </summary>
        public void IngredientInput()
        {
            Console.WriteLine("what is the name of the Recipe?");
            recipe = Console.ReadLine();

            Console.WriteLine("The recipe for \"{0}\" contains how many ingredient(s)?", recipe);

            int ingredients_total = IntegerValidation(Console.ReadLine(), 1, 9999);     //VALIDATE THE NUMBER ENTERED


            arr_ingredients = new IngredientClass[ingredients_total];

            for (int i = 0; i < ingredients_total; i++)
            {
                int count = i + 1;
                Console.WriteLine("what is the name of ingredient {0}?", count);
                name = Console.ReadLine();


                Console.WriteLine("what is the quantity of {0}?", name);
                quantity = IntegerValidation(Console.ReadLine(), 1, 9999);


                Console.WriteLine("what is the unit of measurement for {0}?", name);
                unitOfMeasurement = Console.ReadLine();

                IngredientClass ingredientClassHere = new IngredientClass(name, quantity, unitOfMeasurement);
                arr_ingredients[i] = ingredientClassHere;



            }

        }

        /// <summary>
        /// this method ask for how many steps --> store the description of each step 
        /// </summary>
        public void StepsInput()
        {
            string stepDescription;
            Console.WriteLine("How many steps are there?");

            steps_total = IntegerValidation(Console.ReadLine(), 1, 9999);

            arr_steps = new string[steps_total];

            for (int i = 0; i < steps_total; i++)
            {
                int count = i + 1;
                Console.WriteLine("Enter the description for step {0}", count);
                stepDescription = Console.ReadLine();
                arr_steps[i] = stepDescription;
            }
        }

        /// <summary>
        /// method to store the entered recipe into arraylist, this list is used to storing recipe and also 
        /// makes menu_input pop out if its at 0
        /// </summary>
        public void SaveRecipe()
        {

            recipeClassHere = new RecipeClass(arr_ingredients.ToList(), arr_steps, recipe) ;

            RecipeTable.Add(recipeClassHere);

        }


        /// <summary>
        /// method for deleting a specific recipe
        /// </summary>
        public void DeleteRecipe(int indexInput)
        {

            RecipeTable.RemoveAt(indexInput);
            Console.WriteLine(" =======------Recipe Removed Successfully------======= ");
        }

        /// <summary>
        /// method for displaying all the saved recipe in the recipe list
        /// </summary>
        public void DisplayRecipe()
        {
            Console.WriteLine("Here are the recorded Recipes.");
            Console.WriteLine(" =======------BEGINNING OF LIST------======= ");

            foreach (RecipeClass recipeClassHere in RecipeTable)
            {
                int i = RecipeTable.IndexOf(recipeClassHere);
                Console.WriteLine("\t\n{0}) {1}", i, recipeClassHere.Recipe_Name1);
            }

            Console.WriteLine(" =======------END OF LIST------=======");

        }

        /// <summary>
        /// this is a method that checks if input value is a NUMBER and if its WITHIN  range.
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int IntegerValidation(string inputValue, int min, int max)
        {
            int outputValue;
            while ((!Int32.TryParse(inputValue, out outputValue)) || (outputValue > max || outputValue < min))
            {
                Console.WriteLine("xxxxx   Enter strictly numbers & has to be within option    xxxxx");
                Console.WriteLine("=====               Re-enter the option again               =====\n");
                inputValue = Console.ReadLine();
            }

            return outputValue;
        }

        /// <summary>
        /// this method prints out the recipe name,ingredient amount and the steps to take to process it.
        /// </summary>
        public void PrintRecipes(int RecipeIndexInput)
        {

            Console.WriteLine("\n========------========------========------========------========------========------========");
            Console.WriteLine("\n\t\t\tRecipe for {0} :", RecipeTable[RecipeIndexInput].Recipe_Name1);


            foreach (IngredientClass ingredientClassHere in RecipeTable[RecipeIndexInput].Ingredients1)
            {
                int i = Array.IndexOf(arr_ingredients, ingredientClassHere);
                // 0=ingrediant name   1 quantity 2=UOMeasurement 3=current index
                Console.WriteLine("\n\tIngredient {3}: {1} {2} of {0}", ingredientClassHere.ING_name1, ingredientClassHere.ING_quantity1
                    , ingredientClassHere.ING_unitOfMeasurement1, i);

            }

            Console.WriteLine("\n========------========------========------========------========------========------========");
            Console.WriteLine("\n\t\tThe {0} steps you have to take to produce {1} :", steps_total, recipe);

            foreach (string stepDescription in RecipeTable[RecipeIndexInput].Steps1)
            {
                int i = Array.IndexOf(arr_steps, stepDescription);

                // 0=current index  1= description
                Console.WriteLine("\n\tStep {0} : {1}", i, stepDescription);

            }
            Console.WriteLine("\n========------========------========------========------========------========------========");

        }

   
    }
}
//  ========= ========= ˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗====== END OF FILE ======˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗ ========= =========
//  ========= ========= ˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗====== Steven Chen ======˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗ ========= =========