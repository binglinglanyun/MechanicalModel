using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.Scripts
{
    public class ScriptTemplateForHengNiuJu
    {
        public const string ScriptXMLHeader = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>

<simulation
  program=""PumpLinx""
  version=""4.6.0""
  customer=""SolidSQUAD""
  date=""Mon Jun 14 21:01:21 2021"">";

        public const string ScriptXMLTail = @"</simulation>";

        // 模型导入
        public const string ImportMoXing = @" 
  <import vendor=""Simerics"">
	 <surface name=""inlet_inlet"" file=""inlet_inlet.stl"" scale=""1""/>
     <surface name=""inlet_mgi_rotor"" file=""inlet_mgi_rotor.stl"" scale=""1""/>
     <surface name=""inlet_wall"" file=""inlet_wall.stl"" scale=""1""/>
     <surface name=""outlet_air_in"" file=""outlet_air_in.stl"" scale=""1""/>
     <surface name=""outlet_mgi_gap9"" file=""outlet_mgi_gap9.stl"" scale=""1""/>
     <surface name=""outlet_mgi_rotor_cylinder"" file=""outlet_mgi_rotor_cylinder.stl"" scale=""1""/>
     <surface name=""outlet_mgi_rotor_side"" file=""outlet_mgi_rotor_side.stl"" scale=""1""/>
     <surface name=""outlet_mgi_rotor_top"" file=""outlet_mgi_rotor_top.stl"" scale=""1""/>
     <surface name=""outlet_outlet"" file=""outlet_outlet.stl"" scale=""1""/>
     <surface name=""outlet_wall"" file=""outlet_wall.stl"" scale=""1""/>
     <surface name=""rotor_blades"" file=""rotor_blades.stl"" scale=""1""/>
     <surface name=""rotor_cylinder_mgi_outlet"" file=""rotor_cylinder_mgi_outlet.stl"" scale=""1""/>
     <surface name=""rotor_mgi_gap1"" file=""rotor_mgi_gap1.stl"" scale=""1""/>
     <surface name=""rotor_mgi_gap3"" file=""rotor_mgi_gap3.stl"" scale=""1""/>
     <surface name=""rotor_mgi_gap32"" file=""rotor_mgi_gap32.stl"" scale=""1""/>
     <surface name=""rotor_mgi_gap5"" file=""rotor_mgi_gap5.stl"" scale=""1""/>
     <surface name=""rotor_mgi_inlet"" file=""rotor_mgi_inlet.stl"" scale=""1""/>
     <surface name=""rotor_mgi_side"" file=""rotor_mgi_side.stl"" scale=""1""/>
     <surface name=""rotor_mgi_stator"" file=""rotor_mgi_stator.stl"" scale=""1""/>
     <surface name=""rotor_mgi_top"" file=""rotor_mgi_top.stl"" scale=""1""/>
     <surface name=""stator_mgi_gap1"" file=""stator_mgi_gap1.stl"" scale=""1""/>
     <surface name=""stator_mgi_outlet1"" file=""stator_mgi_outlet1.stl"" scale=""1""/>
     <surface name=""stator_mgi_outlet2"" file=""stator_mgi_outlet2.stl"" scale=""1""/>
     <surface name=""stator_mgi_outlet3"" file=""stator_mgi_outlet3.stl"" scale=""1""/>
     <surface name=""stator_mgi_outlet4"" file=""stator_mgi_outlet4.stl"" scale=""1""/>
     <surface name=""stator_mgi_rotor"" file=""stator_mgi_rotor.stl"" scale=""1""/>
     <surface name=""stator_wall"" file=""stator_wall.stl"" scale=""1""/>
  </import>";

        public static string WangGeHuafenConstScript = @"
  <include file=""torque_hengniuju.sgrd""/>
  <volume name=""gap5""/>
  <volume name=""gap1""/>
  <volume name=""gap12""/>
  <volume name=""gap2""/>
  <volume name=""gap91""/>
  <volume name=""gap92""/>
  <volume name=""gap93""/>
  <volume name=""gap94""/>
  <volume name=""gap95""/>
  <volume name=""gap6""/>
  <volume name=""gap9""/>
  <volume name=""gap3""/>
  <volume name=""gap31""/>
  <volume name=""gap32""/>
  <volume name=""air_outlet2""/>
  <volume name=""air_outlet1""/>
  <volume name=""air_outlet3""/>
  <volume name=""air_outlet4""/>
  <volume name=""rotor""/>
  <volume name=""stator""/>
  <volume name=""outlet""/>
  <volume name=""inlet""/>

  <patch name=""dir_min"" volume=""gap5""/>
  <patch name=""cylinder_min"" volume=""gap5""/>
  <patch name=""dir_max"" volume=""gap5""/>
  <patch name=""cylinder"" volume=""gap5""/>
  <patch name=""dir_min_1"" volume=""gap1""/>
  <patch name=""cylinder_min_1"" volume=""gap1""/>
  <patch name=""dir_max_1"" volume=""gap1""/>
  <patch name=""cylinder_1"" volume=""gap1""/>
  <patch name=""dir_min_2"" volume=""gap12""/>
  <patch name=""cylinder_min_2"" volume=""gap12""/>
  <patch name=""dir_max_2"" volume=""gap12""/>
  <patch name=""cylinder_2"" volume=""gap12""/>
  <patch name=""dir_min_3"" volume=""gap2""/>
  <patch name=""cylinder_min_3"" volume=""gap2""/>
  <patch name=""dir_max_3"" volume=""gap2""/>
  <patch name=""cylinder_3"" volume=""gap2""/>
  <patch name=""dir_min_4"" volume=""gap91""/>
  <patch name=""cylinder_min_4"" volume=""gap91""/>
  <patch name=""dir_max_4"" volume=""gap91""/>
  <patch name=""cylinder_4"" volume=""gap91""/>
  <patch name=""dir_min_5"" volume=""gap92""/>
  <patch name=""cylinder_min_5"" volume=""gap92""/>
  <patch name=""dir_max_5"" volume=""gap92""/>
  <patch name=""cylinder_5"" volume=""gap92""/>
  <patch name=""dir_min_6"" volume=""gap93""/>
  <patch name=""cylinder_min_6"" volume=""gap93""/>
  <patch name=""dir_max_6"" volume=""gap93""/>
  <patch name=""cylinder_6"" volume=""gap93""/>
  <patch name=""dir_min_7"" volume=""gap94""/>
  <patch name=""cylinder_min_7"" volume=""gap94""/>
  <patch name=""dir_max_7"" volume=""gap94""/>
  <patch name=""cylinder_7"" volume=""gap94""/>
  <patch name=""dir_min_8"" volume=""gap95""/>
  <patch name=""cylinder_min_8"" volume=""gap95""/>
  <patch name=""dir_max_8"" volume=""gap95""/>
  <patch name=""cylinder_8"" volume=""gap95""/>
  <patch name=""dir_min_9"" volume=""gap6""/>
  <patch name=""cylinder_min_9"" volume=""gap6""/>
  <patch name=""dir_max_9"" volume=""gap6""/>
  <patch name=""cylinder_9"" volume=""gap6""/>
  <patch name=""dir_min_10"" volume=""gap9""/>
  <patch name=""cylinder_min_10"" volume=""gap9""/>
  <patch name=""dir_max_10"" volume=""gap9""/>
  <patch name=""cylinder_10"" volume=""gap9""/>
  <patch name=""dir_min_11"" volume=""gap3""/>
  <patch name=""cylinder_min_11"" volume=""gap3""/>
  <patch name=""dir_max_11"" volume=""gap3""/>
  <patch name=""cylinder_11"" volume=""gap3""/>
  <patch name=""dir_min_12"" volume=""gap31""/>
  <patch name=""cylinder_min_12"" volume=""gap31""/>
  <patch name=""dir_max_12"" volume=""gap31""/>
  <patch name=""cylinder_12"" volume=""gap31""/>
  <patch name=""dir_min_13"" volume=""gap32""/>
  <patch name=""cylinder_min_13"" volume=""gap32""/>
  <patch name=""dir_max_13"" volume=""gap32""/>
  <patch name=""cylinder_13"" volume=""gap32""/>
  <patch name=""dir_min_14"" volume=""air_outlet2""/>
  <patch name=""dir_max_14"" volume=""air_outlet2""/>
  <patch name=""cylinder_14"" volume=""air_outlet2""/>
  <patch name=""dir_min_15"" volume=""air_outlet1""/>
  <patch name=""dir_max_15"" volume=""air_outlet1""/>
  <patch name=""cylinder_15"" volume=""air_outlet1""/>
  <patch name=""dir_min_16"" volume=""air_outlet3""/>
  <patch name=""dir_max_16"" volume=""air_outlet3""/>
  <patch name=""cylinder_16"" volume=""air_outlet3""/>
  <patch name=""dir_min_17"" volume=""air_outlet4""/>
  <patch name=""dir_max_17"" volume=""air_outlet4""/>
  <patch name=""cylinder_17"" volume=""air_outlet4""/>
  <patch name=""rotor_mgi_stator"" volume=""rotor""/>
  <patch name=""rotor_mgi_gap3"" volume=""rotor""/>
  <patch name=""rotor_blades"" volume=""rotor""/>
  <patch name=""rotor_mgi_gap32"" volume=""rotor""/>
  <patch name=""rotor_cylinder_mgi_outlet"" volume=""rotor""/>
  <patch name=""rotor_mgi_side"" volume=""rotor""/>
  <patch name=""rotor_mgi_top"" volume=""rotor""/>
  <patch name=""rotor_mgi_gap1"" volume=""rotor""/>
  <patch name=""rotor_mgi_inlet"" volume=""rotor""/>
  <patch name=""rotor_mgi_gap5"" volume=""rotor""/>
  <patch name=""stator_wall"" volume=""stator""/>
  <patch name=""stator_mgi_rotor"" volume=""stator""/>
  <patch name=""stator_mgi_outlet2"" volume=""stator""/>
  <patch name=""stator_mgi_gap1"" volume=""stator""/>
  <patch name=""stator_mgi_outlet3"" volume=""stator""/>
  <patch name=""stator_mgi_outlet1"" volume=""stator""/>
  <patch name=""stator_mgi_outlet4"" volume=""stator""/>
  <patch name=""outlet_wall"" volume=""outlet""/>
  <patch name=""outlet_mgi_rotor_cylinder"" volume=""outlet""/>
  <patch name=""outlet_mgi_rotor_side"" volume=""outlet""/>
  <patch name=""outlet_mgi_gap9"" volume=""outlet""/>
  <patch name=""outlet_mgi_rotor_top"" volume=""outlet""/>
  <patch name=""outlet_air_in"" volume=""outlet""/>
  <patch name=""outlet_outlet"" volume=""outlet""/>
  <patch name=""inlet_wall"" volume=""inlet""/>
  <patch name=""inlet_mgi_rotor"" volume=""inlet""/>
  <patch name=""inlet_inlet"" volume=""inlet""/>

  <mgi name=""MGI01"">
    <patch name=""dir_min_15""/>
    <patch name=""stator_mgi_outlet1""/>
  </mgi>

  <mgi name=""MGI02"">
    <patch name=""dir_min_14""/>
    <patch name=""stator_mgi_outlet2""/>
  </mgi>

  <mgi name=""MGI03"">
    <patch name=""dir_min_16""/>
    <patch name=""stator_mgi_outlet3""/>
  </mgi>

  <mgi name=""MGI04"">
    <patch name=""dir_min_17""/>
    <patch name=""stator_mgi_outlet4""/>
  </mgi>

  <mgi name=""MGI05"">
    <patch name=""cylinder_1""/>
    <patch name=""cylinder_min_2""/>
  </mgi>

  <mgi name=""MGI06"">
    <patch name=""cylinder_2""/>
    <patch name=""cylinder_min_3""/>
  </mgi>

  <mgi name=""MGI07"">
    <patch name=""cylinder_3""/>
    <patch name=""rotor_mgi_gap1""/>
    <patch name=""stator_mgi_gap1""/>
  </mgi>

  <mgi name=""MGI08"">
    <patch name=""rotor_mgi_gap3""/>
    <patch name=""dir_min_11""/>
  </mgi>

  <mgi name=""MGI09"">
    <patch name=""cylinder_min_10""/>
    <patch name=""cylinder_8""/>
  </mgi>

  <mgi name=""MGI10"">
    <patch name=""cylinder_12""/>
    <patch name=""cylinder_min_13""/>
  </mgi>

  <mgi name=""MGI11"">
    <patch name=""dir_max_13""/>
    <patch name=""rotor_mgi_gap32""/>
  </mgi>

  <mgi name=""MGI12"">
    <patch name=""cylinder""/>
    <patch name=""rotor_mgi_gap5""/>
  </mgi>

  <mgi name=""MGI13"">
    <patch name=""rotor_mgi_inlet""/>
    <patch name=""inlet_mgi_rotor""/>
    <patch name=""dir_max_9""/>
  </mgi>

  <mgi name=""MGI14"">
    <patch name=""outlet_mgi_gap9""/>
    <patch name=""dir_max_10""/>
  </mgi>

  <mgi name=""MGI15"">
    <patch name=""cylinder_min_4""/>
    <patch name=""cylinder_9""/>
  </mgi>

  <mgi name=""MGI16"">
    <patch name=""cylinder_4""/>
    <patch name=""cylinder_min_5""/>
  </mgi>

  <mgi name=""MGI17"">
    <patch name=""cylinder_min_8""/>
    <patch name=""cylinder_7""/>
  </mgi>

  <mgi name=""MGI18"">
    <patch name=""cylinder_min_7""/>
    <patch name=""cylinder_6""/>
  </mgi>

  <mgi name=""MGI19"">
    <patch name=""cylinder_min_6""/>
    <patch name=""cylinder_5""/>
  </mgi>

  <mgi name=""MGI20"">
    <patch name=""cylinder_min_12""/>
    <patch name=""cylinder_11""/>
  </mgi>

  <mgi name=""MGI21"">
    <patch name=""outlet_mgi_rotor_cylinder""/>
    <patch name=""rotor_cylinder_mgi_outlet""/>
  </mgi>

  <mgi name=""MGI22"" tolerance=""0.02213742090729019"">
    <patch name=""rotor_mgi_side""/>
    <patch name=""outlet_mgi_rotor_side""/>
  </mgi>

  <mgi name=""MGI23"">
    <patch name=""outlet_mgi_rotor_top""/>
    <patch name=""rotor_mgi_top""/>
  </mgi>

  <mgi name=""MGI24"">
    <patch name=""stator_mgi_rotor""/>
    <patch name=""rotor_mgi_stator""/>
  </mgi>

  <build
    operation=""template mesh""
    name=""gap5""
    new_mesh_name=""gap5""
    autorun=""on""
    grid_type=""annulus""
    first_point=""-0.0143 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.07779999999999999""
    annulus_outer_radius=""0.078""
    number_cell_i=""20""
    number_cell_j=""5""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap1""
    new_mesh_name=""gap1""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""-0.0514 0 0""
    first_point=""-0.04 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.0563""
    annulus_outer_radius=""0.0565""
    number_cell_i=""20""
    number_cell_j=""5""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap12""
    new_mesh_name=""gap12""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""-0.0422 0 0""
    first_point=""-0.04 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.0565""
    annulus_outer_radius=""0.0988""
    number_cell_i=""5""
    number_cell_j=""30""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap2""
    new_mesh_name=""gap2""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""-0.057 0 0""
    first_point=""-0.04 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.0988""
    annulus_outer_radius=""0.099""
    number_cell_i=""20""
    number_cell_j=""5""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap91""
    new_mesh_name=""gap91""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""0.012 0 0""
    first_point=""0.0104 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.1085""
    annulus_outer_radius=""0.1158""
    number_cell_i=""5""
    number_cell_j=""20""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap92""
    new_mesh_name=""gap92""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""0.012 0 0""
    first_point=""-0.0016 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.1158""
    annulus_outer_radius=""0.116""
    number_cell_i=""20""
    number_cell_j=""5""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap93""
    new_mesh_name=""gap93""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""0 0 0""
    first_point=""-0.0016 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.116""
    annulus_outer_radius=""0.1225""
    number_cell_i=""5""
    number_cell_j=""20""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap94""
    new_mesh_name=""gap94""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""0.012 0 0""
    first_point=""-0.0016 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.1225""
    annulus_outer_radius=""0.1227""
    number_cell_i=""20""
    number_cell_j=""5""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap95""
    new_mesh_name=""gap95""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""0.012 0 0""
    first_point=""0.0104 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.1227""
    annulus_outer_radius=""0.1298""
    number_cell_i=""5""
    number_cell_j=""20""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap6""
    new_mesh_name=""gap6""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""0.012 0 0""
    first_point=""0 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.1083""
    annulus_outer_radius=""0.1085""
    number_cell_i=""20""
    number_cell_j=""5""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap9""
    new_mesh_name=""gap9""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""0.012 0 0""
    first_point=""0 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.1298""
    annulus_outer_radius=""0.13""
    number_cell_i=""10""
    number_cell_j=""5""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap3""
    new_mesh_name=""gap3""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""-0.055 0 0""
    first_point=""-0.044 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.19175""
    annulus_outer_radius=""0.19225""
    number_cell_i=""30""
    number_cell_j=""5""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap31""
    new_mesh_name=""gap31""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""-0.046 0 0""
    first_point=""-0.044 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.19225""
    annulus_outer_radius=""0.1935""
    number_cell_i=""5""
    number_cell_j=""10""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""gap32""
    new_mesh_name=""gap32""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""-0.046 0 0""
    first_point=""-0.042 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.1935""
    annulus_outer_radius=""0.194""
    number_cell_i=""20""
    number_cell_j=""5""
    number_cell_k=""120""/>
  <build
    operation=""template mesh""
    name=""air_outlet2""
    new_mesh_name=""air_outlet2""
    autorun=""on""
    grid_type=""cylinder""
    reference_point=""-0.06310696 -0.1477558 -0.0493733""
    first_point=""-0.1 -0.1400235 -0.07823078""
    radius=""0.003""
    number_cell_i=""10""
    number_cell_j=""5""
    number_cell_k=""12""/>
  <build
    operation=""template mesh""
    name=""air_outlet1""
    new_mesh_name=""air_outlet1""
    autorun=""on""
    grid_type=""cylinder""
    reference_point=""-0.06310696 0.049373375 -0.1477558""
    first_point=""-0.1 0.07823078 -0.1400235""
    radius=""0.003""
    number_cell_i=""10""
    number_cell_j=""5""
    number_cell_k=""12""/>
  <build
    operation=""template mesh""
    name=""air_outlet3""
    new_mesh_name=""air_outlet3""
    autorun=""on""
    grid_type=""cylinder""
    reference_point=""-0.06310696 -0.0493733 0.14775589""
    first_point=""-0.1 -0.07823078 0.1400235""
    radius=""0.003""
    number_cell_i=""10""
    number_cell_j=""5""
    number_cell_k=""12""/>
  <build
    operation=""template mesh""
    name=""air_outlet4""
    new_mesh_name=""air_outlet4""
    autorun=""on""
    grid_type=""cylinder""
    reference_point=""-0.06310696 0.14775589 0.049373375""
    first_point=""-0.1 0.1400235 0.07823078""
    radius=""0.003""
    number_cell_i=""10""
    number_cell_j=""5""
    number_cell_k=""12""/>
  <build
    operation=""general mesh""
    name=""outlet""
    new_mesh_name=""outlet""
    autorun=""on""
    cell_size_definitions=""local size""
    maximum_size=""0.005""
    minimum_size=""0.0008"">
    <attribute surfaces=""outlet_air_in outlet_mgi_gap9 outlet_mgi_rotor_cylinder outlet_mgi_rotor_side outlet_mgi_rotor_top outlet_outlet outlet_wall""/>
    <refine type=""cylinder_refinement"" refinements_cell_size=""0.0005"" bottom_center=""-0.003 0 0"" radius=""0.133""/>
  </build>
  <build
    operation=""general mesh""
    name=""inlet""
    new_mesh_name=""inlet""
    autorun=""on""
    surfaces=""inlet_inlet inlet_mgi_rotor inlet_wall""
    cell_size_definitions=""local size""
    maximum_size=""0.006""
    minimum_size=""0.0005""/>";

        // 动轮 {0} - 最大网格尺度 {1} - 最小网格尺度 {2} - 最大面网格尺度
        public static string DongLunForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""rotor""
    new_mesh_name=""rotor""
    autorun=""on""
    cell_size_definitions=""local size""
    maximum_size=""{0}""
    minimum_size=""{1}""
    maximum_at_surface=""{2}"">
    <attribute surfaces=""rotor_blades rotor_cylinder_mgi_outlet rotor_mgi_gap1 rotor_mgi_gap3 rotor_mgi_gap32 rotor_mgi_gap5 rotor_mgi_inlet rotor_mgi_side rotor_mgi_stator rotor_mgi_top""/>

    <surface name=""rotor_mgi_gap1"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""rotor_mgi_gap32"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""rotor_mgi_gap5"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
  </build>";

        // 定轮 {0} - 最大网格尺度 {1} - 最小网格尺度 {2} - 最大面网格尺度
        public static string DingLunForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""stator""
    new_mesh_name=""stator""
    autorun=""on""
    user_mode=""normal_mode""
    cell_size_definitions=""local size""
    maximum_size=""{0}""
    minimum_size=""{1}""
    maximum_at_surface=""{2}"">
    <attribute surfaces=""stator_mgi_gap1 stator_mgi_outlet1 stator_mgi_outlet2 stator_mgi_outlet3 stator_mgi_outlet4 stator_mgi_rotor stator_wall""/>

    <surface name=""stator_mgi_gap1"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""stator_mgi_outlet1"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""stator_mgi_outlet2"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""stator_mgi_outlet3"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""stator_mgi_outlet4"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
  </build>";

        // {0} -- 1d3d边界结果文件
        public static string ImportedOilFiles = $@"  
  <expressions>
    Vcen=rotate_1d.rpm
    temp=heat.T
    den=table(""{ScriptWrapperForHengNiuJu.DensityFileName}"",temp)
    vis=table(""{ScriptWrapperForHengNiuJu.ViscosityFileName}"",temp)
    cond=table(""{ScriptWrapperForHengNiuJu.HeatConductivityFileName}"",temp)
    capa=table(""{ScriptWrapperForHengNiuJu.HeatCapacityFileName}"",temp)
    Vall=0.00747456
    Qflux=(-1)*flow.pow@rotor_blades/Vall
    Vf_oil=(time&lt;0.001)?0:1
    Vf_air=1-Vf_oil
    P1=flow.pressure@outlet_outlet
    Qoutlet=table({{0}},P1)
    Qvoutlet=Qoutlet/825
  </expressions>";

        // 物质定义
        // {0} -- 空气粘度 {1} -- 空气比热容 {2} -- 空气热导率
        // 油：比热容"capa", 热导率"cond", 密度"den"来自自定义文件。
        public static string WuZhiDingYi = @"  
  <module type=""flowphasecomp"" flowphasecomp=""oil"">
    <bc patch=""outlet_outlet"" type=""flow_comp_wall"" default=""yes"" output=""user_select""/>
    <vc volume=""gap5"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap1"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap12"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap2"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap91"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap92"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap93"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap94"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap95"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap6"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap9"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap3"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap31"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap32"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""air_outlet2"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""air_outlet1"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""air_outlet3"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""air_outlet4"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""stator"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""outlet"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""inlet"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""air_outlet1"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""stator"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""outlet"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""inlet"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap95"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap94"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap93"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap92"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap91"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap9"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap6"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap5"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap32"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap31"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap3"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap2"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap12"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""gap1"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""air_outlet4"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""air_outlet3"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""air_outlet2"" type=""surface_tension"" surface_tension=""0.04""/>
    <vc volume=""rotor"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""rotor"" type=""surface_tension"" surface_tension=""0.04""/>
  </module>

  <module type=""flowphasecomp"" flowphasecomp=""air"">
    <bc patch=""outlet_outlet"" type=""flow_comp_wall"" default=""yes"" output=""user_select""/>
    <vc volume=""gap5"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap1"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap12"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap91"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap92"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap93"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap94"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap95"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap6"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap9"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap3"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap31"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap32"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""air_outlet2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""air_outlet1"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""air_outlet3"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""air_outlet4"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""rotor"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""stator"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""outlet"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""inlet"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
  </module>

  <module type=""heatphasecomp"" heatphasecomp=""oil"">
    <vc volume=""air_outlet1"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""stator"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""rotor"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""outlet"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""inlet"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap95"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap94"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap93"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap92"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap91"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap9"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap6"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap5"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap32"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap31"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap3"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap2"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap12"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap1"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""air_outlet4"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""air_outlet3"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""air_outlet2"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""air_outlet1"" type=""const_capacity"" value=""capa""/>
    <vc volume=""stator"" type=""const_capacity"" value=""capa""/>
    <vc volume=""rotor"" type=""const_capacity"" value=""capa""/>
    <vc volume=""outlet"" type=""const_capacity"" value=""capa""/>
    <vc volume=""inlet"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap95"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap94"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap93"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap92"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap91"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap9"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap6"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap5"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap32"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap31"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap3"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap2"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap12"" type=""const_capacity"" value=""capa""/>
    <vc volume=""gap1"" type=""const_capacity"" value=""capa""/>
    <vc volume=""air_outlet4"" type=""const_capacity"" value=""capa""/>
    <vc volume=""air_outlet3"" type=""const_capacity"" value=""capa""/>
    <vc volume=""air_outlet2"" type=""const_capacity"" value=""capa""/>
  </module>

  <module type=""heatphasecomp"" heatphasecomp=""air"">
    <vc volume=""gap5"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap1"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap12"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap2"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap91"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap92"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap93"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap94"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap95"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap6"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap9"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap3"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap31"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap32"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""air_outlet2"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""air_outlet1"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""air_outlet3"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""air_outlet4"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""rotor"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""stator"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""outlet"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""inlet"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""air_outlet1"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""stator"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""rotor"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""outlet"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""inlet"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap95"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap94"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap93"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap92"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap91"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap9"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap6"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap5"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap32"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap31"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap3"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap2"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap12"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap1"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""air_outlet4"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""air_outlet3"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""air_outlet2"" type=""const_conductivity"" conductivity=""{2}""/>
  </module>

  <module type=""sharephasecomp"" sharephasecomp=""oil"">
    <vc volume=""gap5"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap1"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap12"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap2"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap91"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap92"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap93"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap94"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap95"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap6"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap9"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap3"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap31"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap32"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""air_outlet2"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""air_outlet1"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""air_outlet3"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""air_outlet4"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""stator"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""outlet"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""inlet"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""rotor"" type=""const_density"" default=""yes"" value=""den""/>
  </module>

  <module type=""sharephasecomp"" sharephasecomp=""air"">
    <vc volume=""air_outlet1"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""stator"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""rotor"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""outlet"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""inlet"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap95"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap94"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap93"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap92"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap91"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap9"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap6"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap5"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap32"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap31"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap3"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap2"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap12"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""gap1"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""air_outlet4"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""air_outlet3"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
    <vc volume=""air_outlet2"" type=""ideal_gas_law"" molecular_weight=""28.97""/>
  </module>";

        // 边界条件定义 + 物理模型选择 + 各种监测
        // {0} -- 动轮转速 {1} -- 动轮转动惯量 {2} -- 进口压力 {3} -- 进口温度 
        // TODO: 通气孔压力
        public static string BianJieTiaoJianDingYi = @"
  <module type=""flow"" state=""active"" numeric_scheme=""2ndorderupwind upwind""/>
  <module type=""heat"" state=""active""/>
  <module type=""turbulence"" state=""active"" relaxation=""0.3 0.3"">
    <bc patch=""rotor_blades"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""stator_wall"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""outlet_wall"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""inlet_wall"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_min"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""dir_min_2"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""dir_max_2"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_min_3"" type=""wall"" default=""yes"" wall_roughness=""rough""
      roughness_height=""0.0005""/>

    <bc patch=""cylinder_3"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""dir_min_5"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""dir_max_5"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_min_6"" type=""wall"" default=""yes"" wall_roughness=""rough""
      roughness_height=""0.0005""/>

    <bc patch=""cylinder_6"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""dir_min_7"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""dir_max_7"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_min_8"" type=""wall"" default=""yes"" wall_roughness=""rough""
      roughness_height=""0.0005""/>

    <bc patch=""cylinder_8"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""dir_min_9"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""dir_max_9"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_min_11"" type=""wall"" default=""yes"" wall_roughness=""rough""
      roughness_height=""0.0005""/>

    <bc patch=""cylinder_11"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_min_4"" type=""wall"" default=""yes"" wall_roughness=""rough""
      roughness_height=""0.0005""/>

    <bc patch=""cylinder_4"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_min_10"" type=""wall"" default=""yes"" wall_roughness=""rough""
      roughness_height=""0.0005""/>

    <bc patch=""cylinder_10"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_min_13"" type=""wall"" default=""yes"" wall_roughness=""rough""
      roughness_height=""0.0005""/>

    <bc patch=""cylinder_13"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_15"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_16"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_14"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
    <bc patch=""cylinder_17"" type=""wall"" default=""yes"" wall_roughness=""rough"" roughness_height=""0.0005""/>
  </module>

  <module
    type=""centrifugal""
    state=""active""
    method=""moving_grid""
    num_revolutions=""100""
    rotation_direction=""counter_clockwise""
    omega=""{0}""
    rotate_axis_direction=""1 0 0""
    n_time_steps_per_pocket_move=""20""
    number_blades=""20"">
    <bc patch=""inlet_inlet"" type=""inlet""/>
    <bc patch=""dir_max_17"" type=""outlet""/>
    <bc patch=""dir_max_16"" type=""outlet""/>
    <bc patch=""dir_max_15"" type=""outlet""/>
    <bc patch=""dir_max_14"" type=""outlet""/>
    <bc patch=""dir_min_1"" type=""outlet""/>
    <bc patch=""dir_max"" type=""outlet""/>
    <bc patch=""rotor_blades"" type=""rotor""/>
    <bc patch=""cylinder_min_1"" type=""rotate wall""/>
    <bc patch=""dir_max_2"" type=""rotate wall""/>
    <bc patch=""cylinder_3"" type=""rotate wall""/>
    <bc patch=""cylinder_min_10"" type=""rotate wall""/>
    <bc patch=""cylinder_min_13"" type=""rotate wall""/>
    <bc patch=""cylinder"" type=""rotate wall""/>
    <bc patch=""cylinder_11"" type=""rotate wall""/>
    <bc patch=""cylinder_min_4"" type=""rotate wall""/>
    <bc patch=""dir_max_5"" type=""rotate wall""/>
    <bc patch=""cylinder_min_6"" type=""rotate wall""/>
    <bc patch=""dir_max_7"" type=""rotate wall""/>
    <bc patch=""cylinder_min_8"" type=""rotate wall""/>
    <bc patch=""dir_max_9"" type=""rotate wall""/>
    <bc patch=""outlet_outlet"" type=""outlet"" output=""user_select""/>
    <vc volume=""gap5"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap1"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap12"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap2"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap91"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap92"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap93"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap94"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap95"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap6"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap9"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap3"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap31"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap32"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""air_outlet2"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""air_outlet1"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""air_outlet3"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""air_outlet4"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""rotor"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""stator"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""outlet"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""inlet"" type=""property"" default=""yes"" pump_material=""oil""/>
  </module>

  <module
    type=""rotate_1d""
    state=""active""
    rotate_direction=""1 0 0""
    rotation_direction=""counter_clockwise""
    initial_omega=""366.5191429188092""
    initial_omega_udsp=""rpm""
    moment_of_inertia=""{1}"">
    <bc patch=""rotor_blades"" type=""dynamicsBC""/>
  </module>

  <module
    type=""multiphase""
    state=""active""
    components=""oil air""
    solve_option=""solve_one_less_eqs""
    max_courant_number=""30""/>
  <module
    type=""multiflow""
    numeric_scheme=""2ndorderupwind upwind""
    gravity=""on""
    g=""-9.81 0 0""
    maximum_v_magnitude=""2000"">
    <bc patch=""dir_min_1"" type=""fix_pressure"" output=""user_select""/>
    <bc patch=""inlet_inlet"" type=""fix_pressure_inlet"" value=""{2}""/>
    <bc patch=""dir_max_16"" type=""fix_pressure""/>
    <bc patch=""dir_max_17"" type=""fix_pressure""/>
    <bc patch=""dir_max_14"" type=""fix_pressure""/>
    <bc patch=""dir_max_15"" type=""fix_pressure""/>
    <bc patch=""dir_max"" type=""fix_pressure""/>
    <bc patch=""outlet_outlet"" type=""fix_volflux"" default=""yes"" print_average_pres=""on""
      value=""Qvoutlet"" output=""user_select""/>
  </module>

  <module type=""multiheat"" viscous_work=""on"" temperature_max=""1000"">
    <bc patch=""inlet_inlet"" type=""fix_t"" value=""{3}""/>
    <bc patch=""dir_max"" type=""outlet""/>
    <bc patch=""dir_max_14"" type=""outlet""/>
    <bc patch=""dir_max_15"" type=""outlet""/>
    <bc patch=""dir_max_17"" type=""outlet""/>
    <bc patch=""dir_max_16"" type=""outlet""/>
    <bc patch=""dir_min_1"" type=""outlet""/>
    <bc patch=""outlet_outlet"" type=""outlet"" default=""yes"" output=""user_select""/>
    <vc volume=""air_outlet1"" type=""output_var"" default=""yes"" print_vol_avg_t=""on""
      print_mass_tot_e=""on"" print_vol_avg_et=""on""/>

    <vc volume=""stator"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""rotor"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""outlet"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""inlet"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap95"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap94"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap93"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap92"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap91"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap9"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap6"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap5"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap32"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap31"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap3"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap2"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap12"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""gap1"" type=""output_var"" default=""yes"" print_vol_avg_t=""on"" print_mass_tot_e=""on""
      print_vol_avg_et=""on""/>

    <vc volume=""air_outlet4"" type=""output_var"" default=""yes"" print_vol_avg_t=""on""
      print_mass_tot_e=""on"" print_vol_avg_et=""on""/>

    <vc volume=""air_outlet3"" type=""output_var"" default=""yes"" print_vol_avg_t=""on""
      print_mass_tot_e=""on"" print_vol_avg_et=""on""/>

    <vc volume=""air_outlet2"" type=""output_var"" default=""yes"" print_vol_avg_t=""on""
      print_mass_tot_e=""on"" print_vol_avg_et=""on""/>

    <vc volume=""air_outlet1"" type=""fix_heat_source""/>
    <vc volume=""stator"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""rotor"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""outlet"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""inlet"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap95"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap94"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap93"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap92"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap91"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap9"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap6"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap5"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap32"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap31"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap3"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap2"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap12"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap1"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""air_outlet4"" type=""fix_heat_source""/>
    <vc volume=""air_outlet3"" type=""fix_heat_source""/>
    <vc volume=""air_outlet2"" type=""fix_heat_source""/>
  </module>

  <module type=""phasecomp"" phasecomp=""oil"" time_accuracy=""firstorder"">
    <bc patch=""inlet_inlet"" type=""fix_value"" value=""Vf_oil"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_17"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_16"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_15"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_14"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_min_1"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""outlet_outlet"" type=""outlet"" output=""user_select""/>
    <vc volume=""rotor"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""stator"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""outlet"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""inlet"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap5"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap1"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap12"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap2"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap91"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap92"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap93"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap94"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap95"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap6"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap9"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap3"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap31"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap32"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""air_outlet2"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""air_outlet1"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""air_outlet3"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""air_outlet4"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <ic volume=""gap5"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap1"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap12"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap2"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap91"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap92"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap93"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap94"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap95"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap6"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap9"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap3"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap31"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap32"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""air_outlet2"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""air_outlet1"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""air_outlet3"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""air_outlet4"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""rotor"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""stator"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""outlet"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""inlet"" type=""fix_value"" default=""yes"" value=""0""/>
  </module>

  <module type=""phasecomp"" phasecomp=""air"" time_accuracy=""firstorder"">
    <bc patch=""dir_max_17"" type=""outlet"" value=""1""/>
    <bc patch=""dir_max_16"" type=""outlet"" value=""1""/>
    <bc patch=""dir_max_15"" type=""outlet"" value=""1""/>
    <bc patch=""dir_max_14"" type=""outlet"" value=""1""/>
    <bc patch=""dir_min_1"" type=""outlet"" value=""1""/>
    <bc patch=""dir_max"" type=""outlet"" value=""1"" print_m_flux=""on"" print_v_flux=""on""
      output=""user_select""/>

    <bc patch=""inlet_inlet"" type=""fix_value"" value=""Vf_air""/>
    <bc patch=""outlet_outlet"" type=""outlet"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <vc volume=""gap5"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap1"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap12"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap2"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap91"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap92"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap93"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap94"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap95"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap6"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap9"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap3"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap31"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap32"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""air_outlet2"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""air_outlet1"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""air_outlet3"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""air_outlet4"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""rotor"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""stator"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""outlet"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""inlet"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <ic volume=""gap5"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap1"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap12"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap2"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap91"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap92"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap93"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap94"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap95"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap6"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap9"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap3"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap31"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""gap32"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""air_outlet2"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""air_outlet1"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""air_outlet3"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""air_outlet4"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""rotor"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""stator"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""outlet"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""inlet"" type=""fix_value"" default=""yes"" value=""1""/>
  </module>";

        // {0} -- 迭代步数 {1} -- 保存频率
        public static string JiSuanKongZhiCanShu = @"
  <module type=""share"" iteration=""{0}"" save_result_interval=""{1}"" template_mode=""advanced_mode"">
    <vc volume=""rotor"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""stator"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""outlet"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""inlet"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap5"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap1"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap12"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap2"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap91"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap92"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap93"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap94"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap95"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap6"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap9"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap3"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap31"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap32"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""air_outlet2"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""air_outlet1"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""air_outlet3"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""air_outlet4"" type=""output_var"" default=""yes"" print_volume=""on""/>
  </module>";

        // {0} -- X1 {1} -- Y1 {2} -- Z1
        // {3} -- X2 {4} -- Y2 {5} -- Z2
        public const string JianKongDianZuoBiaoCanShu = @"  <probe_point name=""Point 01"" position=""{0} {1} {2}""/>
  <probe_point name=""Point 02"" position=""{3} {4} {5}""/>";
    }
}
