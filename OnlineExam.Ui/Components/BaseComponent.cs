using Microsoft.AspNetCore.Components;
using OnlineExam.Ui.DTO.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineExam.Ui.Components
{
    public class BaseComponent : ComponentBase
    {
        protected List<string> Errors { get; set; } = new();
        private PaginateRequestDTO PaginateRequestDTO = new PaginateRequestDTO();
        public void SetErrors(List<string> errors)
        {
            Errors.Clear();
            if (errors != null)
            {
                Errors.AddRange(errors);
            }
            StateHasChanged();
        }
        public void SetErrors(string error)
        {
            Errors.Clear();
            if (error != null)
            {
                Errors.Add(error);
            }
            StateHasChanged();
        }
        public void SetPaginateOrder(string orderBy,bool descending)
        {
            PaginateRequestDTO.SortBy=orderBy;
            PaginateRequestDTO.Descending = descending;
        }
        public PaginateRequestDTO GetDefultPaginate()
        {
            return PaginateRequestDTO;
        }
        public int GetPageNumber()
        {
            return PaginateRequestDTO.PageNumber;
        }
        public int GetPageCount()
        {
            return PaginateRequestDTO.PageCount;
        }
        public void SetPageNumber(int pageNumber)
        {
            PaginateRequestDTO.PageNumber = pageNumber;
        }
        public void SetPageCount(int pageCount)
        {
            PaginateRequestDTO.PageCount = pageCount;

        }
    }
}
