using Digibooky.Domain.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Authors.Interfaces
{
    interface IAuthorMapper
    {
        List<AuthorDTO> ListofAuthorToDTOObject(List<Author> givenListOfAuthors);
        AuthorDTO AuthorToDTO(Author givenBook);
    }
}
