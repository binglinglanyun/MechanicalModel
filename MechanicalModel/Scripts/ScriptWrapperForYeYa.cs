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
        public static string DefaultModuleDirectory = Path.Combine(CommonUtils.CurrentWorkDirectory, "Scripts", "Module");
        public static string DefaultResultDirectory = Path.Combine(CommonUtils.CurrentWorkDirectory, "Results");

        public static string DefaultSourceModulePath = Path.Combine(DefaultModuleDirectory, ModuleName);
        public static string DestModulePath = Path.Combine(WorkDirectory, ModuleName);

        public static string SourceScriptPath = Path.Combine(DefaultModuleDirectory, ScriptName);
        public static string DestScriptPath = Path.Combine(WorkDirectory, ScriptName);
    }
}
