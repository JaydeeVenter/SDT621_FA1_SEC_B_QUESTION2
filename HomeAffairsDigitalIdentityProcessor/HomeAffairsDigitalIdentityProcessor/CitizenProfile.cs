using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAffairsDigitalIdentityProcessor
{
    //this class is for holding valuable information about the citizens like their names, ID's, etc
    public class CitizenProfile
    {
        //getter and setter for the required properties and stores it for each person:
        //stores the full name of the user
        public string FullName { get; set; }
        //stores the ID of the user
        public string IDNumber { get; set; }
        //stores the Age of the user
        public int Age { get; set; }
        //stores the Ctizen status of the user:
        public string CitizenshipStatus { get; set; }

        //this is the constructor 
        public CitizenProfile(string userName, string userId, string userStatus)
        {
            //this takes the name form the form and saves it.
            FullName = userName;
            //this takes the ID from the form and saves it
            IDNumber = userId;
            //returns users age
            CalculateUserAge();
            //this takes the citizenship status of the user and saves it.
            CitizenshipStatus = userStatus;
        }

        //this will calculate the users age:
        private void CalculateUserAge()
        {
            //this if is to handle errors if ID is empty
            if (string.IsNullOrEmpty(IDNumber) || IDNumber.Length < 13) return;
            //this gets the year inwhich the user was born in.
            string yearFromID = IDNumber.Substring(0, 2);
            //this converts that 'string' into a int
            //YOB = Year Of Birth
            int shortYOBFromID = int.Parse(yearFromID);


            //the block of code below will calculate whether the user was born in 1900's or 2000's

            //gets current year:
            int currentYear = DateTime.Now.Year;
            int currentYearShort = currentYear % 100;

            int longYOB = (shortYOBFromID <= currentYearShort)? 2000 + shortYOBFromID : 1900 + shortYOBFromID;
            //this hets the year in which the user was born.
            Age = currentYear - longYOB;
        }

        //this method below is the ValidateID() Method
        public string ValidateID()
        {
            //checks and ensures that the id is exactly 13 digits:
            if (IDNumber.Length != 13)
                return "ID Number is not valid, please reenter carefully!";
            //checks whether the id number entered is fully numeric
            if (!long.TryParse(IDNumber, out _))
                return "ID Number is not valid, please ensure that only digits are entered!";
            //this uses the calculated age as a validation method
            if (Age <= 0 || Age > 110)
                return "Invalid Age!";
            //only if all above validation methods are passed, this will print
            return $"Valid ID. Citizen is {Age} years old";
        }
    }
}
