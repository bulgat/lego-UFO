using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.strategChess
{
    public static class RusticEventTile
    {

        // there's a good standard class for it, do not re-invent the wheel
        public static event EventHandler HappyBirthday;

        //EventHandler(this, EventArgs.Empty);
        public static void Send(PathMove pathMove)
        {
            if (null != HappyBirthday)
            {
                HappyBirthday((object)pathMove, EventArgs.Empty);
            }
        }
    }
}
