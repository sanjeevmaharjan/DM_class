using System;
using System.Collections.Generic;
using System.Linq;

namespace AssociationRuleMining
{
    public class DatasetModel {
        public ItemSetModel itemset { get; private set;}
        public int count {get; private set;}

        /*
         * @params
         *      string: comma separated items in itemsets
         *      int: count
         */
        public DatasetModel(string items, int count) : this(new ItemSetModel(items.Split(',')), count) {}
        public DatasetModel(ItemSetModel itemset, int count) {
            this.itemset = itemset;
            this.count = count;
        }

        public void AddCount(int n) {
            count += n;
        }
    }
}