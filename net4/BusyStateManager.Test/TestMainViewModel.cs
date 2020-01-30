using System.Threading.Tasks;

namespace Savaged.BusyStateManager.Test
{
    public class TestMainViewModel : TestViewModelBase
    {
        public TestMainViewModel(IBusyStateRegistry busyStateRegistry)
            : base(busyStateRegistry)
        {
        }
    }
}
