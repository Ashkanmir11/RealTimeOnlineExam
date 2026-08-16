using OnlineExam.Ui.DTO.Common;

namespace OnlineExam.Ui.EndPoints
{
    public class ApiRoutes
    {
        public const string ApiVersion = "1";
        public const string ApiUrl = $"http://localhost/ExamApi/api/v{ApiVersion}";
        private static string GetPaginateUrl(string baseUrl, PaginateRequestDTO paginateRequestDTO)
        {
            baseUrl += $"?PageNumber={paginateRequestDTO.PageNumber}";
            baseUrl += $"&PageCount={paginateRequestDTO.PageCount}";
            if (paginateRequestDTO.SortBy != null)
            {
                baseUrl += $"&SortBy={paginateRequestDTO.SortBy}";
            }
            baseUrl += $"&Descending={paginateRequestDTO.Descending}";

            return baseUrl;
        }


        //Auth
        public const string Login = $"{ApiUrl}/auth/login";
        public const string myInfo = $"{ApiUrl}/accounts/me";
        public const string RefreshToken = $"{ApiUrl}/auth/refresh-token";
        public const string Logout = $"{ApiUrl}/auth/logout";
        public const string Register = $"{ApiUrl}/auth/register";

        //Class Room
        public const string CreateClassRoom = $"{ApiUrl}/class-rooms";
        public static string GetClassRoomAsTeacher(PaginateRequestDTO paginateRequestDTO)
        {
            string baseUrl = $"{ApiUrl}/class-rooms/my/as-teacher";
            baseUrl = GetPaginateUrl(baseUrl, paginateRequestDTO);
            return baseUrl;
        }
        public static string DeleteClassRoom(int id) => $"{ApiUrl}/class-rooms/{id}";
        public static string GetClassRoomById(int Id) => $"{ApiUrl}/class-rooms/{Id}";
        public static string UpdateClassRoom(int Id) => $"{ApiUrl}/class-rooms/{Id}";
        public static string GetStudentClassRoom(PaginateRequestDTO paginateRequestDTO)
        {
            string baseUrl = $"{ApiUrl}/class-rooms/my/as-student";
            baseUrl = GetPaginateUrl(baseUrl, paginateRequestDTO);
            return baseUrl;
        }
        //Class Room Members
        public static string GetClassRoomMember(int classId) => $"{ApiUrl}/class-room-members/{classId}/students";
        public const string CreateClassRoomMember = $"{ApiUrl}/class-room-members";
        public static string DeleteClassRoomMember(string StudentId, int ClassId) => $"{ApiUrl}/class-room-members/{ClassId}/{StudentId}";

        //Exam
        public const string CreateExam = $"{ApiUrl}/exams";
        public static string GetExamByClassId(int classId, PaginateRequestDTO paginateRequestDTO)
        {
            string baseUrl = $"{ApiUrl}/exams/class-room/{classId}";
            baseUrl = GetPaginateUrl(baseUrl, paginateRequestDTO);
            return baseUrl;
        }
        public static string DeleteExam(int id) => $"{ApiUrl}/exams/{id}";
        public static string GetExamById(int id) => $"{ApiUrl}/exams/{id}";
        public static string UpdateExam(int id) => $"{ApiUrl}/exams/{id}";
        public static string StartExam(PaginateRequestDTO paginateRequestDTO, int examId)
        {
            var baseUrl = $"{ApiUrl}/exams/{examId}/start";
            baseUrl = GetPaginateUrl(baseUrl, paginateRequestDTO);
            return baseUrl;
        }
        //Question
        public const string CreateQuestion = $"{ApiUrl}/questions";
        public static string GetQuestionByExamId(PaginateRequestDTO paginateRequestDTO, int examId)
        {
            var baseUrl = $"{ApiUrl}/exams/{examId}/questions";
            return GetPaginateUrl(baseUrl, paginateRequestDTO);
        }
        public static string DeleteQuestion(int id) => $"{ApiUrl}/questions/{id}";

        //True or false answer
        public static string GetMyTrueOrFalseAnswer(int questionId) => $"{ApiUrl}/true-or-false-answers/my/{questionId}";
        public const string CreateTrueOrFalseAnswer = $"{ApiUrl}/true-or-false-answers";
        public static string UpdateTrueOrFalseAnswer(int id) => $"{ApiUrl}/true-or-false-answers/{id}";

    }


}
