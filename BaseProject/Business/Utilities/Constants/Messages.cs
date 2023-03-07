using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Constants
{
    public class Messages
    {
        public static string ItemAdded = "Item is added";
        public static string ItemRemoved = "Item is removed";
        public static string ItemNameInvalid = "Item Name is invalid!";
        public static string ItemUpdated = "Item is updated";
        public static string AllItems = "All items is listed";
        public static string ErrorItem = "Item could not taken";
        public static string GetAllByProductPrice = "Products between these interval are listed";
        public static string CategoryById = "Products are listed by Category Id";
        public static string ProductDetails = "Product details are listed";
        public static string ProductNumberByCategoryExceeded = "The number of units in a category should lower than 10";
        public static string ProductAlreadyExists = "This product names alreadye exists";
        public static string AllCategoriesTaken = "All categories are listed";
        public static string AuthorizationDenied = "Unauthorized Access Attempt";
        public static string UserRegistered = "User is registered";
        public static string UserNotFound = "User not found error";
        public static string PasswordError = "Password not correct";
        public static string SuccessfulLogin = "Login is successfull";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Access token is created";
    }
}
