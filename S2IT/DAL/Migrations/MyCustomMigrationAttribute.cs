using System;
using FluentMigrator;

namespace DAL.Migrations
{
    /// <summary>
    /// Marca todas as migrações com este versionamento ao invés de [Migration].
    /// Exemplo: https://iainhunter.wordpress.com/2012/08/02/easy-database-migrations-with-c-and-fluentmigrator/
    /// Wiki: https://github.com/schambers/fluentmigrator/wiki
    /// </summary>
    public class MyCustomMigrationAttribute : MigrationAttribute
    {
        public MyCustomMigrationAttribute(int userStoryId, int taskId, int day, int month, int year, string author)
            : base(CalculateValue(userStoryId, taskId, day, month, year))
        {
            Author = author;
        }

        public string Author { get; }

        private static long CalculateValue(int userStoryId, int taskId, int day, int month, int year)
        {
            return Convert.ToInt64(
                userStoryId.ToString().PadLeft(5, '0') +
                taskId.ToString().PadLeft(5, '0') +
                year.ToString().PadLeft(2, '0').Substring(2, 2) +
                month.ToString().PadLeft(2, '0') +
                day.ToString().PadLeft(2, '0')
            );
        }
    }
}