using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValideEmail(string email, bool expectedResult)
        {
            //Arrange
            var accountController = new AccountController();

            //Act
            var actualResult = accountController.ValidateEmail(email);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [
            Test,
            TestCase("Abcdefgh", false),
            TestCase("ABCDEFG2", false),
            TestCase("abcdefg2", false),
            TestCase("abcDe2", false),
            TestCase("aBcdEf2g", true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            //Arrange
            var accountController = new AccountController();

            //Act
            var actualResult = accountController.ValidatePassword(password);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [
            Test,
            TestCase("irf@uni-corvinus.hu", "AbCdE2h3"),
            TestCase("irf@gmail.com", "Abcdeg1234")
        ]
        public void TestRegisterHappyPath(string email, string password)
        {
            //Arrange
            var accountController = new AccountController();

            //Act
            var actualResult = accountController.Register(email, password);

            //Assert
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(actualResult.ID, Guid.Empty);
        }

        [
            Test,
            TestCase("abcd1234", "Abcdefgh"),
            TestCase("irf@uni-corvinus", "ABCDEFG2"),
            TestCase("irf.uni-corvinus.hu", "abcdefg2"),
            TestCase("irf@uni-corvinus.hu", "abcDe2"),
            TestCase("irf@uni-corvinus.hu", "abcdABCD")
        ]
        public void TestRegisterValidateException(string email, string password)
        {
            //Arrange
            var accountController = new AccountController();

            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }
        }
    }
}
