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
        public MechanicalModelListViewModel(JiSuanType jiSuanType)
        {
            InitializeMechanicalModelList(jiSuanType);
        }

        private void InitializeMechanicalModelList(JiSuanType jiSuanType)
        {
            List<TreeViewNode> treeViewNodeList = new List<TreeViewNode>();
            switch (jiSuanType)
            {
                case JiSuanType.KongSuanJiSuan:
                    // The second layer for "空损计算"
                    TreeViewNode JiHeKongSunJiSuanMoXing = new TreeViewNode("空损计算模型", ViewType.JiHeKongSunJiSuanMoXing);
                    TreeViewNode ShuXueKongSunWangGeHuaFen = new TreeViewNode("网格划分", ViewType.ShuXueKongSunWangGeHuaFen);
                    TreeViewNode ShuXueKongSunJiSuanCanShuShuRu = new TreeViewNode("计算参数输入", ViewType.ShuXueKongSunJiSuanCanShuShuRu);
                    TreeViewNode ShuXueKongSunJiSuan = new TreeViewNode("计算", ViewType.ShuXueKongSunJiSuan);
                    TreeViewNode ShuXueKongSunJiSuanJieGuoShuChu = new TreeViewNode("计算结果输出", ViewType.ShuXueKongSunJiSuanJieGuoShuChu);

                    // The first layer for "空损计算"
                    TreeViewNode KongSunJiSuan = new TreeViewNode("空损计算", ViewType.Others);
                    KongSunJiSuan.Nodes = new List<TreeViewNode>() { JiHeKongSunJiSuanMoXing, ShuXueKongSunWangGeHuaFen, ShuXueKongSunJiSuanCanShuShuRu, ShuXueKongSunJiSuan, ShuXueKongSunJiSuanJieGuoShuChu };

                    treeViewNodeList.Add(KongSunJiSuan);
                    break;
                case JiSuanType.HengNiuJuJiSuan:
                    // The second layer for "制动特性计算"
                    TreeViewNode JiHeHengNiuJuJiSuanMoXing = new TreeViewNode("起效特性计算模型", ViewType.JiHeHengNiuJuJiSuanMoXing);
                    TreeViewNode ShuXueZhiDongNiuJuPiPeiTeXingGuanXi = new TreeViewNode("制动扭矩匹配特性关系", ViewType.ShuXueZhiDongNiuJuPiPeiTeXingGuanXi);
                    TreeViewNode ShuXueHengNiuJuWangGeHuaFen = new TreeViewNode("网格划分", ViewType.ShuXueHengNiuJuWangGeHuaFen);
                    TreeViewNode ShuXueHengNiuJuJiSuanCanShuShuRu = new TreeViewNode("计算参数输入", ViewType.ShuXueHengNiuJuJiSuanCanShuShuRu);
                    TreeViewNode ShuXueHengNiuJuJiSuan = new TreeViewNode("计算", ViewType.ShuXueHengNiuJuJiSuan);
                    TreeViewNode ShuXueHengNiuJuJiSuanJieGuoShuChu = new TreeViewNode("计算结果输出", ViewType.ShuXueHengNiuJuJiSuanJieGuoShuChu);

                    // The first layer for "制动特性计算"
                    TreeViewNode HengNiuJuJiSuan = new TreeViewNode("起效特性计算", ViewType.Others);
                    HengNiuJuJiSuan.Nodes = new List<TreeViewNode>() { ShuXueZhiDongNiuJuPiPeiTeXingGuanXi, JiHeHengNiuJuJiSuanMoXing, ShuXueHengNiuJuWangGeHuaFen, ShuXueHengNiuJuJiSuanCanShuShuRu, ShuXueHengNiuJuJiSuan, ShuXueHengNiuJuJiSuanJieGuoShuChu };

                    treeViewNodeList.Add(HengNiuJuJiSuan);
                    break;
            }

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
