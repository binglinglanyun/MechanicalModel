using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.Scripts
{
    public static class ScriptWrapperForYeYa
    {
        public const string ModuleName = "HydrSys_retarder.ame";
        public const string ScriptName = "HydrSys_retarder.py";

        public static string WorkDirectory = Path.Combine(CommonUtils.CurrentWorkDirectory, "Temp", "YeYa");
        public static string DestModulePath = Path.Combine(ScriptWrapperForYeYa.WorkDirectory, ScriptWrapperForYeYa.ModuleName);

        public static string SourceScriptPath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", ScriptName);
        public static string DestScriptPath = Path.Combine(ScriptWrapperForYeYa.WorkDirectory, ScriptWrapperForYeYa.ScriptName);
    }
}
