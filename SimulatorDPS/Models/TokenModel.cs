namespace SimulatorDPS.Models
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public int LifeTime { get; set; }
        public int UserId { get; set; }
        public string UserLogin { get; set; }
    }
}