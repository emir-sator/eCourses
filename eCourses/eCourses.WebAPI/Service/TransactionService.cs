using AutoMapper;
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Model;
using eCourses.WebAPI.Model.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Service
{
    public class TransactionService:CRUDService<MTransaction,TransactionSearchRequest, Transaction,TransactionUpsertRequest,TransactionUpsertRequest>
    {
        private readonly eCoursesContext _context;
        private readonly IMapper _mapper;
        public TransactionService(eCoursesContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MTransaction>> Get(TransactionSearchRequest request)
        {
            var query = _context.Transactions.AsQueryable().OrderBy(c => c.TransactionDate);

            if (request.UserID != 0)
            {
                query = (IOrderedQueryable<Transaction>)query.Where(i => i.UserID == request.UserID);
            }
            if (request.From != null)
            {
                query = (IOrderedQueryable<Transaction>)query.Where(i => i.TransactionDate >= request.From);
            }
            if (request.To != null)
            {
                query = (IOrderedQueryable<Transaction>)query.Where(i => i.TransactionDate <= request.To);
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<MTransaction>>(list);
        }
        public override async Task<MTransaction> GetById(int ID)
        {
            var entity = await _context.Transactions
                .Where(i => i.TransactionID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MTransaction>(entity);
        }
        public override async Task<MTransaction> Insert(TransactionUpsertRequest request)
        {
           
            var entity = _mapper.Map<Transaction>(request);

            _context.Set<Transaction>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MTransaction>(entity);
        }
        public override async Task<MTransaction> Update(int ID, TransactionUpsertRequest request)
        {
            

            var entity = _context.Set<Transaction>().Find(ID);
            _context.Set<Transaction>().Attach(entity);
            _context.Set<Transaction>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MTransaction>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var transaction = await _context.Transactions.Where(i => i.TransactionID == ID).FirstOrDefaultAsync();
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

    }
}
