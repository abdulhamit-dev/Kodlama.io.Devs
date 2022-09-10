using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.ProgramingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRule
    {
        private readonly IProgrammingLangugageRepository _programingLangugageRepository;

        public ProgrammingLanguageBusinessRule(IProgrammingLangugageRepository programingLangugageRepository)
        {
            _programingLangugageRepository = programingLangugageRepository;
        }

        public async Task ProgramingNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programingLangugageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programing langugage name exists.");
        }

    }
}
