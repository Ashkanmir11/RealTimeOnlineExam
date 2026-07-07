using System;
using OnlineExam.Application.Exceptions;

namespace OnlineExam.Api.Herlpers
{
    public static class ExceptionCodeHelper
    {
        public static int ExceptionMap(Exception excepetion)
        {
            switch (excepetion)
            {
                case DirectoryNotFoundException:
                    {
                        return 404;
                    }
                case BadRequestException:
                    {
                        return 400;
                    }
                case UnauthorizedAccessException:
                    {
                        return 401;
                    }
                case ValidationException:
                    {
                        return 403;
                    }
                default:
                    {
                        return 500;
                    }
            }
        }
    }
}
