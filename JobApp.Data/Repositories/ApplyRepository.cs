﻿using JobApp.Data.Contexts;
using JobApp.Domain.Models;
using JobApp.Interfaces.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Data.Repositories
{
    public class ApplyRepository : Repository<Apply, long>, IApplyRepository
    {
        public ApplyRepository(JobAppContext context) : base(context)
        {
        }
        public override long GetKey(Apply instance)
        {
            return instance.ApplyId;
        }
    }
}
