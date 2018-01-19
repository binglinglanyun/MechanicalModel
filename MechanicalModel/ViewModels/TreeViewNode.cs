using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.ViewModels
{
    public class TreeViewNode
    {
        public TreeViewNode(string name, ViewType type)
        {
            this.NodeName = name;
            this.ViewType = type;
        }

        public string NodeName { get; set; }
        public ViewType ViewType { get; set; }
        public List<TreeViewNode> Nodes { get; set; }
    }
}
