using BookLive.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLive.Application.Services.Interfaces;

public interface IAuthorService
{
    Task AddAuthor(Author author);
}
