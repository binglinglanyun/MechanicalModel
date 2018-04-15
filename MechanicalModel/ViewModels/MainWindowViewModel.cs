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
        public MainWindowViewModel()
        {
            this.MechanicalModelListViewModel = new MechanicalModelListViewModel();
            this.MechanicalModelListViewModel.Click = OpenNewView;
        }

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
                                this.MechanicalModelViewHostViewModel = new JiHeKongSunJiSuanMoXingViewModel();
                                return;
                            case ViewType.JiHeHengNiuJuJiSuanMoXing:
                                this.MechanicalModelViewHostViewModel = new JiHeHengNiuJuJiSuanMoXingViewModel();
                                return;
                            case ViewType.ShuXueKongSunWangGeHuaFen:
                                this.MechanicalModelViewHostViewModel = new ShuXueKongSunWangGeHuaFenViewModel();
                                return;
                            case ViewType.ShuXueKongSunJiSuanCanShuShuRu:
                                this.MechanicalModelViewHostViewModel = new ShuXueKongSunJiSuanCanShuShuRuViewModel();
                                return;
                            case ViewType.ShuXueKongSunJiSuan:
                                this.MechanicalModelViewHostViewModel = new ShuXueKongSunJiSuanViewModel();
                                return;
                            case ViewType.ShuXueKongSunJiSuanJieGuoShuChu:
                                this.MechanicalModelViewHostViewModel = new ShuXueKongSunJiSuanJieGuoShuChuViewModel();
                                return;
                            case ViewType.ShuXueHengNiuJuWangGeHuaFen:
                                this.MechanicalModelViewHostViewModel = new ShuXueHengNiuJuWangGeHuaFenViewModel();
                                return;
                            case ViewType.ShuXueHengNiuJuJiSuanCanShuShuRu:
                                this.MechanicalModelViewHostViewModel = new ShuXueHengNiuJuJiSuanCanShuShuRuViewModel();
                                return;
                            case ViewType.ShuXueHengNiuJuJiSuan:
                                this.MechanicalModelViewHostViewModel = new ShuXueHengNiuJuJiSuanViewModel();
                                return;
                            case ViewType.ShuXueHengNiuJuJiSuanJieGuoShuChu:
                                this.MechanicalModelViewHostViewModel = new ShuXueHengNiuJuJiSuanJieGuoShuChuViewModel();
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
