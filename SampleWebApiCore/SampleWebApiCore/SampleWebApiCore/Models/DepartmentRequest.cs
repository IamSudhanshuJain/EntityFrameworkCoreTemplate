using System.ComponentModel.DataAnnotations;

namespace SampleWebApiCore.Models
{
    public class DepartmentRequest
    {
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}
