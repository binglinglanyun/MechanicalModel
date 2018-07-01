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
    public static class ScriptWrapperForKongSun
    {
        public const string ScriptName = "torque_kongsun.spro";
        public const string SgrdFileName = "torque_kongsun.sgrd";
        public static string WorkDirectory = Path.Combine(CommonUtils.CurrentWorkDirectory, "KongSun");
        public static string SourceSgrdFilePath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", SgrdFileName);
        public static string DestSgrdFilePath = Path.Combine(WorkDirectory, SgrdFileName);
        public static string ScriptXMLHeader = ScriptTemplateForKongSun.ScriptXMLHeader;
        public static string ScriptXMLTail = ScriptTemplateForKongSun.ScriptXMLTail;
        public static string ImportScript = ScriptTemplateForKongSun.ImportScript;
        public static string WangGeHuafenConstScript = ScriptTemplateForKongSun.WangGeHuafenConstScript;
        public static string DongLunForWangGeHuaFen = string.Empty;
        public static string DingLunForWangGeHuaFen = string.Empty;
        public static string BianJieTiaoJianDingYi = string.Empty;
        public static string WuZhiDingYi = string.Empty;
        public static string JiSuanKongZhiCanShu = string.Empty;
        public static string JianKongDianZuoBiaoCanShu = string.Empty;

        public const string KongSunGongLvResultTitle = "pow_rotor_blades";

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
            if (string.IsNullOrEmpty(WuZhiDingYi) || string.IsNullOrEmpty(BianJieTiaoJianDingYi))
            {
                MessageBox.Show("请输入计算参数");
                return null;
            }
            else
            {
                sb.AppendLine(WuZhiDingYi);
                sb.AppendLine(BianJieTiaoJianDingYi);
            }

            if (string.IsNullOrEmpty(JiSuanKongZhiCanShu) || string.IsNullOrEmpty(JianKongDianZuoBiaoCanShu))
            {
                MessageBox.Show("请输入计算控制参数和监控点参数");
                return null;
            }
            else
            {
                sb.AppendLine(JiSuanKongZhiCanShu);
                sb.AppendLine(JianKongDianZuoBiaoCanShu);
            }

            return sb.ToString();
        }

        /// <summary>
        /// ScriptXMLHeader + 
        /// ScriptXMLTail
        /// </summary>
        public static string CreateFullScriptForTempScript()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ScriptXMLHeader);
            sb.AppendLine(ScriptXMLTail);
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
