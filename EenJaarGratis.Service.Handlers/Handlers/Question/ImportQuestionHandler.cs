using System.Globalization;
using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using CsvHelper;
using CsvHelper.Configuration;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Question;

public class ImportQuestionHandler : IRequestHandler<ImportQuestionRequest>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public ImportQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ImportQuestionRequest request, CancellationToken cancellationToken)
    {
        
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };
        
        using StringReader textReader = new StringReader(request.Csv);
        using CsvReader csv = new CsvReader(textReader, config);
 
            var questionRecords = csv.GetRecords<ImportQuestionObject>().ToList();
            var questionEntities = questionRecords.Select(qr =>
            {
                string[] answers = { qr.Antwoord1, qr.Antwoord2, qr.Antwoord3 };
                Shuffle(answers);
                return Service.Storage.Domain.Question.Create(qr.Vraag, answers[0], answers[1], answers[2],
                    Array.IndexOf(answers, qr.Antwoord1));
            }).ToList();

            foreach (var questionEntity in questionEntities)
            {
                await _questionRepository.Insert(questionEntity, cancellationToken);
            }


        return Unit.Value;

    }

    private void Shuffle<T>(T[] array)
    {
        Random random = Random.Shared;

        for (int i = 0; i < array.Length - 1; ++i)
        {
            int r = random.Next(i, array.Length);
            (array[r], array[i]) = (array[i], array[r]);
        }
    }

    private record ImportQuestionObject
    {
        public string Vraag { get; set; }
        public string Antwoord1 { get; set; }
        public string Antwoord2 { get; set; }
        public string Antwoord3 { get; set; }
    }
}