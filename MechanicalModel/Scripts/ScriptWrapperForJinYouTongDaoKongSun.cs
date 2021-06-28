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
    public static class ScriptWrapperForJinYouTongDaoKongSun
    {
        public const string ScriptName = "torque_jinyoutongdao_kongsun.spro";
        public const string SgrdFileName = "torque_jinyoutongdao_kongsun.sgrd";
        public const string DensityFileName = "torque_jinyoutongdao_kongsun_density.txt";
        public const string ViscosityFileName = "torque_jinyoutongdao_kongsun_viscosity.txt";
        public const string HeatConductivityFileName = "torque_jinyoutongdao_kongsun_heat_conductivity.txt";
        public const string HeatCapacityFileName = "torque_jinyoutongdao_kongsun_heat_capacity.txt";

        public static string ResultsDirectory = Path.Combine(CommonUtils.CurrentWorkDirectory, "Results");
        public static string WorkDirectory = Path.Combine(CommonUtils.CurrentWorkDirectory, "Temp", "JinYouTongDaoKongSun");
        public static string SourceSgrdFilePath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", SgrdFileName);
        public static string DestSgrdFilePath = Path.Combine(WorkDirectory, SgrdFileName);

        public static string SourceMoXingFolderPath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", "Surface", "JinYouTongDaoKongSun");
        public static string SourceOilFilesFolderPath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", "OilFiles");

        public const string LoadResultScriptName = "torque_jinqibi_kongsun_loadresults.spro";
        public const string LoadResultsSgrdFileName = "torque_jinqibi_kongsun_loadresults.sgrd";
        public static string SourceLoadResultScriptPath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", LoadResultScriptName);
        public static string DestLoadResultScriptPath = Path.Combine(WorkDirectory, LoadResultScriptName);
        public static string SourceLoadResultsSgrdFilePath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", LoadResultsSgrdFileName);
        public static string DestLoadResultsSgrdFilePath = Path.Combine(WorkDirectory, LoadResultsSgrdFileName);

        public static string ScriptXMLHeader = ScriptTemplateForJinYouTongDaoKongSun.ScriptXMLHeader;
        public static string ScriptXMLTail = ScriptTemplateForJinYouTongDaoKongSun.ScriptXMLTail;
        public static string ImportMoXing = ScriptTemplateForJinYouTongDaoKongSun.ImportMoXing;
        public static string WangGeHuafenConstScript = ScriptTemplateForJinYouTongDaoKongSun.WangGeHuafenConstScript;
        public static string ImportedOilFiles = ScriptTemplateForJinYouTongDaoKongSun.ImportedOilFiles;
        public static string DongLunForWangGeHuaFen = string.Empty;
        public static string DingLunForWangGeHuaFen = string.Empty;
        public static string RuKouForWangGeHuaFen = string.Empty;
        public static string ChuKouForWangGeHuaFen = string.Empty;
        public static string BianJieTiaoJianDingYi = string.Empty;
        public static string WuZhiDingYi = string.Empty;
        public static string JiSuanKongZhiCanShu = string.Empty;
        public static string JianKongDianZuoBiaoCanShu = string.Empty;

        public const string KongSunGongLvResultTitle = "pow_rotor_blades";

        private static string GetWangGeHuaFenScript()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(DongLunForWangGeHuaFen) || string.IsNullOrEmpty(DingLunForWangGeHuaFen) || 
                string.IsNullOrEmpty(RuKouForWangGeHuaFen) || string.IsNullOrEmpty(ChuKouForWangGeHuaFen))
            {
                MessageBox.Show("请输入网格划分参数");
                return null;
            }
            else
            {
                sb.AppendLine(WangGeHuafenConstScript);
                sb.AppendLine(DongLunForWangGeHuaFen);
                sb.AppendLine(DingLunForWangGeHuaFen);
                sb.AppendLine(RuKouForWangGeHuaFen);
                sb.AppendLine(ChuKouForWangGeHuaFen);
            }

            return sb.ToString();
        }

        private static string GetJiSuanScript()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(WuZhiDingYi) || string.IsNullOrEmpty(BianJieTiaoJianDingYi))
            {
                MessageBox.Show("请输入计算参数并确认");
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
        /// ImportMoXing + 
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
        /// ImportMoXing + 
        /// WangGeHuafenConstScript + DongLunForWangGeHuaFen + DingLunForWangGeHuaFen + ChuKouForWangGeHuaFen + RuKouForWangGeHuaFen +
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
        /// ImportMoXing + 
        /// WangGeHuafenConstScript + DongLunForWangGeHuaFen + DingLunForWangGeHuaFen + ChuKouForWangGeHuaFen + RuKouForWangGeHuaFen +
        /// BianJieTiaoJianDingYi + WuZhiDingYi + JiSuanKongZhiCanShu + JianKongDianCanShu + 
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
