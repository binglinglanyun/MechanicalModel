using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MechanicalModel.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBaseCommonClass
    {
        // "进气比空损"
        private JinQiBiKongSunJiSuanMoXingViewModel _jinQiBiKongSunJiSuanMoXingViewModel = null;
        private JinQiBiKongSunWangGeHuaFenViewModel _jinQiBiKongSunWangGeHuaFenViewModel = null;
        private JinQiBiKongSunJiSuanCanShuShuRuViewModel _jinQiBiKongSunJiSuanCanShuShuRuViewModel = null;
        private JinQiBiKongSunJiSuanViewModel _jinQiBiKongSunJiSuanViewModel = null;
        private JinQiBiKongSunJiSuanJieGuoShuChuViewModel _jinQiBiKongSunJiSuanJieGuoShuChuViewModel = null;

        // "进油通道空损"
        private JinYouTongDaoKongSunJiSuanMoXingViewModel _jinYouTongDaoJiSuanJiHeMoXingViewModel = null;
        private JinYouTongDaoKongSunWangGeHuaFenViewModel _jinYouTongDaoKongSunWangGeHuaFenViewModel = null;
        private JinYouTongDaoKongSunJiSuanCanShuShuRuViewModel _jinYouTongDaoKongSunJiSuanCanShuShuRuViewModel = null;
        private JinYouTongDaoKongSunJiSuanViewModel _jinYouTongDaoKongSunJiSuanViewModel = null;
        private JinYouTongDaoKongSunJiSuanJieGuoShuChuViewModel _jinYouTongDaoKongSunJiSuanJieGuoShuChuViewModel = null;

        // "制动特性计算"
        private ZhiDongNiuJuPiPeiTeXingGuanXiViewModel _zhiDongNiuJuPiPeiTeXingGuanXiViewModel = null;
        private HengNiuJuJiSuanMoXingViewModel _hengNiuJuJiSuanMoXingViewModel = null;
        private HengNiuJuWangGeHuaFenViewModel _hengNiuJuWangGeHuaFenViewModel = null;
        private HengNiuJuJiSuanCanShuShuRuViewModel _hengNiuJuJiSuanCanShuShuRuViewModel = null;
        private HengNiuJuJiSuanViewModel _hengNiuJuJiSuanViewModel = null;
        private HengNiuJuJiSuanJieGuoShuChuViewModel _hengNiuJuJiSuanJieGuoShuChuViewModel = null;

        public MainWindowViewModel()
        {
        }

        #region Properties
        private MechanicalModelListViewModel _mechanicalModelListViewModel;
        public MechanicalModelListViewModel MechanicalModelListViewModel
        {
            get
            {
                return _mechanicalModelListViewModel;
            }
            set
            {
                SetClassProperty(value, ref _mechanicalModelListViewModel);
            }
        }

        private IViewModelCategory _mechanicalModelViewHostViewModel;
        public IViewModelCategory MechanicalModelViewHostViewModel
        {
            get
            {
                return _mechanicalModelViewHostViewModel;
            }
            set
            {
                SetClassProperty(value, ref _mechanicalModelViewHostViewModel);
            }
        }

        private Visibility _mechanicalModelContentVisibility = Visibility.Collapsed;
        public Visibility MechanicalModelContentVisibility
        {
            get
            {
                return _mechanicalModelContentVisibility;
            }
            set
            {
                SetValueProperty(value, ref _mechanicalModelContentVisibility);
            }
        }

        private Visibility _jiSuanButtonVisibility = Visibility.Visible;
        public Visibility JiSuanButtonVisibility
        {
            get
            {
                return _jiSuanButtonVisibility;
            }
            set
            {
                SetValueProperty(value, ref _jiSuanButtonVisibility);
            }
        }

        private Visibility _niuJuPiPeiTeXingFenXiXiTongMainWindowVisibility = Visibility.Collapsed;
        public Visibility NiuJuPiPeiTeXingFenXiXiTongMainWindowVisibility
        {
            get
            {
                return _niuJuPiPeiTeXingFenXiXiTongMainWindowVisibility;
            }
            set
            {
                SetValueProperty(value, ref _niuJuPiPeiTeXingFenXiXiTongMainWindowVisibility);
            }
        }

        public string BackgroundSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/background.jpg"); ;
            }
        }

        public string KongSunJiSuanSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/KongSunJiHeMoXing.png"); ;
            }
        }

        public string HengNiuJuJiSuanSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/HengNiuJuJiHeMoXing.png"); ;
            }
        }
        #endregion

        public ICommand OpenNewView
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    TreeViewNode node = o as TreeViewNode;
                    if (node != null)
                    {
                        MechanicalModelContentVisibility = Visibility.Visible;
                        switch (node.ViewType)
                        {
                            // "进油比空损"
                            case ViewType.JinQiBiKongSunJiSuanMoXing:
                                _jinQiBiKongSunJiSuanMoXingViewModel = _jinQiBiKongSunJiSuanMoXingViewModel ?? new JinQiBiKongSunJiSuanMoXingViewModel();
                                this.MechanicalModelViewHostViewModel = _jinQiBiKongSunJiSuanMoXingViewModel;
                                return;
                            case ViewType.JinQiBiKongSunWangGeHuaFen:
                                _jinQiBiKongSunWangGeHuaFenViewModel = _jinQiBiKongSunWangGeHuaFenViewModel ?? new JinQiBiKongSunWangGeHuaFenViewModel();
                                this.MechanicalModelViewHostViewModel = _jinQiBiKongSunWangGeHuaFenViewModel;
                                return;
                            case ViewType.JinQiBiKongSunJiSuanCanShuShuRu:
                                _jinQiBiKongSunJiSuanCanShuShuRuViewModel = _jinQiBiKongSunJiSuanCanShuShuRuViewModel ?? new JinQiBiKongSunJiSuanCanShuShuRuViewModel();
                                this.MechanicalModelViewHostViewModel = _jinQiBiKongSunJiSuanCanShuShuRuViewModel;
                                return;
                            case ViewType.JinQiBiKongSunJiSuan:
                                _jinQiBiKongSunJiSuanViewModel = _jinQiBiKongSunJiSuanViewModel ?? new JinQiBiKongSunJiSuanViewModel();
                                this.MechanicalModelViewHostViewModel = _jinQiBiKongSunJiSuanViewModel;
                                return;
                            case ViewType.JinQiBiKongSunJiSuanJieGuoShuChu:
                                _jinQiBiKongSunJiSuanJieGuoShuChuViewModel = _jinQiBiKongSunJiSuanJieGuoShuChuViewModel ?? new JinQiBiKongSunJiSuanJieGuoShuChuViewModel();
                                this.MechanicalModelViewHostViewModel = _jinQiBiKongSunJiSuanJieGuoShuChuViewModel;
                                return;

                            // "进油通道空损"
                            case ViewType.JinYouTongDaoJiSuanJiHeMoXing:
                                _jinYouTongDaoJiSuanJiHeMoXingViewModel = _jinYouTongDaoJiSuanJiHeMoXingViewModel ?? new JinYouTongDaoKongSunJiSuanMoXingViewModel();
                                this.MechanicalModelViewHostViewModel = _jinYouTongDaoJiSuanJiHeMoXingViewModel;
                                return;
                            case ViewType.JinYouTongDaoKongSunWangGeHuaFen:
                                _jinYouTongDaoKongSunWangGeHuaFenViewModel = _jinYouTongDaoKongSunWangGeHuaFenViewModel ?? new JinYouTongDaoKongSunWangGeHuaFenViewModel();
                                this.MechanicalModelViewHostViewModel = _jinYouTongDaoKongSunWangGeHuaFenViewModel;
                                return;
                            case ViewType.JinYouTongDaoKongSunJiSuanCanShuShuRu:
                                _jinYouTongDaoKongSunJiSuanCanShuShuRuViewModel = _jinYouTongDaoKongSunJiSuanCanShuShuRuViewModel ?? new JinYouTongDaoKongSunJiSuanCanShuShuRuViewModel();
                                this.MechanicalModelViewHostViewModel = _jinYouTongDaoKongSunJiSuanCanShuShuRuViewModel;
                                return;
                            case ViewType.JinYouTongDaoKongSunJiSuan:
                                _jinYouTongDaoKongSunJiSuanViewModel = _jinYouTongDaoKongSunJiSuanViewModel ?? new JinYouTongDaoKongSunJiSuanViewModel();
                                this.MechanicalModelViewHostViewModel = _jinYouTongDaoKongSunJiSuanViewModel;
                                return;
                            case ViewType.JinYouTongDaoKongSunJiSuanJieGuoShuChu:
                                _jinYouTongDaoKongSunJiSuanJieGuoShuChuViewModel = _jinYouTongDaoKongSunJiSuanJieGuoShuChuViewModel ?? new JinYouTongDaoKongSunJiSuanJieGuoShuChuViewModel();
                                this.MechanicalModelViewHostViewModel = _jinYouTongDaoKongSunJiSuanJieGuoShuChuViewModel;
                                return;

                            // "制动特性计算"
                            case ViewType.ZhiDongNiuJuPiPeiTeXingGuanXi:
                                _zhiDongNiuJuPiPeiTeXingGuanXiViewModel = _zhiDongNiuJuPiPeiTeXingGuanXiViewModel ?? new ZhiDongNiuJuPiPeiTeXingGuanXiViewModel();
                                this.MechanicalModelViewHostViewModel = _zhiDongNiuJuPiPeiTeXingGuanXiViewModel;
                                return;
                            case ViewType.HengNiuJuJiSuanMoXing:
                                _hengNiuJuJiSuanMoXingViewModel = _hengNiuJuJiSuanMoXingViewModel ?? new HengNiuJuJiSuanMoXingViewModel();
                                this.MechanicalModelViewHostViewModel = _hengNiuJuJiSuanMoXingViewModel;
                                return;
                            case ViewType.HengNiuJuWangGeHuaFen:
                                _hengNiuJuWangGeHuaFenViewModel = _hengNiuJuWangGeHuaFenViewModel ?? new HengNiuJuWangGeHuaFenViewModel();
                                this.MechanicalModelViewHostViewModel = _hengNiuJuWangGeHuaFenViewModel;
                                return;
                            case ViewType.HengNiuJuJiSuanCanShuShuRu:
                                _hengNiuJuJiSuanCanShuShuRuViewModel = _hengNiuJuJiSuanCanShuShuRuViewModel ?? new HengNiuJuJiSuanCanShuShuRuViewModel();
                                this.MechanicalModelViewHostViewModel = _hengNiuJuJiSuanCanShuShuRuViewModel;
                                return;
                            case ViewType.HengNiuJuJiSuan:
                                _hengNiuJuJiSuanViewModel = _hengNiuJuJiSuanViewModel ?? new HengNiuJuJiSuanViewModel();
                                this.MechanicalModelViewHostViewModel = _hengNiuJuJiSuanViewModel;
                                return;
                            case ViewType.HengNiuJuJiSuanJieGuoShuChu:
                                _hengNiuJuJiSuanJieGuoShuChuViewModel = _hengNiuJuJiSuanJieGuoShuChuViewModel ?? new HengNiuJuJiSuanJieGuoShuChuViewModel();
                                this.MechanicalModelViewHostViewModel = _hengNiuJuJiSuanJieGuoShuChuViewModel;
                                return;
                            case ViewType.Others:
                                break;
                        }
                    }

                    MechanicalModelContentVisibility = Visibility.Collapsed;
                });
            }
        }

        public ICommand KongSunJiSuanClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    this.JiSuanButtonVisibility = Visibility.Collapsed;
                    this.NiuJuPiPeiTeXingFenXiXiTongMainWindowVisibility = Visibility.Visible;
                    this.MechanicalModelListViewModel = new MechanicalModelListViewModel(JiSuanType.KongSuanJiSuan);
                    this.MechanicalModelListViewModel.Click = OpenNewView;
                });
            }
        }

        public ICommand HengNiuJuJiSuanClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    this.JiSuanButtonVisibility = Visibility.Collapsed;
                    this.NiuJuPiPeiTeXingFenXiXiTongMainWindowVisibility = Visibility.Visible;
                    this.MechanicalModelListViewModel = new MechanicalModelListViewModel(JiSuanType.HengNiuJuJiSuan);
                    this.MechanicalModelListViewModel.Click = OpenNewView;
                });
            }
        }
    }
}
