﻿using System;
using NUnit.Framework;
using eInsight.AppModule.MainAdminApp;
using BaseUtility.Utility;
using eInsight.AppModule.UI;
using System.Text.RegularExpressions;
using InfoMessageLogger;
using Constants = eInsight.Utility.Constants;
using LegacyTestData = eInsight.Utility.LegacyTestData;
using eInsightSetup = eInsight.Utility.Setup;
using OpenQA.Selenium;
using System.Threading;

namespace eInsightAudienceBuilderAssociatedCampaign
{
    
    public class eIn_TP_240302_AudienceBuilder_AssociatedCampaign : eInsightSetup
    {
        static string GetProjectName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
        public eIn_TP_240302_AudienceBuilder_AssociatedCampaign(string browser, string version, string os, string resolution) : base(browser, version, os, resolution)
        {
            Drivers = new ThreadLocal<IWebDriver>();
        }
        [SetUp]
        public static void Initialize()
        {

            TestPlanId = Constants.TP_240302;

            //Initialize the test case set up.

            InitializeSetup(TestPlanId,GetProjectName);

            //TestDataFile = TestDataLocation.TP_240302;

            AddDelay(8000);

            //Can use this to update the URL Manually
            //LegacyTestData.CommonFrontendURL = "https://poceinsight.cendyn.com/";
        }

        [Test, Category("Regression")]

        public static void TC_261225()

        {
            try
            {

                /**Test execution - Start**/

                Legacy_SetupTestCase(Constants.TC_261225);
                Logger.DeleteOldFolder();
                string[] eachFrontEndURL = Regex.Split(LegacyTestData.CommonFrontendURL, ", ");
                foreach (string frontendURL in eachFrontEndURL)
                {
                    Login.CommonLogin(frontendURL);

                    //Start

                    MainAdminApp.TP_240302();

                    RenewDriver();
                }

                /**Test execution - End**/

                TestHandling.TestEnd();
            }

            catch (Exception e)
            {
                TestHandling.TestFailed(e);
                throw;
            }
        }

        public static void TC_261830()
        {

            try

            {

                /**Test execution - Start**/

                Legacy_SetupTestCase(Constants.TC_261830);

                Logger.DeleteOldFolder();

                string[] eachFrontEndURL = Regex.Split(LegacyTestData.CommonFrontendURL, ", ");

                foreach (string frontendURL in eachFrontEndURL)

                {

                    Login.CommonLogin(frontendURL);

                    //Start

                    MainAdminApp.TP_240302();

                    RenewDriver();

                }
                    /**Test execution - End**/

                TestHandling.TestEnd();

            }

            catch (Exception e)
            {
                TestHandling.TestFailed(e);
                throw;
            }

        }

        [Test, Category("Regression")]
        public static void TC_261833()
        {
            try
            {
                /**Test execution - Start**/

                Legacy_SetupTestCase(Constants.TC_261833);

                Logger.DeleteOldFolder();

                string[] eachFrontEndURL = Regex.Split(LegacyTestData.CommonFrontendURL, ", ");

                foreach (string frontendURL in eachFrontEndURL)
                {
                    Login.CommonLogin(frontendURL);

                    //Start

                    MainAdminApp.TP_240302();

                    RenewDriver();

                }
                /**Test execution - End**/

                TestHandling.TestEnd();
            }

            catch (Exception e)
            {
                TestHandling.TestFailed(e);
                throw;
            }
        }

        /// <summary>
        /// Method is executed after every Test Script.
        /// </summary>
        [TearDown]
        public void Quit()
        {
            TestHandling.TearDown();
        }
    }
}
