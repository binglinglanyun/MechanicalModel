using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MechanicalModel.ViewModels
{
    public class MechanicalModelListViewModel : PropertyChangedBaseCommonClass
    {
        public MechanicalModelListViewModel()
        {
            InitializeMechanicalModelList();
        }

        private void InitializeMechanicalModelList()
        {
            List<TreeViewNode> treeViewNodeList = new List<TreeViewNode>();

            // The second layer for the first node
            TreeViewNode JiHeMoXingDaoRuZhuangPei = new TreeViewNode("几何模型导入/装配", ViewType.JiHeMoXingDaoRuZhuangPei);

            // The first layer for the first node
            TreeViewNode CanShuHuaMoXing = new TreeViewNode("参数化模型", ViewType.Others);
            CanShuHuaMoXing.Nodes = new List<TreeViewNode>() { JiHeMoXingDaoRuZhuangPei };

            // The third layer for the second node
            TreeViewNode WangGeHuaFen = new TreeViewNode("网格划分", ViewType.WangGeHuaFen);
            TreeViewNode JiSuanCanShuShuRu = new TreeViewNode("计算参数输入", ViewType.JiSuanCanShuShuRu);
            TreeViewNode JiSuan = new TreeViewNode("计算", ViewType.JiSuan);
            TreeViewNode JiSuanJieGuoShuChu = new TreeViewNode("计算结果输出", ViewType.JiSuanJieGuoShuChu);

            // The second layer for the second node
            TreeViewNode HengNiuJuJiSuan = new TreeViewNode("恒扭矩计算", ViewType.Others);
            HengNiuJuJiSuan.Nodes = new List<TreeViewNode>() { WangGeHuaFen, JiSuanCanShuShuRu, JiSuan, JiSuanJieGuoShuChu };
            TreeViewNode KongSunJiSuan = new TreeViewNode("空损计算", ViewType.Others);

            // The first layer for the second node
            TreeViewNode LiuChangFangZhen = new TreeViewNode("流场仿真数学模型", ViewType.Others);
            LiuChangFangZhen.Nodes = new List<TreeViewNode>() { KongSunJiSuan, HengNiuJuJiSuan };

            treeViewNodeList.Add(CanShuHuaMoXing);
            treeViewNodeList.Add(LiuChangFangZhen);

            this.TreeViewNodeList = treeViewNodeList;
        }

        private List<TreeViewNode> _treeViewNodeList = null;
        public List<TreeViewNode> TreeViewNodeList
        {
            get
            {
                return _treeViewNodeList;
            }
            set
            {
                SetClassProperty(value, ref _treeViewNodeList);
            }
        }

        private ICommand _click;
        public ICommand Click
        {
            get
            {
                return _click;
            }
            set
            {
                if (_click != value)
                {
                    _click = value;
                    NotifyPropertyChanged("Click");
                }
            }
        }
    }
}
