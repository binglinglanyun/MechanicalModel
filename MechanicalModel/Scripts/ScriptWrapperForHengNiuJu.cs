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
        public const string DensityFileName = "torque_hengniuju_density.txt";
        public const string ViscosityFileName = "torque_hengniuju_viscosity.txt";
        public const string HeatConductivityFileName = "torque_hengniuju_heat_conductivity.txt";
        public const string HeatCapacityFileName = "torque_hengniuju_heat_capacity.txt";

        public static string ResultsDirectory = Path.Combine(CommonUtils.CurrentWorkDirectory, "Results");
        public static string WorkDirectory = Path.Combine(CommonUtils.CurrentWorkDirectory, "Temp", "HengNiuJu");
        public static string SurfaceDirectory = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", "Surface", "HengNiuJu");
        public static string SourceOilFilesFolderPath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", "OilFiles");

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
        public static string ImportMoXing = ScriptTemplateForHengNiuJu.ImportMoXing;
        public static string WangGeHuafenConstScript = ScriptTemplateForHengNiuJu.WangGeHuafenConstScript;
        public static string DongLunForWangGeHuaFen = string.Empty;
        public static string DingLunForWangGeHuaFen = string.Empty;
        public static string OneDimThreeDimFileName = string.Empty;

        public static string ImportedOilFiles = string.Empty;
        public static string WuZhiDingYi = string.Empty;
        public static string BianJieTiaoJianDingYi = string.Empty;

        public static string JiSuanKongZhiCanShu = string.Empty;
        public static string JianKongDianZuoBiaoCanShu = string.Empty;

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
            if (string.IsNullOrEmpty(WuZhiDingYi) || string.IsNullOrEmpty(BianJieTiaoJianDingYi) || string.IsNullOrEmpty(ImportedOilFiles))
            {
                MessageBox.Show("请输入计算参数并确认设置");
                return null;
            }
            else
            {
                sb.AppendLine(ImportedOilFiles);
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
        /// ImportScript + 
        /// ScriptXMLTail
        /// </summary>
        public static string CreateFullScriptForImportMoXing()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ScriptXMLHeader);
            sb.AppendLine(ImportMoXing);
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
            sb.AppendLine(ImportMoXing);

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
        /// WuZhiDingYi + BianJieTiaoJianDingYi + 
        /// JiSuanKongZhiCanShu + JianKongDianCanShu + 
        /// ScriptXMLTail
        /// </summary>
        /// <returns></returns>
        public static string CreateFullScriptForJiSuan()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ScriptXMLHeader);
            sb.AppendLine(ImportMoXing);

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
