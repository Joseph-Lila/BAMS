#Task

-----

##Testing - Part 2

>Bank Account Management System

*Create structure of classes that allow you to manage bank operations 
(Deposit/Withdraw) and some options related 
to bank account functionality.*

###Description:

There are few types of Customers: ordinary, entrepreneur, VIP. 

Everyone has its own interest rate depends on card balance.

*Everyone has its own interest rate depends on transactions history.

Every customer can deposit any amount to account.

Ordinary customer can withdraw once-off only particular money. 

Define the values with your own preferences.

Every customer can request credit card but amount might be restricted 
and interest rate depends on conditions.

There is Credit Department and its responsibility for 
making decision about credit which can be given to customers.

Credit card could be released via Bank Account but decision 
maker is Credit Department.

Account should have ability to show balance information with first and
last name (capitalized), ssn number i the following format
{xxx}-{xx}-{xxxx} and balance.

Basement you can find below:

```
public class Logger
{
    public static void Log(string message)
    {
        Console.WriteLine(message); // format might be extended
    }
}

public class BankAccount
{
    // (+) - public class member
    //
    // +Deposit
    // +Withdraw
    // ... other methods you need to define based on requirements
    
    //Please add logger to every operation you use (not necessary to plugIn nugets here)
    
    // Some methods in hierarchy throw an exaption, check the case in unit tests
}
```

Notes:

- Cover with Unit Tests all functions you have implemented.
- Code coverage should be close to 80-90%.
- Create library and project with tests using the following naming convention:

   {Short Name Library}.csproj

   {Short Name Library}.Tests.csproj
- Choose xUnit Tes Framework for the task
- Choose NSubstitute Mock Framework for the task
- Plug in Fluent Assertion and use it for assertions
- Use Coverlet Nuget package to check code Coverity
- Please, Include into the last commit run https://github.com/danielpalme/ReportGenerator to add detailed report with coverage information.


(*) - optional task



