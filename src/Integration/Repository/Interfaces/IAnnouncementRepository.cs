using System;
using System.Collections.Generic;
using Model;

namespace Integration.Repository.Interfaces
{
    interface IAnnouncementRepository: IGenericRepository<Announcement, int>
    {
        List<Announcement> GetByUserType(UserType userType);
        List<Announcement> GetIndividualAnnouncements(String userId);
    }
}
