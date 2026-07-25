using AutoMapper;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.DTOs.LogType;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.DTOs.Objection;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.DTOs.Question;

namespace OnlineExam.Application.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            //Class Room
            CreateMap<ClassRoom, CreateClassRoomDTO>().ReverseMap();
            CreateMap<ClassRoom, GetClassRoomDTO>().ReverseMap();
            CreateMap<ClassRoom, UpdateClassRoomDTO>().ReverseMap();
            CreateMap<ClassRoom, GetClassRoomTeacherDTO>().ReverseMap();
            CreateMap<ClassRoom, GetClassRoomStudentDTO>().ReverseMap();

            //Class Room Member
            CreateMap<ClassRoomMembers, CreateClassRoomMemberDTO>().ReverseMap();
            CreateMap<ClassRoomMembers, GetClassRoomDTO>().ReverseMap();
            CreateMap<ClassRoomMembers, UpdateClassRoomDTO>().ReverseMap();

            //Exam
            CreateMap<Exam, CreateExamDTO>().ReverseMap();
            CreateMap<Exam, GetExamDTO>().ReverseMap();
            CreateMap<Exam, UpdateExamDTO>().ReverseMap();
            CreateMap<Exam, GetExamSummeryDTO>().ReverseMap();
            CreateMap<Exam, GetExamDetailDTO>().ReverseMap();

            //Descriptive Question
            CreateMap<DescriptiveQuestion, CreateDescriptiveQuestionDTO>().ReverseMap();
            CreateMap<DescriptiveQuestion, GetDescriptiveQuestionDTO>().ReverseMap();
            CreateMap<DescriptiveQuestion, UpdateDescriptiveQuestionDTO>().ReverseMap();
            CreateMap<DescriptiveQuestion, GetDescriptiveQuestionStudentDTO>().ReverseMap();
            CreateMap<DescriptiveQuestion, GetDescriptiveQuestionTeacherDTO>().ReverseMap();

            //Descriptive Answer
            CreateMap<DescriptiveAnswers, CreateDescriptiveAnswersDTO>().ReverseMap();
            CreateMap<DescriptiveAnswers, GetDescriptiveAnswersDTO>().ReverseMap();
            CreateMap<DescriptiveAnswers, UpdateDescriptiveAnswersDTO>().ReverseMap();
            CreateMap<DescriptiveAnswers, GetDescriptiveAnswersTeacherDTO>().ReverseMap();
            CreateMap<DescriptiveAnswers, UpdateDescriptiveAnswersTeacherDTO>().ReverseMap();
            CreateMap<DescriptiveAnswers, GetDescriptiveAnswerStudentDTO>().ReverseMap();

            //Multiple Choice Question
            CreateMap<MultipleChoiceQuestion, CreateMultipleChoiceQuestionDTO>().ReverseMap();
            CreateMap<MultipleChoiceQuestion, GetMultipleChoiceQuestionDTO>().ReverseMap();
            CreateMap<MultipleChoiceQuestion, UpdateMultipleChoiceQuestionDTO>().ReverseMap();
            CreateMap<MultipleChoiceQuestion, GetMultipleChoiceQuestionStudentDTO>().ReverseMap();
            CreateMap<MultipleChoiceQuestion, GetMultipleChoiceQuestionTeacherDTO>().ReverseMap();

            //Multiple Choice Answer
            CreateMap<MultipleChoiceAnswers, CreateMultipleChoiceAnswerDTO>().ReverseMap();
            CreateMap<MultipleChoiceAnswers, GetMultipleChoiceAnswerDTO>().ReverseMap();
            CreateMap<MultipleChoiceAnswers, UpdateMultipleChoiceAnswerDTO>().ReverseMap();
            CreateMap<MultipleChoiceAnswers, GetMultipleChoiceAnswerTeacherDTO>().ReverseMap();
            CreateMap<MultipleChoiceAnswers, UpdateMultipleChoiceAnswerTeacherDTO>().ReverseMap();

            //Question
            CreateMap<Question, CreateQuestionDTO>().ReverseMap();
            CreateMap<Question, GetQuestionStudentDTO>().ReverseMap();
            CreateMap<Question, UpdateQuestionDTO>().ReverseMap();
            CreateMap<Question, GetQuestionTeacherDTO>().ReverseMap();

            //Objection
            CreateMap<Objection, CreateObjectionDTO>().ReverseMap();
            CreateMap<Objection, GetObjectionDTO>().ReverseMap();
            CreateMap<Objection, UpdateObjectionDTO>().ReverseMap();

            //Log type
            CreateMap<LogType, CreateLogTypeDTO>().ReverseMap();
            CreateMap<LogType, GetLogTypeDTO>().ReverseMap();
            CreateMap<LogType, UpdateLogTypeDTO>().ReverseMap();

            //True or false question
            CreateMap<TrueOrFalseQuestion, CreateTrueOrFalseQuestionDTO>().ReverseMap();
            CreateMap<TrueOrFalseQuestion, GetTrueOrFalseQuestionDTO>().ReverseMap();
            CreateMap<TrueOrFalseQuestion, UpdateTrueOfFalseQuestionDTO>().ReverseMap();
            CreateMap<TrueOrFalseQuestion, GetTrueOrFalseQuestionStudentDTO>().ReverseMap();
            CreateMap<TrueOrFalseQuestion, GetTrueOrFalseQuestionTeacherDTO>().ReverseMap();

            //True or false Answer
            CreateMap<TrueOrFalseAnswers, CreateTrueOrFalseAnswerDTO>().ReverseMap();
            CreateMap<TrueOrFalseAnswers, GetTrueOrFalseAnswerDTO>().ReverseMap();
            CreateMap<TrueOrFalseAnswers, UpdateTrueOrFalseAnswerDTO>().ReverseMap();
            CreateMap<TrueOrFalseAnswers, GetTrueOrFalseAnswerTeacherDTO>().ReverseMap();
            CreateMap<TrueOrFalseAnswers, UpdateTrueOrFalseAnswerTeacherDTO>().ReverseMap();
        }
    }
}
