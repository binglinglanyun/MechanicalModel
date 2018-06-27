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
        public static string SourceSgrdFilePath = @"C:\Users\xnl\OneDrive - Microsoft\MechanicsModel\Script\torque_chongyou_add_gap_test_open_no.sgrd";
        public static string DestSgrdFilePath = Path.Combine(ConstantValues.CurrentWorkDirectory, "torque_hengniuju.sgrd");
        public static string ScriptXMLHeader = ScriptTemplateForHengNiuJu.ScriptXMLHeader;
        public static string ScriptXMLTail = ScriptTemplateForHengNiuJu.ScriptXMLTail;
        public static string ImportScript = string.Empty;
        public static string WangGeHuafenConstScript = ScriptTemplateForHengNiuJu.WangGeHuafenConstScript;
        public static string DongLunForWangGeHuaFen = string.Empty;
        public static string DingLunForWangGeHuaFen = string.Empty;
        public static string JianKongDianZuoBiaoCanShu = string.Empty;
        public static string JiSuanKongZhiCanShu = string.Empty;
        public static string FaMenCanShu = string.Empty;
        public static string BianJieTiaoJianDingYi = string.Empty;
        public static string WuZhiDingYi = string.Empty;

        private static string GetImportMoXingScript()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(ImportScript))
            {
                MessageBox.Show("请导入模型文件");
                return null;
            }
            else
            {
                sb.AppendLine(ImportScript);
            }

            return sb.ToString();
        }

        private static string GetWangGeHuaFenScript()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(DongLunForWangGeHuaFen) || string.IsNullOrEmpty(DingLunForWangGeHuaFen))
            {
                MessageBox.Show("请输入网格划分参数");
                return null;
            }
            else
            {
                sb.AppendLine(WangGeHuafenConstScript);
                sb.AppendLine(DongLunForWangGeHuaFen);
                sb.AppendLine(DingLunForWangGeHuaFen);
            }

            return sb.ToString();
        }

        private static string GetJiSuanScript()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(JiSuanKongZhiCanShu) || string.IsNullOrEmpty(JianKongDianZuoBiaoCanShu))
            {
                MessageBox.Show("请输入计算控制参数和监控点参数");
                return null;
            }
            else
            {
                sb.AppendLine(JianKongDianZuoBiaoCanShu);
                sb.AppendLine(JiSuanKongZhiCanShu);
            }

            if (string.IsNullOrEmpty(WuZhiDingYi) || string.IsNullOrEmpty(BianJieTiaoJianDingYi) || string.IsNullOrEmpty(FaMenCanShu))
            {
                MessageBox.Show("请输入计算参数");
                return null;
            }
            else
            {
                sb.AppendLine(FaMenCanShu);
                sb.AppendLine(BianJieTiaoJianDingYi);
                sb.AppendLine(WuZhiDingYi);
            }

            return sb.ToString();
        }

        /// <summary>
        /// ScriptXMLHeader + 
        /// ImportScript + 
        /// ScriptXMLTail
        /// </summary>
        public static string CreateFullScriptForImportMoXing()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ScriptWrapperForHengNiuJu.ScriptXMLHeader);

            string importScript = GetImportMoXingScript();
            if (!string.IsNullOrEmpty(importScript))
            {
                sb.AppendLine(importScript);
            }

            sb.AppendLine(ScriptWrapperForHengNiuJu.ScriptXMLTail);
            return sb.ToString();
        }

        /// <summary>
        /// ScriptXMLHeader + 
        /// ImportScript + 
        /// WangGeHuafenConstScript + DongLunForWangGeHuaFen + DingLunForWangGeHuaFen + 
        /// ScriptXMLTail
        /// </summary>
        public static string CreateFullScriptForWangGeHuaFen()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ScriptTemplateForHengNiuJu.ScriptXMLHeader);

            string importScript = GetImportMoXingScript();
            if (!string.IsNullOrEmpty(importScript))
            {
                sb.AppendLine(importScript);
            }

            string wangGeHuaFenScript = GetWangGeHuaFenScript();
            if (!string.IsNullOrEmpty(wangGeHuaFenScript))
            {
                sb.AppendLine(wangGeHuaFenScript);
            }

            sb.AppendLine(ScriptTemplateForHengNiuJu.ScriptXMLTail);
            return sb.ToString();
        }

        /// <summary>
        /// ScriptXMLHeader + 
        /// ImportScript + 
        /// WangGeHuafenConstScript + DongLunForWangGeHuaFen + DingLunForWangGeHuaFen + 
        /// BianJieTiaoJianDingYi + FaMenCanShu + WuZhiDingYi + JiSuanKongZhiCanShu + JianKongDianCanShu + 
        /// ScriptXMLTail
        /// </summary>
        /// <returns></returns>
        public static string CreateFullScriptForJiSuan()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ScriptTemplateForHengNiuJu.ScriptXMLHeader);

            string importScript = GetImportMoXingScript();
            if (!string.IsNullOrEmpty(importScript))
            {
                sb.AppendLine(importScript);
            }

            string wangGeHuaFenScript = GetWangGeHuaFenScript();
            if (!string.IsNullOrEmpty(wangGeHuaFenScript))
            {
                sb.AppendLine(wangGeHuaFenScript);
            }

            string jiSuanScript = GetJiSuanScript();
            if (!string.IsNullOrEmpty(jiSuanScript))
            {
                sb.AppendLine(jiSuanScript);
            }

            sb.AppendLine(ScriptTemplateForHengNiuJu.ScriptXMLTail);
            return sb.ToString();
        }
    }
}
