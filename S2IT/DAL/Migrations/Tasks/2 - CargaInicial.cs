using FluentMigrator;

namespace DAL.Migrations.Tasks
{
    [MyCustomMigration(1, 2, 24, 11, 2017, "Carlos Gonçalves")]
    public class CargaInicial : Migration
    {
        public override void Up()
        {
            Execute.Sql("INSERT INTO Usuario (Email, Nome, Senha) VALUES ('carloscajo@gmail.com', 'Carlos Gonçalves', 'f9hQuZ0/4eJKjPyzUxYqy2Afzlma9ePk+CyiT0TAe0s=')");
            Execute.Sql("INSERT INTO Usuario (Email, Nome, Senha) VALUES ('s2it@gmail.com', 'S2IT', 'f9hQuZ0/4eJKjPyzUxYqy2Afzlma9ePk+CyiT0TAe0s=')");
        }

        public override void Down()
        {
            Execute.Sql("DELETE FROM Usuario WHERE Email = 'carloscajo@gmail.com'");
            Execute.Sql("DELETE FROM Usuario WHERE Email = 's2it@gmail.com'");
        }
    }
}