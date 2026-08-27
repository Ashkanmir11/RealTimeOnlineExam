using OnlineExam.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Test.Handlers;
using OnlineExam.Test.Models.ClassRoom;
using Shouldly;
namespace OnlineExam.Test
{
    public class ClassRoomTest
    {
        [Fact]
        public void CreateClassRoom()
        {
            var model = new CreateClassRoomDTO()
            {
                ClassName = "سلام",
            };
            bool result = new ClassRoomHandler().Craete(model);

            Assert.True(result);
            result.ShouldBeTrue();
        }
    }

}
