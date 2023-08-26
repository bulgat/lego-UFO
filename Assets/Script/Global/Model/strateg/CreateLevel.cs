using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Global.Model.strateg
{
    public class CreateLevel
    {
        public List<InfoFleet> InitGameLevel(int level)
        {
            var fleet_ar = new List<InfoFleet>();
            if (level == 0)
            {
                fleet_ar.Add(GlobalConf.fillGameLFleet(7, 7, "Колдун", 0, false, new List<int>() { 1, 0, 0, 0, 0, 2 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(3, 7, "Дарт Вейдер", 1, false, new List<int>() { 1, 2, 2, 2 }));
                //
                fleet_ar.Add(GlobalConf.fillGameLFleet(3, 0, "Добрый", 2, true, new List<int>() { 1, 1, 0, 2, 2, 5 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(7, 0, "Соло", 3, true, new List<int>() { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 5 }));
                GlobalConf.CreateGame();
            }
            if (level == 1)
            {
                fleet_ar.Add(GlobalConf.fillGameLFleet(7, 7, "Капитан", 0, false, new List<int>() { 1, 0, 0, 0, 0 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(6, 7, "Капитан", 0, false, new List<int>() { 1, 0, 0, 0, 0 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(5, 7, "Капитан", 0, false, new List<int>() { 1, 0, 0, 0, 0 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(3, 7, "Дарт Вейдер", 1, false, new List<int>() { 1 }));
                //
                fleet_ar.Add(GlobalConf.fillGameLFleet(3, 0, "Добрый", 2, true, new List<int>() { 1, 1 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(7, 0, "Соло", 3, true, new List<int>() { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
                GlobalConf.CreateGame();
            }
            if (level == 2)
            {
                fleet_ar.Add(GlobalConf.fillGameLFleet(7, 7, "Капитан", 0, false, new List<int>() { 1, 0, 0, 0, 0 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(6, 7, "Капитан", 0, false, new List<int>() { 1, 0, 0, 0, 0 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(5, 7, "Капитан", 0, false, new List<int>() { 1, 0, 0, 0, 0 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(4, 7, "Капитан", 0, false, new List<int>() { 1, 0, 0, 0, 0 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(2, 7, "Капитан", 0, false, new List<int>() { 1, 0, 0, 0, 0 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(3, 7, "Дарт Вейдер", 1, false, new List<int>() { 1 }));
                //
                fleet_ar.Add(GlobalConf.fillGameLFleet(3, 0, "Добрый", 2, true, new List<int>() { 1, 1 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(7, 0, "Соло", 3, true, new List<int>() { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
                GlobalConf.CreateGame();
            }
            // StickBattle.
            if (level == 99)
            {
                fleet_ar.Add(GlobalConf.fillGameLFleet(7, 7, "Капитан", 0, false, new List<int>() { 4, 1, 1 }));
                fleet_ar.Add(GlobalConf.fillGameLFleet(3, 0, "Добрый", 1, true, new List<int>() { 4, 6, 7 }));
            }
            return fleet_ar;
        }
    }
}
