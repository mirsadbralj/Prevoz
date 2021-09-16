using Prevoz.Model.Requests.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Feedback
{
    public interface IFeedbackService
    {
        List<Model.Feedback> Get();
        Model.Feedback GetById(int Id);
        Model.Feedback Insert(FeedbackUpsertRequest request);
    }
}
