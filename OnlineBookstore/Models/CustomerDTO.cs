namespace OnlineBookstore.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }     
        public string FisrtName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; }  
        public string Phone { get; set; }      
        public DateTime DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? PasswordHash { get; set; }
        public string City { get; set; }  
        public string Street { get; set; }  
        public string AddressLine { get; set; }   
        public string PostalCode { get; set; }
        public string RoleName { get; set; }

    }
}
