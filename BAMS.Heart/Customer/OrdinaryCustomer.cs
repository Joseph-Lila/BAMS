using BAMS.Heart.Customer.Interfaces;

namespace BAMS.Heart.Customer;

public class OrdinaryCustomer : ICustomer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SsnNumber { get; set; }

    public OrdinaryCustomer(string firstName, string lastName, int ssnNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        SsnNumber = ssnNumber;
    }
}