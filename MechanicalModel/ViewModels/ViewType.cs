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
        JinQiBiKongSunJiSuanMoXing,                // 进气比空损计算 --> 空损计算模型
        JinQiBiKongSunWangGeHuaFen,                // 进气比空损计算 --> 网格划分
        JinQiBiKongSunJiSuanCanShuShuRu,           // 进气比空损计算 --> 计算参数输入
        JinQiBiKongSunJiSuan,                      // 进气比空损计算 --> 计算
        JinQiBiKongSunJiSuanJieGuoShuChu,          // 进气比空损计算 --> 计算参数输出

        JinYouTongDaoJiSuanJiHeMoXing,             // 进油通道空损计算 --> 计算几何模型
        JinYouTongDaoKongSunWangGeHuaFen,          // 进油通道空损计算 --> 网格划分
        JinYouTongDaoKongSunJiSuanCanShuShuRu,     // 进油通道空损计算 --> 计算参数输入
        JinYouTongDaoKongSunJiSuan,                // 进油通道空损计算 --> 计算
        JinYouTongDaoKongSunJiSuanJieGuoShuChu,    // 进油通道空损计算 --> 计算参数输出

        ZhiDongNiuJuPiPeiTeXingGuanXi,             // 制动特性计算模型 --> 制动扭矩匹配特性关系
        HengNiuJuJiSuanMoXing,                     // 制动特性计算模型 --> 制动特性计算模型模型
        HengNiuJuWangGeHuaFen,                     // 制动特性计算模型 --> 网格划分
        HengNiuJuJiSuanCanShuShuRu,                // 制动特性计算模型 --> 计算参数输入
        HengNiuJuJiSuan,                           // 制动特性计算模型 --> 计算
        HengNiuJuJiSuanJieGuoShuChu                // 制动特性计算模型 --> 计算参数输出
    }
}
