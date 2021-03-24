﻿using MechanicalModel.Scripts;
using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MechanicalModel.ViewModels
{
    public class JinYouTongDaoKongSunJiSuanViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JinYouTongDaoKongSunJiSuanViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.JinYouTongDaoKongSunJiSuan;
            }
        }

        private string _dieDaiBuShu = "200000";
        public string DieDaiBuShu
        {
            get
            {
                return _dieDaiBuShu;
            }
            set
            {
                SetValueProperty(value, ref _dieDaiBuShu);
            }
        }

        private string _canShuX = "-0.05";
        public string CanShuX
        {
            get
            {
                return _canShuX;
            }
            set
            {
                SetValueProperty(value, ref _canShuX);
            }
        }

        private string _canShuY = "0.083";
        public string CanShuY
        {
            get
            {
                return _canShuY;
            }
            set
            {
                SetValueProperty(value, ref _canShuY);
            }
        }

        private string _canShuZ = "0.224";
        public string CanShuZ
        {
            get
            {
                return _canShuZ;
            }
            set
            {
                SetValueProperty(value, ref _canShuZ);
            }
        }

        public ICommand JiSuanButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    ScriptWrapperForJinQiBiKongSun.JiSuanKongZhiCanShu = string.Format(ScriptTemplateForJinQiBiKongSun.JiSuanKongZhiCanShu,
                        this.DieDaiBuShu);

                    ScriptWrapperForJinQiBiKongSun.JianKongDianZuoBiaoCanShu = string.Format(ScriptTemplateForJinQiBiKongSun.JianKongDianZuoBiaoCanShu,
                        this.CanShuX, this.CanShuY, this.CanShuZ);
                    
                    string scriptContent = ScriptWrapperForJinQiBiKongSun.CreateFullScriptForJiSuan();
                    if (scriptContent != null)
                    {
                        StartOtherProcessHelper.StartPumpLinxForKongSun(scriptContent);
                    }
                });
            }
        }
    }
}