using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MechanicalModel.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBaseCommonClass
    {
        private JiHeKongSunJiSuanMoXingViewModel _jiHeKongSunJiSuanMoXingViewModel = null;
        private JiHeHengNiuJuJiSuanMoXingViewModel _jiHeHengNiuJuJiSuanMoXingViewModel = null;
        private ShuXueKongSunWangGeHuaFenViewModel _shuXueKongSunWangGeHuaFenViewModel = null;
        private ShuXueKongSunJiSuanCanShuShuRuViewModel _shuXueKongSunJiSuanCanShuShuRuViewModel = null;
        private ShuXueKongSunJiSuanViewModel _shuXueKongSunJiSuanViewModel = null;
        private ShuXueKongSunJiSuanJieGuoShuChuViewModel _shuXueKongSunJiSuanJieGuoShuChuViewModel = null;
        private ShuXueZhiDongNiuJuPiPeiTeXingGuanXiViewModel _shuXueZhiDongNiuJuPiPeiTeXingGuanXiViewModel = null;
        private ShuXueHengNiuJuWangGeHuaFenViewModel _shuXueHengNiuJuWangGeHuaFenViewModel = null;
        private ShuXueHengNiuJuJiSuanCanShuShuRuViewModel _shuXueHengNiuJuJiSuanCanShuShuRuViewModel = null;
        private ShuXueHengNiuJuJiSuanViewModel _shuXueHengNiuJuJiSuanViewModel = null;
        private ShuXueHengNiuJuJiSuanJieGuoShuChuViewModel _shuXueHengNiuJuJiSuanJieGuoShuChuViewModel = null;

        public MainWindowViewModel()
        {
            this.MechanicalModelListViewModel = new MechanicalModelListViewModel();
            this.MechanicalModelListViewModel.Click = OpenNewView;
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
                                _jiHeKongSunJiSuanMoXingViewModel = _jiHeKongSunJiSuanMoXingViewModel ?? new JiHeKongSunJiSuanMoXingViewModel();
                                this.MechanicalModelViewHostViewModel = _jiHeKongSunJiSuanMoXingViewModel;
                                return;
                            case ViewType.JiHeHengNiuJuJiSuanMoXing:
                                _jiHeHengNiuJuJiSuanMoXingViewModel = _jiHeHengNiuJuJiSuanMoXingViewModel ?? new JiHeHengNiuJuJiSuanMoXingViewModel();
                                this.MechanicalModelViewHostViewModel = _jiHeHengNiuJuJiSuanMoXingViewModel;
                                return;
                            case ViewType.ShuXueKongSunWangGeHuaFen:
                                _shuXueKongSunWangGeHuaFenViewModel = _shuXueKongSunWangGeHuaFenViewModel ?? new ShuXueKongSunWangGeHuaFenViewModel();
                                this.MechanicalModelViewHostViewModel = _shuXueKongSunWangGeHuaFenViewModel;
                                return;
                            case ViewType.ShuXueKongSunJiSuanCanShuShuRu:
                                _shuXueKongSunJiSuanCanShuShuRuViewModel = _shuXueKongSunJiSuanCanShuShuRuViewModel ?? new ShuXueKongSunJiSuanCanShuShuRuViewModel();
                                this.MechanicalModelViewHostViewModel = _shuXueKongSunJiSuanCanShuShuRuViewModel;
                                return;
                            case ViewType.ShuXueKongSunJiSuan:
                                _shuXueKongSunJiSuanViewModel = _shuXueKongSunJiSuanViewModel ?? new ShuXueKongSunJiSuanViewModel();
                                this.MechanicalModelViewHostViewModel = _shuXueKongSunJiSuanViewModel;
                                return;
                            case ViewType.ShuXueKongSunJiSuanJieGuoShuChu:
                                _shuXueKongSunJiSuanJieGuoShuChuViewModel = _shuXueKongSunJiSuanJieGuoShuChuViewModel ?? new ShuXueKongSunJiSuanJieGuoShuChuViewModel();
                                this.MechanicalModelViewHostViewModel = _shuXueKongSunJiSuanJieGuoShuChuViewModel;
                                return;
                            case ViewType.ShuXueZhiDongNiuJuPiPeiTeXingGuanXi:
                                _shuXueZhiDongNiuJuPiPeiTeXingGuanXiViewModel = _shuXueZhiDongNiuJuPiPeiTeXingGuanXiViewModel ?? new ShuXueZhiDongNiuJuPiPeiTeXingGuanXiViewModel();
                                this.MechanicalModelViewHostViewModel = _shuXueZhiDongNiuJuPiPeiTeXingGuanXiViewModel;
                                return;
                            case ViewType.ShuXueHengNiuJuWangGeHuaFen:
                                _shuXueHengNiuJuWangGeHuaFenViewModel = _shuXueHengNiuJuWangGeHuaFenViewModel ?? new ShuXueHengNiuJuWangGeHuaFenViewModel();
                                this.MechanicalModelViewHostViewModel = _shuXueHengNiuJuWangGeHuaFenViewModel;
                                return;
                            case ViewType.ShuXueHengNiuJuJiSuanCanShuShuRu:
                                _shuXueHengNiuJuJiSuanCanShuShuRuViewModel = _shuXueHengNiuJuJiSuanCanShuShuRuViewModel ?? new ShuXueHengNiuJuJiSuanCanShuShuRuViewModel();
                                this.MechanicalModelViewHostViewModel = _shuXueHengNiuJuJiSuanCanShuShuRuViewModel;
                                return;
                            case ViewType.ShuXueHengNiuJuJiSuan:
                                _shuXueHengNiuJuJiSuanViewModel = _shuXueHengNiuJuJiSuanViewModel ?? new ShuXueHengNiuJuJiSuanViewModel();
                                this.MechanicalModelViewHostViewModel = _shuXueHengNiuJuJiSuanViewModel;
                                return;
                            case ViewType.ShuXueHengNiuJuJiSuanJieGuoShuChu:
                                _shuXueHengNiuJuJiSuanJieGuoShuChuViewModel = _shuXueHengNiuJuJiSuanJieGuoShuChuViewModel ?? new ShuXueHengNiuJuJiSuanJieGuoShuChuViewModel();
                                this.MechanicalModelViewHostViewModel = _shuXueHengNiuJuJiSuanJieGuoShuChuViewModel;
                                return;
                            case ViewType.Others:
                                break;
                        }
                    }

                    MechanicalModelContentVisibility = Visibility.Collapsed;
                });
            }
        }
    }
}
