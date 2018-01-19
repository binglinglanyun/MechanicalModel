using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MechanicalModel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
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

        public ICommand OpenNewView
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    TreeViewNode node = o as TreeViewNode;
                    if (node != null)
                    {
                        switch (node.ViewType)
                        {
                            case ViewType.WangGeHuaFen:
                                this.MechanicalModelViewHostViewModel = new WangGeHuaFenViewModel();
                                break;
                            case ViewType.JiSuanCanShuShuRu:
                                this.MechanicalModelViewHostViewModel = new JiSuanCanShuShuRuViewModel();
                                break;
                            case ViewType.JiSuan:
                                this.MechanicalModelViewHostViewModel = new JiSuanViewModel();
                                break;
                            case ViewType.JiSuanJieGuoShuChu:
                                this.MechanicalModelViewHostViewModel = new JiSuanJieGuoShuChuViewModel();
                                break;
                            case ViewType.Others:
                                return;
                        }
                    }
                });
            }
        }
    }
}
