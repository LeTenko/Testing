//========= ========= ˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗====== BEGINNING OF FILE ======˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗ ========= =========

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace st10190203StevenChen_PROG6221_POE_P1.Classes
{
    /// <summary>
    /// this method acts as the main for this project thus providing more security.
    /// </summary>
    internal class WorkerClass
    {
        public void START()
        {

            MenuClass menuClassHere = new MenuClass();
            while (menuClassHere.RecipeTable1.Count > -1)
            {

                while (menuClassHere.RecipeTable1.Count != 0)
                {
                    menuClassHere.Menu_interactive();
                }

                while (menuClassHere.RecipeTable1.Count == 0)
                {
                    Console.WriteLine("=== Recipe Book is empty ===\n");
                    menuClassHere.Menu_input();
                }


            }
        }
    }
}
//  ========= ========= ˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗====== END OF FILE ======˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗ ========= =========
//  ========= ========= ˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗====== Steven Chen ======˗ˏˋ ★ ˎˊ˗========˗ˏˋ ★ ˎˊ˗ ========= =========