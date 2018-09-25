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
        JiHeKongSunJiSuanMoXing,              // 数学模型 --> 空损计算 --> 空损计算模型
        ShuXueKongSunWangGeHuaFen,            // 数学模型 --> 空损计算 --> 网格划分
        ShuXueKongSunJiSuanCanShuShuRu,       // 数学模型 --> 空损计算 --> 计算参数输入
        ShuXueKongSunJiSuan,                  // 数学模型 --> 空损计算 --> 计算
        ShuXueKongSunJiSuanJieGuoShuChu,      // 数学模型 --> 空损计算 --> 计算参数输出
        ShuXueZhiDongNiuJuPiPeiTeXingGuanXi,  // 数学模型 --> 制动特性计算模型 --> 制动扭矩匹配特性关系
        JiHeHengNiuJuJiSuanMoXing,            // 数学模型 --> 制动特性计算模型 --> 制动特性计算模型模型
        ShuXueHengNiuJuWangGeHuaFen,          // 数学模型 --> 制动特性计算模型 --> 网格划分
        ShuXueHengNiuJuJiSuanCanShuShuRu,     // 数学模型 --> 制动特性计算模型 --> 计算参数输入
        ShuXueHengNiuJuJiSuan,                // 数学模型 --> 制动特性计算模型 --> 计算
        ShuXueHengNiuJuJiSuanJieGuoShuChu     // 数学模型 --> 制动特性计算模型 --> 计算参数输出
    }
}
