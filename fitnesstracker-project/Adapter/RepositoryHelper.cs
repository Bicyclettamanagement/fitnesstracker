using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class RepositoryHelper
    {
        public int GetHighestId(string filePath)
        {
            int highestId = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                // Überspringen der Kopfzeile
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length >= 2)
                    {
                        int Id = int.Parse(fields[0]);

                        if (Id > highestId)
                        {
                            highestId = Id;
                        }
                    }
                }
            }

            return highestId;
        }
    }
}
