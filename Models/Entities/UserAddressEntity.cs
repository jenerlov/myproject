namespace myproject.Models.Entities;
    
    public class UserAddressEntity
    {
        public string UserId {get; set;} = null!;
        public UserEntity User {get; set;} = null!;
        public int AddressId {get; set;}
        public AddressEntity Address {get; set;} = null!;
    }
