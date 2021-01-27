using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

using System.Net;
using System.Configuration;
using System.Threading.Tasks;

using PayFast;
using PayFast.AspNet;

using Auction_Prop_Buyers.Models.DisplayMadels;
using Microsoft.AspNet.Identity;

namespace Auction_Prop_Buyers.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        #region Fields

        private readonly PayFastSettings payFastSettings;

        #endregion Fields

        #region Constructor

        public PaymentController()
        {
            this.payFastSettings = new PayFastSettings();
            this.payFastSettings.MerchantId = ConfigurationManager.AppSettings["MerchantId"];
            this.payFastSettings.MerchantKey = ConfigurationManager.AppSettings["MerchantKey"];
            this.payFastSettings.PassPhrase = ConfigurationManager.AppSettings["PassPhrase"];
            this.payFastSettings.ProcessUrl = ConfigurationManager.AppSettings["ProcessUrl"];
            this.payFastSettings.ValidateUrl = ConfigurationManager.AppSettings["ValidateUrl"];
            this.payFastSettings.ReturnUrl = ConfigurationManager.AppSettings["ReturnUrl"];
            this.payFastSettings.CancelUrl = ConfigurationManager.AppSettings["CancelUrl"];
            this.payFastSettings.NotifyUrl = ConfigurationManager.AppSettings["NotifyUrl"];
        }

        #endregion Constructor

        #region Methods

        public ActionResult Index()
        {
            return View();
        }
           
        public ActionResult Deposit()
        {
            return OnceOff( 5000,0);
        }
        
        public ActionResult AdminFees(int id)
        {
            return OnceOff(150, id);
        }
        public ActionResult AdminAndDeposit(int id)
        {
            return OnceOff(5150,id);
        }

       



        public ActionResult OnceOff(double amount,  int idd)
        {
            var onceOffRequest = new PayFastRequest(this.payFastSettings.PassPhrase);

            // Merchant Details
            onceOffRequest.merchant_id = this.payFastSettings.MerchantId;
            onceOffRequest.merchant_key = this.payFastSettings.MerchantKey;
         
            onceOffRequest.cancel_url = this.payFastSettings.CancelUrl;
            onceOffRequest.notify_url = this.payFastSettings.NotifyUrl;

            onceOffRequest.email_address = "cmmadeleyn@gmail.com";

            // Transaction Details
            onceOffRequest.m_payment_id = idd.ToString();
            onceOffRequest.amount = amount;
            onceOffRequest.amount = 10;
            onceOffRequest.item_name = "Once off option";
            onceOffRequest.item_description = "Auction-prop Regestrasion fees.";

            // Transaction Options
            onceOffRequest.email_confirmation = true;
            onceOffRequest.confirmation_address = "sbtu01@payfast.co.za";
            // Transaction Options
            onceOffRequest.email_confirmation = true;
            onceOffRequest.confirmation_address = "";
              string rI = "";
            if (idd !=0)
            {


                rI = idd.ToString();

            }
            if(amount>=5000)
            {
                try
                {
                    rI += "-5000";
                }
                catch { }
               
            }


            onceOffRequest.return_url = this.payFastSettings.ReturnUrl+rI;
            var redirectUrl = $"{this.payFastSettings.ProcessUrl}{onceOffRequest.ToString()}";

     
            return Redirect(redirectUrl);
        }

       

        public ActionResult Return(string id )
        {
            string[] s = id.Split('-');
            int i = 0;
            if(id.Contains("-5000"))
            {
                try
                {
                    Deposit dep = new Deposit
                    {
                        BuyerID = User.Identity.GetUserId(),
                        DateOfPayment = DateTime.Now,
                        Paid = true,
                        DepositReturned = false,
                        ProofOfPaymentPath = "none",
                        ProofOfReturnPayment = "none",
                        Amount = 5000

                    };
                    APILibrary.APIMethods.APIPost<Deposit>(dep, "Deposits");
                }
                catch { }


            }
            
            if(s[0] !="" )
            {
                i = Convert.ToInt32(s[0]);

                try
                {
                    AdminFee fees = new AdminFee
                    {
                        PaymentID = i,
                        ProofOfPaymentPath = "none",
                        DateOfPayment = DateTime.Now,
                        Amount = 150

                    };
                    APILibrary.APIMethods.APIPost<AdminFee>(fees, "AdminFees");
                    AuctionRegistration AR = APILibrary.APIMethods.APIGet<AuctionRegistration>(i.ToString(), "AuctionRegistrations");
                    return View(AR);
                }
                catch { }

            }
            return View();

        }

        [HttpPost]
        public void _PayAdminFees(int id, AuctionRegistration reg)
        {
            AdminFee fees = new AdminFee
            {
                PaymentID = reg.id,
                ProofOfPaymentPath = "none",
                DateOfPayment = DateTime.Now,
                Amount = 150

            };
            APILibrary.APIMethods.APIPost<Deposit>(fees, "AdminFees");



        }

        public ActionResult Cancel()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Notify([ModelBinder(typeof(PayFastNotifyModelBinder))]PayFastNotify payFastNotifyViewModel)
        {
            payFastNotifyViewModel.SetPassPhrase(this.payFastSettings.PassPhrase);

            var calculatedSignature = payFastNotifyViewModel.GetCalculatedSignature();

            var isValid = payFastNotifyViewModel.signature == calculatedSignature;

            System.Diagnostics.Debug.WriteLine($"Signature Validation Result: {isValid}");

            // The PayFast Validator is still under developement
            // Its not recommended to rely on this for production use cases
            var payfastValidator = new PayFastValidator(this.payFastSettings, payFastNotifyViewModel, IPAddress.Parse(this.HttpContext.Request.UserHostAddress));

            var merchantIdValidationResult = payfastValidator.ValidateMerchantId();

            System.Diagnostics.Debug.WriteLine($"Merchant Id Validation Result: {merchantIdValidationResult}");

            var ipAddressValidationResult = payfastValidator.ValidateSourceIp();

            System.Diagnostics.Debug.WriteLine($"Ip Address Validation Result: {merchantIdValidationResult}");

            // Currently seems that the data validation only works for successful payments
            if (payFastNotifyViewModel.payment_status == PayFastStatics.CompletePaymentConfirmation)
            {
                var dataValidationResult = await payfastValidator.ValidateData();

                System.Diagnostics.Debug.WriteLine($"Data Validation Result: {dataValidationResult}");
            }

            if (payFastNotifyViewModel.payment_status == PayFastStatics.CancelledPaymentConfirmation)
            {
                System.Diagnostics.Debug.WriteLine($"Subscription was cancelled");
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Error()
        {
            return View();
        }

        #endregion Methods
    }
}