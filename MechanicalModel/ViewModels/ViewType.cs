using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.ViewModels
{
    public enum ViewType
    {
        Others,
        JiHeMoXingDaoRuZhuangPei,    // 几何模型导入/装配
        WangGeHuaFen,                // 网格划分
        JiSuanCanShuShuRu,           // 计算参数输入
        JiSuan,                      // 计算
        JiSuanJieGuoShuChu           // 计算参数输出
    }
}
