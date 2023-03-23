using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System.Collections.Concurrent;
//using System.Random;

namespace Assets.MainScript
{
    public class ThreadA
    {
        private ConcurrentQueue<string> AgentConcurentList;
        private List<string> AgentList;
        public ThreadA()
        {
            AgentList = new List<string>() {"dfgf","tt", "tt" };
            AgentConcurentList = new ConcurrentQueue<string>();
            AgentConcurentList.Enqueue("gfdg9");
            AgentConcurentList.Enqueue("gfdg0");
            AgentConcurentList.Enqueue("gfdg8");
            ThreadPool.QueueUserWorkItem(AddNewCall);

            ThreadPool.QueueUserWorkItem(HandleCall);
            ThreadPool.QueueUserWorkItem(HandleCall);
            ThreadPool.QueueUserWorkItem(HandleCall);
            ThreadPool.QueueUserWorkItem(HandleCall);
            ThreadPool.QueueUserWorkItem(HandleCall);
        }
        public void AddNewCall(object StateInfo)
        {
            while (true)
            {
                Debug.Log("start");
                System.Random r = new System.Random();
                int sleepTime = r.Next(1,15);
                Thread.Sleep(sleepTime * 1000);
                Debug.Log("end");
            }
        }
        public void HandleCall(object StateInfo)
        {
            string agent = this.AgentConcurentList.First();
            if (agent != null)
            {
                lock (agent)
                {
                    Debug.Log("--start agent L=" + this.AgentConcurentList.Count);
                    Thread.Sleep(15 * 1000);
                    //this.AgentConcurentList.RemoveAt(0);
                    this.AgentConcurentList.TryDequeue(out agent);
                    Debug.Log("--end agent L" + this.AgentConcurentList.Count);
                }
            }
        }
    }
}
