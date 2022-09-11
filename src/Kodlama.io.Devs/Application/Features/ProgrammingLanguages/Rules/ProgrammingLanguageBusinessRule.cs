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

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRule
    {
        private readonly IProgrammingLanguageRepository _programingLangugageRepository;

        public ProgrammingLanguageBusinessRule(IProgrammingLanguageRepository programingLangugageRepository)
        {
            _programingLangugageRepository = programingLangugageRepository;
        }

        public async Task ProgramingNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programingLangugageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) 
                throw new BusinessException("Programing langugage name exists.");
        }

        public async Task ProgramingShouldExistWhenRequested(int id)
        {
            ProgrammingLanguage? result = await _programingLangugageRepository.GetAsync(b => b.Id == id);
            if (result == null) 
                throw new BusinessException("Programing langugage not found.");
        }
        public async Task ProgramingShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null)
                throw new BusinessException("Programing langugage not found.");
        }
    }
}
