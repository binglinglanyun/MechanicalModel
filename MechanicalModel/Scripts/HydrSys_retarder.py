# Import LMS Amesim Python module
import amesim
import pylab
import subprocess

# Store the model name in a variable
sname = 'HydrSys_retarder'

# Open LMS Amesim model, check it, compile and close
msg = subprocess.check_output(
         'AMECirChecker -g -q --nobackup --nologfile ' + sname + '.ame',
         stderr=subprocess.STDOUT,
         shell=True)
print msg

# Unpack the LMS Amesim model file
popen = subprocess.Popen(["AMELoad", sname + '.ame'])
popen.wait()

# Get the parameter and variable name from datapath
# - get the parameters
[youyuan_parname] = amesim.amegetparamnamefromui(sname, 'k@constant_1')
[ev2_parname] = amesim.amegetparamnamefromui(sname, 'k@constant')
[oil_parname] = amesim.amegetparamnamefromui(sname, 'fluidnameTFFD1@thf_fluid_data_10')
[air_parname] = amesim.amegetparamnamefromui(sname, 'xair@thf_fluid_data_10')

# - get the result variables
[p2_varname] = amesim.amegetvarnamefromui(sname, 'ops@pressuresensor')
[p3_varname] = amesim.amegetvarnamefromui(sname, 'ops@pressuresensor_1')
[inlet_flow_varname] = amesim.amegetvarnamefromui(sname, 'outm@thf_mass_flow_sensor')
[total_gas_varname] = amesim.amegetvarnamefromui(sname, 'oxs@thf_gas_mass_fraction_sensor')


# Set simulation end time at 10s and the print interval to 0.01s
sim_opt = amesim.amegetsimopt(sname)
sim_opt.finalTime = 10.0
sim_opt.printInterval = 0.01

fig = pylab.figure()
fig.suptitle('Cylinder Displacement [m]', fontsize=14, fontweight='bold')

# Set parameter
#amesim.ameputp(sname, youyuan_parname, 2.5*10+1.013)
amesim.ameputp(sname, ev2_parname, 1.5)

# Run simulation
[ret_stat, msg] = amesim.amerunsingle(sname, sim_opt)

# Get results
[results,var_names] = amesim.ameloadt(sname)
time_data, [time_label] = amesim.amegetvar(results, var_names, 'time [s]')
p2_data, [p2_label] = amesim.amegetvar(results, var_names, p2_varname)
p3_data, [p3_label] = amesim.amegetvar(results, var_names, p3_varname)
inlet_flow_data, [inlet_flow_label] = amesim.amegetvar(results, var_names, inlet_flow_varname)
total_gas_data, [total_gas_label] = amesim.amegetvar(results, var_names, total_gas_varname)

# Plot P2 & P3 vs. time
ax=pylab.subplot(411)
pylab.plot(time_data[0], p2_data[0], label='P2 [barA]')
pylab.plot(time_data[0], p3_data[0], label='P3 [barA]')
pylab.legend(loc='upper left')
pylab.xlabel('Time [s]')
pylab.ylabel('barA')
pylab.xlim(0.0, 10.0)

# Plot inlet_flow vs. time
pylab.subplot(412)
pylab.plot(time_data[0], inlet_flow_data[0], label='inlet flow [kg/s]')
pylab.legend(loc='upper left')
pylab.xlabel('Time [s]')
pylab.ylabel('null')
pylab.xlim(0.0, 10.0)

# Plot inlet_flow vs. P2
ax=pylab.subplot(413)
pylab.plot(p2_data[0], inlet_flow_data[0], label='inlet flow [kg/s]')
pylab.legend(loc='upper left')
pylab.xlabel('P2 [barA]')
pylab.ylabel('null')
pylab.xlim(0, 70)

# Plot total_gas vs. time
pylab.subplot(414)
pylab.plot(time_data[0], total_gas_data[0], label='total gas mass fraction [mg/kg]')
pylab.legend(loc='upper left')
pylab.xlabel('Time [s]')
pylab.ylabel('mg/kg')
pylab.xlim(0.0, 10.0)

#pylab.title('- single run simulations -')

pylab.show()

# Save and close the LMS Amesim system
popen = subprocess.Popen(["AMESave", sname + '.ame'])
