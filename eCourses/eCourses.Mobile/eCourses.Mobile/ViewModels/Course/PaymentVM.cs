﻿using Acr.UserDialogs;
using eCourses.Mobile.Helpers;
using eCourses.Mobile.Models;
using eCourses.Mobile.ViewModels.SearchCourse;
using eCourses.Mobile.Views.Account;
using eCourses.Mobile.Views.Course;
using eCourses.Mobile.Views.SearchCourse;
using eCourses.Model;
using eCourses.Model.Request;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.Course
{
    public class PaymentVM:BaseVM
    {
        private readonly APIService buyCourseService = new APIService("BuyCourse");
        private readonly APIService transactionService = new APIService("Transaction");
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public PaymentVM()
        {

        }
        public PaymentVM(INavigation nav)
        {
            this.Navigation = nav;
            SubmitCommand = new Command(async () => await BuyCourse());
        }

        private readonly INavigation Navigation;
        public MCourse Course { get; set; }

        private string StripeTestApiKey = "pk_test_51ITsWFJhqfSL3GBcw3lQq0WwQqPGbri16hs24aIootbfGr4U2bHqzpNCc5oexs9hOf7wxVusWxr70YDc06xvlDdL00CejvATXy";

        private CreditCard _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;
        private string _number;
        private string _cvc;

        MUser user = SignedInUser.User;
        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }
        public string Cvc
        {
            get { return _cvc; }
            set { SetProperty(ref _cvc, value); }
        }
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }
        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }
        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }
        public CreditCard CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }
        public ICommand SubmitCommand { get; set; }
        private async Task<string> CreateTokenAsync()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeTestApiKey;

                var Tokenoptions = new TokenCreateOptions()
                {
                    Card = new TokenCardOptions()
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = user.FirstName + " " + user.LastName,
                        AddressLine1 = "Orašje L21",
                        AddressLine2 = "11",
                        AddressCity = "Konjic",
                        AddressZip = "88400",
                        AddressState = "Konjic12",
                        AddressCountry = "Bosna i Hercegovina",
                        Currency = "usd",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> MakePaymentAsync(string token)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51ITsWFJhqfSL3GBcXqWrUGofCVqfLCVWlzB12obhiSRf50cr6HkFhs8pFMKw19AXwPqy1MxTmWpTHffMZLCYFQGI00dP6lZAJl";

                var options = new ChargeCreateOptions();

                options.Amount = Convert.ToInt64(Course.Price) * 100;
                options.Currency = "usd";
                options.Description = Course.Name;
                options.Source = stripeToken.Id;
                options.StatementDescriptor = "Custom descriptor";
                options.Capture = true;
                options.ReceiptEmail = user.Email.ToString();
                var service = new ChargeService();
                Charge charge = service.Create(options);
                UserDialogs.Instance.Alert("Purchase was successful!");
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(Course.Name + " (CreateCharge)" + ex.Message);
                throw ex;
            }
        }
        public async Task BuyCourse()
        {
            var courses = await buyCourseService.Get<List<MBuyCourse>>(null);
            bool have = false;
            foreach (var x in courses)
                if (x.UserID == user.UserID && Course.CourseID == x.CourseID)
                    have = true;

            if (have == true)
            {
                await App.Current.MainPage.DisplayAlert("Information", "You already bought this course!", "OK");
            }
            else
            {
                if (ExpMonth == null || ExpMonth == "" || ExpYear == null || ExpYear == "" || Number == null || Number == "" || Cvc == null || Cvc == "")
                {
                    UserDialogs.Instance.Alert("You have to fill all fields!", "Payment failed", "OK");
                    return;
                }
                if (ExpMonth != null || ExpMonth != "" || ExpYear != null || ExpYear != "" || Number != null || Number != "" || Cvc != null || Cvc != "")
                {
                    if (!IsDigitsOnly(ExpMonth) || !IsDigitsOnly(ExpMonth) || !IsDigitsOnly(Number) || !IsDigitsOnly(Cvc))
                    {
                        UserDialogs.Instance.Alert("You can't use letters!", "Payment failed", "OK");
                        return;
                    }
                }
                CreditCardModel = new CreditCard();
                CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth);
                CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);
                CreditCardModel.Number = Number;
                CreditCardModel.Cvc = Cvc;
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;
                try
                {
                    UserDialogs.Instance.ShowLoading("Payment processing ...");
                    await Task.Run(async () =>
                    {
                        var Token = CreateTokenAsync();
                        Console.Write(Course.Name + "Token :" + Token);
                        if (Token.ToString() != null)
                        {
                            IsTransectionSuccess = await MakePaymentAsync(Token.Result);
                        }
                        else
                        {
                            UserDialogs.Instance.Alert("Bad card credentials", null, "OK");
                        }
                    });
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert(ex.Message, null, "OK");
                    Console.Write(Course.Name + ex.Message);
                }
                finally
                {
                    if (IsTransectionSuccess)
                    {
                        var request = new BuyCourseRequest()
                        {
                            DateOfBuying = DateTime.Now,
                            CourseID = Course.CourseID,
                            UserID = user.UserID,
                            Price = Course.Price,
                            Username = user.Username,
                            CourseName = Course.Name
                        };

                        var TransReq = new TransactionUpsertRequest
                        {
                            CourseID = Course.CourseID,
                            UserID=user.UserID,
                            Price=Course.Price,
                            TransactionDate=DateTime.Now
                        };
                        await transactionService.Insert<MTransaction>(TransReq);
                        await buyCourseService.Insert<MBuyCourse>(request);
                        await Navigation.PushAsync(new CoursesPage());
                        Console.Write(Course.Name + "Payment Successful");
                        
                        UserDialogs.Instance.HideLoading();
                        
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        //UserDialogs.Instance.Alert("Oops, something went wrong", "Payment failed", "OK");
                        Console.Write(Course.Name + "Payment Failure ");
                    }
                }
            }
        }
    }
}

