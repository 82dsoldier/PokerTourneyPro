using Autofac;
using PokerTourneyPro.Interfaces;
using PokerTourneyPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static PokerTourneyPro.Common.Global;

namespace PokerTourneyPro {
	public partial class App : Application {
		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);
			var builder = new ContainerBuilder();
			builder.RegisterType<MainViewModel>().As<IMainViewModel>();
			builder.RegisterType<MainView>();
			Container = builder.Build();
			var mainView = Container.Resolve<MainView>();
			mainView.Show();
		}
	}
}
