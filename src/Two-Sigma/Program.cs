using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Sigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] jobs = { 15, 30, 15, 5, 10 };
            int servers = 3;

            ServerFarm.AllocateJobs(jobs, servers);
            Console.ReadKey(true);
        }
    }
}
