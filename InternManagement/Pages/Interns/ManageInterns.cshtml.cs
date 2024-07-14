using IMSBussinessObjects;
using IMSRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages.Interns
{
    public class ManageInternModel : PageModel
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IInternRepository _internRepository;

        public ManageInternModel(ITeamRepository teamRepository, IInternRepository internRepository)
        {
            _teamRepository = teamRepository;
            _internRepository = internRepository;
        }

        [BindProperty(SupportsGet = true)]
        public int? TeamId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? InternId { get; set; }

        public List<SelectListItem> TeamsSelectList { get; set; }
        public List<SelectListItem> InternsSelectList { get; set; }

        public Team SelectedTeam { get; set; }
        public Intern SelectedIntern { get; set; }

        public void OnGet()
        {
            TeamsSelectList = _teamRepository.GetAllTeams()
                .Select(t => new SelectListItem
                {
                    Value = t.TeamId.ToString(),
                    Text = t.TeamName
                })
                .ToList();

            if (TeamId.HasValue)
            {
                SelectedTeam = _teamRepository.GetTeamById(TeamId.Value);
                InternsSelectList = _internRepository.GetInternByTeamId(TeamId.Value)
                    .Select(i => new SelectListItem
                    {
                        Value = i.InternId.ToString(),
                        Text = i.FullName
                    })
                    .ToList();
            }
            if (InternId.HasValue)
            {
                SelectedIntern = _internRepository.GetInternById(InternId.Value);
            }
        }
        public IActionResult OnPostDelete(int id)
        {
            var intern = _internRepository.GetInternById(id);
            if (intern != null)
            {
                _internRepository.RemoveIntern(id);
            }
            return RedirectToPage();
        }
    }
}