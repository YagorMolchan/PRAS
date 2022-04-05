using PRAS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRAS.Interfaces
{
    public interface INewRepository
    {
        List<New> News { get;  }

        List<New> GetNews(int page, int pageSize);

        List<New> GetNews(int pageSize);

        New GetNew(int id);

        Task Create(New n);

        Task Edit(New n);

        Task Delete(New n);

    }
}
