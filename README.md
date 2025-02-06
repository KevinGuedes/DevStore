# DevStore

## Highlights
* Unit Testing for domain entities.
* Integration Testing leveraging TestContainers to spin up a temporary PostgreSQL database within a Docker container.
* MediatR for request handling, ensuring separation of concerns and maintainability.
* Discount Calculation implemented using the Strategy behavioral pattern for flexible and scalable business rules.
* Verify Tests to test the response payload correctness, going beyond checking just sucessful status code for integration tests

## Design Patterns & Architecture
* Mediator Pattern (MediatR)
* All requests are handled through MediatR to promote loose coupling.
* Commands and queries are structured following the CQRS pattern.
* Strategy Pattern (Discount Logic)
* The discount logic follows the Strategy pattern, allowing for multiple discount strategies without modifying existing code.
* New discount types can be added by implementing the `IDiscountStrategy` interface.

## Future Improvements (If I Had More Time...)
If more time were available, the following enhancements would be implemented:
* Create the missing endpoints to complete full functionality.
* Add more test cases to improve coverage and reliability.
* Test all endpoints via integration tests to ensure end-to-end correctness.
* Integrate RabbitMQ for event-driven communication and message handling.

## To Run The Project
1. Clone the repo:
```sh
git https://github.com/KevinGuedes/DevStore.git
```

2. Access the folder and:
```sh
docker compose up -d
```

3. The API will be available in https://localhost:8081/swagger/index.html