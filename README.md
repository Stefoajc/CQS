Series of code changes from Monolithic Service Class to CQS compliant design  
1.Monolithic Service Class (Entity Centric Use Case).  

2.SRP applied to the Monolithic Service Class (Split the broad interface to one method interfaces).  
  IProductService here is facade interface.  
  Product service forward the work to the fine grain worker classes. (Implementors of one method interfaces)  
  
3.CQS design applied.  
  - Single method interfaces changing the state are merged in ICommandHandler interface (They shouldn't return result)  
  - Single method interfaces getting information from the application are merged in IQueryHandler (They must not change the state)  
4. CQS design with generics  
  - ICommandHandler is changed to ICommandHandler<TCommand> (TCommand is the type of command)  
  - IQueryHandler is changed to IQueryHandler<TQuery, TResult>  
    (TQuery is the type of the  input parameter, TResult is the type of the result of the query)  
  - This way we add compile time checks and bypass casting from and to  
