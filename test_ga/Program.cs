using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_ga
{
    class Program
    {
        static int generation = 0;
        static List<membre> pool = new List<membre>();
        public static membre[] test = new membre[500];
        static int[] fit = new int[test.Length];
        static int perfect_score = 100;
        static bool is_finished = false;
        static Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {

            Console.Write("Please enter a target phrase : \n");
            membre.target = Console.ReadLine();
            // Begin timing.
            stopwatch.Start();
            Random r = new Random();
            
            
            
            for (int i =0;i<test.Length;i++)//initialize population
            {
                test[i] = new membre();


            }
            for(int i = 0;i<test.Length;i++)//generate random genes for population
            {
                test[i].set_genes(r);
                
            }
           
            for (int i = 0; i < test.Length; i++)
            {
                test[i].calc_fitness();

            }
    
            while (!is_finished)
            { 
                create_pool();
          
                reproduction(r);
            for (int i = 0; i < test.Length; i++)
            {
                test[i].calc_fitness();

            }
         
            Console.Write(get_best());
                if(is_finished == true)
                {
                    stopwatch.Stop();
                    Console.Write("\n Time elapsed : {0}", stopwatch.Elapsed);
                }



           }
            
            Console.ReadKey();

        }
        public static void create_pool()
        {
            pool.Clear();
            
            for(int i =0; i<test.Length;i++)
            {
                int n = test[i].fitness;
                for(int j =0;j<n;j++)
                {
                    pool.Add(test[i]);
                }

            }

        }

        public static void reproduction(Random r)
        {
            for(int i =0;i<test.Length;i++)
            {
                int index_parent_a = r.Next(pool.Count);
           
                int index_parent_b = r.Next(pool.Count);
            
                membre ma = pool[index_parent_a];
            
                membre mb = pool[index_parent_b];
            
                membre child = ma.crossover(mb, r);// crossover
            
                child.mutate(r);//mutation
                test[i] = child;
            }
            generation++;
            
        }

        public static string get_best()
        {
            string result;
            int record = 0;
            int index = 0;
            for(int i =0;i<test.Length;i++)
            {
                if(test[i].fitness > record)
                {
                    index = i;
                    record = test[i].fitness;

                }
            }

            if(record == perfect_score)
            {
                is_finished = true;
            }           
            result = new string(test[index].genes);          
            result = "Best result so far :"+result + " ,fitness : "+ test[index].fitness.ToString()+",generation :"+generation+"\n";
            return result;

        }
    }
}
