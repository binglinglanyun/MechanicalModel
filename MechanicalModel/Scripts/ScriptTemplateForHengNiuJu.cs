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

<simulation program=""PumpLinx"" version=""4.0.3"" customer=""Customer"" date=""Tue Jun 12 13:48:04 2018"">";

        public const string ScriptXMLTail = @"
</simulation>";

        // {0} script file name
        public const string ImportScript = @" 
  <import vendor=""Simerics"">
	<surface name=""inlet_inlet"" file=""{0}"" scale=""1""/>
  </import>
  
  <include file=""torque_kongsun.sgrd""/>
  <volume name=""valve2_up""/>
  <volume name=""valve2_bot""/>
  <volume name=""valve1_bot""/>
  <volume name=""valve2_mid""/>
  <volume name=""valve1_mid""/>
  <volume name=""pipe""/>
  <volume name=""inlet""/>
  <volume name=""rotor2""/>
  <volume name=""airout1""/>
  <volume name=""airout2""/>
  <volume name=""airout3""/>
  <volume name=""valve1_bot_pipe""/>
  <volume name=""valve1_up""/>
  <volume name=""valve1_outlet""/>
  <volume name=""valve2_outlet1""/>
  <volume name=""valve2_outlet2""/>
  <volume name=""volute""/>
  <volume name=""valve2_gap4""/>
  <volume name=""valve2_gap3""/>
  <volume name=""valve2_gap2""/>
  <volume name=""valve2_gap1""/>
  <volume name=""valve1_chamber""/>
  <volume name=""valve1_up_gap""/>
  <volume name=""stator""/>
  <volume name=""hub_gap1""/>
  <volume name=""hub_gap2""/>
  <volume name=""hub_gap3""/>
  <volume name=""inlet_gap""/>
  <volume name=""rotor_gap1""/>
  <volume name=""rotor_gap2""/>
  <volume name=""rotor_gap3""/>

  <patch name=""valve2_up_valve"" volume=""valve2_up""/>
  <patch name=""valve2_up_end"" volume=""valve2_up""/>
  <patch name=""valve2_up_cylinder"" volume=""valve2_up""/>
  <patch name=""valve2_bot_end"" volume=""valve2_bot""/>
  <patch name=""valve2_bot_cylinder"" volume=""valve2_bot""/>
  <patch name=""valve2_bot_valve"" volume=""valve2_bot""/>
  <patch name=""valve1_bot_valve"" volume=""valve1_bot""/>
  <patch name=""valve1_bot_cylinder_min"" volume=""valve1_bot""/>
  <patch name=""valve1_bot_end"" volume=""valve1_bot""/>
  <patch name=""valve1_bot_cylinder"" volume=""valve1_bot""/>
  <patch name=""valve2_mid_cylinder_mgi"" volume=""valve2_mid""/>
  <patch name=""valve2_mid_mgi_up"" volume=""valve2_mid""/>
  <patch name=""valve2_mid_valve"" volume=""valve2_mid""/>
  <patch name=""valve1_mid_wall"" volume=""valve1_mid""/>
  <patch name=""valve1_mid_mgi"" volume=""valve1_mid""/>
  <patch name=""pipe_mgi_valve1"" volume=""pipe""/>
  <patch name=""pipe_wall"" volume=""pipe""/>
  <patch name=""pipe_mgi_valve2"" volume=""pipe""/>
  <patch name=""inlet_wall"" volume=""inlet""/>
  <patch name=""inlet_mgi_rotor2"" volume=""inlet""/>
  <patch name=""inlet_inlet"" volume=""inlet""/>
  <patch name=""rotor2_mgi_volute_top"" volume=""rotor2""/>
  <patch name=""rotor2_mgi_volute_side2"" volume=""rotor2""/>
  <patch name=""rotor2_wall"" volume=""rotor2""/>
  <patch name=""rotor2_mgi_volute_side1"" volume=""rotor2""/>
  <patch name=""rotor2_mgi_gap"" volume=""rotor2""/>
  <patch name=""rotor2_mgi_stator"" volume=""rotor2""/>
  <patch name=""rotor2_mgi_inlet"" volume=""rotor2""/>
  <patch name=""airout1_wall"" volume=""airout1""/>
  <patch name=""airout1_mgi_stator"" volume=""airout1""/>
  <patch name=""airout1_outlet"" volume=""airout1""/>
  <patch name=""airout2_mgi_stator"" volume=""airout2""/>
  <patch name=""airout2_wall"" volume=""airout2""/>
  <patch name=""airout2_outlet"" volume=""airout2""/>
  <patch name=""airout3_wall"" volume=""airout3""/>
  <patch name=""airout3_mgi_stator"" volume=""airout3""/>
  <patch name=""airout3_outlet"" volume=""airout3""/>
  <patch name=""valve1_bot_pipe_outlet"" volume=""valve1_bot_pipe""/>
  <patch name=""valve1_bot_pipe_mgi_valve1_bot"" volume=""valve1_bot_pipe""/>
  <patch name=""valve1_bot_pipe_cylinder"" volume=""valve1_bot_pipe""/>
  <patch name=""valve1_up_cylinder"" volume=""valve1_up""/>
  <patch name=""valve1_up_valve"" volume=""valve1_up""/>
  <patch name=""valve1_up_end"" volume=""valve1_up""/>
  <patch name=""valve1_up_end_mgi_volute"" volume=""valve1_up""/>
  <patch name=""valve1_outlet_outlet1"" volume=""valve1_outlet""/>
  <patch name=""valve1_outlet_wall"" volume=""valve1_outlet""/>
  <patch name=""valve1_outlet_mgi_mdi_up"" volume=""valve1_outlet""/>
  <patch name=""valve1_outlet_outlet2"" volume=""valve1_outlet""/>
  <patch name=""valve2_outlet1_wall"" volume=""valve2_outlet1""/>
  <patch name=""valve2_outlet1_mgi_gap3"" volume=""valve2_outlet1""/>
  <patch name=""valve2_outlet1_outlet"" volume=""valve2_outlet1""/>
  <patch name=""valve2_outlet2_wall"" volume=""valve2_outlet2""/>
  <patch name=""valve2_outlet2_mgi_gap4"" volume=""valve2_outlet2""/>
  <patch name=""valve2_outlet2_outlet"" volume=""valve2_outlet2""/>
  <patch name=""volute_wall"" volume=""volute""/>
  <patch name=""volute_side_mgi_rotor2"" volume=""volute""/>
  <patch name=""volute_top_mgi_rotor2"" volume=""volute""/>
  <patch name=""volute_wall_mgi_gap"" volume=""volute""/>
  <patch name=""volute_side_mgi_rotor1"" volume=""volute""/>
  <patch name=""volute_kongsun_inlet"" volume=""volute""/>
  <patch name=""volute_mgi_valve"" volume=""volute""/>
  <patch name=""valve2_gap4_wall1"" volume=""valve2_gap4""/>
  <patch name=""valve2_gap4_mgi_bot"" volume=""valve2_gap4""/>
  <patch name=""valve2_gap4_wall2"" volume=""valve2_gap4""/>
  <patch name=""valve2_gap4_mgi_outlet2"" volume=""valve2_gap4""/>
  <patch name=""valve2_gap3_wall1"" volume=""valve2_gap3""/>
  <patch name=""valve2_gap3_mgi_mid"" volume=""valve2_gap3""/>
  <patch name=""valve2_gap3_wall2"" volume=""valve2_gap3""/>
  <patch name=""valve2_gap3_mgi_outlet1"" volume=""valve2_gap3""/>
  <patch name=""valve2_gap2_mgi_gap1"" volume=""valve2_gap2""/>
  <patch name=""valve2_gap2_mgi_mid"" volume=""valve2_gap2""/>
  <patch name=""valve2_gap2_wall"" volume=""valve2_gap2""/>
  <patch name=""valve2_gap2_cylinder_wall"" volume=""valve2_gap2""/>
  <patch name=""valve2_gap1_wall1"" volume=""valve2_gap1""/>
  <patch name=""valve2_gap1_mgi_up"" volume=""valve2_gap1""/>
  <patch name=""valve2_gap1_mgi_gap2"" volume=""valve2_gap1""/>
  <patch name=""valve2_gap1_cylinder_wall"" volume=""valve2_gap1""/>
  <patch name=""valve1_chamber_wall1"" volume=""valve1_chamber""/>
  <patch name=""valve1_chamber_mgi_bot"" volume=""valve1_chamber""/>
  <patch name=""valve1_chamber_wall2"" volume=""valve1_chamber""/>
  <patch name=""valve1_up_gap_valve"" volume=""valve1_up_gap""/>
  <patch name=""valve1_up_gap_cylinder_out"" volume=""valve1_up_gap""/>
  <patch name=""valve1_up_gap_cylinder_in"" volume=""valve1_up_gap""/>
  <patch name=""valve1_up_gap_end"" volume=""valve1_up_gap""/>
  <patch name=""stator_wall"" volume=""stator""/>
  <patch name=""stator_mgi_rotor2"" volume=""stator""/>
  <patch name=""stator_mgi_airoutlet1"" volume=""stator""/>
  <patch name=""stator_mgi_airoutlet2"" volume=""stator""/>
  <patch name=""stator_mgi_airoutlet3"" volume=""stator""/>
  <patch name=""hub_gap1_up"" volume=""hub_gap1""/>
  <patch name=""hub_gap1_cylinder_min"" volume=""hub_gap1""/>
  <patch name=""hub_gap1_bot"" volume=""hub_gap1""/>
  <patch name=""hub_gap1_cylinder_out"" volume=""hub_gap1""/>
  <patch name=""hub_gap2_bot"" volume=""hub_gap2""/>
  <patch name=""hub_gap2_cylinder_min"" volume=""hub_gap2""/>
  <patch name=""hub_gap2_up"" volume=""hub_gap2""/>
  <patch name=""hub_gap2_cylinder_out"" volume=""hub_gap2""/>
  <patch name=""hub_gap3_bot"" volume=""hub_gap3""/>
  <patch name=""hub_gap3_cylinder_min"" volume=""hub_gap3""/>
  <patch name=""hub_gap3_up"" volume=""hub_gap3""/>
  <patch name=""hub_gap3_cylinder_out"" volume=""hub_gap3""/>
  <patch name=""inlet_gap_up"" volume=""inlet_gap""/>
  <patch name=""inlet_gap_cylinder_min"" volume=""inlet_gap""/>
  <patch name=""inlet_gap_bot"" volume=""inlet_gap""/>
  <patch name=""inlet_gap_cylinder_out"" volume=""inlet_gap""/>
  <patch name=""rotor_gap1_top"" volume=""rotor_gap1""/>
  <patch name=""rotor_gap1_cylinder_min"" volume=""rotor_gap1""/>
  <patch name=""rotor_gap1_bot"" volume=""rotor_gap1""/>
  <patch name=""rotor_gap1_cylinder_out"" volume=""rotor_gap1""/>
  <patch name=""rotor_gap2_bot"" volume=""rotor_gap2""/>
  <patch name=""rotor_gap2_cylinder_min"" volume=""rotor_gap2""/>
  <patch name=""rotor_gap2_top"" volume=""rotor_gap2""/>
  <patch name=""rotor_gap2_cylinder_out"" volume=""rotor_gap2""/>
  <patch name=""rotor_gap3_top"" volume=""rotor_gap3""/>
  <patch name=""rotor_gap3_cylinder_min"" volume=""rotor_gap3""/>
  <patch name=""rotor_gap3_bot"" volume=""rotor_gap3""/>
  <patch name=""rotor_gap3_cylinder_out"" volume=""rotor_gap3""/>

  <mgi name=""MGI01"">
    <patch name=""valve2_outlet2_mgi_gap4""/>
    <patch name=""valve2_gap4_mgi_outlet2""/>
  </mgi>

  <mgi name=""MGI02"">
    <patch name=""valve2_bot_cylinder""/>
    <patch name=""valve2_gap4_mgi_bot""/>
  </mgi>

  <mgi name=""MGI03"">
    <patch name=""valve2_gap3_mgi_outlet1""/>
    <patch name=""valve2_outlet1_mgi_gap3""/>
  </mgi>

  <mgi name=""MGI04"">
    <patch name=""valve2_gap3_mgi_mid""/>
    <patch name=""valve2_mid_cylinder_mgi""/>
    <patch name=""valve2_gap2_mgi_mid""/>
  </mgi>

  <mgi name=""MGI05"">
    <patch name=""valve2_gap2_mgi_gap1""/>
    <patch name=""valve2_gap1_mgi_gap2""/>
  </mgi>

  <mgi name=""MGI06"">
    <patch name=""valve2_mid_mgi_up""/>
    <patch name=""valve2_up_valve""/>
  </mgi>

  <mgi name=""MGI07"">
    <patch name=""valve2_gap1_mgi_up""/>
    <patch name=""valve2_up_cylinder""/>
  </mgi>

  <mgi name=""MGI08"">
    <patch name=""valve2_up_end""/>
    <patch name=""pipe_mgi_valve2""/>
  </mgi>

  <mgi name=""MGI09"">
    <patch name=""valve1_bot_end""/>
    <patch name=""valve1_bot_pipe_mgi_valve1_bot""/>
    <patch name=""pipe_mgi_valve1""/>
  </mgi>

  <mgi name=""MGI10"">
    <patch name=""valve1_outlet_mgi_mdi_up""/>
    <patch name=""valve1_mid_mgi""/>
    <patch name=""valve1_up_gap_cylinder_out""/>
  </mgi>

  <mgi name=""MGI11"">
    <patch name=""airout1_mgi_stator""/>
    <patch name=""stator_mgi_airoutlet1""/>
  </mgi>

  <mgi name=""MGI12"">
    <patch name=""airout2_mgi_stator""/>
    <patch name=""stator_mgi_airoutlet2""/>
  </mgi>

  <mgi name=""MGI13"">
    <patch name=""airout3_mgi_stator""/>
    <patch name=""stator_mgi_airoutlet3""/>
  </mgi>

  <mgi name=""MGI14"">
    <patch name=""rotor2_mgi_stator""/>
    <patch name=""stator_mgi_rotor2""/>
  </mgi>

  <mgi name=""MGI15"">
    <patch name=""inlet_mgi_rotor2""/>
    <patch name=""rotor2_mgi_inlet""/>
    <patch name=""inlet_gap_bot""/>
  </mgi>

  <mgi name=""MGI16"" tolerance=""0.0319691692590995"">
    <patch name=""volute_side_mgi_rotor2""/>
    <patch name=""rotor2_mgi_volute_side2""/>
  </mgi>

  <mgi name=""MGI17"" tolerance=""0.0319691692590995"">
    <patch name=""rotor2_mgi_volute_top""/>
    <patch name=""volute_top_mgi_rotor2""/>
  </mgi>

  <mgi name=""MGI18"">
    <patch name=""valve1_up_end_mgi_volute""/>
    <patch name=""volute_mgi_valve""/>
  </mgi>

  <mgi name=""MGI19"">
    <patch name=""valve1_chamber_mgi_bot""/>
    <patch name=""valve1_bot_valve""/>
  </mgi>

  <mgi name=""MGI20"">
    <patch name=""valve1_up_gap_cylinder_in""/>
    <patch name=""valve1_up_cylinder""/>
  </mgi>

  <mgi name=""MGI21"">
    <patch name=""hub_gap1_bot""/>
    <patch name=""hub_gap2_up""/>
  </mgi>

  <mgi name=""MGI22"">
    <patch name=""rotor2_mgi_gap""/>
    <patch name=""hub_gap1_up""/>
  </mgi>

  <mgi name=""MGI23"">
    <patch name=""hub_gap2_cylinder_min""/>
    <patch name=""hub_gap3_cylinder_out""/>
  </mgi>

  <mgi name=""MGI24"">
    <patch name=""rotor2_mgi_volute_side1""/>
    <patch name=""volute_side_mgi_rotor1""/>
  </mgi>

  <mgi name=""MGI25"">
    <patch name=""rotor_gap1_bot""/>
    <patch name=""volute_wall_mgi_gap""/>
  </mgi>

  <mgi name=""MGI26"">
    <patch name=""rotor_gap1_top""/>
    <patch name=""rotor_gap2_bot""/>
  </mgi>

  <mgi name=""MGI27"">
    <patch name=""rotor_gap3_cylinder_out""/>
    <patch name=""rotor_gap2_cylinder_min""/>
  </mgi>";

        public static string WangGeHuafenConstScript = @"<build
    operation=""template mesh""
    name=""valve_up""
    new_mesh_name=""valve_up""
    grid_type=""cylinder""
    reference_point=""-0.0355 0.2380405 0.3815352""
    first_point=""-0.0355 0.232439 0.3836855""
    radius=""0.006""
    number_cell_i=""20""
    number_cell_j=""15""/>
  <build
    operation=""build valve""
    name=""valve_bot""
    new_mesh_name=""valve_bot""
    spool_valve_surfaces=""valve2_bot_valve""
    spool_cylinder_surfaces=""valve2_bot_cylinder""
    spool_end_surfaces=""valve2_bot_end""
    spool_move_direction=""0 -0.0056015 0.0021503""
    spool_minimum_gap=""0.0001""
    spool_maximum_displacement=""0.1""
    spool_maximum_cell_size=""0.02""
    spool_maximum_boundary_cell=""0.02""/>
  <build
    operation=""template mesh""
    name=""valve1_bot""
    new_mesh_name=""valve1_bot""
    grid_type=""annulus""
    reference_point=""-0.0515 0.1235473 0.3218518""
    first_point=""-0.0515 0.1254287 0.3267531""
    pie_angle=""360""
    annulus_inner_radius=""0.0095""
    annulus_outer_radius=""0.0275""
    number_cell_i=""10""
    number_cell_j=""15""/>
  <build
    operation=""template mesh""
    name=""valve1_bot_pipe""
    new_mesh_name=""valve1_bot_pipe""
    grid_type=""cylinder""
    reference_point=""-0.0315 0.149283 0.3540152""
    first_point=""-0.0315 0.1370985 0.3222735""
    radius=""0.0015""
    number_cell_j=""3""
    number_cell_k=""12""/>
	<build
    operation=""template mesh""
    name=""valve2_gap4""
    new_mesh_name=""valve2_gap4""
    grid_type=""annulus""
    reference_point=""-0.0355 0.2921882 0.3607499""
    first_point=""-0.0355 0.2987233 0.3582413""
    pie_angle=""360""
    annulus_inner_radius=""0.006""
    annulus_outer_radius=""0.007""/>
  <build
    operation=""template mesh""
    name=""valve2_gap3""
    new_mesh_name=""valve2_gap3""
    grid_type=""annulus""
    reference_point=""-0.0355 0.2483099 0.3775932""
    first_point=""-0.0355 0.2557786 0.3747263""
    pie_angle=""360""
    annulus_inner_radius=""0.006""
    annulus_outer_radius=""0.008""/>
  <build
    operation=""template mesh""
    name=""valve2_gap2""
    new_mesh_name=""valve2_gap2""
    grid_type=""annulus""
    reference_point=""-0.0355 0.2380405 0.3815352""
    first_point=""-0.0355 0.2455092 0.3786683""
    pie_angle=""360""
    annulus_inner_radius=""0.006""
    annulus_outer_radius=""0.008""/>
  <build
    operation=""template mesh""
    name=""valve2_gap1""
    new_mesh_name=""valve2_gap1""
    grid_type=""annulus""
    reference_point=""-0.0355 0.2240368 0.3869108""
    first_point=""-0.0355 0.2380405 0.3815352""
    pie_angle=""360""
    annulus_inner_radius=""0.006""
    annulus_outer_radius=""0.008""
    number_cell_i=""15""/>
  <build
    operation=""build valve""
    name=""valve1_up""
    new_mesh_name=""valve1_up""
    spool_valve_surfaces=""valve1_up_valve""
    spool_cylinder_surfaces=""valve1_up_cylinder""
    spool_end_surfaces=""valve1_up_end valve1_up_end_mgi""
    spool_move_direction=""0 -0.0021502 -0.0056014""
    spool_minimum_gap=""0.0001""
    spool_maximum_displacement=""0.1""
    spool_maximum_cell_size=""0.02""
    spool_maximum_boundary_cell=""0.02""
    spool_layers_valve_to_seat=""10""/>
	<build
    operation=""build valve""
    name=""valve1_up_gap""
    new_mesh_name=""valve1_up_gap""
    spool_valve_surfaces=""valve1_up_gap_valve""
    spool_cylinder_surfaces=""valve1_up_gap_cylinder_in valve1_up_gap_cylinder_out""
    spool_end_surfaces=""valve1_up_gap_end""
    spool_move_direction=""0 -0.0021502 -0.0056014""
    spool_minimum_gap=""0.0001""
    spool_maximum_displacement=""0.1""
    spool_maximum_cell_size=""0.02""
    spool_maximum_boundary_cell=""0.02""
    spool_layers_valve_to_seat=""10""/>
  <build
    operation=""template mesh""
    name=""hub_gap1""
    new_mesh_name=""hub_gap1""
    grid_type=""annulus""
    reference_point=""-0.002 0 0""
    first_point=""-0.0107 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.0987""
    annulus_outer_radius=""0.099""
    number_cell_i=""6""
    number_cell_j=""3""/>
  <build
    operation=""template mesh""
    name=""hub_gap2""
    new_mesh_name=""hub_gap2""
    grid_type=""annulus""
    reference_point=""-0.017 0 0""
    first_point=""-0.0107 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.0563""
    annulus_outer_radius=""0.099""
    number_cell_i=""6""
    number_cell_j=""40""/>
  <build
    operation=""template mesh""
    name=""hub_gap3""
    new_mesh_name=""hub_gap3""
    grid_type=""annulus""
    reference_point=""-0.017 0 0""
    first_point=""-0.0012 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.0563""
    annulus_outer_radius=""0.0566""
    number_cell_i=""6""
    number_cell_j=""3""/>
  <build
    operation=""template mesh""
    name=""inlet_gap""
    new_mesh_name=""inlet_gap""
    grid_type=""annulus""
    reference_point=""-0.0447 0 0""
    first_point=""-0.0572 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.07779999999999999""
    annulus_outer_radius=""0.0781""
    number_cell_i=""6""
    number_cell_j=""3""/>
  <build
    operation=""template mesh""
    name=""rotor_gap1""
    new_mesh_name=""rotor_gap1""
    grid_type=""annulus""
    reference_point=""-0.0132 0 0""
    first_point=""-0.015 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.1935""
    annulus_outer_radius=""0.194""
    number_cell_i=""6""
    number_cell_j=""5""/>
  <build
    operation=""template mesh""
    name=""rotor_gap2""
    new_mesh_name=""rotor_gap2""
    grid_type=""annulus""
    reference_point=""-0.0132 0 0""
    first_point=""-0.011 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.19225""
    annulus_outer_radius=""0.194""
    number_cell_i=""8""
    number_cell_j=""10""/>
  <build
    operation=""template mesh""
    name=""rotor_gap3""
    new_mesh_name=""rotor_gap3""
    grid_type=""annulus""
    reference_point=""-0.0132 0 0""
    first_point=""-0.002 0 0""
    pie_angle=""360""
    annulus_inner_radius=""0.19175""
    annulus_outer_radius=""0.19225""
    number_cell_i=""8""
    number_cell_j=""5""/>
  <build
    operation=""general mesh""
    name=""valve1_outlet""
    new_mesh_name=""valve1_outlet""
    maximum_size=""0.008""
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
    names_by_size=""off"">
    <attribute surfaces=""valve1_outlet_mgi_mdi_up valve1_outlet_outlet1 valve1_outlet_outlet2 valve1_outlet_wall""/>
  </build>
  <build
    operation=""general mesh""
    name=""valve2_outlet1""
    new_mesh_name=""valve2_outlet1""
    surfaces=""valve2_outlet1_mgi_gap3 valve2_outlet1_outlet valve2_outlet1_wall""
    maximum_size=""0.04""
    minimum_size=""0.001""
    maximum_at_surface=""0.02""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""valve2_outlet2""
    new_mesh_name=""valve2_outlet2""
    surfaces=""valve2_outlet2_mgi_gap4 valve2_outlet2_outlet valve2_outlet2_wall""
    maximum_size=""0.02""
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""volute""
    new_mesh_name=""volute""
    maximum_size=""0.006""
    minimum_size=""0.001"">
    <attribute surfaces=""volute_kongsun_inlet volute_mgi_valve volute_side_mgi_rotor1 volute_side_mgi_rotor2 volute_top_mgi_rotor2 volute_wall volute_wall_mgi_gap""/>
    <surface name=""volute_side_mgi_rotor1"" bc_cell_size_opt=""custom_size"" cell_size=""0.002""/>
  </build>
  <build
    operation=""general mesh""
    name=""valve2_mid""
    new_mesh_name=""valve2_mid""
    surfaces=""valve2_mid_cylinder_mgi valve2_mid_mgi_up valve2_mid_valve""
    maximum_size=""0.02""
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""valve1_mid""
    new_mesh_name=""valve1_mid""
    surfaces=""valve1_mid_mgi valve1_mid_wall""
    maximum_size=""0.02""
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""pipe""
    new_mesh_name=""pipe""
    surfaces=""pipe_mgi_valve1 pipe_mgi_valve2 pipe_wall""
    maximum_size=""0.006""
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""inlet""
    new_mesh_name=""inlet""
    surfaces=""inlet_inlet inlet_mgi_rotor2 inlet_wall""
    maximum_size=""0.006""
    minimum_size=""0.001""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""airout1""
    new_mesh_name=""airout1""
    surfaces=""airout1_inlet airout1_mgi_stator airout1_wall""
    maximum_size=""0.04""
    minimum_size=""0.001""
    maximum_at_surface=""0.02""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""airout2""
    new_mesh_name=""airout2""
    surfaces=""airout2_inlet airout2_mgi_stator airout2_wall""
    maximum_size=""0.04""
    minimum_size=""0.001""
    maximum_at_surface=""0.02""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""airout3""
    new_mesh_name=""airout3""
    surfaces=""airout3_inlet airout3_mgi_stator airout3_wall""
    maximum_size=""0.04""
    minimum_size=""0.001""
    maximum_at_surface=""0.02""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>
  <build
    operation=""general mesh""
    name=""valve1_chamber""
    new_mesh_name=""valve1_chamber""
    surfaces=""valve1_chamber_mgi_bot valve1_chamber_wall1 valve1_chamber_wall2""
    maximum_size=""0.02""
    volume_by_surfs_prefix=""off""
    names_by_size=""off""/>";

        // 动轮 {0} - 最大网格尺度 {1} - 最小网格尺度 
        public static string DongLunForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""rotor2""
    new_mesh_name=""rotor2""
    maximum_size=""{0}""
    minimum_size=""{1}""
    volume_by_surfs_prefix=""off""
    names_by_size=""off"">
    <attribute surfaces=""rotor2_mgi_gap rotor2_mgi_inlet rotor2_mgi_stator rotor2_mgi_volute_side1 rotor2_mgi_volute_side2 rotor2_mgi_volute_top rotor2_wall""/>
    <surface name=""rotor2_mgi_volute_side1"" bc_cell_size_opt=""custom_size"" cell_size=""0.002""
      bc_min_cell_size=""default_size""/>
  </build>";

        // 定轮 {0} - 最大网格尺度 {1} - 最小网格尺度 
        public static string DingLunForWangGeHuaFen = @"  <build
    operation=""general mesh""
    name=""stator""
    new_mesh_name=""stator""
    maximum_size=""{0}""
    minimum_size=""{1}"">
    <attribute surfaces=""stator_mgi_airoutlet1 stator_mgi_airoutlet2 stator_mgi_airoutlet3 stator_mgi_rotor2 stator_wall""/>
    <surface name=""stator_mgi_airoutlet1"" bc_cell_size_opt=""custom_size"" cell_size=""0.002""/>
    <surface name=""stator_mgi_airoutlet2"" bc_cell_size_opt=""custom_size"" cell_size=""0.002""/>
    <surface name=""stator_mgi_airoutlet3"" bc_cell_size_opt=""custom_size"" cell_size=""0.002""/>
  </build>";

        // {0} -- X {1} -- Y {2} -- Z  TODO: Add more probe point
        public static string JianKongDianCanShu = @"  <probe_point name=""Point 01"" position=""{0} {1} {2}""/>
  <probe_point name=""Point 02"" position=""-0.0515 0.1267599729704603 0.2562916443662048""/>
  <probe_point name=""Point 03"" position=""-0.051 0.1024932 0.267004""/>
  <probe_point name=""Point 04"" position=""-0.051 0.1024932 0.267004""/>
  <probe_point
    name=""Point 05""
    type=""stationary""
    position=""-0.051 0.1363857359439135 0.3210142738372088"">
    <output module=""flow"" derived=""on""/>
  </probe_point>
  <probe_point name=""Point 06"" position=""-0.03980238649763423 0.09385995490348284 0.2433976844376425""/>";

        // {0} -- 迭代步数 {1} -- 保存频率
        public static string JiSuanKongZhiCanShu = @"  <module type=""share"" iteration=""0{}"" save_result_interval=""{1}"" template_mode=""advanced_mode"">
    <vc volume=""inlet"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""rotor2"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""volute"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""hub_gap1"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""hub_gap2"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""hub_gap3"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""inlet_gap"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""rotor_gap1"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""rotor_gap2"" type=""output_var"" default=""yes"" print_volume=""on""/>
    <vc volume=""rotor_gap3"" type=""output_var"" default=""yes"" print_volume=""on""/>
  </module>";

        public static string JiSuanCanShuConstScript = @"  <module
    type=""spool""
    spool=""1""
    state=""active""
    dynamics=""trans_1d 1""
    minimum_gap=""0.0001""
    maximum_displacement=""0.1""
    closure_model=""radial""
    closure_radius=""0.0265""
    closure_center=""-0.0515 0.1024932 0.267004"">
    <bc patch=""valve1_bot_cylinder"" type=""cylinder_wall""/>
    <bc patch=""valve1_bot_cylinder_min"" type=""cylinder_wall""/>
    <bc patch=""valve1_bot_end"" type=""valve_end""/>
    <bc patch=""valve1_bot_valve"" type=""valve_wall""/>
    <bc patch=""valve1_chamber_wall1"" type=""valve_wall""/>
    <bc patch=""valve1_chamber_wall2"" type=""valve_wall""/>
    <bc patch=""valve1_mid_wall"" type=""valve_wall""/>
    <bc patch=""valve1_up_cylinder"" type=""cylinder_wall""/>
    <bc patch=""valve1_up_end"" type=""valve_end""/>
    <bc patch=""valve1_up_end_mgi_volute"" type=""valve_end""/>
    <bc patch=""valve1_up_valve"" type=""valve_wall""/>
    <bc patch=""valve1_up_gap_cylinder_in"" type=""cylinder_wall""/>
    <bc patch=""valve1_up_gap_cylinder_out"" type=""cylinder_wall""/>
    <bc patch=""valve1_up_gap_end"" type=""valve_end""/>
    <bc patch=""valve1_up_gap_valve"" type=""valve_wall""/>
    <bc patch=""valve2_outlet1_outlet"" type=""outlet""/>
    <bc patch=""valve1_outlet_outlet1"" type=""outlet""/>
    <bc patch=""valve1_outlet_outlet2"" type=""outlet""/>
    <bc patch=""valve2_outlet2_outlet"" type=""inlet""/>
    <bc patch=""inlet_inlet"" type=""inlet""/>
    <bc patch=""airout1_outlet"" type=""outlet""/>
    <bc patch=""airout3_outlet"" type=""outlet""/>
    <bc patch=""airout2_outlet"" type=""outlet""/>
    <bc patch=""inlet_gap_up"" type=""outlet""/>
    <bc patch=""hub_gap3_up"" type=""outlet""/>
    <vc volume=""valve2_up"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_bot"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_bot"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_mid"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_mid"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""pipe"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""inlet"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""rotor2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""airout1"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""airout2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""airout3"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_bot_pipe"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_up"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_outlet"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_outlet1"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_outlet2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""volute"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_gap4"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_gap3"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_gap2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_gap1"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_chamber"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_up_gap"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""stator"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""hub_gap1"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""hub_gap2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""hub_gap3"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""inlet_gap"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""rotor_gap1"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""rotor_gap2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""rotor_gap3"" type=""property"" default=""yes"" valve_material=""oil""/>
  </module>

  <module
    type=""spool""
    spool=""2""
    state=""active""
    dynamics=""trans_1d 2""
    minimum_gap=""0.0001""
    maximum_displacement=""0.1"">
    <bc patch=""valve2_bot_cylinder"" type=""cylinder_wall""/>
    <bc patch=""valve2_bot_end"" type=""valve_end""/>
    <bc patch=""valve2_bot_valve"" type=""valve_wall""/>
    <bc patch=""valve2_mid_valve"" type=""valve_wall""/>
    <bc patch=""valve2_up_cylinder"" type=""cylinder_wall""/>
    <bc patch=""valve2_up_end"" type=""valve_end""/>
    <bc patch=""valve2_up_valve"" type=""valve_wall""/>
    <bc patch=""valve2_outlet1_outlet"" type=""outlet""/>
    <bc patch=""valve1_outlet_outlet1"" type=""outlet""/>
    <bc patch=""valve1_outlet_outlet2"" type=""outlet""/>
    <bc patch=""valve2_outlet2_outlet"" type=""inlet""/>
    <bc patch=""inlet_inlet"" type=""inlet""/>
    <bc patch=""airout1_outlet"" type=""outlet""/>
    <bc patch=""airout3_outlet"" type=""outlet""/>
    <bc patch=""airout2_outlet"" type=""outlet""/>
    <bc patch=""inlet_gap_up"" type=""outlet""/>
    <bc patch=""hub_gap3_up"" type=""outlet""/>
    <vc volume=""valve2_up"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_bot"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_bot"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_mid"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_mid"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""pipe"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""inlet"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""rotor2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""airout1"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""airout2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""airout3"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_bot_pipe"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_up"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_outlet"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_outlet1"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_outlet2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""volute"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_gap4"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_gap3"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_gap2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve2_gap1"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_chamber"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""valve1_up_gap"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""stator"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""hub_gap1"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""hub_gap2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""hub_gap3"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""inlet_gap"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""rotor_gap1"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""rotor_gap2"" type=""property"" default=""yes"" valve_material=""oil""/>
    <vc volume=""rotor_gap3"" type=""property"" default=""yes"" valve_material=""oil""/>
  </module>

  <module
    type=""trans_1d""
    trans_1d=""1""
    state=""active""
    body_motion=""coupled""
    move_direction=""0 0.0021502 0.0056014""
    body_mass=""0.55""
    spring_constant=""12800""
    preload=""156""/>
  <module
    type=""trans_1d""
    trans_1d=""2""
    state=""active""
    body_motion=""coupled""
    move_direction=""0 -0.0056015 0.0021503""
    body_mass=""0.01""/>
  <module
    type=""rotate_1d""
    state=""active""
    rotate_direction=""1 0 0""
    rotation_direction=""counter_clockwise""
    initial_omega=""376.99112""
    moment_of_inertia=""150"">
    <bc patch=""rotor2_wall"" type=""dynamicsBC""/>
  </module>

  <module
    type=""multiphase""
    state=""active""
    components=""oil air""
    courant_number=""1""
    max_courant_number=""10""
    adaptive_courant_number=""off""/>";

        // {0} -- 滑阀回油出口 {1} -- 背压阀出口 {2} -- 指令油入口 {3} -- 反馈压力入口
        public static string BianJieTiaoJianDingYi = @"  <module
    type=""multiflow""
    numeric_scheme=""2ndorderupwind upwind""
    gravity=""on""
    g=""0 9.800000000000001 0""
    maximum_v_magnitude=""2000"">
    <bc patch=""valve1_outlet_outlet1"" type=""fix_pressure""/>
    <bc patch=""valve1_outlet_outlet2"" type=""fix_pressure""/>
    <bc patch=""valve2_outlet1_outlet"" type=""fix_pressure"" value=""{0}""/>
    <bc patch=""valve1_bot_pipe_outlet"" type=""fix_pressure"" value=""{1}""/>
    <bc patch=""valve1_bot_valve"" type=""wall"" default=""yes"" print_average_total_pres=""on""
      print_mass_total_pressure=""on"" print_average_pres=""on"" output=""user_select""/>

    <bc patch=""valve1_mid_wall"" type=""wall"" default=""yes"" print_average_total_pres=""on""
      print_mass_total_pressure=""on"" print_average_pres=""on"" output=""user_select""/>

    <bc patch=""valve1_up_valve"" type=""wall"" default=""yes"" print_average_total_pres=""on""
      print_mass_total_pressure=""on"" print_average_pres=""on"" output=""user_select""/>

    <bc patch=""valve1_chamber_wall1"" type=""wall"" default=""yes"" print_average_total_pres=""on""
      print_mass_total_pressure=""on"" print_average_pres=""on"" output=""user_select""/>

    <bc patch=""valve1_chamber_wall2"" type=""wall"" default=""yes"" print_average_total_pres=""on""
      print_mass_total_pressure=""on"" print_average_pres=""on"" output=""user_select""/>

    <bc patch=""valve2_outlet2_outlet"" type=""fix_pressure_inlet"" value=""{2} Pa""/>
    <bc patch=""inlet_inlet"" type=""fix_pressure_inlet"" value=""{3}""/>
    <bc patch=""hub_gap3_cylinder_min"" type=""rotate_wall"" omega=""Vcen rpm""/>
    <bc patch=""hub_gap2_cylinder_out"" type=""rotate_wall"" omega=""Vcen rpm""/>
    <bc patch=""hub_gap1_cylinder_out"" type=""rotate_wall"" omega=""Vcen rpm""/>
    <bc patch=""hub_gap2_bot"" type=""rotate_wall"" omega=""Vcen rpm""/>
    <bc patch=""inlet_gap_cylinder_out"" type=""rotate_wall"" omega=""Vcen rpm""/>
    <bc patch=""rotor_gap1_cylinder_min"" type=""rotate_wall"" omega=""Vcen rpm""/>
    <bc patch=""rotor_gap3_cylinder_min"" type=""rotate_wall"" omega=""Vcen rpm""/>
    <bc patch=""rotor_gap2_bot"" type=""rotate_wall"" omega=""Vcen rpm""/>
    <bc patch=""airout1_outlet"" type=""fix_pressure""/>
    <bc patch=""airout3_outlet"" type=""fix_pressure""/>
    <bc patch=""airout2_outlet"" type=""fix_pressure""/>
    <bc patch=""inlet_gap_up"" type=""fix_pressure""/>
    <bc patch=""hub_gap3_up"" type=""fix_pressure""/>
    <ic volume=""valve1_bot"" type=""fix_value"" default=""yes"" pressure=""101325""/>
    <ic volume=""pipe"" type=""fix_value"" default=""yes"" pressure=""101325""/>
    <ic volume=""valve1_bot_pipe"" type=""fix_value"" default=""yes"" pressure=""101325""/>
    <ic volume=""valve2_outlet2"" type=""fix_value"" default=""yes"" pressure=""500000""/>
    <ic volume=""valve1_chamber"" type=""fix_value"" default=""yes"" pressure=""101325""/>
    <ic volume=""valve2_up"" type=""fix_value"" default=""yes"" pressure=""101325""/>
    <ic volume=""valve2_mid"" type=""fix_value"" default=""yes"" pressure=""101325""/>
    <ic volume=""valve2_outlet1"" type=""fix_value"" default=""yes"" pressure=""101325""/>
    <ic volume=""valve2_gap3"" type=""fix_value"" default=""yes"" pressure=""101325""/>
    <ic volume=""valve2_gap2"" type=""fix_value"" default=""yes"" pressure=""101325""/>
    <ic volume=""valve2_gap1"" type=""fix_value"" default=""yes"" pressure=""101325""/>
  </module>";

        // {0} -- 粘度 {1} -- 密度
        public static string WuZhiDingYi = @"  <module type=""flowphasecomp"" flowphasecomp=""oil"">
    <vc volume=""valve2_up"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve2_bot"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve1_bot"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve2_mid"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve1_mid"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""pipe"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""inlet"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""rotor2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""airout1"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""airout2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""airout3"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve1_bot_pipe"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve1_up"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve1_outlet"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve2_outlet1"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve2_outlet2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""volute"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve2_gap4"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve2_gap3"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve2_gap2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve2_gap1"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve1_chamber"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""valve1_up_gap"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""airout1"" type=""surface_tension""/>
    <vc volume=""volute"" type=""surface_tension""/>
    <vc volume=""valve2_up"" type=""surface_tension""/>
    <vc volume=""valve2_outlet2"" type=""surface_tension""/>
    <vc volume=""valve2_outlet1"" type=""surface_tension""/>
    <vc volume=""valve2_mid"" type=""surface_tension""/>
    <vc volume=""valve2_gap4"" type=""surface_tension""/>
    <vc volume=""valve2_gap3"" type=""surface_tension""/>
    <vc volume=""valve2_gap2"" type=""surface_tension""/>
    <vc volume=""valve2_gap1"" type=""surface_tension""/>
    <vc volume=""valve2_bot"" type=""surface_tension""/>
    <vc volume=""valve1_up_gap"" type=""surface_tension""/>
    <vc volume=""valve1_up"" type=""surface_tension""/>
    <vc volume=""valve1_outlet"" type=""surface_tension""/>
    <vc volume=""valve1_mid"" type=""surface_tension""/>
    <vc volume=""valve1_chamber"" type=""surface_tension""/>
    <vc volume=""valve1_bot_pipe"" type=""surface_tension""/>
    <vc volume=""valve1_bot"" type=""surface_tension""/>
    <vc volume=""rotor2"" type=""surface_tension""/>
    <vc volume=""pipe"" type=""surface_tension""/>
    <vc volume=""inlet"" type=""surface_tension""/>
    <vc volume=""airout3"" type=""surface_tension""/>
    <vc volume=""airout2"" type=""surface_tension""/>
    <vc volume=""stator"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""hub_gap1"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""hub_gap2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""hub_gap3"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""inlet_gap"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""rotor_gap1"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""rotor_gap2"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""rotor_gap3"" type=""const_viscosity"" default=""yes"" value=""{0}""/>
    <vc volume=""stator"" type=""surface_tension""/>
    <vc volume=""rotor_gap3"" type=""surface_tension""/>
    <vc volume=""rotor_gap2"" type=""surface_tension""/>
    <vc volume=""rotor_gap1"" type=""surface_tension""/>
    <vc volume=""inlet_gap"" type=""surface_tension""/>
    <vc volume=""hub_gap3"" type=""surface_tension""/>
    <vc volume=""hub_gap2"" type=""surface_tension""/>
    <vc volume=""hub_gap1"" type=""surface_tension""/>
  </module>

  <module type=""sharephasecomp"" sharephasecomp=""oil"">
    <vc volume=""valve2_up"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve2_bot"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve1_bot"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve2_mid"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve1_mid"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""pipe"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""inlet"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""rotor2"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""airout1"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""airout2"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""airout3"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve1_bot_pipe"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve1_up"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve1_outlet"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve2_outlet1"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve2_outlet2"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""volute"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve2_gap4"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve2_gap3"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve2_gap2"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve2_gap1"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve1_chamber"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""valve1_up_gap"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""stator"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""hub_gap1"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""hub_gap2"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""hub_gap3"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""inlet_gap"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""rotor_gap1"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""rotor_gap2"" type=""const_density"" default=""yes"" value=""{1}""/>
    <vc volume=""rotor_gap3"" type=""const_density"" default=""yes"" value=""{1}""/>
  </module>

  <module type=""sharephasecomp"" sharephasecomp=""air"">
    <vc volume=""airout1"" type=""ideal_gas_law""/>
    <vc volume=""volute"" type=""ideal_gas_law""/>
    <vc volume=""valve2_up"" type=""ideal_gas_law""/>
    <vc volume=""valve2_outlet2"" type=""ideal_gas_law""/>
    <vc volume=""valve2_outlet1"" type=""ideal_gas_law""/>
    <vc volume=""valve2_mid"" type=""ideal_gas_law""/>
    <vc volume=""valve2_gap4"" type=""ideal_gas_law""/>
    <vc volume=""valve2_gap3"" type=""ideal_gas_law""/>
    <vc volume=""valve2_gap2"" type=""ideal_gas_law""/>
    <vc volume=""valve2_gap1"" type=""ideal_gas_law""/>
    <vc volume=""valve2_bot"" type=""ideal_gas_law""/>
    <vc volume=""valve1_up_gap"" type=""ideal_gas_law""/>
    <vc volume=""valve1_up"" type=""ideal_gas_law""/>
    <vc volume=""valve1_outlet"" type=""ideal_gas_law""/>
    <vc volume=""valve1_mid"" type=""ideal_gas_law""/>
    <vc volume=""valve1_chamber"" type=""ideal_gas_law""/>
    <vc volume=""valve1_bot_pipe"" type=""ideal_gas_law""/>
    <vc volume=""valve1_bot"" type=""ideal_gas_law""/>
    <vc volume=""rotor2"" type=""ideal_gas_law""/>
    <vc volume=""pipe"" type=""ideal_gas_law""/>
    <vc volume=""inlet"" type=""ideal_gas_law""/>
    <vc volume=""airout3"" type=""ideal_gas_law""/>
    <vc volume=""airout2"" type=""ideal_gas_law""/>
    <vc volume=""stator"" type=""ideal_gas_law""/>
    <vc volume=""rotor_gap3"" type=""ideal_gas_law""/>
    <vc volume=""rotor_gap2"" type=""ideal_gas_law""/>
    <vc volume=""rotor_gap1"" type=""ideal_gas_law""/>
    <vc volume=""inlet_gap"" type=""ideal_gas_law""/>
    <vc volume=""hub_gap3"" type=""ideal_gas_law""/>
    <vc volume=""hub_gap2"" type=""ideal_gas_law""/>
    <vc volume=""hub_gap1"" type=""ideal_gas_law""/>
  </module>

  <module type=""phasecomp"" phasecomp=""oil"" blending_factor=""0.1"">
    <bc patch=""valve2_outlet1_outlet"" type=""outlet"" value=""1""/>
    <bc patch=""valve2_outlet2_outlet"" type=""fix_value"" value=""1""/>
    <bc patch=""valve1_outlet_outlet2"" type=""outlet"" value=""0""/>
    <bc patch=""valve1_outlet_outlet1"" type=""outlet"" value=""0""/>
    <bc patch=""inlet_inlet"" type=""fix_value"" value=""1"" print_m_flux=""on"" print_v_flux=""on""
      output=""user_select""/>

    <bc patch=""airout1_outlet"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on""
      output=""user_select""/>

    <bc patch=""airout3_outlet"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on""
      output=""user_select""/>

    <bc patch=""airout2_outlet"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on""
      output=""user_select""/>

    <bc patch=""inlet_gap_up"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on""
      output=""user_select""/>

    <bc patch=""hub_gap3_up"" type=""outlet"" value=""0"" print_m_flux=""on"" print_v_flux=""on""
      output=""user_select""/>

    <vc volume=""inlet"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""rotor2"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""volute"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""hub_gap1"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""hub_gap2"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""hub_gap3"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""inlet_gap"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""rotor_gap1"" type=""output_var"" default=""yes"" print_mass_frac=""on""
      print_vol_frac=""on"" print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""rotor_gap2"" type=""output_var"" default=""yes"" print_mass_frac=""on""
      print_vol_frac=""on"" print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""rotor_gap3"" type=""output_var"" default=""yes"" print_mass_frac=""on""
      print_vol_frac=""on"" print_tot_mass=""on"" print_tot_vol=""on""/>

    <ic volume=""valve2_up"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve2_bot"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve1_bot"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve2_mid"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve1_mid"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""pipe"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""inlet"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""rotor2"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""airout1"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""airout2"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""airout3"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve1_bot_pipe"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve1_up"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve1_outlet"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve2_outlet1"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve2_outlet2"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""volute"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve2_gap4"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve2_gap3"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve2_gap2"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve2_gap1"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve1_chamber"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve1_up_gap"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""stator"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""hub_gap1"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""hub_gap2"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""hub_gap3"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""inlet_gap"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""rotor_gap1"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""rotor_gap2"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""rotor_gap3"" type=""fix_value"" default=""yes"" value=""0""/>
  </module>

  <module type=""phasecomp"" phasecomp=""air"" blending_factor=""0.1"">
    <bc patch=""valve2_outlet1_outlet"" type=""outlet"" value=""0""/>
    <bc patch=""valve2_outlet2_outlet"" type=""fix_value"" value=""0""/>
    <bc patch=""valve1_bot_pipe_outlet"" type=""outlet"" value=""0""/>
    <bc patch=""valve1_outlet_outlet1"" type=""outlet"" value=""1""/>
    <bc patch=""valve1_outlet_outlet2"" type=""outlet"" value=""1""/>
    <bc patch=""airout1_outlet"" type=""outlet"" value=""1""/>
    <bc patch=""airout3_outlet"" type=""outlet"" value=""1""/>
    <bc patch=""airout2_outlet"" type=""outlet"" value=""1""/>
    <bc patch=""inlet_inlet"" type=""fix_value"" print_m_flux=""on"" print_v_flux=""on"" output=""user_select""/>
    <bc patch=""inlet_gap_up"" type=""outlet"" value=""1"" print_m_flux=""on"" print_v_flux=""on""
      output=""user_select""/>

    <bc patch=""hub_gap3_up"" type=""outlet"" value=""1"" print_m_flux=""on"" print_v_flux=""on""
      output=""user_select""/>

    <vc volume=""inlet"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""rotor2"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""volute"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""hub_gap1"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""hub_gap2"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""hub_gap3"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""inlet_gap"" type=""output_var"" default=""yes"" print_mass_frac=""on"" print_vol_frac=""on""
      print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""rotor_gap1"" type=""output_var"" default=""yes"" print_mass_frac=""on""
      print_vol_frac=""on"" print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""rotor_gap2"" type=""output_var"" default=""yes"" print_mass_frac=""on""
      print_vol_frac=""on"" print_tot_mass=""on"" print_tot_vol=""on""/>

    <vc volume=""rotor_gap3"" type=""output_var"" default=""yes"" print_mass_frac=""on""
      print_vol_frac=""on"" print_tot_mass=""on"" print_tot_vol=""on""/>

    <ic volume=""valve2_up"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve2_bot"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve1_bot"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve2_mid"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve1_mid"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""pipe"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""inlet"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""rotor2"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""airout1"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""airout2"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""airout3"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve1_bot_pipe"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve1_up"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve1_outlet"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve2_outlet1"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve2_outlet2"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""volute"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""valve2_gap4"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve2_gap3"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve2_gap2"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve2_gap1"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve1_chamber"" type=""fix_value"" default=""yes"" value=""0""/>
    <ic volume=""valve1_up_gap"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""stator"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""hub_gap1"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""hub_gap2"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""hub_gap3"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""inlet_gap"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""rotor_gap1"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""rotor_gap2"" type=""fix_value"" default=""yes"" value=""1""/>
    <ic volume=""rotor_gap3"" type=""fix_value"" default=""yes"" value=""1""/>
  </module>";
    }
}
