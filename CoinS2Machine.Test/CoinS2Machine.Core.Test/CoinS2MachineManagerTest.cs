﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinS2Machine.Core;
using CoinS2Machine.Core.DataContracts;
using CoinS2Machine.Core.Utility;
using CoinS2Machine.Test.CoinS2Machine.Core.Test.Mocks;
using Dlp.Framework.Container;

namespace CoinS2Machine.Test.CoinS2Machine.Core.Test {

    [TestClass]
    public class CoinS2MachineManagerTest {

        [TestMethod]
        public void CalculateChange_CalculateInvalidPaidAmount_Test() {

            IocFactory.Register(
                    Component.For<IConfigurationUtility>()
                    .ImplementedBy<ConfigurationUtilityMock>().IsSingleton()                    
                );

            CoinS2MachineManager manager = new CoinS2MachineManager();

            CalculateChangeRequest request = new CalculateChangeRequest();

            request.PaidAmount = 0;
            request.ProductAmount = 10;

            CalculateChangeResponse response = manager.CalculateChange(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationReportList.Any() == true);
        }
    }
}
