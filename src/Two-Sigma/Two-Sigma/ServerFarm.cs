using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Sigma
{
    class ServerFarm
    {
        public static int[][] AllocateJobs(int[] jobs, int servers)
        {
            int[][] answer = new int[servers][];

            if (jobs.Length == 0)
            {
                for (int i = 0; i < servers; i++)
                {
                    answer[i] = new int[0];
                }
                return answer;
            }

            Dictionary<int, List<int>> jobsPerServer = new Dictionary<int, List<int>> { };
            Dictionary<int, int> timeRemaining = new Dictionary<int, int> { };

            for (int i = 0; i < servers; i++)
            {
                jobsPerServer.Add(i, new List<int> { });
                timeRemaining.Add(i, 0);
            }

            int max, maxIndex, leastTime;
            int freestServer = 0;

            while ((max = jobs.Max()) != 0)
            {
                maxIndex = Array.IndexOf(jobs, max);
                leastTime = int.MaxValue;

                foreach (KeyValuePair<int, int> entry in timeRemaining)
                {
                    if (entry.Value < leastTime)
                    {
                        leastTime = entry.Value;
                        freestServer = entry.Key;
                    }
                }

                jobsPerServer[freestServer].Add(maxIndex);
                timeRemaining[freestServer] += max;
                jobs[maxIndex] = 0;
            }

            int[] subArray;
            int x = 0;

            foreach (KeyValuePair<int, List<int>> entry in jobsPerServer)
            {
                subArray = entry.Value.ToArray();
                answer[x] = subArray;
                x++;
            }

            // Show where jobs were allocated
            for (int i = 0; i < servers; i++)
            {
                Console.Write("Server #{0} {{ ", i);
                foreach (int num in answer[i])
                {
                    Console.Write("{0} ", num);
                }
                Console.Write("}\n");
            }

            return answer;
        }

    }
}
