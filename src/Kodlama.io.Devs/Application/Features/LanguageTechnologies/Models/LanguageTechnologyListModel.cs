using Application.Features.LanguageTechnologies.Dtos;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Models
{
    public class LanguageTechnologyListModel: BasePageableModel
    {
        public IList<LanguageTechnologyListDto> Items { get; set; }
    }
}
