namespace PassagensAereasAPI.DTOs
{
    public class PassagemAereaRequest
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime Partida { get; set; }
    }
}
