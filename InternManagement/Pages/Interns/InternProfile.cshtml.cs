using IMSBussinessObjects;
using IMSRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Interns
{
    public class InternProfileModel : PageModel
    {
        private readonly IInternRepository _internRepository;
        private readonly IAssignmentRepository _assignmentRepository;
        public InternProfileModel(IInternRepository internRepository, IAssignmentRepository assignmentRepository)
        {
            _internRepository = internRepository;
            _assignmentRepository = assignmentRepository;
        }
        [BindProperty(SupportsGet = true)]
        public int? InternId { get; set; }
        public List<Assignment> Assignments { get; set; }
        [BindProperty]
        public Intern SelectedIntern { get; set; }
        public void OnGet()
        {
            if (InternId.HasValue)
            {
                SelectedIntern = _internRepository.GetInternById(InternId.Value);
                Assignments = _assignmentRepository.GetAssignmentByInternId(InternId.Value);
            }
        }
    }
}
