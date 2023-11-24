using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaharovNik_KT_42_20.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи для группы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_student_GroupName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_сourse",
                columns: table => new
                {
                    сourse_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи группы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_сourse_title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название предмета"),
                    c_group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_сourse_сourse_id", x => x.сourse_id);
                    table.ForeignKey(
                        name: "fk_c_group_id",
                        column: x => x.c_group_id,
                        principalTable: "Groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_student_FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя студента"),
                    c_student_LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    c_student_MiddleName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    c_student_GroupId = table.Column<int>(type: "int", nullable: false, comment: "Внешний ключ на группу")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.c_student_GroupId,
                        principalTable: "Groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_сourse_fk_c_group_id",
                table: "cd_сourse",
                column: "c_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_student_c_student_GroupId",
                table: "cd_student",
                column: "c_student_GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_сourse");

            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
