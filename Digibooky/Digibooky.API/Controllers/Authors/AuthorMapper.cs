using Digibooky.API.Controllers.Authors.Interfaces;
using Digibooky.Domain.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Authors
{
    public class AuthorMapper : IAuthorMapper
    {
        public List<AuthorDTO> ListofAuthorToDTOObject(List<Author> givenListOfAuthors)
        {
            List<AuthorDTO> dtos = new List<AuthorDTO>();

            foreach (var author in givenListOfAuthors)
            {
                dtos.Add(AuthorToDTO(author));
            }
            return dtos;
        }

        public AuthorDTO AuthorToDTO(Author givenAuthor)
        {
            return new AuthorDTO
            {
                AuthorId = givenAuthor.AuthorId,
                FirstName = givenAuthor.FirstName,
                LastName = givenAuthor.LastName
            };
        }
    }
}
