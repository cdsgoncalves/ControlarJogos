using System;
using System.Configuration;

namespace Util
{
    /// <summary>
    /// Classe para leitura e tratamento de arquivos de configuração da aplicação (Web.config ou App.config)
    /// </summary>
    public static class Configuracao
    {
        public static string ConnectionString => LerValorConfig(TipoChaveConfig.ConnectionStrings, "S2ItContext");
        public static string ConnectionStringMigration => LerValorConfig(TipoChaveConfig.ConnectionStrings, "MigrationConn");
        public static string SaltKey => LerValorConfig(TipoChaveConfig.AppSettings, "SaltKey");

        #region Metodos Privados
        /// <summary>
        /// Leitura de uma chave de configuração.
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="chave">Chave a ser lida do arquivo de configuração</param>
        /// <param name="valorPadrao">Valor padrão a ser usado caso a chave não seja encontrada</param>
        /// <returns>Valor lido do arquivo, ou valor padrão informado, caso a chave não seja encontrada</returns>
        /// <remarks>Lança exceção no caso da chave não ter sido encontrada, e nenhum valor padrão ter sido informado</remarks>
        private static string LerValorConfig(TipoChaveConfig tipo, string chave, string valorPadrao = null)
        {
            string valor;

            // Leitura do valor
            switch (tipo)
            {
                case TipoChaveConfig.AppSettings:
                    valor = ConfigurationManager.AppSettings[chave];
                    break;

                case TipoChaveConfig.ConnectionStrings:
                    valor = ConfigurationManager.ConnectionStrings[chave]?.ConnectionString;
                    break;

                default:
                    throw new InvalidOperationException($"Tipo de chave de configuração inválido: '{tipo}'");
            }

            // Chave existe: retorna valor lido
            if (!string.IsNullOrEmpty(valor))
                return valor;

            // Chave não existe: retorna valor padrão se informado
            if (!string.IsNullOrEmpty(valorPadrao))
                return valorPadrao;

            // Chave não existe e valor padrão não informado: lança exceção
            throw new ConfigurationErrorsException($"Chave de configuração não encontrada: '{chave}'");
        }
        #endregion
    }

    #region Enumerações Internas
    internal enum TipoChaveConfig
    {
        AppSettings,
        ConnectionStrings
    }
    #endregion
}