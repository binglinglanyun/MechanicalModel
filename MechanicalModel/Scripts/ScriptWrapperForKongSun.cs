using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MechanicalModel.Scripts
{
    public static class ScriptWrapperForKongSun
    {
        public static string ScriptName = "torque_kongsun.spro";
        public static string SourceSgrdFilePath = @"C:\Users\xnl\OneDrive - Microsoft\MechanicsModel\Script\torque_kongsun_test2.sgrd";
        public static string DestSgrdFilePath = Path.Combine(ConstantValues.CurrentWorkDirectory, "torque_kongsun.sgrd");
        public static string ScriptXMLHeader = ScriptTemplateForKongSun.ScriptXMLHeader;
        public static string ScriptXMLTail = ScriptTemplateForKongSun.ScriptXMLTail;
        public static string ImportScript = string.Empty;
        public static string WangGeHuafenConstScript = ScriptTemplateForKongSun.WangGeHuafenConstScript;
        public static string DongLunForWangGeHuaFen = string.Empty;
        public static string DingLunForWangGeHuaFen = string.Empty;
        public static string BianJieTiaoJianDingYi = string.Empty;
        public static string WuZhiDingYi = string.Empty;
        public static string JiSuanKongZhiCanShu = string.Empty;
        public static string JianKongDianCanShu = string.Empty;

        /// <summary>
        /// ImportScript + WangGeHuafenConstScript + DongLunForWangGeHuaFen + DingLunForWangGeHuaFen
        /// </summary>
        /// <returns></returns>
        private static string CreateBasicScript()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(ScriptWrapperForKongSun.ImportScript))
            {
                MessageBox.Show("请导入模型文件");
                return null;
            }
            else
            {
                sb.AppendLine(ScriptWrapperForKongSun.ImportScript);
            }

            if (string.IsNullOrEmpty(ScriptWrapperForKongSun.WangGeHuafenConstScript) || string.IsNullOrEmpty(ScriptWrapperForKongSun.DongLunForWangGeHuaFen) || string.IsNullOrEmpty(ScriptWrapperForKongSun.DingLunForWangGeHuaFen))
            {
                MessageBox.Show("请划分网格");
                return null;
            }
            else
            {
                sb.AppendLine(ScriptWrapperForKongSun.WangGeHuafenConstScript);
                sb.AppendLine(ScriptWrapperForKongSun.DongLunForWangGeHuaFen);
                sb.AppendLine(ScriptWrapperForKongSun.DingLunForWangGeHuaFen);
            }

            return sb.ToString();
        }

        /// <summary>
        /// ScriptXMLHeader + 
        /// ImportScript + WangGeHuafenConstScript + DongLunForWangGeHuaFen + DingLunForWangGeHuaFen +  ==> basic script
        /// ScriptXMLTail
        /// </summary>
        public static string CreateScriptForWangGeHuaFen()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ScriptWrapperForKongSun.ScriptXMLHeader);
            string basicString = CreateBasicScript();
            if (!string.IsNullOrEmpty(basicString))
            {
                sb.AppendLine(basicString);
            }
            sb.AppendLine(ScriptWrapperForKongSun.ScriptXMLTail);

            return sb.ToString();
        }

        /// <summary>
        /// ScriptXMLHeader + 
        /// ImportScript + WangGeHuafenConstScript + DongLunForWangGeHuaFen + DingLunForWangGeHuaFen + ==> basic script
        /// ShiJianBuChang + DongLunZhuanSu + TongQiKongAndPaiQiKong + MiDuNianDuOfOil + JianKongDianCanShu + 
        /// ScriptXMLTail
        /// </summary>
        /// <returns></returns>
        public static string CreateScriptForJiSuan()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ScriptXMLHeader);
            string basicString = CreateBasicScript();
            if (!string.IsNullOrEmpty(basicString))
            {
                sb.AppendLine(basicString);
            }

            if (string.IsNullOrEmpty(JiSuanKongZhiCanShu))
            {
                MessageBox.Show("请输入时间步长");
                return null;
            }
            else
            {
                sb.AppendLine(JiSuanKongZhiCanShu);
            }

            if (string.IsNullOrEmpty(BianJieTiaoJianDingYi) || string.IsNullOrEmpty(WuZhiDingYi))
            {
                MessageBox.Show("请输入参数");
                return null;
            }
            {
                sb.AppendLine(ScriptWrapperForKongSun.DongLunZhuanSu);
                sb.AppendLine(ScriptWrapperForKongSun.TongQiKongAndPaiQiKong);
                sb.AppendLine(ScriptWrapperForKongSun.MiDuNianDuOfOil);
            }
            sb.AppendLine(ScriptWrapperForKongSun.ScriptXMLTail);

            return sb.ToString();
        }
    }

    public static class ConstantValues
    {
        public static string CurrentWorkDirectory = Directory.GetCurrentDirectory();
    }
}
