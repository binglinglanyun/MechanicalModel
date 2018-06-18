using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MechanicalModel.Scripts
{
    public static class StaticStringForKongSun
    {
        public static string ScriptName = "torque_kongsun.spro";
        public static string SourceSgrdFilePath = @"C:\Users\xnl\OneDrive - Microsoft\MechanicsModel\Script\torque_kongsun_test2.sgrd";
        public static string DestSgrdFilePath = Path.Combine(ConstantValues.CurrentWorkDirectory, "torque_kongsun.sgrd");
        public static string ScriptXMLHeader = StringTemplateForKongSun.ScriptXMLHeader;
        public static string ScriptXMLTail = StringTemplateForKongSun.ScriptXMLTail;
        public static string ImportScript = string.Empty;
        public static string WangGeHuafenConstScript = StringTemplateForKongSun.WangGeHuafenConstScript;
        public static string DongLunForWangGeHuaFen = string.Empty;
        public static string DingLunForWangGeHuaFen = string.Empty;
        public static string DongLunZhuanSu = string.Empty;
        public static string TongQiKongAndPaiQiKong = string.Empty;
        public static string MiDuNianDuOfOil = string.Empty;
        public static string ShiJianBuChang = string.Empty;
        public static string JianKongDianCanShu = string.Empty;

        private static string CreateBasicScript()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(StaticStringForKongSun.ImportScript))
            {
                MessageBox.Show("请导入模型文件");
                return null;
            }
            else
            {
                sb.AppendLine(StaticStringForKongSun.ImportScript);
            }

            if (string.IsNullOrEmpty(StaticStringForKongSun.WangGeHuafenConstScript) || string.IsNullOrEmpty(StaticStringForKongSun.DongLunForWangGeHuaFen) || string.IsNullOrEmpty(StaticStringForKongSun.DingLunForWangGeHuaFen))
            {
                MessageBox.Show("请划分网格");
                return null;
            }
            else
            {
                sb.AppendLine(StaticStringForKongSun.WangGeHuafenConstScript);
                sb.AppendLine(StaticStringForKongSun.DongLunForWangGeHuaFen);
                sb.AppendLine(StaticStringForKongSun.DingLunForWangGeHuaFen);
            }

            return sb.ToString();
        }

        public static string CreateScriptForWangGeHuaFen()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(StaticStringForKongSun.ScriptXMLHeader);
            string basicString = CreateBasicScript();
            if (!string.IsNullOrEmpty(basicString))
            {
                sb.AppendLine(basicString);
            }
            sb.AppendLine(StaticStringForKongSun.ScriptXMLTail);

            return sb.ToString();
        }

        public static string CreateScriptForJiSuan()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(StaticStringForKongSun.ScriptXMLHeader);
            string basicString = CreateBasicScript();
            if (!string.IsNullOrEmpty(basicString))
            {
                sb.AppendLine(basicString);
            }

            if (string.IsNullOrEmpty(StaticStringForKongSun.ShiJianBuChang))
            {
                MessageBox.Show("请输入时间步长");
                return null;
            }
            else
            {
                sb.AppendLine(StaticStringForKongSun.ShiJianBuChang);
            }

            if (string.IsNullOrEmpty(StaticStringForKongSun.DongLunZhuanSu) || string.IsNullOrEmpty(TongQiKongAndPaiQiKong) || string.IsNullOrEmpty(MiDuNianDuOfOil))
            {
                MessageBox.Show("请输入参数");
                return null;
            }
            {
                sb.AppendLine(StaticStringForKongSun.DongLunZhuanSu);
                sb.AppendLine(StaticStringForKongSun.TongQiKongAndPaiQiKong);
                sb.AppendLine(StaticStringForKongSun.MiDuNianDuOfOil);
            }
            sb.AppendLine(StaticStringForKongSun.ScriptXMLTail);

            return sb.ToString();
        }
    }

    public static class ConstantValues
    {
        public static string CurrentWorkDirectory = Directory.GetCurrentDirectory();
    }
}
