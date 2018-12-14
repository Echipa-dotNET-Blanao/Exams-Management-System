﻿using System.Collections.Generic;
using ExamManagement.Core.SharedKernel;

namespace ExamManagement.Core.Interfaces.Repositories
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
    }
}