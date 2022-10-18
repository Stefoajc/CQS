Series of code changes from Monolithic Service Class to CQS compliant design  

CQS.DB.Models, CQS.Models, CQS.Repositories, CQS.UI are helper projects giving some context to the Application

1. CQS.MonolithicImplementation  - Monolithic Service Class (Entity Centric Use Case).  

2. CQS.SOLID - SRP applied to the Monolithic Service Class (Split the broad interface to one method interfaces).  
  IProductService here is facade interface.  
  Product service forward the work to the fine grain worker classes. (Implementors of one method interfaces)  
  
3. CQS.FinalWithCasting - CQS design applied.  
  - Single method interfaces changing the state are merged in ICommandHandler interface (They shouldn't return result)  
  - Single method interfaces getting information from the application are merged in IQueryHandler (They must not change the state)  
4. CQS.FinalGeneric - CQS design with generics  
  - ICommandHandler is changed to ICommandHandler<TCommand> (TCommand is the type of command)  
  - IQueryHandler is changed to IQueryHandler<TQuery, TResult>  
    (TQuery is the type of the  input parameter, TResult is the type of the result of the query)  
  - This way we add compile time checks and bypass casting from and to  

5. CQS.MediatR - CQS using MediatR library
  - MediatR is one of the most popular libraries imlementing the Mediator pattern along with CQS
  - IRequest<TResult> is the interface which represents both commands and queries
  - IRequestHandler<IRequest<TResult>, TResult> is the interface where the implementation of the functionality takes place