namespace nthLesson7.Models
{
    public class NthEmployee
    {
        public int NthId { get; set; }             // Mã nhân viên
        public string NthName { get; set; }           // Tên nhân viên
        public DateTime NthBirthDay { get; set; }     // Ngày sinh
        public string NthEmail { get; set; }          // Email
        public string NthPhone { get; set; }          // Số điện thoại
        public decimal NthSalary { get; set; }        // Lương
        public bool NthStatus { get; set; }           // Trạng thái (đang làm việc hay nghỉ)
    }
}
