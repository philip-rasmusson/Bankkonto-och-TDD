using Bankkonto_och_TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bankkonto_och_TDD.Tests
{
    [TestClass()]
    public class BankkontoTests
    {
        public Bankkonto ResetAccount()
        {
            var bk = new Bankkonto();
            bk.credit = 0;
            bk.saldo = 2000;
            bk.swishLimit = 3000;

            return bk;
        }

        [TestMethod()]
        public void IsAmountMoreThanZero()
        {
            var bk = ResetAccount();
            var actual = bk.IsDepositCorrect(399);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsAmountLessThanZero()
        {
            var bk = ResetAccount();
            var actual = bk.IsDepositCorrect(-399);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsAmountLessThanSaldo()
        {
            var bk = ResetAccount();
            var actual = bk.IsWithdrawlCorrect(399);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsAmountMoreThanSaldo()
        {
            var bk = ResetAccount();
            bk.saldo = 2000;
            bk.credit = 0;
            var actual = bk.IsWithdrawlCorrect(4000);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsAmountLessThanCredit()
        {
            var bk = ResetAccount();
            bk.credit = 50;
            var actual = bk.IsWithdrawlCorrect(10);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsAmountMoreThanCredit()
        {
            var bk = ResetAccount();
            bk.credit = 50000;
            var actual = bk.IsWithdrawlCorrect(39988980);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsAmountLessSwishLimit()
        {
            var bk = ResetAccount();            
            var actual = bk.SwishTransaction(2000);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsAmountMoreSwishLimit()
        {
            var bk = ResetAccount();
            bk.SwishTransaction(2000);
            var actual = bk.SwishTransaction(2000);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void IsTransactionLessThanAccount()
        {
            var bk = ResetAccount();
            var actual = bk.Transaction(400);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

    }
}