using Digibooky.Domain.Lendings;
using System;
using System.Collections.Generic;
using System.Linq;
using Digibooky.API.Controllers.Lendings.Interfaces;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Lendings
{
    public class LendingMapper : ILendingMapper
    {

        public LendingDTO LendingToLendingDTO(Lending lending)
        {
            return new LendingDTO(lending);
        }

        //public Lending LendingDTOToLending(LendingDTO lendingDTO)
        //{
        //    return new Lending(lendingDTO);
        //}

        public List<LendingDTO> LendingListToLendingDTOList(List<Lending> lendingList)
        {
            List<LendingDTO> lendingDtoList = new List<LendingDTO>();

            foreach(Lending lending in lendingList)
            {
                lendingDtoList.Add(LendingToLendingDTO(lending));
            }

            return lendingDtoList;
        }

    }
}
