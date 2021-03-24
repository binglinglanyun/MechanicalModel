using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.Scripts
{
    public static class ScriptTemplateForJinQiBiKongSun
    {
        public const string ScriptXMLHeader = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>

<simulation program=""PumpLinx"" version=""4.0.3"" customer=""Customer"" date=""Tue Jun 12 13:48:04 2018"">";

        public const string ScriptXMLTail = @"
</simulation>";

        // {0} script file name
        public const string ImportScript = @" 
  <import vendor=""Simerics"">
	<surface name=""air_inlet1_mgi_stator"" file=""air_inlet1_mgi_stator.stl"" scale=""1""/>
	<surface name=""air_inlet1_wall"" file=""air_inlet1_wall.stl"" scale=""1""/>
	<surface name=""air_inlet1_inlet"" file=""air_inlet1_inlet.stl"" scale=""1""/>
	<surface name=""air_inlet2_wall"" file=""air_inlet2_wall.stl"" scale=""1""/>
	<surface name=""air_inlet2_mgi_stator"" file=""air_inlet2_mgi_stator.stl"" scale=""1""/>
	<surface name=""air_inlet2_inlet"" file=""air_inlet2_inlet.stl"" scale=""1""/>
	<surface name=""air_inlet3_wall"" file=""air_inlet3_wall.stl"" scale=""1""/>
	<surface name=""air_inlet3_mgi_stator"" file=""air_inlet3_mgi_stator.stl"" scale=""1""/>
	<surface name=""air_inlet3_inlet"" file=""air_inlet3_inlet.stl"" scale=""1""/>
	<surface name=""inlet_wall"" file=""inlet_wall.stl"" scale=""1""/>
	<surface name=""inlet_mgi_rotor"" file=""inlet_mgi_rotor.stl"" scale=""1""/>
	<surface name=""inlet_inlet"" file=""inlet_inlet.stl"" scale=""1""/>
	<surface name=""outlet_wall"" file=""outlet_wall.stl"" scale=""1""/>
	<surface name=""outlet_mgi_rotor"" file=""outlet_mgi_rotor.stl"" scale=""1""/>
	<surface name=""outlet_mgi_rotor_cyl"" file=""outlet_mgi_rotor_cyl.stl"" scale=""1""/>
	<surface name=""outlet_outlet_air"" file=""outlet_outlet_air.stl"" scale=""1""/>
	<surface name=""outlet_outlet"" file=""outlet_outlet.stl"" scale=""1""/>
	<surface name=""rotor_mgi_outlet"" file=""rotor_mgi_outlet.stl"" scale=""1""/>
	<surface name=""rotor_mgi_outlet_cyl"" file=""rotor_mgi_outlet_cyl.stl"" scale=""1""/>
	<surface name=""rotor_blades"" file=""rotor_blades.stl"" scale=""1""/>
	<surface name=""rotor_mgi_stator"" file=""rotor_mgi_stator.stl"" scale=""1""/>
	<surface name=""rotor_mgi_inlet"" file=""rotor_mgi_inlet.stl"" scale=""1""/>
	<surface name=""stator_mgi_rotor"" file=""stator_mgi_rotor.stl"" scale=""1""/>
	<surface name=""stator_wall"" file=""stator_wall.stl"" scale=""1""/>
	<surface name=""stator_mgi_air_inlet3"" file=""stator_mgi_air_inlet3.stl"" scale=""1""/>
	<surface name=""stator_mgi_air_inlet1"" file=""stator_mgi_air_inlet1.stl"" scale=""1""/>
	<surface name=""stator_mgi_air_inlet2"" file=""stator_mgi_air_inlet2.stl"" scale=""1""/>
  </import>";

        public const string WangGeHuafenConstScript = @"
  <include file=""torque_jinqibikongsun.sgrd""/>

  <volume name=""air_inlet1""/>
  <volume name=""air_inlet2""/>
  <volume name=""air_inlet3""/>
  <volume name=""inlet""/>
  <volume name=""outlet""/>
  <volume name=""rotor""/>
  <volume name=""stator""/>

  <patch name=""air_inlet1_mgi_stator"" volume=""air_inlet1""/>
  <patch name=""air_inlet1_wall"" volume=""air_inlet1""/>
  <patch name=""air_inlet1_inlet"" volume=""air_inlet1""/>
  <patch name=""air_inlet2_wall"" volume=""air_inlet2""/>
  <patch name=""air_inlet2_mgi_stator"" volume=""air_inlet2""/>
  <patch name=""air_inlet2_inlet"" volume=""air_inlet2""/>
  <patch name=""air_inlet3_wall"" volume=""air_inlet3""/>
  <patch name=""air_inlet3_mgi_stator"" volume=""air_inlet3""/>
  <patch name=""air_inlet3_inlet"" volume=""air_inlet3""/>
  <patch name=""inlet_wall"" volume=""inlet""/>
  <patch name=""inlet_mgi_rotor"" volume=""inlet""/>
  <patch name=""inlet_inlet"" volume=""inlet""/>
  <patch name=""outlet_wall"" volume=""outlet""/>
  <patch name=""outlet_mgi_rotor"" volume=""outlet""/>
  <patch name=""outlet_mgi_rotor_cyl"" volume=""outlet""/>
  <patch name=""outlet_outlet_air"" volume=""outlet""/>
  <patch name=""outlet_outlet"" volume=""outlet""/>
  <patch name=""rotor_mgi_outlet"" volume=""rotor""/>
  <patch name=""rotor_mgi_outlet_cyl"" volume=""rotor""/>
  <patch name=""rotor_blades"" volume=""rotor""/>
  <patch name=""rotor_mgi_stator"" volume=""rotor""/>
  <patch name=""rotor_mgi_inlet"" volume=""rotor""/>
  <patch name=""stator_mgi_rotor"" volume=""stator""/>
  <patch name=""stator_wall"" volume=""stator""/>
  <patch name=""stator_mgi_air_inlet3"" volume=""stator""/>
  <patch name=""stator_mgi_air_inlet1"" volume=""stator""/>
  <patch name=""stator_mgi_air_inlet2"" volume=""stator""/>
  <patch
    name=""MGI01_air_inlet1_mgi_stator_stator_mgi_air_inlet1""
    left_volume=""stator""
    right_volume=""air_inlet1""/>
  <patch name=""MGI02_inlet_mgi_rotor_rotor_mgi_inlet"" left_volume=""inlet"" right_volume=""rotor""/>
  <patch name=""MGI03_outlet_mgi_rotor_rotor_mgi_outlet"" left_volume=""outlet"" right_volume=""rotor""/>
  <patch
    name=""MGI04_outlet_mgi_rotor_cyl_rotor_mgi_outlet_cyl""
    left_volume=""rotor""
    right_volume=""outlet""/>
  <patch name=""MGI05_rotor_mgi_stator_stator_mgi_rotor"" left_volume=""rotor"" right_volume=""stator""/>
  <patch
    name=""MGI06_air_inlet2_mgi_stator_stator_mgi_air_inlet2""
    left_volume=""stator""
    right_volume=""air_inlet2""/>
  <patch
    name=""MGI07_air_inlet3_mgi_stator_stator_mgi_air_inlet3""
    left_volume=""stator""
    right_volume=""air_inlet3""/>

  <mgi name=""MGI01"">
    <patch name=""stator_mgi_air_inlet1""/>
    <patch name=""air_inlet1_mgi_stator""/>
  </mgi>

  <mgi name=""MGI02"">
    <patch name=""inlet_mgi_rotor""/>
    <patch name=""rotor_mgi_inlet""/>
  </mgi>

  <mgi name=""MGI03"" tolerance=""0.01"">
    <patch name=""outlet_mgi_rotor""/>
    <patch name=""rotor_mgi_outlet""/>
  </mgi>

  <mgi name=""MGI04"" tolerance=""0.01"">
    <patch name=""outlet_mgi_rotor_cyl""/>
    <patch name=""rotor_mgi_outlet_cyl""/>
  </mgi>

  <mgi name=""MGI05"">
    <patch name=""rotor_mgi_stator""/>
    <patch name=""stator_mgi_rotor""/>
  </mgi>

  <mgi name=""MGI06"">
    <patch name=""stator_mgi_air_inlet2""/>
    <patch name=""air_inlet2_mgi_stator""/>
  </mgi>

  <mgi name=""MGI07"">
    <patch name=""stator_mgi_air_inlet3""/>
    <patch name=""air_inlet3_mgi_stator""/>
  </mgi>

  <build
    operation=""general mesh""
    name=""air_inlet1""
    new_mesh_name=""air_inlet1""
    surfaces=""air_inlet1_inlet air_inlet1_mgi_stator air_inlet1_wall""
    maximum_size=""0.02""
    minimum_size=""0.001""
    maximum_at_surface=""0.02""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""air_inlet2""
    new_mesh_name=""air_inlet2""
    surfaces=""air_inlet2_inlet air_inlet2_mgi_stator air_inlet2_wall""
    maximum_size=""0.02""
    minimum_size=""0.001""
    maximum_at_surface=""0.02""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""air_inlet3""
    new_mesh_name=""air_inlet3""
    surfaces=""air_inlet3_inlet air_inlet3_mgi_stator air_inlet3_wall""
    maximum_size=""0.02""
    minimum_size=""0.001""
    maximum_at_surface=""0.02""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""inlet""
    new_mesh_name=""inlet""
    surfaces=""inlet_inlet inlet_mgi_rotor inlet_wall""
    maximum_size=""0.01""
    minimum_size=""0.001""
    maximum_at_surface=""0.01""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""outlet""
    new_mesh_name=""outlet""
    maximum_size=""0.01""
    minimum_size=""0.001""
    maximum_at_surface=""0.01""
    volume_by_surfs_prefix=""off""
    names_by_size=""off"">
    <attribute surfaces=""outlet_mgi_rotor outlet_mgi_rotor_cyl outlet_outlet outlet_outlet_air outlet_wall""/>
  </build>";

        // 动轮 {0} - 最大网格尺度 {1} - 最小网格尺度 {2} - 最大面网格尺度
        public const string DongLunForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""rotor""
    new_mesh_name=""rotor""
    maximum_size=""{0}""
    minimum_size=""{1}""
    maximum_at_surface=""{2}""
    volume_by_surfs_prefix=""off""
    names_by_size=""off"">
 <attribute surfaces=""rotor_blades rotor_mgi_inlet rotor_mgi_outlet rotor_mgi_outlet_cyl rotor_mgi_stator""/>
  </build>";

        // 定轮 {0} - 最大网格尺度 {1} - 最小网格尺度 {2} - 最大面网格尺度
        public const string DingLunForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""stator""
    new_mesh_name=""stator""
    maximum_size=""{0}""
    minimum_size=""{1}""
    maximum_at_surface=""{2}""
    volume_by_surfs_prefix=""off""
    names_by_size=""off"">
<attribute surfaces=""stator_mgi_air_inlet1 stator_mgi_air_inlet2 stator_mgi_air_inlet3 stator_mgi_rotor stator_wall""/>
  </build>";

        // {0} - 时间步长
        public const string JiSuanKongZhiCanShu = @"  <module type=""share"" iteration=""{0}"" template_mode=""advanced_mode""/>";

        // {0} - 动轮转速 {1} - 排气孔 {2} - 通气孔 {3} - 油液体积分数
        public const string BianJieTiaoJianDingYi = @"  <module type=""flow"" state=""active"" numeric_scheme=""2ndorderupwind upwind""/>
  <module type=""turbulence"" state=""active""/>
  <module
    type=""centrifugal""
    state=""active""
    user_mode=""advanced_mode""
    method=""mrf""
    rotation_direction=""counter_clockwise""
    omega=""{0}""
    rotate_axis_direction=""1 0 0""
    number_blades=""20"">
    <bc patch=""rotor_blades"" type=""rotor""/>
    <bc patch=""outlet_mgi_rotor"" type=""rotate wall""/>
    <bc patch=""outlet_mgi_rotor_cyl"" type=""rotate wall""/>
    <bc patch=""outlet_outlet_air"" type=""outlet""/>
    <bc patch=""air_inlet1_inlet"" type=""inlet""/>
    <bc patch=""air_inlet3_inlet"" type=""inlet""/>
    <bc patch=""air_inlet2_inlet"" type=""inlet""/>
    <bc patch=""sub-features_2"" type=""rotor""/>
    <vc volume=""general mesh"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""general mesh_1"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""general mesh_2"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""general mesh_3"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""general mesh_4"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""general mesh_5"" type=""property"" default=""yes"" pump_material=""oil""/>
    <vc volume=""general mesh_6"" type=""property"" default=""yes"" pump_material=""oil""/>
  </module>

  <module
    type=""multiphase""
    state=""active""
    components=""oil air""
    courant_number=""0.34""
    adaptive_courant_number=""off""/>
  <module type=""multiflow"" numeric_scheme=""2ndorderupwind upwind"">
    <bc patch=""outlet_outlet_air"" type=""fix_pressure"" value=""{1}""/>
    <bc patch=""air_inlet1_inlet"" type=""fix_totalp"" default=""yes"" totalp=""{2}""/>
    <bc patch=""air_inlet3_inlet"" type=""fix_totalp"" default=""yes"" totalp=""{2}""/>
    <bc patch=""air_inlet2_inlet"" type=""fix_totalp"" default=""yes"" totalp=""{2}""/>
  </module>

  <module type=""phasecomp"" phasecomp=""oil"">
    <ic volume=""general mesh"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_1"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_2"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_3"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_4"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_5"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_6"" type=""fix_value"" default=""yes"" value=""{3}""/>
  </module>";

        // {0} -- 油粘度 {1} -- 空气粘度 {2} -- 油密度  {3} -- "1 - 油液体积分数"
        public const string WuZhiDingYi = @"  <module type=""flowphasecomp"" flowphasecomp=""oil"">
    <vc volume=""general mesh"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""general mesh_1"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""general mesh_2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""general mesh_3"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""general mesh_4"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""general mesh_5"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""general mesh_6"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""general mesh"" type=""surface_tension"" surface_tension=""0.0721""/>
    <vc volume=""general mesh_6"" type=""surface_tension"" surface_tension=""0.0721""/>
    <vc volume=""general mesh_5"" type=""surface_tension"" surface_tension=""0.0721""/>
    <vc volume=""general mesh_4"" type=""surface_tension"" surface_tension=""0.0721""/>
    <vc volume=""general mesh_3"" type=""surface_tension"" surface_tension=""0.0721""/>
    <vc volume=""general mesh_2"" type=""surface_tension"" surface_tension=""0.0721""/>
    <vc volume=""general mesh_1"" type=""surface_tension"" surface_tension=""0.0721""/>
  </module>

  <module type=""flowphasecomp"" flowphasecomp=""air"">
    <vc volume=""general mesh"" type=""const_viscosity"" default=""yes"" value=""{1}""/>
    <vc volume=""general mesh_1"" type=""const_viscosity"" default=""yes"" value=""{1}""/>
    <vc volume=""general mesh_2"" type=""const_viscosity"" default=""yes"" value=""{1}""/>
    <vc volume=""general mesh_3"" type=""const_viscosity"" default=""yes"" value=""{1}""/>
    <vc volume=""general mesh_4"" type=""const_viscosity"" default=""yes"" value=""{1}""/>
    <vc volume=""general mesh_5"" type=""const_viscosity"" default=""yes"" value=""{1}""/>
    <vc volume=""general mesh_6"" type=""const_viscosity"" default=""yes"" value=""{1}""/>
  </module>

  <module type=""sharephasecomp"" sharephasecomp=""oil"">
    <vc volume=""general mesh"" type=""const_density"" value=""{2}""/>
    <vc volume=""general mesh_1"" type=""const_density"" value=""{2}""/>
    <vc volume=""general mesh_2"" type=""const_density"" value=""{2}""/>
    <vc volume=""general mesh_3"" type=""const_density"" value=""{2}""/>
    <vc volume=""general mesh_4"" type=""const_density"" value=""{2}""/>
    <vc volume=""general mesh_5"" type=""const_density"" value=""{2}""/>
    <vc volume=""general mesh_6"" type=""const_density"" value=""{2}""/>
  </module>

  <module type=""sharephasecomp"" sharephasecomp=""air"">
    <vc volume=""general mesh"" type=""ideal_gas_law"" molecular_weight=""28.99""/>
    <vc volume=""general mesh_6"" type=""ideal_gas_law"" molecular_weight=""28.99""/>
    <vc volume=""general mesh_5"" type=""ideal_gas_law"" molecular_weight=""28.99""/>
    <vc volume=""general mesh_4"" type=""ideal_gas_law"" molecular_weight=""28.99""/>
    <vc volume=""general mesh_3"" type=""ideal_gas_law"" molecular_weight=""28.99""/>
    <vc volume=""general mesh_2"" type=""ideal_gas_law"" molecular_weight=""28.99""/>
    <vc volume=""general mesh_1"" type=""ideal_gas_law"" molecular_weight=""28.99""/>
  </module>

  <module type=""phasecomp"" phasecomp=""air"">
    <bc patch=""air_inlet1_inlet"" type=""fix_value"" value=""1""/>
    <bc patch=""air_inlet3_inlet"" type=""fix_value"" value=""1""/>
    <bc patch=""air_inlet2_inlet"" type=""fix_value"" value=""1""/>
    <ic volume=""general mesh"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_1"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_2"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_3"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_4"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_5"" type=""fix_value"" default=""yes"" value=""{3}""/>
    <ic volume=""general mesh_6"" type=""fix_value"" default=""yes"" value=""{3}""/>
  </module>";

        // {0} -- X {1} -- Y {2} -- Z
        public const string JianKongDianZuoBiaoCanShu = @"  <probe_point name=""Point 01"" position=""{0} {1} {2}"" />";
    }
}
