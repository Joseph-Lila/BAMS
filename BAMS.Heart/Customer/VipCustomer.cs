using BAMS.Heart.Customer.Interfaces;

namespace BAMS.Heart.Customer;

public class VipCustomer : ICustomer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SsnNumber { get; set; }

    public VipCustomer(string firstName, string lastName, int ssnNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        SsnNumber = ssnNumber;
    }
}