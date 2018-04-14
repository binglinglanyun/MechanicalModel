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
        JiHeKongSunJiSuanMoXing,              // 参数化几何模型 --> 控损计算模型
        JiHeHengNiuJuJiSuanMoXing,            // 参数化几何模型 --> 恒扭矩计算模型
        ShuXueKongSunWangGeHuaFen,            // 数学模型 --> 空损计算 --> 网格划分
        ShuXueKongSunJiSuanCanShuShuRu,       // 数学模型 --> 空损计算 --> 计算参数输入
        ShuXueKongSunJiSuan,                  // 数学模型 --> 空损计算 --> 计算
        ShuXueKongSunJiSuanJieGuoShuChu,      // 数学模型 --> 空损计算 --> 计算参数输出
        ShuXueHengNiuJuWangGeHuaFen,          // 数学模型 --> 恒扭矩计算 --> 网格划分
        ShuXueHengNiuJuJiSuanCanShuShuRu,     // 数学模型 --> 恒扭矩计算 --> 计算参数输入
        ShuXueHengNiuJuJiSuan,                // 数学模型 --> 恒扭矩计算 --> 计算
        ShuXueHengNiuJuJiSuanJieGuoShuChu     // 数学模型 --> 恒扭矩计算 --> 计算参数输出
    }
}
