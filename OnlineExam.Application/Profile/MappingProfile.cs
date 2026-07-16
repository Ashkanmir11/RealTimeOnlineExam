using AutoMapper;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.DTOs.LogType;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
using OnlineExam.Application.DTOs.Objection;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //Class Room Member
            CreateMap<ClassRoomMembers, CreateClassRoomMemberDTO>().ReverseMap();
            CreateMap<ClassRoomMembers, GetClassRoomDTO>().ReverseMap();
            CreateMap<ClassRoomMembers, UpdateClassRoomDTO>().ReverseMap();

            //Exam
            CreateMap<Exam, CreateExamDTO>().ReverseMap();
            CreateMap<Exam, GetExamDTO>().ReverseMap();
            CreateMap<Exam, UpdateExamDTO>().ReverseMap();

            //Descriptive Question
            CreateMap<DescriptiveQuestion, CreateDescriptiveQuestionDTO>().ReverseMap();
            CreateMap<DescriptiveQuestion, GetDescriptiveQuestionDTO>().ReverseMap();
            CreateMap<DescriptiveQuestion, UpdateDescriptiveQuestionDTO>().ReverseMap();

            //Descriptive Question Answer
            CreateMap<DescriptiveQuestionAnswers, CreateDescriptiveQuestionAnswersDTO>().ReverseMap();
            CreateMap<DescriptiveQuestionAnswers, GetDescriptiveQuestionAnswersDTO>().ReverseMap();
            CreateMap<DescriptiveQuestionAnswers, UpdateDescriptiveQuestionAnswersDTO>().ReverseMap();


            //Multiple Choice Question
            CreateMap<MultipleChoiceQuestion,CreateMultipleChoiceQuestionDTO>().ReverseMap();
            CreateMap<MultipleChoiceQuestion,GetMultipleChoiceQuestionDTO>().ReverseMap();
            CreateMap<MultipleChoiceQuestion, UpdateMultipleChoiceQuestionDTO>().ReverseMap();

            //Multiple Choice Question Answer
            CreateMap<MultipleChoiceQuestionAnswers, CreateMultipleChoiceQuestionAnswerDTO>().ReverseMap();
            CreateMap<MultipleChoiceQuestionAnswers, GetMultipleChoiceQuestionAnswerDTO>().ReverseMap();
            CreateMap<MultipleChoiceQuestionAnswers, UpdateMultipleChoiceQuestionAnswerDTO>().ReverseMap();


            //Objection
            CreateMap<Objection, CreateObjectionDTO>().ReverseMap();
            CreateMap<Objection, GetObjectionDTO>().ReverseMap();
            CreateMap<Objection, UpdateObjectionDTO>().ReverseMap();

            //Log type
            CreateMap<LogType, CreateLogTypeDTO>().ReverseMap();
            CreateMap<LogType, GetLogTypeDTO>().ReverseMap();
            CreateMap<LogType, UpdateLogTypeDTO>().ReverseMap();

            //True or false question
            CreateMap<TrueOrFalseQuestion,CreateTrueOrFalseQuestionDTO>().ReverseMap();
            CreateMap<TrueOrFalseQuestion, GetTrueOrFalseQuestionDTO>().ReverseMap();
            CreateMap<TrueOrFalseQuestion, UpdateTrueOfFalseQuestionDTO>().ReverseMap();

            //True or false question Answer
            CreateMap<TrueOrFalseQuestionAnswers, CreateTrueOrFalseQuestionAnswerDTO>().ReverseMap();
            CreateMap<TrueOrFalseQuestionAnswers, GetTrueOrFalseQuestionAnswerDTO>().ReverseMap();
            CreateMap<TrueOrFalseQuestionAnswers, UpdateTrueOrFalseQuestionAnswerDTO>().ReverseMap();

        }
    }
}
