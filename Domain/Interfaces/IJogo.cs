using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Domain.Interfaces
{
    public interface IJogo
    {
        void CriarJogo(IEnumerable<int> numeros, Bilhete.NomeJogo nomeJogo, int qtdNumeros, int numeroMaximo);
        void CriarJogoAutomatico(Bilhete.NomeJogo nomeJogo, int qtdNumeros, int numeroMaximo);

        IEnumerable<int> SortearNumeros();
        IEnumerable<int> GerarNumerosParaAposta(int qtdNumeros, int numeroMaximo);

        IEnumerable<Bilhete> GetBilhetes();
        Dictionary<int, List<Bilhete>> VerificarAcertadores(IEnumerable<Bilhete> bilhetes, List<int> numerosSorteados, int[] dezenasAcertadores);

    }
}
