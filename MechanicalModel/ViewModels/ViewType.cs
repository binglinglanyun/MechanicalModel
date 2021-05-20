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

        YeYaXiTongJieGouTu,                        // 一维流体静力学液压计算 --> 系统结构图搭建
        YeYaJiSuanTiaoJianSheZhi,                  // 一维流体静力学液压计算 --> 计算条件设置
        YeYaJieGuoXianShiShuChu,                   // 一维流体静力学液压计算 --> 计算结果显示及输出

        ZhiDongNiuJuPiPeiTeXingGuanXi,             // 三维流动液力计算 --> 制动扭矩匹配特性关系
        HengNiuJuJiSuanMoXing,                     // 三维流动液力计算 --> 制动特性计算模型模型
        HengNiuJuWangGeHuaFen,                     // 三维流动液力计算 --> 网格划分
        HengNiuJuJiSuanCanShuShuRu,                // 三维流动液力计算 --> 计算参数输入
        HengNiuJuJiSuan,                           // 三维流动液力计算 --> 计算
        HengNiuJuJiSuanJieGuoShuChu                // 三维流动液力计算 --> 计算参数输出
    }
}
