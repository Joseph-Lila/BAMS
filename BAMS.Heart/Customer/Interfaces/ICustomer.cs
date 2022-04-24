namespace BAMS.Heart.Customer.Interfaces;

public interface ICustomer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SsnNumber { get; set; }
}