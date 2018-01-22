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
                            case ViewType.JiHeMoXingDaoRuZhuangPei:
                                this.MechanicalModelViewHostViewModel = new JiHeMoXingDaoRuZhuangPeiViewModel();
                                return;
                            case ViewType.WangGeHuaFen:
                                this.MechanicalModelViewHostViewModel = new WangGeHuaFenViewModel();
                                return;
                            case ViewType.JiSuanCanShuShuRu:
                                this.MechanicalModelViewHostViewModel = new JiSuanCanShuShuRuViewModel();
                                return;
                            case ViewType.JiSuan:
                                this.MechanicalModelViewHostViewModel = new JiSuanViewModel();
                                return;
                            case ViewType.JiSuanJieGuoShuChu:
                                this.MechanicalModelViewHostViewModel = new JiSuanJieGuoShuChuViewModel();
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
