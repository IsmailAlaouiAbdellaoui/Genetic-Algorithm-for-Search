using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test_ga
{
    public  class membre
    {
        
         public static string target ;
         public  char[] genes;
        public int fitness;
        public double mutation_rate = 0.02;
         


        public  membre()
        {
           genes = new char[target.Length];
            
            
            

        }
        public void set_genes(Random r)
        {
            
            for (int i = 0; i < target.Length; i++)
            {

                genes[i] = Convert.ToChar(r.Next(32, 127));
            }

        }
        public void calc_fitness()
        {
            double score = 0;
            double temp;
            char[] targ_array = target.ToCharArray();
            for(int i =0;i<targ_array.Length;i++)
            {
                if(genes[i] == targ_array[i])
                {
                    score++;
                    //Console.Write("score++!!!");
                }
                
            }
            temp = score / Convert.ToDouble(target.Length);
            temp *= 100;
            fitness = Convert.ToInt32(temp);
        }
        public membre crossover(membre partner,Random r)
        {
            membre c = new membre();
            int midpoint = r.Next(genes.Length);
            for(int i =0;i<genes.Length;i++)
            {
                if(i>midpoint)
                {
                    c.genes[i] = genes[i];
                }
                else
                {
                    c.genes[i] = partner.genes[i];
                }
            }


            return c;
        } 
        public void mutate(Random r)
        {
            for(int i =0;i<genes.Length;i++)
            {
                if(r.NextDouble() < mutation_rate)
                {
                    genes[i] = Convert.ToChar(r.Next(32, 127));
                }
            }
        }

    }
}
