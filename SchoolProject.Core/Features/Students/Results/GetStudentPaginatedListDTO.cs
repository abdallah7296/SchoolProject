namespace SchoolProject.Core.Features.Students.Results
{
    public class GetStudentPaginatedListDTO
    {
        public int StudID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DepartName { get; set; }

        public GetStudentPaginatedListDTO(int StudId, string? name, string? address, string departName)
        {
            StudID = StudId;
            Name = name;
            Address = address;
            DepartName = departName;
        }
    }
}
