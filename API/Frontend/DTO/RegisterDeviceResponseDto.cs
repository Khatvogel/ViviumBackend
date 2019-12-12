using Backend.Entities;

namespace Frontend.DTO
{
    public class RegisterDeviceResponseDto
    {
        public Device Device { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }

        public RegisterDeviceResponseDto(Device device)
        {
            Device = device;
        }
    }
}