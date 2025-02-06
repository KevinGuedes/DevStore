using Ambev.DeveloperEvaluation.Integration.Common;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.SharedContexts;

/// <summary>
/// Collection fixture for the application factory. 
/// Used to share the same application factory instance and therefore only one docker container will be created
/// </summary>
[CollectionDefinition(nameof(ApplicationFactoryCollection))]
public class ApplicationFactoryCollection : ICollectionFixture<ApplicationFactory>;
