//========= ========= ˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗====== BEGINNING OF FILE ======˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗ ========= =========
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10190203StevenChen_PROG6221_POE_P1.Classes
{
    public class IngredientClass
    {
        //ingredient's abbreviation is ING

        /// <summary>
        /// ingredient's name
        /// </summary>
        private string ING_name = string.Empty;

        /// <summary>
        /// ingredient's unit of measurement
        /// </summary>
        private string ING_unitOfMeasurement = string.Empty;

        /// <summary>
        /// ingredient's quantity
        /// </summary>
        private double ING_quantity = 0.0;

        /// <summary>
        /// original, set amount that the user initially inputs
        /// </summary>
        private double ING_quantity_Original = 0.0;

        /// <summary>
        /// getters setters
        /// </summary>
        public string ING_name1 { get => ING_name; set => ING_name = value; }
        public string ING_unitOfMeasurement1 { get => ING_unitOfMeasurement; set => ING_unitOfMeasurement = value; }
        public double ING_quantity1 { get => ING_quantity; set => ING_quantity = value; }
        public double ING_quantity_Original1 { get => ING_quantity_Original; set => ING_quantity_Original = value; }

        /// <summary>
        /// constructor
        /// </summary>
        IngredientClass() { }

        /// <summary>
        /// constructor for the requested ingredient input  (part 1 request)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="unitOfMeasurement"></param>
        public IngredientClass(string name, double quantity, string unitOfMeasurement)
        {

            //stored original reference 
            ING_quantity_Original = quantity;

            //changable values user initially enters
            ING_name = name;
            ING_quantity = quantity;
            ING_unitOfMeasurement = unitOfMeasurement;

        }
        public void ScaleValue(double scaleAmount)
        {
            ING_quantity *= scaleAmount;
        }

        public void ResetValue()
        {
            ING_quantity = ING_quantity_Original;
        }



    }
}
//  ========= ========= ˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗====== END OF FILE ======˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗ ========= =========
//  ========= ========= ˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗====== Steven Chen ======˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗ ========= =========