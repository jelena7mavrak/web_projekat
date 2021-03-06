﻿using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static WebApp.Models.Enums;

namespace WebApp.Models
{
    // Models used as parameters to AccountController actions.
    public class LoginBindingModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }


    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "BirthdayDate")]
        public string BirthdayDate { get; set; }

        [Required]
        [Display(Name = "PassengerType")]
        public PassengerType PassengerType { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ActivePricelistBindingModel
    {
        [Required]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "HourlyPrice")]
        public double HourlyPrice { get; set; }
        [Required]
        [Display(Name = "DailyPrice")]
        public double DailyPrice { get; set; }
        [Required]
        [Display(Name = "MonthlyPrice")]
        public double MonthlyPrice { get; set; }
        [Required]
        [Display(Name = "AnnualPrice")]
        public double AnnualPrice { get; set; }
    }

    public class LineBindingModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "RouteNumber")]
        public int RouteNumber { get; set; }

        [Required]
        [Display(Name = "RouteType")]
        public RouteType RouteType { get; set; }

    }
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class PersonRegisterBindingModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Birthday Date")]
        public DateTime BirthdayDate { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }

    public class PricelistBindingModel
    {
        [Required]
        [Display(Name ="StartDate")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [Display(Name = "IsActive")]
        public bool InUse { get; set; }
    }

    public class PricelistItemBindingModel
    {
        [Required]
        [Display(Name = "HourlyPrice")]
        public double HourlyPrice { get; set; }
        [Required]
        [Display(Name = "DailyPrice")]
        public double DailyPrice { get; set; }
        [Required]
        [Display(Name = "MonthlyPrice")]
        public double MonthlyPrice { get; set; }
        [Required]
        [Display(Name = "AnnualPrice")]
        public double AnnualPrice { get; set; }
    }
}