using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MainScript
{
    public class TaskA
    {
        static int Id = 666;
        public delegate int EventArgs(int x);
        static TaskA()
        {
            EventArgs eventDelegate = GetId;
            eventDelegate+= PrintId;
            var kol = eventDelegate(5);
            
            ReadIdDelegate(UnPrintId,77);
           var stop =  FuncIdDelegate(FuncPrintId, 77777);
Debug.Log("0000 === == ____" + stop);
        }
        public TaskA()
        {
            Debug.Log("0001 ======= ____");
        }

        public void Count(object Sync)
        {
            lock (Sync)
            {
                Debug.Log("0002 ======= ____");
                Thread.Sleep(1000);
                Debug.Log("0003 ======= ____");
            }
        }
        public static int GetId(int y) => Id - y;
        public static int PrintId(int y) {
            Debug.Log("0006 ======= ____");
            return Id;
        }
        public static void UnPrintId(int z)
        {
            Debug.Log("0008===== ____"+z);
        }
        public static int ReadIdDelegate(Action<int> DelegNum,int z)
        {
            DelegNum(z);
            Debug.Log("0007 ====== ____" );
            return Id;
        }
        public static int FuncPrintId(int z)
        {
            Debug.Log("0010===== ____" + z);
            return z;
        }
        public static int FuncIdDelegate(Func<int,int> DelegNum, int z)
        {
            DelegNum(z);
            Debug.Log("0011 ====== ____");
            return z;
        }
        public int this[string Index]
        {
            get => 999999;
        }
    }
}
