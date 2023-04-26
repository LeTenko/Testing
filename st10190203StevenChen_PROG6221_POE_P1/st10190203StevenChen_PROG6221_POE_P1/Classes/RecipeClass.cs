using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10190203StevenChen_PROG6221_POE_P1.Classes
{
    internal class RecipeClass
    {

        private List<IngredientClass> Ingredients;
        private Array Steps;
        private String Recipe_Name;


        public List<IngredientClass> Ingredients1 { get => Ingredients; set => Ingredients = value; }
        public Array Steps1 { get => Steps; set => Steps = value; }
        public string Recipe_Name1 { get => Recipe_Name; set => Recipe_Name = value; }


        public RecipeClass() { }

        public RecipeClass(List<IngredientClass> Ingredients, Array Steps, String Name)
        {
            this.Ingredients = Ingredients;
            this.Steps = Steps;
            this.Recipe_Name = Name;

        }

    }
}
