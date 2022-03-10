using System;
using System.Collections.Generic;
using Hospital.Schedule.Model;
using Hospital.SharedModel;

namespace Hospital.Schedule.Repository
{
    interface IAnnouncementRepository: IGenericRepository<Announcement, int>
    {
        List<Announcement> GetByUserType(UserType userType);
        List<Announcement> GetIndividualAnnouncements(String userId);
    }
}
