using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class AllCascadeToRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Haf_YearMasters_Mem_Masters_CLogin",
                table: "Haf_YearMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Views_Job_Masters_MasterId",
                table: "Job_Views");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Views_Mem_Masters_MemberId",
                table: "Job_Views");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_AdminPrivilages_Mem_Masters_MemberId",
                table: "Mem_AdminPrivilages");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_DistrictMasters_Mem_Masters_CLogin",
                table: "Mem_DistrictMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_EducationalQualifications_Mem_Masters_CLogin",
                table: "Mem_EducationalQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_SpouseEducationMasters_Mem_Masters_CLogin",
                table: "Mem_SpouseEducationMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_StateMasters_Mem_Masters_CLogin",
                table: "Mem_StateMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_UgColleges_Mem_Masters_CLogin",
                table: "Mem_UgColleges");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_UniversityMasters_Mem_Masters_CLogin",
                table: "Mem_UniversityMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Categorypermissions_Mem_Masters_CLogin",
                table: "Post_Categorypermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Categorypermissions_Post_Categories_PostCategoryId",
                table: "Post_Categorypermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_CommentEdits_Post_Comments_CommentId",
                table: "Post_CommentEdits");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_CommentsLikes_Mem_Masters_MemberId",
                table: "Post_CommentsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Donations_Mem_Masters_MemberId",
                table: "Post_Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_EventRegistrations_Mem_Masters_MemberId",
                table: "Post_EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Followers_Post_Masters_MemberId",
                table: "Post_Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMasters_Mem_Masters_CLogin",
                table: "Post_GroupMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Images_Post_Masters_PostId",
                table: "Post_Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_InterestedAreaMasters_Mem_Masters_CLogin",
                table: "Post_InterestedAreaMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Likes_Mem_Masters_MemberId",
                table: "Post_Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Likes_Post_Masters_PostId",
                table: "Post_Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Views_Mem_Masters_MemberId",
                table: "Post_Views");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Views_Post_Masters_PostId",
                table: "Post_Views");

            migrationBuilder.AlterColumn<int>(
                name: "UgCollageId",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Haf_YearMasters_Mem_Masters_CLogin",
                table: "Haf_YearMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Views_Job_Masters_MasterId",
                table: "Job_Views",
                column: "MasterId",
                principalTable: "Job_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Views_Mem_Masters_MemberId",
                table: "Job_Views",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_AdminPrivilages_Mem_Masters_MemberId",
                table: "Mem_AdminPrivilages",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_DistrictMasters_Mem_Masters_CLogin",
                table: "Mem_DistrictMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_EducationalQualifications_Mem_Masters_CLogin",
                table: "Mem_EducationalQualifications",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_SpouseEducationMasters_Mem_Masters_CLogin",
                table: "Mem_SpouseEducationMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_StateMasters_Mem_Masters_CLogin",
                table: "Mem_StateMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_UgColleges_Mem_Masters_CLogin",
                table: "Mem_UgColleges",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_UniversityMasters_Mem_Masters_CLogin",
                table: "Mem_UniversityMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Categorypermissions_Mem_Masters_CLogin",
                table: "Post_Categorypermissions",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Categorypermissions_Post_Categories_PostCategoryId",
                table: "Post_Categorypermissions",
                column: "PostCategoryId",
                principalTable: "Post_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_CommentEdits_Post_Comments_CommentId",
                table: "Post_CommentEdits",
                column: "CommentId",
                principalTable: "Post_Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_CommentsLikes_Mem_Masters_MemberId",
                table: "Post_CommentsLikes",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Donations_Mem_Masters_MemberId",
                table: "Post_Donations",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_EventRegistrations_Mem_Masters_MemberId",
                table: "Post_EventRegistrations",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Followers_Post_Masters_MemberId",
                table: "Post_Followers",
                column: "MemberId",
                principalTable: "Post_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMasters_Mem_Masters_CLogin",
                table: "Post_GroupMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Images_Post_Masters_PostId",
                table: "Post_Images",
                column: "PostId",
                principalTable: "Post_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_InterestedAreaMasters_Mem_Masters_CLogin",
                table: "Post_InterestedAreaMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Likes_Mem_Masters_MemberId",
                table: "Post_Likes",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Likes_Post_Masters_PostId",
                table: "Post_Likes",
                column: "PostId",
                principalTable: "Post_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Views_Mem_Masters_MemberId",
                table: "Post_Views",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Views_Post_Masters_PostId",
                table: "Post_Views",
                column: "PostId",
                principalTable: "Post_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Haf_YearMasters_Mem_Masters_CLogin",
                table: "Haf_YearMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Views_Job_Masters_MasterId",
                table: "Job_Views");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Views_Mem_Masters_MemberId",
                table: "Job_Views");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_AdminPrivilages_Mem_Masters_MemberId",
                table: "Mem_AdminPrivilages");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_DistrictMasters_Mem_Masters_CLogin",
                table: "Mem_DistrictMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_EducationalQualifications_Mem_Masters_CLogin",
                table: "Mem_EducationalQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_SpouseEducationMasters_Mem_Masters_CLogin",
                table: "Mem_SpouseEducationMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_StateMasters_Mem_Masters_CLogin",
                table: "Mem_StateMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_UgColleges_Mem_Masters_CLogin",
                table: "Mem_UgColleges");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_UniversityMasters_Mem_Masters_CLogin",
                table: "Mem_UniversityMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Categorypermissions_Mem_Masters_CLogin",
                table: "Post_Categorypermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Categorypermissions_Post_Categories_PostCategoryId",
                table: "Post_Categorypermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_CommentEdits_Post_Comments_CommentId",
                table: "Post_CommentEdits");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_CommentsLikes_Mem_Masters_MemberId",
                table: "Post_CommentsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Donations_Mem_Masters_MemberId",
                table: "Post_Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_EventRegistrations_Mem_Masters_MemberId",
                table: "Post_EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Followers_Post_Masters_MemberId",
                table: "Post_Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMasters_Mem_Masters_CLogin",
                table: "Post_GroupMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Images_Post_Masters_PostId",
                table: "Post_Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_InterestedAreaMasters_Mem_Masters_CLogin",
                table: "Post_InterestedAreaMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Likes_Mem_Masters_MemberId",
                table: "Post_Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Likes_Post_Masters_PostId",
                table: "Post_Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Views_Mem_Masters_MemberId",
                table: "Post_Views");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Views_Post_Masters_PostId",
                table: "Post_Views");

            migrationBuilder.AlterColumn<int>(
                name: "UgCollageId",
                table: "Mem_Masters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Haf_YearMasters_Mem_Masters_CLogin",
                table: "Haf_YearMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Views_Job_Masters_MasterId",
                table: "Job_Views",
                column: "MasterId",
                principalTable: "Job_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Views_Mem_Masters_MemberId",
                table: "Job_Views",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_AdminPrivilages_Mem_Masters_MemberId",
                table: "Mem_AdminPrivilages",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_DistrictMasters_Mem_Masters_CLogin",
                table: "Mem_DistrictMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_EducationalQualifications_Mem_Masters_CLogin",
                table: "Mem_EducationalQualifications",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_SpouseEducationMasters_Mem_Masters_CLogin",
                table: "Mem_SpouseEducationMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_StateMasters_Mem_Masters_CLogin",
                table: "Mem_StateMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_UgColleges_Mem_Masters_CLogin",
                table: "Mem_UgColleges",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_UniversityMasters_Mem_Masters_CLogin",
                table: "Mem_UniversityMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Categorypermissions_Mem_Masters_CLogin",
                table: "Post_Categorypermissions",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Categorypermissions_Post_Categories_PostCategoryId",
                table: "Post_Categorypermissions",
                column: "PostCategoryId",
                principalTable: "Post_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_CommentEdits_Post_Comments_CommentId",
                table: "Post_CommentEdits",
                column: "CommentId",
                principalTable: "Post_Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_CommentsLikes_Mem_Masters_MemberId",
                table: "Post_CommentsLikes",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Donations_Mem_Masters_MemberId",
                table: "Post_Donations",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_EventRegistrations_Mem_Masters_MemberId",
                table: "Post_EventRegistrations",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Followers_Post_Masters_MemberId",
                table: "Post_Followers",
                column: "MemberId",
                principalTable: "Post_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMasters_Mem_Masters_CLogin",
                table: "Post_GroupMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Images_Post_Masters_PostId",
                table: "Post_Images",
                column: "PostId",
                principalTable: "Post_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_InterestedAreaMasters_Mem_Masters_CLogin",
                table: "Post_InterestedAreaMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Likes_Mem_Masters_MemberId",
                table: "Post_Likes",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Likes_Post_Masters_PostId",
                table: "Post_Likes",
                column: "PostId",
                principalTable: "Post_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Views_Mem_Masters_MemberId",
                table: "Post_Views",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Views_Post_Masters_PostId",
                table: "Post_Views",
                column: "PostId",
                principalTable: "Post_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
