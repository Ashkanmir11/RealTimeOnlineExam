using OnlineExam.Ui.DTO.Common;

namespace OnlineExam.Ui.EndPoints
{
    public class ApiRoutes
    {
        public const string ApiVersion = "1";
        public const string ApiUrl = $"http://localhost/ExamApi/api/v{ApiVersion}";

        public const string Login = $"{ApiUrl}/auth/login";
        public const string myInfo = $"{ApiUrl}/accounts/me";
        public const string RefreshToken = $"{ApiUrl}/auth/refresh-token";
        public const string Logout = $"{ApiUrl}/auth/logout";
        public const string Register = $"{ApiUrl}/auth/register";
        public const string CreateClassRoom = $"{ApiUrl}/class-rooms";
        public static string GetClassRoomAsTeacher(PaginateRequestDTO paginateRequestDTO)
        {
            string baseUrl = $"{ApiUrl}/class-rooms/my/as-teacher";
            baseUrl += $"?PageNumber={paginateRequestDTO.PageNumber}";
            baseUrl += $"&PageCount={paginateRequestDTO.PageCount}";
            if (paginateRequestDTO.SortBy != null)
            {
                baseUrl += $"&SortBy={paginateRequestDTO.SortBy}";
            }
            baseUrl += $"&Descending={paginateRequestDTO.Descending}";

            return baseUrl ;
        }
        public static string DeleteClassRoom(int id) => $"{ApiUrl}/class-rooms/{id}";
        public static string GetClassRoomById(int Id) => $"{ApiUrl}/class-rooms/{Id}";
        public static string UpdateClassRoom(int Id) => $"{ApiUrl}/class-rooms/{Id}";

        public static string GetClassRoomMember(int classId) => $"{ApiUrl}/class-room-members/{classId}/students";


    }

}
