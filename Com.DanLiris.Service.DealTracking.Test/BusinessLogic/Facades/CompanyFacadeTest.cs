﻿using Com.DanLiris.Service.DealTracking.Lib;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Implementation;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Lib.Services;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.DataUtils;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Utils;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Facades
{
   public class CompanyFacadeTest : BaseFacadeTest<DealTrackingDbContext, CompanyFacade, CompanyLogic, Company, CompanyDataUtil>
    {
        private const string ENTITY = "Companies";
        public CompanyFacadeTest() : base(ENTITY)
        {
        }

        protected override Mock<IServiceProvider> GetServiceProviderMock(DealTrackingDbContext dbContext)
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };
            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var companyLogic = new CompanyLogic(serviceProviderMock.Object, dbContext);

            serviceProviderMock
                .Setup(x => x.GetService(typeof(CompanyLogic)))
                .Returns(companyLogic);



            return serviceProviderMock;
        }
    }
}
