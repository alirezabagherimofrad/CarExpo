namespace CarExpo.Infrastructure.Authentication
{
    public interface IJwtService
    {
        public Task<string> GenerateToken(Guid userid);

    }
}
