﻿using System;
using OpenQA.Selenium;
using NUnit.Framework;
using Common;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using InfoMessageLogger;
using BaseUtility.Utility;
using Constants = eMenus.Utility.Constants;
using eMenus.PageObject.UI;

namespace eMenus.AppModule.UI
{
    public class Email
    {
        public static void LogIntoCatchAll()
        {
            Hotmail.NavigateAndLogIntoCatchAll();
        }
        public static void Click_Share_Menu_Link()
        {
            Helper.ElementClick(PageObject_Email.Share_Menu_Email());
        }
        public static void Login_Cendyn_Access()
        {
            Helper.ElementClick(PageObject_Email.Login_Cendyn_Access());
        }
        
        public static void CatchAll_SearchEmailAndOpenLatestMessage(string email)
        {
            Time.AddDelay(10000);
            Hotmail.SearchEmailAndOpenLatestEmail(email);
        }

        public static void ActivationEmail_Check(string ProjectName)
        {
            ProjectName = ProjectName.Replace("_", " ");
            string accountActivation = "we just need you to verify your email";
            try
            {
                if (Helper.VerifyTextOnPage(accountActivation))
                {
                    Logger.WriteInfoMessage("The Activation Email was received by the user.");
                }
                else if (ProjectName == "HotelOrigami")
                {
                    accountActivation = "Thank you for signing up for Club Rewards.";
                }
               else
                {
                    Assert.Fail("The Activation Email was NOT received by the user.");
                }
            }
            catch (Exception e)
            {
                Logger.WriteFatalMessage(e);
                throw;
            }
        }

        public static void ActivationEmail_ClickLink(string ProjectName)
        {
            ProjectName = ProjectName.Replace("_", " ");

            try
            {
                if (ProjectName == "HotelOrigami")
                {
                    Helper.ScrollToElement(PageObject_Email.Activation_Email_Link());
                    Helper.ElementClick(PageObject_Email.Activation_Email_Link());
                    Logger.WriteInfoMessage("Clicked the link on the  email.");
                }
                            
            }
            catch (Exception e)
            {
                Logger.WriteFatalMessage(e);
                throw;
            }

        }

        public static void WelcomeEmail_Check(string ProjectName)
        {
            Time.AddDelay(25000);
            string welcomeMessage = "Welcome to IC LOCAL";
            ProjectName = ProjectName.Replace("_", " ");
            try
            {
                
                if (ProjectName == "HotelOrigami")
                {
                    welcomeMessage = "We take great pleasure in welcoming you to Club Rewards, and hope you enjoy the exclusive privileges lined up for you.";
                    if (Helper.VerifyTextOnPage(welcomeMessage))
                        Logger.WriteInfoMessage("The Welcome Email was received by the user.");
                    else
                    {
                        Assert.Fail("The Welcome Email was NOT received by the user.");
                    }
                }
             
            }
            catch (Exception e)
            {
                Logger.WriteFatalMessage(e);
                throw;
            }
        }

        public static void WelcomeEmail_ClickLink(string ProjectName, string URL)
        {
            try
            {
                string GetProjectName = ProjectName.Replace("_"," ");
                if(ProjectName == "IndependentCollection")
                {
                    Helper.AddDelay(3000);
                    Helper.ScrollToElement(Helper.Driver.FindElement(By.LinkText("here")));
                    Helper.ElementClick(Helper.Driver.FindElement(By.LinkText("here")));
                    Logger.WriteInfoMessage("Clicked the Sign In link on the welcome email.");
                }
                if (ProjectName == "MyStay")
                {
                    Helper.AddDelay(3000);
                    Helper.ScrollToElement(Helper.Driver.FindElement(By.XPath("//span[@class='x_addressNoBlue']")));
                    Helper.ElementClick(Helper.Driver.FindElement(By.XPath("//span[@class='x_addressNoBlue']")));
                    Logger.WriteInfoMessage("Clicked the Sign In link on the welcome email.");
                }
                else if (ProjectName == "NYLO" || ProjectName == "HotelIcon")
                {
                    Helper.AddDelay(3000);
                    if (!Helper.VerifyTextOnPage("Now"))
                    {
                        Helper.ScrollToElement(Helper.Driver.FindElement(By.PartialLinkText("Now")));
                        Helper.ElementClick(Helper.Driver.FindElement(By.PartialLinkText("Now")));
                    }
                    else
                    {
                        Helper.ScrollToElement(Helper.Driver.FindElement(By.PartialLinkText("NOW")));
                        Helper.ElementClick(Helper.Driver.FindElement(By.PartialLinkText("NOW")));
                    }
                    Logger.WriteInfoMessage("Clicked the Sign In link on the welcome email.");
                }                
                else if (ProjectName != "IndependentCollection" || ProjectName == "PublicHotel" || ProjectName == "Loews")
                {
                    Helper.Driver.Navigate().GoToUrl(URL);
                }
            }
            catch (Exception e)
            {
                Logger.WriteFatalMessage(e);
                throw;
            }

        }

        public static void ForgotPasswordEmail_Check()
        {
            string ForgotPassword = "RESET YOUR PASSWORD";
            try
            {
                if (Helper.VerifyTextOnPage(ForgotPassword) || Helper.VerifyTextOnPage("Reset Your Password") || Helper.VerifyTextOnPage("Reset your Password"))
                {
                    Logger.WriteInfoMessage("The Forgot Password Email was received by the user.");
                }
                
            }
            catch (Exception e)
            {
                Logger.WriteFatalMessage(e);
                throw;
            }
        }
      
        public static void ActivationForgotPassword_CLick()
        {
            try
            {
                try
                {
                    Helper.ScrollToElement(PageObject_Email.Reset_Password_Button());
                    Logger.WriteInfoMessage("Reset Your Password button is Present.");
                    Helper.ElementClick(PageObject_Email.Reset_Password_Button());
                    Logger.WriteInfoMessage("Reset Your Password is clicked.");
                }
                catch (Exception)
                {
                    Helper.ScrollToElement(PageObject_Email.Forgot_Password_Button());
                    Logger.WriteInfoMessage("Reset Your Password button is Present.");
                    Helper.ElementClick(PageObject_Email.Forgot_Password_Button());
                    Logger.WriteInfoMessage("Reset Your Password is clicked.");
                }

            }
            catch (Exception e)
            {
                Logger.WriteFatalMessage(e);
                throw;
            }

        }

        public static void KioskVerifyEmail_Check()
        {
            string ForgotPassword = "Verify Your Email";
            try
            {
                if (Helper.VerifyTextOnPage(ForgotPassword))
                {
                    Logger.WriteInfoMessage("Verification Email was received by the user for Kiosk Page.");
                }
                else if (Helper.VerifyTextOnPage("Just one more step to activate your account and receive 10%"))
                {
                    Logger.WriteInfoMessage("Verification Email was received by the user for Kiosk Page.");
                }
                else if (Helper.VerifyTextOnPage("We received a request from you for resetting your password with this email"))
                {
                    Logger.WriteInfoMessage("Verification Email was received by the user for Kiosk Page.");
                }
                else if (Helper.VerifyTextOnPage("Simply click below to verify and activate your account."))
                {
                    Logger.WriteInfoMessage("Verification Email was received by the user for Kiosk Page.");
                }
                else if(Helper.VerifyTextOnPage("Account Activation"))
                {
                    Logger.WriteInfoMessage("Verification Email was received by the user for Kiosk Page.");
                }
                else if (Helper.VerifyTextOnPage("Activate your account to enjoy exclusive privileges!"))
                {
                    Logger.WriteInfoMessage("Verification Email was received by the user for Kiosk Page.");
                }
                else
                {
                    Assert.Fail("Verification Email was NOT received by the user for Kiosk Page.");
                }
            }
            catch (Exception e)
            {
                Logger.WriteFatalMessage(e);
                throw;
            }
        }

        public static void KioskActivateMember_CLick()
        {
            try
            {
                if (Helper.VerifyTextOnPage("Activate Membership"))
                {
                    Helper.PageDown();
                    Helper.OpenPopUpWindow(CommonMethod.Driver.FindElement(By.LinkText("Activate Membership")));
                    Logger.WriteInfoMessage("Reset Your Password is clicked.");
                }
                else if (Helper.VerifyTextOnPage("Activate Your Account"))
                {
                    Helper.PageDown();
                    Helper.OpenPopUpWindow(CommonMethod.Driver.FindElement(By.LinkText("Activate Your Account")));
                    Logger.WriteInfoMessage("Reset Your Password is clicked.");
                }
                else if (Helper.VerifyTextOnPage("CHANGE PASSWORD"))
                {
                    Helper.PageDown();
                    Helper.OpenPopUpWindow(CommonMethod.Driver.FindElement(By.LinkText("CHANGE PASSWORD")));
                    Logger.WriteInfoMessage("Reset Your Password is clicked.");
                }
                else if (Helper.VerifyTextOnPage("Activate your account to enjoy exclusive privileges!"))
                {
                    Helper.PageDown();
                    if (Helper.VerifyTextOnPage("here"))
                    {
                        Helper.OpenPopUpWindow(CommonMethod.Driver.FindElement(By.LinkText("here")));
                    }
                    Logger.WriteInfoMessage("Reset Your Password is clicked.");
                }
                else if (Helper.VerifyTextOnPage("Account Activation"))
                {
                    Helper.PageDown();
                    if(Helper.VerifyTextOnPage("Set Your Password"))
                    {
                        Helper.OpenPopUpWindow(CommonMethod.Driver.FindElement(By.LinkText("Set Your Password")));
                    }
                    else if (Helper.VerifyTextOnPage("Click here"))
                    {
                        Helper.OpenPopUpWindow(CommonMethod.Driver.FindElement(By.LinkText("Click here")));
                    }
                    
                    Logger.WriteInfoMessage("Reset Your Password is clicked.");
                }                
            }
            catch (Exception e)
            {
                Logger.WriteFatalMessage(e);
                throw;
            }

        }

        /// <summary>
        /// This method will log into gmail using CendynAutomationQa@gmail.com
        /// </summary>
        public static void LogIntoGmail()
        {
            Gmail.NavigateAndLogIntoGmail();
        }

        public static void Gmail_OpenLatestEmail()
        {
            Time.AddDelay(10000);
            CommonMethod.Driver.Navigate().GoToUrl("https://www.gmail.com");
            Gmail.OpenFirstEmail();
        }

    }

    public class Gmail : Helper
    {

        public static string commonEmail = "cendynqaautomation@gmail.com";
        private static string commonPassword = "Cendyn123$";

        private static void ClickShowContentButton()
        {
            try
            {
                if (
                    Driver.FindElement(By.XPath("//img[@class='ajT']"))
                        .Displayed)
                {

                    Driver.FindElement(By.XPath("//img[@class='ajT']"))
                        .Click();
                }
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// Returns the user to the Gmail inbox.
        /// </summary>
        public static void ReturnToInbox()
        {
            AddDelay(15000);
            try
            {
                Driver.FindElement(By.XPath("/html/body/div[7]/div[3]/div/div[1]/div[4]/div[1]/div[1]/div[2]/div/a/span"))
                    .Click();
                AddDelay(3000);
                Logger.WriteInfoMessage("Returned to the Inbox.");
            }
            catch (Exception)
            {
                Logger.WriteFatalMessage("Unable to return to the inbox.");
                throw;
            }
        }

        /// <summary>
        /// Enters the email.
        /// </summary>
        /// <param name="email"></param>
        private static void EnterEmail(string email)
        {
            try
            {
                Driver.FindElement(By.XPath("//*[@id='identifierId']")).SendKeys(email);
                AddDelay(2500);
                Logger.WriteInfoMessage("Entered the email on the Gmail page.");
            }
            catch (Exception)
            {
                Logger.WriteWarnMessage("Unable to enter the Gmail email. Probably already logged into Gmail.");
                throw;
            }
        }

        /// <summary>
        /// Clicks the Next button.
        /// </summary>
        private static void ClickNext()
        {
            try
            {
                AddDelay(2500);
                Driver.FindElement(By.XPath("//span[contains(.,'Next')]")).Click();
                AddDelay(2000);
                Logger.WriteInfoMessage("Clicked Next on the Gmail page.");
            }
            catch (Exception)
            {
                Logger.WriteWarnMessage("Already logged into Gmail.");
                throw;
            }
        }

        /// <summary>
        /// Enters the password.
        /// </summary>
        /// <param name="password"></param>
        private static void EnterPassword(string password)
        {
            try
            {
                Driver.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input")).SendKeys(password);
                AddDelay(2500);
                Logger.WriteInfoMessage("Entered the Password on the Gmail page.");
            }
            catch (Exception)
            {
                Logger.WriteWarnMessage("Unable to enter the Gmail password. Probably already logged into Gmail.");
                throw;
            }
        }

        /// <summary>
        /// Clicks the Sign In button.
        /// </summary>
        private static void ClickSignIn()
        {
            try
            {
                Driver.FindElement(By.Id("signIn")).Click();
                AddDelay(3500);
                Logger.WriteInfoMessage("Clicked Sign In on the Gmail page.");
            }
            catch (Exception)
            {
                Logger.WriteWarnMessage("Unable to click the Sign In button. Probably already logged into Gmail.");
                throw;
            }
        }

        /// <summary>
        /// This will enter the email and password and click the appropiate buttons to log into GMail.
        /// </summary>
        /// <param name="email">Gmail email</param>
        /// <param name="password">Gmail password</param>
        public static void LogIn(string email, string password)
        {
            try
            {
                EnterEmail(email);
                ClickNext();
                EnterPassword(password);
                ClickNext();
            }
            catch (Exception)
            {
                Logger.WriteWarnMessage("Already logged into Gmail.");
            }
        }

        /// <summary>
        /// This will log into gmail using the common email.
        /// cendynautomationqa@gmail.com
        /// </summary>
        /// <param name="email">Gmail email</param>
        /// <param name="password">Gmail password</param>
        public static void LogIn()
        {
            try
            {
                EnterEmail(commonEmail);
                ClickNext();
                EnterPassword(commonPassword);
                ClickNext();
            }
            catch (Exception)
            {
                Logger.WriteWarnMessage("Already logged into Gmail.");
            }
        }

        /// <summary>
        /// This will open the first email message.
        /// Email must have the filters turned off
        /// </summary>
        public static void OpenFirstEmail()
        {
            AddDelay(10000);
            try
            {
                Driver.FindElement(
                    By.XPath(
                        "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div/div[2]/div[1]/div[1]/div/div/div[3]/div[1]/div/table/tbody/tr[1]/td[6]"))
                    .Click();
                AddDelay(1500);
                Logger.WriteInfoMessage("Opened the first email on the Gmail page.");
            }
            catch (Exception)
            {
                Logger.WriteFatalMessage("Unable to select the first email message.");
                throw;
            }
        }

        /// <summary>
        /// Clicks a link on the email with the entered text and opens in a new window. 
        /// </summary>
        /// <param name="text">Link text to click</param>
        public static void GmailClickLinkByText(string text)
        {
            AddDelay(5000);
            try
            {
                ClickShowContentButton();
                OpenPopUpWindow(Driver.FindElement(By.PartialLinkText(text)));
                AddDelay(7500);
                Logger.WriteInfoMessage("Clicked the link on the email by text on the Gmail page.");
            }
            catch (Exception)
            {
                Logger.WriteFatalMessage("Unable to locate the text to click on the email.");
                throw;
            }
        }

        /// <summary>
        /// Clicks a link on the email with the entered text and opens in a new window. 
        /// </summary>
        /// <param name="element">Element text to click</param>
        public static void GmailClickLinkByElement(IWebElement element)
        {
            AddDelay(5000);
            try
            {
                //ClickShowContentButton();
                OpenPopUpWindow(element);
                AddDelay(7500);
                Logger.WriteInfoMessage("Clicked the link on the email by text on the Gmail page.");
            }
            catch (Exception)
            {
                Logger.WriteFatalMessage("Unable to locate the text to click on the email.");
                throw;
            }
        }

        /// <summary>
        /// Closes the email popup and returns to Gmail.
        /// </summary>
        public static void CloseEmailPopup()
        {
            AddDelay(5000);
            ClosePopUpWindow();
            AddDelay(2500);
        }

        /// <summary>
        /// Checks the email for a certain text
        /// </summary>
        /// <param name="text">Text to search for on the email.</param>
        public static void SearchEmailForText(string text)
        {
            AddDelay(5000);
            try
            {
                if (VerifyTextOnPage(text))
                    Logger.WriteInfoMessage("Found the email text.");

            }
            catch (Exception)
            {
                Logger.WriteFatalMessage("Did not find the email text.");
                throw;
            }
        }

        public static void NavigateToGmail()
        {
            AddDelay(10000);
            Driver.Navigate().GoToUrl("https://www.gmail.com");
            AddDelay(1500);
        }

        /// <summary>
        /// This method will navigate and log into Gmail
        /// </summary>
        public static void NavigateAndLogIntoGmail(string email, string password)
        {
            NavigateToGmail();
            LogIn(email, password);
        }

        /// <summary>
        /// This method will navigate and log into Gmail
        /// </summary>
        public static void NavigateAndLogIntoGmail()
        {
            NavigateToGmail();
            LogIn(commonEmail, commonPassword);
        }

        public static void LogOut()
        {
            Driver.FindElement(By.XPath("//span[@class='gb_bb gbii']")).Click();
            AddDelay(1000);
            Driver.FindElement(By.XPath("//a[contains(.,'Sign out')]")).Click();
            AddDelay(1500);
        }

        /// <summary>
        /// This method will navigate to the "Use another account" page from the Log In page.
        /// </summary>
        public static void SelectAnotherAccount()
        {
            Driver.Quit();
            TestHandling.BrowserSetup();

            //Click the Gmail user drop down
            Driver.FindElement(By.XPath("//path[@d='M7.41 7.84L12 12.42l4.59-4.58L18 9.25l-6 6-6-6z']")).Click();
            AddDelay(1500);

            //Click "Use another account"
            Driver.FindElement(By.XPath("//p[contains(.,'Use another account')]")).Click();
            AddDelay(1500);

        }
    }

    public class Hotmail : Helper
    {
        //private static string SignIn_Email = "//input[@type='email']";
        public static string SignIn_Button = "//input[@type='submit']";
       // private static string SignIn_Password = "//input[@name='passwd']";
       // private static string SignIn_DontShowAgainCheckBox = "//input[@name='DontShowAgain']";
       // private static string SignIn_YesButton = "//input[@value='Yes']";
        //private static string SearchIcon = "//button[@aria-label='Activate Search Textbox']";
        private static string SearchIcon = "//i[@data-icon-name='Search']";
        //private static string SearchBox = "//input[contains(@role,'combobox')]";
        private static string SearchBox = "//input[@aria-label='Search']";
        //private static string Search = "//span[contains(@class,'_n_m owaimg ms-Icon--search ms-icon-font-size-20 ms-fcl-ts-b')]";
       // private static string Search = "//span[contains(@class,'_fc_3 owaimg ms-Icon--search ms-icon-font-size-20 ms-fcl-ts-b')]";
        private static string OutLookIcon = "ShellMail_link_text";
      //  private static string FirstMessage = "//div[@role='heading'][@tabindex='-1']/following-sibling::div[@data-convid][1]";
        private static string catchalladvancebutton = "//*[@id='details-button']";
        private static string catchallproceedbutton = "//*[@id='proceed-link']";
        //private static string FirstMessageAlt = "/html/body/div[2]/div/div[3]/div[5]/div/div[1]/div/div[4]/div[3]/div/div[2]/div/div/div/div[5]/div[4]/div[1]/div[3]/div[1]/div/div/div[2]/div[2]/div[2]/div[4]/div[3]/div/span";
        //private static string FirstMessageAlt = "div[@role='heading'][@tabindex='-1']/following-sibling::div[@data-convid][1]";


        /// <summary>
        /// This method will navigate and log into the Catchall account, search by the email provided and open the latest email.
        /// </summary>
        public static void LogIntoCatchAllAndOpenFirstMessageByEmail(string email)
        {
            NavigateAndLogIntoCatchAll();
            SearchEmail(email);
            OpenLatestEmail();
        }

        public static void NavigateToWebmail()
        {
            Driver.Navigate().GoToUrl("https://login.microsoftonline.com/");
            try
            {
                if(Driver.FindElement(By.XPath(catchalladvancebutton)).Displayed)
                {
                    ElementClick(Driver.FindElement(By.XPath(catchalladvancebutton)));
                    ElementClick(Driver.FindElement(By.XPath(catchallproceedbutton)));
                }

            }catch(Exception)
            {
                Logger.WriteDebugMessage("Landed on CatchAll SignIn Page");
            }
            
        }

        public static void ClickOutLook()
        {
            ElementClick(Driver.FindElement(By.Id(OutLookIcon)));
        }

        public static void CheckActiveWindow()
        {
            IList<String> handles = Driver.WindowHandles;
            if(handles.Count.Equals(2))
            {
                ControlToPreviousWindow();
                CloseCurrentTab();
                ControlToNewWindow();
            }
            else
            {
                Driver.SwitchTo().Window(handles[1]);
                CloseCurrentTab();
                ControlToNewWindow();
            }


        }

        public static void SignIn()
        {
            AddDelay(5000);
            ElementEnterText(PageObject_Email.CatchAll_SignIn_Email(), Constants.CatchAllEmail);
            ElementClick(PageObject_Email.CatchAll_SignIn_Button());
            AddDelay(4000);
            ElementEnterText(PageObject_Email.CatchAll_SignIn_Password(), Constants.CatchAllPassword);
            Logger.WriteDebugMessage("Entered Catchall UserName and Password");
            ElementClick(PageObject_Email.CatchAll_SignIn_Button());

            try
            {
                MakeSureIsChecked(PageObject_Email.CatchALl_SignIn_DontShowAgain());
                ElementClick(PageObject_Email.Catchall_SignIn_Yes_Button());
                AddDelay(5000);
                //Navigate to the mailbox
                //Had to use the URL since the landing page randomly changes.
                ElementClick(PageObject_Email.CatchAll_Outlook());
                CheckActiveWindow();                
                //Driver.Navigate().GoToUrl("https://outlook.office365.com/owa/?realm=cendyn17.com&exsvurl=1&ll-cc=1033&modurl=0&path=/mail/search");
            }
            catch (Exception e)
            {
                Assert.Fail("Unable to move further due to - " + e);
            }
        }

        /// <summary>
        /// This method will navigate to Cendyn Webmail and log into the CatchAll account
        /// </summary>
        public static void NavigateAndLogIntoCatchAll()
        {
            NavigateToWebmail();
            if(BrowserType.Equals("internetExplorer"))
            {
                IWebElement SSLCerificate = Driver.FindElement(By.Id("overridelink"));
                if (SSLCerificate.Enabled || SSLCerificate.Enabled)
                {
                    DoubleClickElement(SSLCerificate);
                    SSLCerificate.Click();
                }
            }           
            SignIn();
        }

        /// <summary>
        /// This method will use the search filter
        /// </summary>
        private static void SearchEmail(string search)
        {
            try
            {
                IWebElement SearchElement = Driver.FindElement(By.XPath(SearchIcon));
                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("arguments[0].click();", SearchElement);
                //ElementClick(Driver.FindElement(By.XPath(SearchIcon)));
                ElementClearText(Driver.FindElement(By.XPath(SearchBox)));
                ElementEnterText(Driver.FindElement(By.XPath(SearchBox)), search);
                Driver.FindElement(By.XPath(SearchBox)).SendKeys(Keys.Enter);
                AddDelay(5000);
            }
            catch (Exception e)
            {
                Assert.Fail("" + e);
            }
        }

        /// <summary>
        /// This will open the first email message.
        /// Email must have the filters turned off
        /// </summary>
        private static void OpenLatestEmail()
        {
            try
            {
                //IWebElement element = Driver.FindElement(By.CssSelector("._lvv_11"));
                //((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].removeAttribute('style')", element);
                //AddDelay(2500);
                //ElementClick(Driver.FindElement(By.XPath("//div[@role='heading'][@tabindex='-1']/following-sibling::div[@data-convid][1]")));                
                DoubleClickElement(PageObject_Email.CatchAll_Email());
                Logger.WriteDebugMessage("Clicked on Email");
            }
            catch (Exception)
            {
                DoubleClickElement(PageObject_Email.CatchAll_Recent_Email());
                Logger.WriteDebugMessage("Clicked on Email");
            }
        }

        /// <summary>
        /// Method to turn on the old outlook view
        /// </summary>
        private static void CheckOutLook()
        {
            try
            {
                string url = Driver.Url;
                if (url.Contains("owa"))
                {
                    TryNewOutLook();
                    Logger.WriteInfoMessage("User redirected to new outlook view");
                }
                else
                {
                    Logger.WriteInfoMessage("User redirected to new outlook view");
                }
            }
            catch (Exception)
            {
                Logger.WriteInfoMessage("User redirected to new outlook view");

            }
        }

        /// <summary>
        /// Method to turn on the new outlook view
        /// </summary>
        private static void TryNewOutLook()
        {
            ElementClick(Driver.FindElement(By.XPath("//*[@id='primaryContainer']/div[4]/div/div[1]/div/div[4]/div[1]/div/div[1]/div/div/div[1]/div/button/span[1]")));
        }
        
        public static void SearchEmailAndOpenLatestEmail(string email)
        {
            AddDelay(2500);
            Helper.ElementClick(Helper.Driver.FindElement(By.XPath("//*[@id='app']//span[contains(text(),'Inbox')]")));
            Helper.ReloadPage();
            CheckOutLook();
            SearchEmail(email);
            OpenLatestEmail();
            Helper.PageDown();
            ControlToNewWindow();
            Helper.Driver.Manage().Window.Maximize();
            Logger.WriteDebugMessage("Opened Latest Email.");
        }

        public static void Clear_SearchBox()
        {
            Actions action = new Actions(Driver);
            ElementClearText(Driver.FindElement(By.XPath(SearchIcon)));
            action.SendKeys(Keys.Tab).Build().Perform();
        }

        public static void OutLookSearchEmail(string email)
        {
            AddDelay(2500);
            CheckOutLook();
            SearchEmail(email);
        }
        
    }


}