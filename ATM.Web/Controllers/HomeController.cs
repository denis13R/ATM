using ATM.BusinessLogic.Interfaces;
using ATM.BusinessLogic.Models;
using ATM.BusinessLogic.Services;
using ATM.DataAccess;
using ATM.DataAccess.Repositories;
using ATM.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace ATM.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICardService _cardService;
        private IOperationService _operationService;

        public HomeController()
            : this(new CardService(new CardRepository(new ATMContext())),
                  new OperationService(new OperationRepository(new ATMContext())))
        {
        }

        public HomeController(ICardService cardService, IOperationService operationService)
        {
            _cardService = cardService;
            _operationService = operationService;
        }

        [HttpGet]
        public ActionResult InputCard()
        {
            Session["incorrectPinCounter"] = 4;
            return View("Start");
        }

        [HttpGet]
        public ActionResult GetCard(string cardNum)
        {
            string errorMessage = "Unfortunately, this card doesn`t exist!";
            if (!string.IsNullOrEmpty(cardNum))
            {
                CardModel model = _cardService.GetCardByNum(cardNum);
                if (model == null)
                {
                    return View("Error", CreateErrorModel(null, errorMessage, "Home", "InputCard"));
                }
                else if(!model.IsActive)
                {
                    errorMessage = "Unfortunately, this card is blocked!";
                    return View("Error", CreateErrorModel(null, errorMessage, "Home", "InputCard"));
                }
                return RedirectToAction("PinCode", "Home", new { cardNum = cardNum });
            }
            return View("Error", CreateErrorModel(null, errorMessage, "Home", "InputCard")); 
        }

        [HttpGet]
        public ActionResult PinCode(string cardNum)
        {
            CardModel model = _cardService.GetCardByNum(cardNum);
            return View("PinInput", model);
        }

        [HttpGet]
        public ActionResult VerifyPin(string cardNum, string pinCode)
        {
            CardModel model = _cardService.GetCardByNum(cardNum);
            if (model.PinCode == pinCode)
            {
                return RedirectToAction("Operations", "Home", new { cardNum = cardNum });
            }
            Session["incorrectPinCounter"] = Convert.ToInt32(Session["incorrectPinCounter"]) - 1;
            string errorMessage = $"Incorrect PIN! You have {Session["incorrectPinCounter"]} attempts to input correct PIN";
            if (Convert.ToInt32(Session["incorrectPinCounter"]) == 0)
            {
                errorMessage = "Unfortunately, this card is blocked!";
                return View("Error", CreateErrorModel(cardNum, errorMessage, "Home", "PinCode"));
            }
            return View("Error", CreateErrorModel(cardNum, errorMessage, "Home", "PinCode")); 
        }

        [HttpGet]
        public ActionResult Operations(string cardNum)
        {
            CardModel model = _cardService.GetCardByNum(cardNum);
            return View("Operations", model);
        }

        [HttpGet]
        public ActionResult Balance(string cardNum)
        {
            CardModel model = _cardService.GetCardByNum(cardNum);
            DateTime dateTime = DateTime.Now;
            _operationService.NoteOperation(model.CardId, cardNum, "Balance checking", 0, dateTime);
            return View("Balance", CreateBalanceModel(cardNum, dateTime, model.Balance, "Home", "Operations"));
        }

        [HttpGet]
        public ActionResult InputAmountOfMoney(string cardNum)
        {
            CardModel model = _cardService.GetCardByNum(cardNum);
            return View("InputAmountOfMoney", model);
        }

        [HttpPost]
        public ActionResult WithdrawMoney(string cardNum, decimal balance, decimal amount)
        {
            if (balance>= amount) 
            {
                CardModel model = _cardService.GetCardByNum(cardNum);
                DateTime dateTime = DateTime.Now;
                _cardService.WithdrawMoney(cardNum, amount);
                _operationService.NoteOperation(model.CardId, cardNum, "Money withdrawal", amount, dateTime);
                return View("WithdrawResult", CreateWithdrawResultModel(cardNum, dateTime, amount, model.Balance - amount, "Home", "Operations"));
            }
            string errorMessage = "Unfortunately, You have not enough money on Your account!";
            return View("Error", CreateErrorModel(cardNum, errorMessage, "Home", "InputAmountOfMoney")); 
        }

        //public string CardNumWithDashes(string cardNum)
        //{
        //    string cardNumWithDashes = cardNum.Insert(4, "-");
        //    int[] ind = { 9, 14};
        //    foreach(int i in ind)
        //    {
        //        cardNumWithDashes = cardNumWithDashes.Insert(i, "-");
        //    }
        //    return cardNumWithDashes;
        //}

        public ErrorViewModel CreateErrorModel(string cardNum, string errorMessage, string backController, string backAction)
        {
            return new ErrorViewModel
            {
                CardNum = cardNum,
                ErrorMessage = errorMessage,
                BackController = backController,
                BackAction = backAction
            };
        }

        public BalanceViewModel CreateBalanceModel(string cardNum, DateTime dateTime, decimal balance, string backController, string backAction)
        {
            string cardNumWithDashes = _cardService.CardNumWithDashes(cardNum);
            return new BalanceViewModel
            {
                CardNum = cardNum,
                CardNumWithDashes = cardNumWithDashes,
                Date = dateTime.ToString("dd/MM/yyyy"),
                Balance = balance,
                BackController = backController,
                BackAction = backAction
            };
        }

        public WithdrawResultViewModel CreateWithdrawResultModel(string cardNum, DateTime dateTime, decimal amount, decimal balance, string backController, string backAction)
        {
            string cardNumWithDashes = _cardService.CardNumWithDashes(cardNum);
            return new WithdrawResultViewModel
            {
                CardNum = cardNum,
                CardNumWithDashes = cardNumWithDashes,
                DateAndTime = dateTime.ToString(),
                WithdrewAmount = amount,
                Balance = balance,
                BackController = backController,
                BackAction = backAction
            };
        }
    }
}

