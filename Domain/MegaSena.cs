using Loteria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Loteria.Domain
{
    public class MegaSena
    {
        #region Attributes

        private Bilhete.NomeJogo _nomeJogo = Bilhete.NomeJogo.MegaSena;

        // Quantidade de números a escolher no jogo da mega sena
        private const int _qtdNumeros = 6;
        // Maior número a se escolher no jogo da mega sena
        private const int _numeroMaximo = 60;
        // Sena, Quina e Quadra.
        private int[] _dezenasAcertadores = {6, 5, 4}; 

        #endregion


        #region Constructor

        private readonly IJogo _jogo;
        public MegaSena()
        {
            var serviceProvider = new ServiceCollection()           
                .AddSingleton<IJogo, Jogo>()           
                .BuildServiceProvider();           
            
            _jogo = serviceProvider.GetService<IJogo>();            
        }

        #endregion


        #region Methods

        public void RegistrarJogo(IEnumerable<int> numeros) => _jogo.CriarJogo(numeros, _nomeJogo, _qtdNumeros, _numeroMaximo);

        public void RegistrarJogoAutomatico() {
            _jogo.CriarJogoAutomatico(_nomeJogo, _qtdNumeros, _numeroMaximo);
        }

        public IEnumerable<int> Sortear()
        {
            return _jogo.SortearNumeros();
        }

        public IEnumerable<int> GerarNumerosParaAposta()
        {
            return _jogo.GerarNumerosParaAposta(_qtdNumeros, _numeroMaximo);
        }

        public IEnumerable<int> Sortear(int qtdNumeros)
        {
            return _jogo.SortearNumeros();
        }

        public Dictionary<int, List<Bilhete>> Acertadores(List<int> numerosSorteados)
        {
            return _jogo.VerificarAcertadores(_jogo.GetBilhetes(), numerosSorteados, _dezenasAcertadores);
        }

        #endregion

    }

}
