using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public static class IdValidator
{
    public static IRuleBuilderOptions<T, Guid> MustBeAValidId<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        => ruleBuilder.NotEqual(Guid.Empty);
}
