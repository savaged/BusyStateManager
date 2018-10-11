using System.Threading.Tasks;

namespace Savaged.BusyStateManager.Test
{
    public class TestSubViewModel : TestViewModelBase
    {
        public TestSubViewModel(IBusyStateRegistry busyStateRegistry)
            : base(busyStateRegistry)
        {
        }       
    }
}
