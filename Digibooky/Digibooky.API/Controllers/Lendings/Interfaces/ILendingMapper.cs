using Digibooky.Domain.Lendings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Lendings.Interfaces
{
    public interface ILendingMapper
    {
        LendingDTO LendingToLendingDTO(Lending lending);
        List<LendingDTO> LendingListToLendingDTOList(List<Lending> lendingList);
    }
}
