using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class PopularDb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO CATEGORIA (NOME_CATEGORIA, URL_IMAGEM) VALUES ('BEBIDAS', 'WWW.GOOGLE.COM.BR') ");
            mb.Sql("INSERT INTO PRODUTO (NOME_PRODUTO, DES_PRODUTO, VAL_PRODUTO, URL_IMAGEM, QTD_ESTOQUE, DATA_CADASTRO, CategoriaId) VALUES ('PEPSI', 'REFRIGERANTE LATA 350 ML', 5.45, 'WWW.GOOGLE.COM.BR', 50, NOW(), (SELECT COD_CATEGORIA FROM CATEGORIA WHERE NOME_CATEGORIA = 'BEBIDAS')) ");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE CATEGORIA");
            mb.Sql("DELETE PRODUTO");
        }
    }
}
