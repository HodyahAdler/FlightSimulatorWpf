using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulatorWpf
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private IModel model;

		
		public SimulatorViewModel Simulator_vm;


		void App_Startup(Object sender, StartupEventArgs e)
		{
			//creating a Model
			IModel model = new FlyModel(new TelnetClient());

			Simulator_vm = new SimulatorViewModel(model);
			

		}

	}
}