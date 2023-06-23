namespace ApiPolizaSeguros.Services.Contracts
{
    public interface IAuthService
    {
        public bool ValidateLogin(string username, string password);
        string GenerateToken(DateTime fechaActual, string username, TimeSpan tiempoValidez);
    }

}

