using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trn.Foundation.Analytics.Models;

namespace Trn.Foundation.Analytics.Services
{
    public interface IContactService
    {
        bool CreateContact(UserModel user);
        bool IsKnownContact(string identifier);
        void AddPageEvent(string identifier, string pageId);
        void AddGoal(string identifier, string goalId);
        void AddOutcome(string identifier, string outcomeId);
    }
}
