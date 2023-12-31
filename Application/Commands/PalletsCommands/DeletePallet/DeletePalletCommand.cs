﻿using MediatR;

namespace Application.Commands.PalletsCommands.DeletePallet
{
    public class DeletePalletCommand : IRequest
    {
        public int Id { get; set; }
    }
}
