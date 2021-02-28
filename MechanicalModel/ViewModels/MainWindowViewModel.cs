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
        private JinQiBiKongSunJiSuanMoXingViewModel _jinQiBiKongSunJiSuanMoXingViewModel = null;
        private HengNiuJuJiSuanMoXingViewModel _hengNiuJuJiSuanMoXingViewModel = null;
        private JinQiBiKongSunWangGeHuaFenViewModel _jinQiBiKongSunWangGeHuaFenViewModel = null;
        private JinQiBiKongSunJiSuanCanShuShuRuViewModel _jinQiBiKongSunJiSuanCanShuShuRuViewModel = null;
        private JinQiBiKongSunJiSuanViewModel _jinQiBiKongSunJiSuanViewModel = null;
        private JinQiBiKongSunJiSuanJieGuoShuChuViewModel _jinQiBiKongSunJiSuanJieGuoShuChuViewModel = null;
        private ZhiDongNiuJuPiPeiTeXingGuanXiViewModel _zhiDongNiuJuPiPeiTeXingGuanXiViewModel = null;
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
                            case ViewType.JiHeKongSunJiSuanMoXing:
                                _jinQiBiKongSunJiSuanMoXingViewModel = _jinQiBiKongSunJiSuanMoXingViewModel ?? new JinQiBiKongSunJiSuanMoXingViewModel();
                                this.MechanicalModelViewHostViewModel = _jinQiBiKongSunJiSuanMoXingViewModel;
                                return;
                            case ViewType.JiHeHengNiuJuJiSuanMoXing:
                                _hengNiuJuJiSuanMoXingViewModel = _hengNiuJuJiSuanMoXingViewModel ?? new HengNiuJuJiSuanMoXingViewModel();
                                this.MechanicalModelViewHostViewModel = _hengNiuJuJiSuanMoXingViewModel;
                                return;
                            case ViewType.ShuXueKongSunWangGeHuaFen:
                                _jinQiBiKongSunWangGeHuaFenViewModel = _jinQiBiKongSunWangGeHuaFenViewModel ?? new JinQiBiKongSunWangGeHuaFenViewModel();
                                this.MechanicalModelViewHostViewModel = _jinQiBiKongSunWangGeHuaFenViewModel;
                                return;
                            case ViewType.ShuXueKongSunJiSuanCanShuShuRu:
                                _jinQiBiKongSunJiSuanCanShuShuRuViewModel = _jinQiBiKongSunJiSuanCanShuShuRuViewModel ?? new JinQiBiKongSunJiSuanCanShuShuRuViewModel();
                                this.MechanicalModelViewHostViewModel = _jinQiBiKongSunJiSuanCanShuShuRuViewModel;
                                return;
                            case ViewType.ShuXueKongSunJiSuan:
                                _jinQiBiKongSunJiSuanViewModel = _jinQiBiKongSunJiSuanViewModel ?? new JinQiBiKongSunJiSuanViewModel();
                                this.MechanicalModelViewHostViewModel = _jinQiBiKongSunJiSuanViewModel;
                                return;
                            case ViewType.ShuXueKongSunJiSuanJieGuoShuChu:
                                _jinQiBiKongSunJiSuanJieGuoShuChuViewModel = _jinQiBiKongSunJiSuanJieGuoShuChuViewModel ?? new JinQiBiKongSunJiSuanJieGuoShuChuViewModel();
                                this.MechanicalModelViewHostViewModel = _jinQiBiKongSunJiSuanJieGuoShuChuViewModel;
                                return;
                            case ViewType.ShuXueZhiDongNiuJuPiPeiTeXingGuanXi:
                                _zhiDongNiuJuPiPeiTeXingGuanXiViewModel = _zhiDongNiuJuPiPeiTeXingGuanXiViewModel ?? new ZhiDongNiuJuPiPeiTeXingGuanXiViewModel();
                                this.MechanicalModelViewHostViewModel = _zhiDongNiuJuPiPeiTeXingGuanXiViewModel;
                                return;
                            case ViewType.ShuXueHengNiuJuWangGeHuaFen:
                                _hengNiuJuWangGeHuaFenViewModel = _hengNiuJuWangGeHuaFenViewModel ?? new HengNiuJuWangGeHuaFenViewModel();
                                this.MechanicalModelViewHostViewModel = _hengNiuJuWangGeHuaFenViewModel;
                                return;
                            case ViewType.ShuXueHengNiuJuJiSuanCanShuShuRu:
                                _hengNiuJuJiSuanCanShuShuRuViewModel = _hengNiuJuJiSuanCanShuShuRuViewModel ?? new HengNiuJuJiSuanCanShuShuRuViewModel();
                                this.MechanicalModelViewHostViewModel = _hengNiuJuJiSuanCanShuShuRuViewModel;
                                return;
                            case ViewType.ShuXueHengNiuJuJiSuan:
                                _hengNiuJuJiSuanViewModel = _hengNiuJuJiSuanViewModel ?? new HengNiuJuJiSuanViewModel();
                                this.MechanicalModelViewHostViewModel = _hengNiuJuJiSuanViewModel;
                                return;
                            case ViewType.ShuXueHengNiuJuJiSuanJieGuoShuChu:
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
