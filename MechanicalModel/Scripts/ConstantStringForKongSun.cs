using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.Scripts
{
    public static class ConstantStringForKongSun
    {
        // {0} script file name
        static string ImportScript = @"
<?xml version=""1.0"" encoding=""ISO-8859-1""?>

<simulation program=""PumpLinx"" version=""4.0.3"" customer=""Customer"" date=""Tue Jun 12 13:48:04 2018"">
  
  <import vendor=""Simerics"">
	<surface name=""inlet_inlet"" file=""{0}"" scale=""1""/>
  </import>
  
  <include file=""torque_kongsun.sgrd""/>

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
  </mgi>";

        static string WangGeHuafenScript1 = @"  <build
    operation=""general mesh""
    name=""air_inlet1""
    new_mesh_name=""air_inlet1""
    surfaces=""air_inlet1_inlet air_inlet1_mgi_stator air_inlet1_wall""
    
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
	names_by_size=""off""/>
   <build
    operation=""general mesh""
    name=""air_inlet2""
    new_mesh_name=""air_inlet2""
    surfaces=""air_inlet2_inlet air_inlet2_mgi_stator air_inlet2_wall""
    
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""air_inlet3""
    new_mesh_name=""air_inlet3""
    surfaces=""air_inlet3_inlet air_inlet3_mgi_stator air_inlet3_wall""
    
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""inlet""
    new_mesh_name=""inlet""
    surfaces=""inlet_inlet inlet_mgi_rotor inlet_wall""
    
    maximum_size=""0.01""
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""outlet""
    new_mesh_name=""outlet""
   
    maximum_size=""0.01""
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
    names_by_size=""off"">
    <attribute surfaces=""outlet_mgi_rotor outlet_mgi_rotor_cyl outlet_outlet outlet_outlet_air outlet_wall""/>
  </build>
  <build
    operation=""general mesh""
    name=""rotor""
    new_mesh_name=""rotor""
    
    maximum_size=""0.02""
    minimum_size=""0.001""
    maximum_at_surface=""0.01""
    volume_by_surfs_prefix=""off""
    names_by_size=""off"">
    <attribute surfaces=""rotor_blades rotor_mgi_inlet rotor_mgi_outlet rotor_mgi_outlet_cyl rotor_mgi_stator""/>
  </build>";

        // 动轮 {0} - 最大网格尺度 {1} - 最小网格尺度 {2} - 最大面网格尺度
        static string DongLunForWangGeHuaFen = @"  <build
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
        static string DingLunForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""stator""
    new_mesh_name=""stator""
    surfaces=""stator_mgi_air_inlet stator_mgi_rotor stator_wall""
    
    maximum_size=""{0}""
    minimum_size=""{1}""
    maximum_at_surface=""{2}""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>";

        // {0} - 时间步长 {1} - 动轮转速
        static string DongLunZhuanSu = @"  <module type=""share"" iteration=""{0}"" template_mode=""advanced_mode""/>
  <module type=""flow"" state=""active"" numeric_scheme=""2ndorderupwind upwind""/>
  <module type=""turbulence"" state=""active""/>
  <module
    type=""centrifugal""
    state=""active""
    method=""mrf""
    rotation_direction=""counter_clockwise""
    omega=""{1}""
    rotate_axis_direction=""1 0 0""
    number_blades=""20"">
    <bc patch=""rotor_blades"" type=""rotor""/>
    <bc patch=""outlet_mgi_rotor"" type=""rotate wall""/>
    <bc patch=""outlet_mgi_rotor_cyl"" type=""rotate wall""/>
    <bc patch=""outlet_outlet_air"" type=""outlet""/>
    <bc patch=""air_inlet1_inlet"" type=""inlet""/>
    <bc patch=""air_inlet3_inlet"" type=""inlet""/>
    <bc patch=""air_inlet2_inlet"" type=""inlet""/>
    <vc volume=""air_inlet1"" type=""property"" default=""yes"" pump_material=""air""/>
    <vc volume=""air_inlet2"" type=""property"" default=""yes"" pump_material=""air""/>
    <vc volume=""air_inlet3"" type=""property"" default=""yes"" pump_material=""air""/>
    <vc volume=""inlet"" type=""property"" default=""yes"" pump_material=""air""/>
    <vc volume=""outlet"" type=""property"" default=""yes"" pump_material=""air""/>
    <vc volume=""rotor"" type=""property"" default=""yes"" pump_material=""air""/>
    <vc volume=""stator"" type=""property"" default=""yes"" pump_material=""air""/>
  </module>";

        // {0} - 排气孔 {1} - 通气孔
        static string TongQiKongAndPaiQiKong = @"  <module
    type=""multiphase""
    state=""active""
    components=""oil air""
    courant_number=""0.34""
    adaptive_courant_number=""off""/>
  <module type=""multiflow"" numeric_scheme=""2ndorderupwind upwind"">
    <bc patch=""outlet_outlet_air"" type=""fix_pressure"" value=""{0}""/>
    <bc patch=""air_inlet1_inlet"" type=""fix_totalp"" default=""yes"" totalp=""{1}""/>
    <bc patch=""air_inlet3_inlet"" type=""fix_totalp"" default=""yes"" totalp=""{1}""/>
    <bc patch=""air_inlet2_inlet"" type=""fix_totalp"" default=""yes"" totalp=""{1}""/>
  </module>";

        // {0} -- 粘度 {1} -- 密度
        static string MiDuNianDuOfOil = @"  <module type=""flowphasecomp"" flowphasecomp=""oil"">
    <vc volume=""air_inlet1"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""air_inlet2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""air_inlet3"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""inlet"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""outlet"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""rotor"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""stator"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""air_inlet1"" type=""surface_tension""/>
    <vc volume=""stator"" type=""surface_tension""/>
    <vc volume=""rotor"" type=""surface_tension""/>
    <vc volume=""outlet"" type=""surface_tension""/>
    <vc volume=""inlet"" type=""surface_tension""/>
    <vc volume=""air_inlet3"" type=""surface_tension""/>
    <vc volume=""air_inlet2"" type=""surface_tension""/>
  </module>

  <module type=""sharephasecomp"" sharephasecomp=""oil"">
    <vc volume=""air_inlet1"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""air_inlet2"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""air_inlet3"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""inlet"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""outlet"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""rotor"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""stator"" type=""const_density"" default=""yes"" value=""{1}""/>
  </module>

  <module type=""phasecomp"" phasecomp=""oil"">
    <ic volume=""air_inlet1"" type=""fix_value"" default=""yes"" value=""0.0018""/>
    <ic volume=""air_inlet2"" type=""fix_value"" default=""yes"" value=""0.0018""/>
    <ic volume=""air_inlet3"" type=""fix_value"" default=""yes"" value=""0.0018""/>
    <ic volume=""inlet"" type=""fix_value"" default=""yes"" value=""0.0018""/>
    <ic volume=""outlet"" type=""fix_value"" default=""yes"" value=""0.0018""/>
    <ic volume=""rotor"" type=""fix_value"" default=""yes"" value=""0.0018""/>
    <ic volume=""stator"" type=""fix_value"" default=""yes"" value=""0.0018""/>
  </module>

  <module type=""sharephasecomp"" sharephasecomp=""air"">
    <vc volume=""air_inlet1"" type=""ideal_gas_law""/>
    <vc volume=""stator"" type=""ideal_gas_law""/>
    <vc volume=""rotor"" type=""ideal_gas_law""/>
    <vc volume=""outlet"" type=""ideal_gas_law""/>
    <vc volume=""inlet"" type=""ideal_gas_law""/>
    <vc volume=""air_inlet3"" type=""ideal_gas_law""/>
    <vc volume=""air_inlet2"" type=""ideal_gas_law""/>
  </module>

  <module type=""phasecomp"" phasecomp=""air"">
    <bc patch=""air_inlet1_inlet"" type=""fix_value"" value=""1""/>
    <bc patch=""air_inlet3_inlet"" type=""fix_value"" value=""1""/>
    <bc patch=""air_inlet2_inlet"" type=""fix_value"" value=""1""/>
    <ic volume=""air_inlet1"" type=""fix_value"" default=""yes"" value=""0.9982""/>
    <ic volume=""air_inlet2"" type=""fix_value"" default=""yes"" value=""0.9982""/>
    <ic volume=""air_inlet3"" type=""fix_value"" default=""yes"" value=""0.9982""/>
    <ic volume=""inlet"" type=""fix_value"" default=""yes"" value=""0.9982""/>
    <ic volume=""outlet"" type=""fix_value"" default=""yes"" value=""0.9982""/>
    <ic volume=""rotor"" type=""fix_value"" default=""yes"" value=""0.9982""/>
    <ic volume=""stator"" type=""fix_value"" default=""yes"" value=""0.9982""/>
  </module>
</simulation>";

    }
}
