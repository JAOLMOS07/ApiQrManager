﻿
using Infrastructure.Context.Application;


namespace Infrastructure.Initialize
{
    public class Start
    {
        private readonly PersistenceContext _context;
        public Start(PersistenceContext context)
        {
            _context = context;
        }

        public async Task InitializeDatabasesAsync()
        {
          
           
        }
    }
}