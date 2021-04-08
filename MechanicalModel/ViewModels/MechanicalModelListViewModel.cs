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
                    // The second layer for "变进气比空损计算"
                    TreeViewNode JinQiBiKongSunJiSuanMoXing = new TreeViewNode("空损计算模型", ViewType.JinQiBiKongSunJiSuanMoXing);
                    TreeViewNode JinQiBiKongSunWangGeHuaFen = new TreeViewNode("网格划分", ViewType.JinQiBiKongSunWangGeHuaFen);
                    TreeViewNode JinQiBiKongSunJiSuanCanShuShuRu = new TreeViewNode("计算参数输入", ViewType.JinQiBiKongSunJiSuanCanShuShuRu);
                    TreeViewNode JinQiBiKongSunJiSuan = new TreeViewNode("计算", ViewType.JinQiBiKongSunJiSuan);
                    TreeViewNode JinQiBiKongSunJiSuanJieGuoShuChu = new TreeViewNode("计算结果输出", ViewType.JinQiBiKongSunJiSuanJieGuoShuChu);

                    // The first layer for "变进气比空损计算"
                    TreeViewNode BianJinQiBiKongSunJiSuan = new TreeViewNode("变进气比空损计算", ViewType.Others);
                    BianJinQiBiKongSunJiSuan.Nodes = new List<TreeViewNode>() { JinQiBiKongSunJiSuanMoXing, JinQiBiKongSunWangGeHuaFen, JinQiBiKongSunJiSuanCanShuShuRu, JinQiBiKongSunJiSuan, JinQiBiKongSunJiSuanJieGuoShuChu };

                    // The second layer for "变进油通道空损计算"
                    TreeViewNode JinYouTongDaoJiSuanJiHeMoXing = new TreeViewNode("计算几何模型", ViewType.JinYouTongDaoJiSuanJiHeMoXing);
                    TreeViewNode JinYouTongDaoKongSunWangGeHuaFen = new TreeViewNode("网格划分", ViewType.JinYouTongDaoKongSunWangGeHuaFen);
                    TreeViewNode JinYouTongDaoKongSunJiSuanCanShuShuRu = new TreeViewNode("计算参数输入", ViewType.JinYouTongDaoKongSunJiSuanCanShuShuRu);
                    TreeViewNode JinYouTongDaoKongSunJiSuan = new TreeViewNode("计算", ViewType.JinYouTongDaoKongSunJiSuan);
                    TreeViewNode JinYouTongDaoKongSunJiSuanJieGuoShuChu = new TreeViewNode("计算结果输出", ViewType.JinYouTongDaoKongSunJiSuanJieGuoShuChu);

                    // The first layer for "变进油通道空损计算"
                    TreeViewNode BianJinYouTongDaoKongSunJiSuan = new TreeViewNode("变进油通道空损计算", ViewType.Others);
                    BianJinYouTongDaoKongSunJiSuan.Nodes = new List<TreeViewNode>() { JinYouTongDaoJiSuanJiHeMoXing, JinYouTongDaoKongSunWangGeHuaFen, JinYouTongDaoKongSunJiSuanCanShuShuRu, JinYouTongDaoKongSunJiSuan, JinYouTongDaoKongSunJiSuanJieGuoShuChu };

                    // Add "变进油通道空损计算" and "变进气比空损计算" to the tree
                    treeViewNodeList.Add(BianJinYouTongDaoKongSunJiSuan);
                    treeViewNodeList.Add(BianJinQiBiKongSunJiSuan);
                    break;
                case JiSuanType.HengNiuJuJiSuan:
                    // The second layer for "制动特性计算"
                    TreeViewNode HengNiuJuJiSuanMoXing = new TreeViewNode("制动特性计算模型", ViewType.HengNiuJuJiSuanMoXing);
                    TreeViewNode ZhiDongNiuJuPiPeiTeXingGuanXi = new TreeViewNode("制动扭矩匹配特性关系", ViewType.ZhiDongNiuJuPiPeiTeXingGuanXi);
                    TreeViewNode HengNiuJuWangGeHuaFen = new TreeViewNode("网格划分", ViewType.HengNiuJuWangGeHuaFen);
                    TreeViewNode HengNiuJuJiSuanCanShuShuRu = new TreeViewNode("计算参数输入", ViewType.HengNiuJuJiSuanCanShuShuRu);
                    TreeViewNode HengNiuJuJiSuan = new TreeViewNode("计算", ViewType.HengNiuJuJiSuan);
                    TreeViewNode HengNiuJuJiSuanJieGuoShuChu = new TreeViewNode("计算结果输出", ViewType.HengNiuJuJiSuanJieGuoShuChu);

                    // The first layer for "制动特性计算"
                    TreeViewNode ZhiDongTeXingJiSuan = new TreeViewNode("制动特性计算", ViewType.Others);
                    ZhiDongTeXingJiSuan.Nodes = new List<TreeViewNode>() { ZhiDongNiuJuPiPeiTeXingGuanXi, HengNiuJuJiSuanMoXing, HengNiuJuWangGeHuaFen, HengNiuJuJiSuanCanShuShuRu, HengNiuJuJiSuan, HengNiuJuJiSuanJieGuoShuChu };

                    treeViewNodeList.Add(ZhiDongTeXingJiSuan);
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
