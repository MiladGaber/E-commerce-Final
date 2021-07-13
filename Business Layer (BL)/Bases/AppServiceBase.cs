using AutoMapper;
using Business_Layer__BL_.Configuration;
using Business_Layer__BL_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.Bases
{
    public class AppServiceBase
    {
        //created...mark

        #region Vars
        protected IUnitOfWork TheUnitOfWork { get; set; }
        protected readonly IMapper Mapper = MapperConfig.Mapper;
        #endregion

        #region CTR
        public AppServiceBase()
        {
            TheUnitOfWork = new UnitOfWork();
        }

        public void Dispose()
        {
            TheUnitOfWork.Dispose();
        }
        #endregion
    }
}
