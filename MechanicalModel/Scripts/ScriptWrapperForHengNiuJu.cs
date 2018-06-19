using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MechanicalModel.Scripts
{
    public static class ScriptWrapperForHengNiuJu
    {
        public static string ScriptName = "torque_hengniuju.spro";
        public static string SourceSgrdFilePath = @"C:\Users\xnl\OneDrive - Microsoft\MechanicsModel\Script\torque_hengniuju.sgrd";
        public static string DestSgrdFilePath = Path.Combine(ConstantValues.CurrentWorkDirectory, "torque_hengniuju.sgrd");
        public static string ScriptXMLHeader = ScriptTemplateForHengNiuJu.ScriptXMLHeader;
        public static string ScriptXMLTail = ScriptTemplateForHengNiuJu.ScriptXMLTail;
        public static string ImportScript = string.Empty;
        public static string WangGeHuafenConstScript = ScriptTemplateForHengNiuJu.WangGeHuafenConstScript;
        public static string DongLunForWangGeHuaFen = string.Empty;
        public static string DingLunForWangGeHuaFen = string.Empty;
        public static string BianJieTiaoJianDingYi = string.Empty;
        public static string FaMenCanShu = string.Empty;
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
            if (string.IsNullOrEmpty(ScriptTemplateForHengNiuJu.ImportScript))
            {
                MessageBox.Show("请导入模型文件");
                return null;
            }
            else
            {
                sb.AppendLine(ScriptTemplateForHengNiuJu.ImportScript);
            }

            if (string.IsNullOrEmpty(ScriptTemplateForHengNiuJu.WangGeHuafenConstScript) || string.IsNullOrEmpty(ScriptWrapperForKongSun.DongLunForWangGeHuaFen) || string.IsNullOrEmpty(ScriptWrapperForKongSun.DingLunForWangGeHuaFen))
            {
                MessageBox.Show("请划分网格");
                return null;
            }
            else
            {
                sb.AppendLine(ScriptTemplateForHengNiuJu.WangGeHuafenConstScript);
                sb.AppendLine(ScriptTemplateForHengNiuJu.DongLunForWangGeHuaFen);
                sb.AppendLine(ScriptTemplateForHengNiuJu.DingLunForWangGeHuaFen);
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
            sb.AppendLine(ScriptTemplateForHengNiuJu.ScriptXMLHeader);
            string basicString = CreateBasicScript();
            if (!string.IsNullOrEmpty(basicString))
            {
                sb.AppendLine(basicString);
            }
            sb.AppendLine(ScriptTemplateForHengNiuJu.ScriptXMLTail);

            return sb.ToString();
        }

        /// <summary>
        /// ScriptXMLHeader + 
        /// ImportScript + WangGeHuafenConstScript + DongLunForWangGeHuaFen + DingLunForWangGeHuaFen +  ==> basic script
        /// MiDuNianDuOfOil + BianJieTiaoJian + FaMenCanShu
        /// ScriptXMLTail
        /// </summary>
        /// <returns></returns>
        public static string CreateScriptForJiSuan()
        {
            return null;
        }
    }
}
