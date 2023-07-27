﻿using Application.Commands.PalletsCommands;
using DbStorageContext;
using MediatR;

namespace Application.Handlers.PalletHandler
{
    public class CreatePalletCommandHandler
        : IRequestHandler<CreatePalletCommand, int>
    {
        private readonly DbInitializer _dbContext;

        public CreatePalletCommandHandler(DbInitializer dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreatePalletCommand request, CancellationToken cancellationToken)
        {
            var pallet = new Pallet
            {
                Height = request.PalletHeight,
                Width = request.PalletWidth,
                Depth = request.PalletDepth,

            };

            await _dbContext.Pallets.AddAsync(pallet, cancellationToken);
            await _dbContext.SaveChangesAsync();
            return pallet.Id;
        }
    }
}
