﻿using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Question;

public class CreateQuestionRequest : IRequest<QuestionResponse>
{
    public string Question { get; set; } = null!;
    public string Possibilities { get; set; }= null!;
}