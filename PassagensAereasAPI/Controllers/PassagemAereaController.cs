using Microsoft.AspNetCore.Mvc;
using PassagensAereasAPI.DTOs;
using PassagensAereasAPI.Services;

namespace PassagensAereasAPI.Controllers
{
    [ApiController]
    [Route("api/PassagensAereas")]
    public class PassagemAereaController : ControllerBase
    {
        private readonly PassagemAereaService passagemAereaService;

        public PassagemAereaController(PassagemAereaService passagemAereaService)
        {
            this.passagemAereaService = passagemAereaService;
        }

        public async Task<IEnumerable<PassagemAereaResponse>> ListaPassagensAereas(PassagemAereaRequest request)
        {
            var result = await passagemAereaService.ListaPassagensAereas(request);
            return result;
        }
    }
}
