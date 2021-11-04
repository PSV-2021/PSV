using System;
using System.Collections.Generic;
using Model;

namespace Integration_API.Repository.Interfaces
{
    interface IAnnouncementRepository: IGenericRepository<Announcement, int>
    {
        List<Announcement> GetByUserType(UserType userType);
        List<Announcement> GetIndividualAnnouncements(String userId);
    }
}
