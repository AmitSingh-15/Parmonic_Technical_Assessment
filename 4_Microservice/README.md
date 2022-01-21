# Parmonic_Technical_Assessment

4 Design

You are in-charge of developing a new backend (no UI) microservice to maintain a single-entry ledger. Write a detailed README file to describe:

· The microservice’s proposed design. Include a block diagram.

· How other services should communicate with this one.

· How it should be deployed to a cloud of your choice.

· Possible roadblocks, questions, unclear requirements.

· Shortcomings of the proposed design.

Amit S- 

IF we are planning to add many features in Ledger system then it makes sense to implement microservice architecture.

For this we should have seperate UI and backend projects. Ledger microservice has to be created as rest API which will communicate to DB and return endpoint which can be consumed in Web App, Mobile app etc.

For CI/CD we can use Teamcity or Jenkins which will run the Unit test cases as well.

We can deploy it on Azure web service.