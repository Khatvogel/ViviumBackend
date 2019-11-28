using Backend.Entities;

namespace Frontend.ViewModels
{
    public class RegisterDeviceResponseViewModel
    {
        public Device Device { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }

        public RegisterDeviceResponseViewModel(Device device)
        {
            Device = device;
        }
    }
}