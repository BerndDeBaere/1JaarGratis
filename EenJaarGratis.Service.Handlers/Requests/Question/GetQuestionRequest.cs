﻿using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Question;

public class GetQuestionRequest : IRequest<List<QuestionResponse>>
{
}