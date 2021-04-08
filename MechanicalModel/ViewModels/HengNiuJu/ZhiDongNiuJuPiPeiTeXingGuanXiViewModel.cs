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
    public class ZhiDongNiuJuPiPeiTeXingGuanXiViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        private const int _order = 3;
        private double[] _coefficient;

        public ZhiDongNiuJuPiPeiTeXingGuanXiViewModel()
        {
            _coefficient = GetMultipleLineCoefficient();
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ZhiDongNiuJuPiPeiTeXingGuanXi;
            }
        }

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/ZhiDongNiuJu.png"); ;
            }
        }

        private string _zhiDongNiuJu = "0";
        public string ZhiDongNiuJu
        {
            get
            {
                return _zhiDongNiuJu;
            }
            set
            {
                SetValueProperty(value, ref _zhiDongNiuJu);
            }
        }

        private string _zhiLingYouYa = "0";
        public string ZhiLingYouYa
        {
            get
            {
                return _zhiLingYouYa;
            }
            set
            {
                SetValueProperty(value, ref _zhiLingYouYa);
            }
        }

        public ICommand ConfirmButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    double niuJu = 0;
                    if (double.TryParse(this.ZhiDongNiuJu, out niuJu))
                    {
                        this.ZhiLingYouYa = GetYouYaByNiuJu(niuJu);
                    }
                    else
                    {
                        MessageBox.Show("请输入有效数字");
                    }
                });
            }
        }

        private double[] GetMultipleLineCoefficient()
        {
            const int DataSize = 4;

            double[] x = new double[DataSize] { 0, 6000, 11000, 15000 };
            double[] y = new double[DataSize] { 0, 0.5, 1, 2 };

            // fit the data
            int order = 3;
            double[] coefficient = MultipleLine.MultiLine(x, y, x.Count(), order);

            return coefficient;
        }

        private string GetYouYaByNiuJu(double niuJu)
        {
            double sum = 0;
            for (int j = 0; j <= _order; j++)
            {
                sum += _coefficient[j] * Math.Pow(niuJu, j) * 1.0;
            }

            return Math.Round(sum, 4).ToString();
        }
    }
}
