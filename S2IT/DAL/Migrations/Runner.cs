using Util;
using FluentMigrator;
using System.Reflection;
using FluentMigrator.Runner;
using System.Collections.Generic;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;

namespace DAL.Migrations
{
    /// <summary>
    /// Classe responsável pela execução dos migrations pendentes.
    /// </summary>
    public static class Runner
    {
        /// <summary>
        /// Opções para execução dos migrations.
        /// </summary>
        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public string ProviderSwitches { get; set; }
            public int Timeout { get; set; }
        }

        /// <summary>
        /// Execução todos os migrates pendentes.
        /// </summary>
        public static void MigrateToLatest()
        {
            var runners = new List<RunnersConfigs>
            {
               new RunnersConfigs { ConnectionString = Configuracao.ConnectionStringMigration, Namespace = "DAL.Migrations.Tasks"},
            };

            foreach (var config in runners)
            {
                var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));
                var assembly = Assembly.GetExecutingAssembly();
                var migrationContext = new RunnerContext(announcer) { Namespace = config.Namespace };
                var options = new MigrationOptions { PreviewOnly = false, Timeout = int.MaxValue };
                var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2014ProcessorFactory();
                var processor = factory.Create(config.ConnectionString, announcer, options);
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateUp(true);
            }
        }
    }

    internal class RunnersConfigs
    {
        public string ConnectionString { get; set; }
        public string Namespace { get; set; }
    }
}