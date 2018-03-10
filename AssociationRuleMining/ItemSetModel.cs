using System.Collections.Generic;
using System.Linq;

namespace AssociationRuleMining {
    public class ItemSetModel {
        List<string> items;

        public ItemSetModel() {}
        public ItemSetModel(params string[] items) {
            this.items = items.ToList<string>();
        }

        public ItemSetModel(string items) {
            this.items = items.Split(',').ToList();
        }
    }
}