﻿using AssetManagement.DesktopUI.ViewModels;
using AssetManagement.Library.DataAccess;
using AssetManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Commands
{
    public class SaveClientCommand : CommandBase
    {

        private readonly ClientData _clientData;
        private readonly ClientsViewModel _viewModel;

        public SaveClientCommand(ClientsViewModel viewModel, ClientData clientData)
        {
            _clientData = clientData;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            ClientModel client = new ClientModel()
            {
                ClientName = _viewModel.SelectedClientName,
                FiscalCode = _viewModel.SelectedClientFiscalCode,
                Address = _viewModel.SelectedClientAddress
            };

            _clientData.SaveClient(client);
            _viewModel.DisplayClients();
        }
    }
}
