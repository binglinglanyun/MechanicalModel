using MechanicalModel.Utils;
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
        public const string ScriptName = "torque_hengniuju.spro";
        public const string SgrdFileName = "torque_hengniuju.sgrd";
        public static string WorkDirectory = Path.Combine(CommonUtils.CurrentWorkDirectory, "HengNiuJu");
        public static string SourceSgrdFilePath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", SgrdFileName);
        public static string DestSgrdFilePath = Path.Combine(WorkDirectory, SgrdFileName);

        public const string LoadResultScriptName = "torque_hengniuju_loadresults.spro";
        public const string LoadResultsSgrdFileName = "torque_hengniuju_loadresults.sgrd";
        public static string SourceLoadResultScriptPath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", LoadResultScriptName);
        public static string DestLoadResultScriptPath = Path.Combine(WorkDirectory, LoadResultScriptName);
        public static string SourceLoadResultsSgrdFilePath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", LoadResultsSgrdFileName);
        public static string DestLoadResultsSgrdFilePath = Path.Combine(WorkDirectory, LoadResultsSgrdFileName);

        public static string ScriptXMLHeader = ScriptTemplateForHengNiuJu.ScriptXMLHeader;
        public static string ScriptXMLTail = ScriptTemplateForHengNiuJu.ScriptXMLTail;
        public static string ImportScript = ScriptTemplateForHengNiuJu.ImportScript;
        public static string WangGeHuafenConstScript = ScriptTemplateForHengNiuJu.WangGeHuafenConstScript;
        public static string DongLunForWangGeHuaFen = string.Empty;
        public static string DingLunForWangGeHuaFen = string.Empty;
        public static string JianKongDianZuoBiaoCanShu = string.Empty;
        public static string JiSuanKongZhiCanShu = string.Empty;
        public static string FaMenCanShu = string.Empty;
        public static string BianJieTiaoJianDingYi = string.Empty;
        public static string WuZhiDingYi = string.Empty;

        public const string HengNiuJuGongLvResultTitle = "pow_rotor2_wall";
        public const string KongZhiNiuJuResultTitle = "torq_rotor2_wall";
        public const string QiXiaoShiJianRusultTitie = "time";
        public const string WeiYiQuXianRusultTitle = "vD_1";

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
            sb.AppendLine(ScriptXMLHeader);
            sb.AppendLine(ImportScript);
            sb.AppendLine(ScriptXMLTail);
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
            sb.AppendLine(ScriptXMLHeader);
            sb.AppendLine(ImportScript);

            string wangGeHuaFenScript = GetWangGeHuaFenScript();
            if (!string.IsNullOrEmpty(wangGeHuaFenScript))
            {
                sb.AppendLine(wangGeHuaFenScript);
            }
            else
            {
                return null;
            }

            sb.AppendLine(ScriptXMLTail);
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
            sb.AppendLine(ScriptXMLHeader);
            sb.AppendLine(ImportScript);

            string wangGeHuaFenScript = GetWangGeHuaFenScript();
            if (!string.IsNullOrEmpty(wangGeHuaFenScript))
            {
                sb.AppendLine(wangGeHuaFenScript);
            }
            else
            {
                return null;
            }

            string jiSuanScript = GetJiSuanScript();
            if (!string.IsNullOrEmpty(jiSuanScript))
            {
                sb.AppendLine(jiSuanScript);
            }
            else
            {
                return null;
            }

            sb.AppendLine(ScriptXMLTail);
            return sb.ToString();
        }
    }
}
