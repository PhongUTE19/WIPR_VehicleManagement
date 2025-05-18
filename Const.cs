using System;
using System.Drawing;

namespace VehicleManagement
{
    class Const
    {
        public static readonly string PROJECT_PATH = @"D:\HCMUTE\Windows_Programming\QLSV\Resources\";
        public static readonly string RESOURCE_PATH = AppDomain.CurrentDomain.BaseDirectory + $@"..\..\Resources\";
        public static readonly Color textColor = Color.Black;
        public static readonly Color fromBackColor = Color.FromArgb(35, 38, 65);
        public static readonly Color errorTextColor = Color.Red;

        public static readonly string HCMUTE_EMAIL = "@student.hcmute.edu.vn";
        public static readonly string FROM_EMAIL = "buiduyphong2212@gmail.com";
        public static readonly string FROM_PASSWORD = "yxaf clhf fvkh xwpo";
        public static readonly string TO_EMAIL = "19110131" + HCMUTE_EMAIL;

        public class Title
        {
            public static readonly string INVALID = "Invalid";
            public static readonly string SUCCESS = "Success";
            public static readonly string FAIL = "Fail";
        }

        public class Message
        {
            public static readonly string EMPTY_FIELD = "Fields must not be empty";
            public static readonly string WRONG_FORMAT_FIELD = "Fields have wrong format";
            public class Account
            {
                public static readonly string USERNAME_EXIST = "Username has already existed.";
                public static readonly string EMAIL_EXIST = "Email has already existed.";

                public static readonly string LOGIN_FAIL = "Login account fail";
                public static readonly string REGISTER_SUCCESS = "Register account success";
                public static readonly string REGISTER_FAIL = "Register account fail";
                public static readonly string RESET_PASSWORD_SUCCESS = "Reset password success";
                public static readonly string RESET_PASSWORD_FAIL = "Reset password fail";
                public static readonly string SEND_CODE_SUCCESS = "Send code success";
                public static readonly string SEND_CODE_FAIL = "Send code fail";

                public static readonly string CODE_NOT_MATCH = "Code is not match";
                public static readonly string REPASSWORD_NOT_MATCH = "Password and re-password are not match";
                public static readonly string NOT_ACCEPT = "Account has not been accepted yet";
            }

            public class Vehicle
            {
                public static readonly string ADD_SUCCESS = "Add vehicle success.";
                public static readonly string ADD_FAIL = "Add vehicle fail.";
                public static readonly string DELETE_SUCCESS = "Delete vehicle success.";
                public static readonly string DELETE_FAIL = "Delete vehicle fail.";
                public static readonly string EDIT_SUCCESS = "Edit vehicle success.";
                public static readonly string EDIT_FAIL = "Edit vehicle fail.";
            }

            public class Staff
            {
                public static readonly string FIRSTNAME_CONTAIN_DIGIT = "Firstname must not contain digit.";
                public static readonly string LASTNAME_CONTAIN_DIGIT = "Lastname must not contain digit.";

                public static readonly string ADD_SUCCESS = "Add staff success.";
                public static readonly string ADD_FAIL = "Add staff fail.";
                public static readonly string DELETE_SUCCESS = "Delete staff success.";
                public static readonly string DELETE_FAIL = "Delete staff fail.";
                public static readonly string EDIT_SUCCESS = "Edit staff success.";
                public static readonly string EDIT_FAIL = "Edit staff fail.";
            }

            public class Job
            {
                public static readonly string FIRSTNAME_CONTAIN_DIGIT = "Firstname must not contain digit.";
                public static readonly string LASTNAME_CONTAIN_DIGIT = "Lastname must not contain digit.";

                public static readonly string ADD_SUCCESS = "Add job success.";
                public static readonly string ADD_FAIL = "Add job fail.";
                public static readonly string DELETE_SUCCESS = "Delete job success.";
                public static readonly string DELETE_FAIL = "Delete job fail.";
                public static readonly string EDIT_SUCCESS = "Edit job success.";
                public static readonly string EDIT_FAIL = "Edit job fail.";
            }
        }
    }
}
