using CustomerSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSupport.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
    }
}
