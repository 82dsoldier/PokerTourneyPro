using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerTourneyPro.Interfaces {
	public interface IMainViewModel {
		DateTime CurrentBlindTime { get; set; }
		ICommand StartTimer { get; }
		ICommand PauseTimer { get; }
	}
}
