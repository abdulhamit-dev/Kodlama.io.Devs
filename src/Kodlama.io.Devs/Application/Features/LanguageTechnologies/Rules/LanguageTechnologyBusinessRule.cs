using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Rules
{
    public class LanguageTechnologyBusinessRule
    {
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

        public LanguageTechnologyBusinessRule(ILanguageTechnologyRepository languageTechnologyRepository)
        {
            _languageTechnologyRepository = languageTechnologyRepository;
        }

        public async Task LanguageTechnologyNameCanNotBeDuplicatedWhenInserted(string name,int programminglanguageId)
        {
            IPaginate<LanguageTechnology> result = await _languageTechnologyRepository.GetListAsync(x => x.Name == name && x.ProgrammingLanguageId== programminglanguageId);
            if (result.Items.Any())
                throw new BusinessException("Language technology name exists.");
        }
    }
}
