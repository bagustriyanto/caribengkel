namespace CariBengkel.Domain.Cores {
    public interface ITokenServices {
        string CreateToken (string username, string roleId);
    }
}