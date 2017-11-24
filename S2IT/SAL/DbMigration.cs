namespace SAL
{
    public static class DbMigration
    {
        public static void Run() => DAL.Migrations.Runner.MigrateToLatest();
    }
}