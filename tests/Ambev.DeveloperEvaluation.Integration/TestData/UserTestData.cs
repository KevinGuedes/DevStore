using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Integration.TestData;

public static class UserTestData
{
    private const int DEFAULT_TEST_USER_SEED = 1;

    public static User GetDefaultUser()
    {
        return new Faker<User>()
            .RuleFor(u => u.Id, f => f.Random.Guid())
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.Password, f => $"Test@{f.Random.Number(100, 999)}")
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Phone, f => $"+55{f.Random.Number(11, 99)}{f.Random.Number(100000000, 999999999)}")
            .RuleFor(u => u.Status, _ => UserStatus.Active)
            .RuleFor(u => u.Role, _ => UserRole.Customer)
            .UseSeed(DEFAULT_TEST_USER_SEED);
    }
}
