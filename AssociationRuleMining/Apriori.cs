using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AssociationRuleMining
{
    public class Apriori
    {
        private List<List<DatasetModel>> qualifiedItemSet; // L_k
        private List<List<ItemSetModel>> candidateItemSet; // C_k
        private StreamReader srFile;

        public void CountSupport()
        {
            var L = qualifiedItemSet.LastOrDefault();
            try
            {
                string line;

                while ((line = srFile.ReadLine()) != null)
                {
                    var lineData = line.Split(',');
                    if (lineData.Length != L.Count)
                    {
                        break;
                    }

                    for (int i = 0; i < lineData.Length; i++)
                    {
                        L[i].AddCount(Convert.ToInt16(lineData[i]));
                    }
                }

                qualifiedItemSet.Add(
                    L.Where(x => x.count > 3)
                            .ToList<DatasetModel>()
                );
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private void MakeCandidateItemSet()
        {
            List<ItemSetModel> c; // C_k-1

            if (qualifiedItemSet != null)
            {
                var cprev = qualifiedItemSet.LastOrDefault()
                                        .Select(x => x.itemset)
                                        .ToList<ItemSetModel>();
                var temp = cprev;
                c = new List<ItemSetModel>();
                for (int i = 0; i < cprev.Count; i++) {
                    for (int j = 0; j < temp.Count; j++) {
                        c.Add(new ItemSetModel(cprev[i].items.FirstOrDefault(), temp[j].items.FirstOrDefault()));
                    }
                    temp = cprev.GetRange(i+1, cprev.Count - i - 1);
                }
            }
            else
            {
                // first C
                candidateItemSet = new List<List<ItemSetModel>>();
                srFile = File.OpenText(@"data");

                var line = srFile.ReadLine();
                var items = line.Split(',');
                c = new List<ItemSetModel>();
                for (int i = 0; i < items.Length; i++) {
                    c.Add(new ItemSetModel(items[i]));
                }
            }


            candidateItemSet.Add(c);
        }
    }
}