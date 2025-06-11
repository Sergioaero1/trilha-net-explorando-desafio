namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            bool capacidadeSuficiente = hospedes.Count <= Suite.Capacidade;
            if (!capacidadeSuficiente)
            {
                throw new InvalidOperationException("😭 Capacidade insuficiente para o número de hóspedes 🫤");
            }
            else
            { 
                Hospedes = hospedes;
            }

        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária --- Cálculo: DiasReservados X Suite.ValorDiaria
            if (Suite == null)
            {
                throw new InvalidOperationException("Nenhuma suíte cadastrada.");
            }
            decimal valor = Suite.ValorDiaria * DiasReservados;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.1m; // Aplicando desconto de 10%
            }

            return Math.Round(valor, 2); // Arredondando para duas casas decimais
            
        }
    }
}