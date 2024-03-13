using AutoMapper;
using Newtonsoft.Json;
using PassagensAereasAPI.DTOs;

namespace PassagensAereasAPI.Services
{
    public class PassagemAereaService
    {
        private readonly IMapper _mapper;

        public PassagemAereaService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<PassagemAereaResponse>> ListaPassagensAereas(PassagemAereaRequest request)
        {
            var dataGol = await RetornaPassagensAereasGol(request);
            var dataLatam = await RetornaPassagensAereasLatam(request);

            if (dataGol == null && dataLatam == null) throw new ApplicationException("Não foram encontradas passagens para esta pesquisa.");

            var listaGol = _mapper.Map<IEnumerable<PassagemAereaResponse>>(dataGol);
            var listaLatam = _mapper.Map<IEnumerable<PassagemAereaResponse>>(dataLatam);

            List<PassagemAereaResponse> listaConsolidada = new List<PassagemAereaResponse>();

            foreach(var item in listaGol)
            {
                listaConsolidada.Add(item);
            }

            return dataGol;
        }

        public async Task<IEnumerable<PassagemAereaResponse>> RetornaPassagensAereasGol(PassagemAereaRequest request)
        {
            var origem = request.Origem.Replace(" ", "%20");
            var destino = request.Origem.Replace(" ", "%20");
            var partida = request.Partida.ToString("yyyy-MM-dd");
            string url = $"https://dev.reserve.com.br/airapi/gol/getavailability?origin={origem}&destination={destino}&date={partida}";
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<IEnumerable<PassagemAereaResponse>>(response);
            return data;
        }
        public async Task<IEnumerable<PassagemAereaResponse>> RetornaPassagensAereasLatam(PassagemAereaRequest request)
        {
            var origem = request.Origem.Replace(" ", "%20");
            var destino = request.Origem.Replace(" ", "%20");
            var partida = request.Partida.ToString("yyyy-MM-dd");
            string url = $"https://dev.reserve.com.br/airapi/latam/flights?departureCity={origem}&arrivalCity={destino}&departureDate={partida}";
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<IEnumerable<PassagemAereaResponse>>(response);
            return data;
        }
    }
}
