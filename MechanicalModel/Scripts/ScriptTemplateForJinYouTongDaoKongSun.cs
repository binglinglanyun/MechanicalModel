using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.Scripts
{
    public static class ScriptTemplateForJinYouTongDaoKongSun
    {
        public const string ScriptXMLHeader = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
<simulation
  program=""Simerics MP+""
  version=""5.0.15""
  customer=""Hi-Key""
  date=""Sat Feb 27 22:42:33 2021"">";

        public const string ScriptXMLTail = @"
</simulation>";

        // 模型导入
        public const string ImportMoXing = @" 
  <import vendor=""Simerics"">
	 <surface name=""inlet_inlet"" file=""inlet_inlet.stl"" scale=""1""/>
     <surface name=""inlet_mgi_rotor"" file=""inlet_mgi_rotor.stl"" scale=""1""/>
     <surface name=""inlet_valve"" file=""inlet_valve.stl"" scale=""1""/>
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

        public static readonly string WangGeHuafenConstScript = $@"
  <include file=""{ScriptWrapperForJinYouTongDaoKongSun.SgrdFileName}""/>

  <volume name=""gap5""/>
  <volume name=""gap1""/>
  <volume name=""gap12""/>
  <volume name=""gap2""/>
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
  <volume name=""gap_69""/>

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
  <patch name=""dir_min_4"" volume=""gap6""/>
  <patch name=""cylinder_min_4"" volume=""gap6""/>
  <patch name=""dir_max_4"" volume=""gap6""/>
  <patch name=""cylinder_4"" volume=""gap6""/>
  <patch name=""dir_min_5"" volume=""gap9""/>
  <patch name=""cylinder_min_5"" volume=""gap9""/>
  <patch name=""dir_max_5"" volume=""gap9""/>
  <patch name=""cylinder_5"" volume=""gap9""/>
  <patch name=""dir_min_6"" volume=""gap3""/>
  <patch name=""cylinder_min_6"" volume=""gap3""/>
  <patch name=""dir_max_6"" volume=""gap3""/>
  <patch name=""cylinder_6"" volume=""gap3""/>
  <patch name=""dir_min_7"" volume=""gap31""/>
  <patch name=""cylinder_min_7"" volume=""gap31""/>
  <patch name=""dir_max_7"" volume=""gap31""/>
  <patch name=""cylinder_7"" volume=""gap31""/>
  <patch name=""dir_min_8"" volume=""gap32""/>
  <patch name=""cylinder_min_8"" volume=""gap32""/>
  <patch name=""dir_max_8"" volume=""gap32""/>
  <patch name=""cylinder_8"" volume=""gap32""/>
  <patch name=""air_outlet2"" volume=""air_outlet2""/>
  <patch name=""dir_min_9"" volume=""air_outlet2""/>
  <patch name=""dir_max_9"" volume=""air_outlet2""/>
  <patch name=""air_outlet1"" volume=""air_outlet1""/>
  <patch name=""dir_min_10"" volume=""air_outlet1""/>
  <patch name=""dir_max_10"" volume=""air_outlet1""/>
  <patch name=""air_outlet3"" volume=""air_outlet3""/>
  <patch name=""dir_min_11"" volume=""air_outlet3""/>
  <patch name=""dir_max_11"" volume=""air_outlet3""/>
  <patch name=""air_outlet4"" volume=""air_outlet4""/>
  <patch name=""dir_min_12"" volume=""air_outlet4""/>
  <patch name=""dir_max_12"" volume=""air_outlet4""/>
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
  <patch name=""inlet_valve"" volume=""inlet""/>
  <patch name=""inlet_inlet"" volume=""inlet""/>
  <patch name=""dir_min_13"" volume=""gap_69""/>
  <patch name=""cylinder_min_9"" volume=""gap_69""/>
  <patch name=""dir_max_13"" volume=""gap_69""/>
  <patch name=""cylinder_9"" volume=""gap_69""/>
  <patch name=""MGI01_dir_min_10_stator_mgi_outlet1"" left_volume=""air_outlet1"" right_volume=""stator""/>
  <patch name=""MGI02_dir_min_9_stator_mgi_outlet2"" left_volume=""air_outlet2"" right_volume=""stator""/>
  <patch name=""MGI03_dir_min_11_stator_mgi_outlet3"" left_volume=""stator"" right_volume=""air_outlet3""/>
  <patch name=""MGI04_dir_min_12_stator_mgi_outlet4"" left_volume=""air_outlet4"" right_volume=""stator""/>
  <patch name=""MGI05_cylinder_1_cylinder_min_2"" left_volume=""gap1"" right_volume=""gap12""/>
  <patch name=""MGI06_cylinder_2_cylinder_min_3"" left_volume=""gap12"" right_volume=""gap2""/>
  <patch name=""MGI07_cylinder_3_rotor_mgi_gap1"" left_volume=""gap2"" right_volume=""rotor""/>
  <patch name=""MGI07_cylinder_3_stator_mgi_gap1"" left_volume=""gap2"" right_volume=""stator""/>
  <patch name=""MGI08_dir_min_6_rotor_mgi_gap3"" left_volume=""gap3"" right_volume=""rotor""/>
  <patch name=""MGI09_cylinder_6_cylinder_min_7"" left_volume=""gap3"" right_volume=""gap31""/>
  <patch name=""MGI10_cylinder_7_cylinder_min_8"" left_volume=""gap31"" right_volume=""gap32""/>
  <patch name=""MGI12_cylinder_rotor_mgi_gap5"" left_volume=""gap5"" right_volume=""rotor""/>
  <patch name=""MGI13_dir_max_8_rotor_mgi_gap32"" left_volume=""gap32"" right_volume=""rotor""/>
  <patch name=""MGI14_dir_max_4_rotor_mgi_inlet"" left_volume=""gap6"" right_volume=""rotor""/>
  <patch name=""MGI14_inlet_mgi_rotor_rotor_mgi_inlet"" left_volume=""inlet"" right_volume=""rotor""/>
  <patch name=""MGI15_cylinder_4_cylinder_min_9"" left_volume=""gap6"" right_volume=""gap_69""/>
  <patch name=""MGI16_dir_max_5_outlet_mgi_gap9"" left_volume=""outlet"" right_volume=""gap9""/>
  <patch name=""MGI17_cylinder_9_cylinder_min_5"" left_volume=""gap_69"" right_volume=""gap9""/>
  <patch
    name=""MGI21_outlet_mgi_rotor_cylinder_rotor_cylinder_mgi_outlet""
    left_volume=""rotor""
    right_volume=""outlet""/>
  <patch name=""MGI22_outlet_mgi_rotor_side_rotor_mgi_side"" left_volume=""rotor"" right_volume=""outlet""/>
  <patch name=""MGI23_outlet_mgi_rotor_top_rotor_mgi_top"" left_volume=""outlet"" right_volume=""rotor""/>
  <patch name=""MGI24_rotor_mgi_stator_stator_mgi_rotor"" left_volume=""stator"" right_volume=""rotor""/>

  <mgi name=""MGI01"">
    <patch name=""dir_min_10""/>
    <patch name=""stator_mgi_outlet1""/>
  </mgi>

  <mgi name=""MGI02"">
    <patch name=""dir_min_9""/>
    <patch name=""stator_mgi_outlet2""/>
  </mgi>

  <mgi name=""MGI03"">
    <patch name=""stator_mgi_outlet3""/>
    <patch name=""dir_min_11""/>
  </mgi>

  <mgi name=""MGI04"">
    <patch name=""dir_min_12""/>
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
    <patch name=""dir_min_6""/>
    <patch name=""rotor_mgi_gap3""/>
  </mgi>

  <mgi name=""MGI09"">
    <patch name=""cylinder_6""/>
    <patch name=""cylinder_min_7""/>
  </mgi>

  <mgi name=""MGI10"">
    <patch name=""cylinder_min_8""/>
    <patch name=""cylinder_7""/>
  </mgi>

  <mgi name=""MGI12"">
    <patch name=""cylinder""/>
    <patch name=""rotor_mgi_gap5""/>
  </mgi>

  <mgi name=""MGI13"">
    <patch name=""dir_max_8""/>
    <patch name=""rotor_mgi_gap32""/>
  </mgi>

  <mgi name=""MGI14"">
    <patch name=""dir_max_4""/>
    <patch name=""inlet_mgi_rotor""/>
    <patch name=""rotor_mgi_inlet""/>
  </mgi>

  <mgi name=""MGI15"">
    <patch name=""cylinder_min_9""/>
    <patch name=""cylinder_4""/>
  </mgi>

  <mgi name=""MGI16"">
    <patch name=""outlet_mgi_gap9""/>
    <patch name=""dir_max_5""/>
  </mgi>

  <mgi name=""MGI17"">
    <patch name=""cylinder_9""/>
    <patch name=""cylinder_min_5""/>
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
    number_cell_i=""20""
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
    operation=""template mesh""
    name=""gap_69""
    new_mesh_name=""gap_69""
    autorun=""on""
    grid_type=""annulus""
    reference_point=""0.0104 0 0""
    first_point=""0.012 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.1085""
    annulus_outer_radius=""0.1298""
    number_cell_i=""10""
    number_cell_j=""50""
    number_cell_k=""120""/>";

        // 动轮 {0} - 最大网格尺度 {1} - 最小网格尺度 {2} - 最大面网格尺度
        public const string DongLunForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""rotor""
    new_mesh_name=""rotor""
    autorun=""on""
    user_mode=""advanced_mode""
    cell_size_definitions=""local size""
    maximum_size=""{0}""
    minimum_size=""{1}""
    maximum_at_surface=""{2}""
    subfeatures=""no_subfeatures"">
    <attribute surfaces=""rotor_blades rotor_cylinder_mgi_outlet rotor_mgi_gap1 rotor_mgi_gap3 rotor_mgi_gap32 rotor_mgi_gap5 rotor_mgi_inlet rotor_mgi_side rotor_mgi_stator rotor_mgi_top""/>

    <surface name=""rotor_mgi_gap1"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""rotor_mgi_gap32"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""rotor_mgi_gap5"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
  </build>";

        // 定轮 {0} - 最大网格尺度 {1} - 最小网格尺度 {2} - 最大面网格尺度
        public const string DingLunForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""stator""
    new_mesh_name=""stator""
    autorun=""on""
    user_mode=""advanced_mode""
    cell_size_definitions=""local size""
    maximum_size=""{0}""
    minimum_size=""{1}""
    maximum_at_surface=""{2}""
    subfeatures=""no_subfeatures"">
    <attribute surfaces=""stator_mgi_gap1 stator_mgi_outlet1 stator_mgi_outlet2 stator_mgi_outlet3 stator_mgi_outlet4 stator_mgi_rotor stator_wall""/>

    <surface name=""stator_mgi_gap1"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""stator_mgi_outlet1"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""stator_mgi_outlet2"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""stator_mgi_outlet3"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
    <surface name=""stator_mgi_outlet4"" bc_cell_size_opt=""custom_size"" cell_size=""0.001""/>
  </build>";

        // 出口 {0} - 最大网格尺度 {1} - 最小网格尺度 {2} - 最大面网格尺度
        public const string ChuKouForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""outlet""
    new_mesh_name=""outlet""
    autorun=""on""
    user_mode=""advanced_mode""
    cell_size_definitions=""local size""
    maximum_size=""{0}""
    minimum_size=""{1}""
    maximum_at_surface=""{2}""
    subfeatures=""no_subfeatures"">
    <attribute surfaces=""outlet_air_in outlet_mgi_gap9 outlet_mgi_rotor_cylinder outlet_mgi_rotor_side outlet_mgi_rotor_top outlet_outlet outlet_wall""/>

    <refine type=""cylinder_refinement"" refinements_cell_size=""0.0005"" bottom_center=""-0.003 0 0""
      radius=""0.133""/>
  </build>";

        // 入口 {0} - 最大网格尺度 {1} - 最小网格尺度 {2} - 最大面网格尺度
        public const string RuKouForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""inlet""
    new_mesh_name=""inlet""
    autorun=""on""
    user_mode=""advanced_mode""
    surfaces=""inlet_inlet inlet_mgi_rotor inlet_valve inlet_wall""
    cell_size_definitions=""local size""
    maximum_size=""{0}""
    minimum_size=""{1}""
    maximum_at_surface=""{2}""
    subfeatures=""no_subfeatures"">
    <surface name=""inlet_mgi_rotor"" bc_cell_size_opt=""custom_size"" cell_size=""0.005""/>
    <refine type=""cylinder_refinement"" refinements_cell_size=""0.003"" top_center=""0.039 0 0.238""
      bottom_center=""0.039 0 0.218"" radius=""0.036""/>
  </build>";

        public static readonly string ImportedOilFiles = $@"
  <expressions>
    Vcen=rotate_1d.rpm
    voil=(z>0.228)?1:0
    vair=1-voil
    temp=heat.T
    den=table(""{ScriptWrapperForJinYouTongDaoKongSun.DensityFileName}"",temp)
    vis=table(""{ScriptWrapperForJinYouTongDaoKongSun.ViscosityFileName}"",temp)
    cond=table(""{ScriptWrapperForJinYouTongDaoKongSun.HeatConductivityFileName}"",temp)
    capa=table(""{ScriptWrapperForJinYouTongDaoKongSun.HeatConductivityFileName}"",temp)
    Vall=0.00623
    Qflux=(iteration>50)?(-1)*flow.pow@rotor_blades/Vall:0
  </expressions>
";
        // 物质定义
        // 空气： {0} -- 空气粘度 {1} -- 空气比热容 {2} -- 空气热导率
        // 油：比热容"capa", 热导率"cond", 密度"den"来自自定义文件。
        public const string WuZhiDingYi = @" 
  <module type=""sharephasecomp"" sharephasecomp=""air"">
    <vc volume=""air_outlet1"" type=""ideal_gas_law""/>
    <vc volume=""stator"" type=""ideal_gas_law""/>
    <vc volume=""rotor"" type=""ideal_gas_law""/>
    <vc volume=""outlet"" type=""ideal_gas_law""/>
    <vc volume=""inlet"" type=""ideal_gas_law""/>
    <vc volume=""gap9"" type=""ideal_gas_law""/>
    <vc volume=""gap6"" type=""ideal_gas_law""/>
    <vc volume=""gap5"" type=""ideal_gas_law""/>
    <vc volume=""gap32"" type=""ideal_gas_law""/>
    <vc volume=""gap31"" type=""ideal_gas_law""/>
    <vc volume=""gap3"" type=""ideal_gas_law""/>
    <vc volume=""gap2"" type=""ideal_gas_law""/>
    <vc volume=""gap12"" type=""ideal_gas_law""/>
    <vc volume=""gap1"" type=""ideal_gas_law""/>
    <vc volume=""air_outlet4"" type=""ideal_gas_law""/>
    <vc volume=""air_outlet3"" type=""ideal_gas_law""/>
    <vc volume=""air_outlet2"" type=""ideal_gas_law""/>
    <vc volume=""gap_69"" type=""ideal_gas_law""/>
  </module>
  <module type=""flowphasecomp"" flowphasecomp=""air"">
    <vc volume=""gap5"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap1"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap12"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""gap2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
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
    <vc volume=""gap_69"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
  </module>

  <module type=""heatphasecomp"" heatphasecomp=""air"">
    <vc volume=""gap5"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap1"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap12"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""gap2"" type=""const_capacity"" default=""yes"" value=""{1}""/>
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
    <vc volume=""gap_69"" type=""const_capacity"" default=""yes"" value=""{1}""/>
    <vc volume=""air_outlet1"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""stator"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""rotor"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""outlet"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""inlet"" type=""const_conductivity"" conductivity=""{2}""/>
    <vc volume=""gap_69"" type=""const_conductivity"" conductivity=""{2}""/>
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

  <module type=""flowphasecomp"" flowphasecomp=""oil"">
    <vc volume=""gap5"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap1"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap12"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap2"" type=""const_viscosity"" default=""yes"" value=""vis""/>
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
    <vc volume=""air_outlet1"" type=""surface_tension""/>
    <vc volume=""stator"" type=""surface_tension""/>
    <vc volume=""outlet"" type=""surface_tension""/>
    <vc volume=""inlet"" type=""surface_tension""/>
    <vc volume=""gap9"" type=""surface_tension""/>
    <vc volume=""gap6"" type=""surface_tension""/>
    <vc volume=""gap5"" type=""surface_tension""/>
    <vc volume=""gap32"" type=""surface_tension""/>
    <vc volume=""gap31"" type=""surface_tension""/>
    <vc volume=""gap3"" type=""surface_tension""/>
    <vc volume=""gap2"" type=""surface_tension""/>
    <vc volume=""gap12"" type=""surface_tension""/>
    <vc volume=""gap1"" type=""surface_tension""/>
    <vc volume=""air_outlet4"" type=""surface_tension""/>
    <vc volume=""air_outlet3"" type=""surface_tension""/>
    <vc volume=""air_outlet2"" type=""surface_tension""/>
    <vc volume=""rotor"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""rotor"" type=""surface_tension""/>
    <vc volume=""gap_69"" type=""const_viscosity"" default=""yes"" value=""vis""/>
    <vc volume=""gap_69"" type=""surface_tension""/>
  </module>

  <module type=""heatphasecomp"" heatphasecomp=""oil"">
    <vc volume=""gap5"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""gap1"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""gap12"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""gap2"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""gap6"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""gap9"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""gap3"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""gap31"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""gap32"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""air_outlet2"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""air_outlet1"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""air_outlet3"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""air_outlet4"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""rotor"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""stator"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""outlet"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""inlet"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""gap_69"" type=""const_capacity"" default=""yes"" value=""capa""/>
    <vc volume=""air_outlet1"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""stator"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""rotor"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""outlet"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""inlet"" type=""const_conductivity"" conductivity=""cond""/>
    <vc volume=""gap_69"" type=""const_conductivity"" conductivity=""cond""/>
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
  </module>

  <module type=""sharephasecomp"" sharephasecomp=""oil"">
    <vc volume=""gap5"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap1"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap12"" type=""const_density"" default=""yes"" value=""den""/>
    <vc volume=""gap2"" type=""const_density"" default=""yes"" value=""den""/>
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
    <vc volume=""gap_69"" type=""const_density"" default=""yes"" value=""den""/>
  </module>";

        // 边界条件定义 + 物理模型选择 + 各种监测
        // {0} -- 动轮转速  {1} -- 入口压力  {2} -- 通气口压力
        // {3} -- 排气口压力  {4} -- 入口温度
        public const string BianJieTiaoJianDingYi = @"
  <module
    type=""centrifugal""
    state=""active""
    method=""mrf""
    rotation_direction=""counter_clockwise""
    omega=""{0}""
    rotate_axis_direction=""1 0 0""
    number_blades=""20""
    rotor_center=""0 0 0"">
    <bc patch=""dir_min_1"" type=""outlet""/>
    <bc patch=""dir_max"" type=""outlet""/>
    <bc patch=""rotor_blades"" type=""rotor""/>
    <bc patch=""outlet_air_in"" type=""outlet""/>
    <bc patch=""inlet_inlet"" type=""inlet""/>
    <bc patch=""dir_max_10"" type=""inlet""/>
    <bc patch=""dir_max_9"" type=""inlet""/>
    <bc patch=""dir_max_12"" type=""inlet""/>
    <bc patch=""dir_max_11"" type=""inlet""/>
    <vc volume=""gap5"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap1"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap12"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""gap2"" type=""property"" default=""yes"" pump_material=""oil""/>
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
    <vc volume=""gap_69"" type=""property"" default=""yes"" pump_material=""oil""/>
  </module>

  <module
    type=""multiphase""
    state=""active""
    components=""oil air""
    max_courant_number=""50""
    compression_factor=""10""/>
  <module type=""multiflow"" converge_criterion=""1e-05"" relaxation=""0 0"" gravity=""on"" g=""0 0 9.81"">
    <bc patch=""outlet_outlet"" type=""wall"" default=""yes"" print_average_total_pres=""on"" print_average_pres=""on"" output=""user_select""/>
    <bc patch=""dir_min_1"" type=""fix_pressure"" output=""user_select""/>
    <bc patch=""dir_max"" type=""fix_pressure""/>
    <bc patch=""inlet_inlet"" type=""fix_pressure_inlet"" value=""{1}""/>
    <bc patch=""dir_max_14"" type=""fix_pressure_inlet"" value=""{2}""/>
    <bc patch=""dir_max_17"" type=""fix_pressure_inlet"" value=""{2}""/>
    <bc patch=""dir_max_16"" type=""fix_pressure_inlet"" value=""{2}""/>
    <bc patch=""dir_max_15"" type=""fix_pressure_inlet"" value=""{2}""/>
	<bc patch=""outlet_air_in"" type=""fix_pressure"" value=""{3}""/>
    <bc patch=""rotor_blades"" type=""rotate_wall"" print_torque=""on"" output=""user_select""/>
    <ic volume=""rotor"" type=""rotate_initial"" direction=""1 0 0""/>
  </module>

  <module type=""multiheat"" relaxation=""0.2"" temperature_max=""1000"" temperature_min=""50"" max_t_dif=""50"">
    <bc patch=""inlet_inlet"" type=""fix_t"" default=""yes"" value=""{4}""/>
    <bc patch=""outlet_outlet"" type=""adiabatic"" default=""yes"" print_avg_t=""on"" output=""user_select""/>
    <bc patch=""dir_max"" type=""outlet"" default=""yes"" back_flow_opt=""user""/>
    <vc volume=""gap1"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""stator"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""rotor"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""outlet"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap_69"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap9"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap6"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap5"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap32"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap31"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap3"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap2"" type=""fix_heat_source"" value=""Qflux""/>
    <vc volume=""gap12"" type=""fix_heat_source"" value=""Qflux""/>
  </module>

  <module type=""phasecomp"" phasecomp=""oil"">
    <bc patch=""dir_min_1"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""outlet_air_in"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""inlet_inlet"" type=""fix_value"" value=""1"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_10"" type=""fix_value"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_9"" type=""fix_value"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_12"" type=""fix_value"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_11"" type=""fix_value"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <vc volume=""rotor"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""stator"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""outlet"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""inlet"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap5"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap1"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap12"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap2"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap6"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap9"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap3"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap31"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap32"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""air_outlet2"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""air_outlet1"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""air_outlet3"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""air_outlet4"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <vc volume=""gap_69"" type=""output_var"" default=""yes"" print_tot_vol=""on""/>
    <ic volume=""gap5"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap1"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap12"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""gap2"" type=""fix_value"" default=""yes"" value=""0""/>
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
    <ic volume=""inlet"" type=""fix_value"" default=""yes"" value=""voil""/>
    <ic volume=""gap_69"" type=""fix_value"" default=""yes"" value=""0""/>
  </module>

  <module type=""phasecomp"" phasecomp=""air"">
    <bc patch=""dir_min_1"" type=""outlet"" value=""1"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max"" type=""outlet"" value=""1"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""outlet_air_in"" type=""outlet"" value=""1"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_10"" type=""fix_value"" value=""1"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_9"" type=""fix_value"" value=""1"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_12"" type=""fix_value"" value=""1"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""dir_max_11"" type=""fix_value"" value=""1"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <vc volume=""gap5"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap1"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap12"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
    <vc volume=""gap2"" type=""output_var"" default=""yes"" print_vol_frac=""on""/>
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
    <ic volume=""inlet"" type=""fix_value"" default=""yes"" value=""vair""/>
    <ic volume=""gap_69"" type=""fix_value"" default=""yes"" value=""1""/>
  </module> 
    
  <module type=""flow"" state=""active"" numeric_scheme=""2ndorderupwind upwind""/>
  <module type=""heat"" state=""active""/>
  <module type=""turbulence"" state=""active"" relaxation=""0.5 0.5""/>";

        // {0} - 时间步长
        public const string JiSuanKongZhiCanShu = @"    <module type=""share"" iteration=""{0}"" save_result_interval=""500"" template_mode=""advanced_mode"">
    <vc volume=""rotor"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""stator"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""outlet"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""inlet"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap5"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap1"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap12"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap2"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap6"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap9"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap3"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap31"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap32"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""air_outlet2"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""air_outlet1"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""air_outlet3"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""air_outlet4"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""gap_69"" type=""output_var"" default=""yes"" print_volume=""on""/>
  </module>";

        // {0} -- X1 {1} -- Y1 {2} -- Z1
        // {3} -- X2 {4} -- Y2 {5} -- Z2
        public const string JianKongDianZuoBiaoCanShu = @"  <probe_point name=""Point 01"" position=""{0} {1} {2}""/>
  <output module=""share"" properties=""on"" derived=""on""/>
  <probe_point name=""Point 02"" position=""{3} {4} {5}""/>";
    }
}
