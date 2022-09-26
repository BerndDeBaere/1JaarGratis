using Bogus;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage.Domain;
using EenJaarGratis.Services.Handlers.Requests;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers;

public class TestHandler :IRequestHandler<TestRequest>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IQuestionRepository _questionRepository;

    public TestHandler(IPlayerRepository playerRepository, IQuestionRepository questionRepository)
    {
        _playerRepository = playerRepository;
        _questionRepository = questionRepository;
    }

    public async Task<Unit> Handle(TestRequest request, CancellationToken cancellationToken)
    {
        // for (int i = 0; i < 60; i++)
        // {
        //     Faker faker = new Faker();
        //
        //     await _playerRepository.Insert(
        //         Service.Storage.Domain.Player.Create(faker.Person.FullName, faker.Person.Company.Name),
        //         cancellationToken);
        // }
        //
        // for (int i = 0; i < 60; i++)
        // {
        //     Faker faker = new Faker();
        //
        //     await _questionRepository.Insert(
        //         Service.Storage.Domain.Question.Create($"wie is de uitvoerder van {faker.Music.Locale}?", faker.Person.FullName, faker.Company.Locale, faker.Person.UserName, faker.Random.Int(0, 2)),
        //         cancellationToken);
        // }



        var players = await _playerRepository.Get(cancellationToken);
        var questions = await _questionRepository.Get(cancellationToken);

        Random random = new Random();
        foreach (var question in questions)
        {
            var aantalGroepen = random.Next(0, 3);
            for (int i = 0; i < aantalGroepen; i++)
            {
                var randomPlayers = players.OrderBy(x => random.Next()).Take(random.Next(1, 20)).ToList();
                QuestionGroup group = QuestionGroup.Create(question, randomPlayers);
                question.QuestionGroups.Add(group);
                await _questionRepository.Update(question, cancellationToken);
            }
        }
        
        
        
        
        return Unit.Value;
    }
}