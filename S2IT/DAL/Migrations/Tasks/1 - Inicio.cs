using FluentMigrator;

namespace DAL.Migrations.Tasks
{
    [MyCustomMigration(1, 1, 24, 11, 2017, "Carlos Gonçalves")]
    public class Inicio : Migration
    {
        public override void Up()
        {
            Create.Table("Usuario")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Email").AsString(150).NotNullable().Unique("UK_Usuario_Email")
                .WithColumn("Nome").AsString(150).NotNullable()
                .WithColumn("Senha").AsString(50).NotNullable()
                .WithColumn("DataCadastro").AsDateTime().WithDefaultValue("GETDATE()").NotNullable()
                .WithColumn("Ativo").AsBoolean().WithDefaultValue(true).NotNullable();

            Create.Table("Jogo")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(150).NotNullable()
                .WithColumn("IdUsuarioOwner").AsInt32().NotNullable().ForeignKey(primaryColumnName: "Id",
                    primaryTableName: "Usuario", foreignKeyName: "FK_Jogo_UsuarioOwner")
                .WithColumn("IdUsuarioAtual").AsInt32().NotNullable().ForeignKey(primaryColumnName: "Id",
                    primaryTableName: "Usuario", foreignKeyName: "FK_Jogo_UsuarioAtual")
                .WithColumn("Ativo").AsBoolean().WithDefaultValue(true).NotNullable();
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Jogo_UsuarioOwner").OnTable("Jogo");
            Delete.ForeignKey("FK_Jogo_UsuarioAtual").OnTable("Jogo");

            Delete.UniqueConstraint("UK_Usuario_Email").FromTable("Usuario");

            Delete.Table("Jogo");
            Delete.Table("Usuario");
        }
    }
}