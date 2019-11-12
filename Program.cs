using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surf_up_sequence_diagram
{
    class Program
    {
        static void Main(string[] args)
        {
            run(@"C:\Users\Diego\Desktop\Scores.txt"); // ubicacion del archivo de los scores ya depende donde se pone y se puna la ruta nada mas

        }

        public static void run(string path)
        {
            List<String[]> listContest = new List<String[]>();
            string[] info = { };

            if (File.Exists(path)) // valida el archivo del "scores"
            {
                info = File.ReadAllLines(path); //lee el archivo
            }

            else // flow alternativo si no se encuentra el archivo
            {
                Console.WriteLine("Incorrect file path, please enter a valid path.");
            }


            int counter = 0;
            int minor = 0;
            foreach (string i in info) //los puntos y nombres los separa
            {
                string[] names = i.Split(' ');

                listContest.Add(names);
                if (int.Parse(listContest[counter][1]) < int.Parse(listContest[minor][1]))
                {
                    minor = counter;
                }

                counter++;
            }

            //pone en orden los 3 primero lugares 
            int firstPlace = minor;
            int secondPlace = minor;
            int thirdPlace = minor;


            for (int i = 1; i < listContest.Count; i++)
            {
                if (int.Parse(listContest[firstPlace][1]) < int.Parse(listContest[i][1]))
                {
                    thirdPlace = secondPlace;
                    secondPlace = firstPlace;
                    firstPlace = i;
                }
            }

            //Pone display los 3 primeros lugares 
            Console.WriteLine("The first place is " + listContest[firstPlace][0] + " with " + listContest[firstPlace][1]);
            Console.WriteLine("The second place is " + listContest[secondPlace][0] + " with " + listContest[secondPlace][1]);
            Console.WriteLine("The third place is " + listContest[thirdPlace][0] + " with " + listContest[thirdPlace][1]);
        }
    }
}
