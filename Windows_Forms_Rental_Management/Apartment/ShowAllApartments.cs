﻿using Rental_Management.Business.DTOs.Apartment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows_Forms_Rental_Management.Rental;

namespace Windows_Forms_Rental_Management.Apartment
{
    public partial class ShowAllApartments : Form
    {
        enum ContextMenuItemsEnum
        {
            AddRental,
            AllRentals,
            Edit,
            Delete,
            MoreDetails
        }
        List<string> ContextMenuItems = new List<string>
            {
                "Add rental",
                "All rentals",
                "Edit",
                "Delete",
                "More details"

            };
        public ShowAllApartments()
        {
            InitializeComponent();
        }


        private async void ShowAllApartments_Load(object sender, EventArgs e)
        {
            RefreshAndLoadData(null, null);
            SetContextMenuItems();
        }

        void SetContextMenuItems()
        {
            dataGridViewWithFilterAndContextMenu1.SetContextMenuItems(ContextMenuItems);
            dataGridViewWithFilterAndContextMenu1.ContextMenuItemClicked += DataGridViewWithFilterAndContextMenu1_ContextMenuItemClicked;
        }

        private async void DataGridViewWithFilterAndContextMenu1_ContextMenuItemClicked(object? sender, DataGridViewWithFilterAndContextMenu.ContextMenuItemClickedEventArgs e)
        {
            
            switch (e.ClickedItem)
            {
                case var t when t == ContextMenuItems[(int)ContextMenuItemsEnum.AddRental]:
                    AddRental addRentalForm = new AddRental(e.RecordId,AddRental.RentalType.Apartment);
                    addRentalForm.FormClosed += RefreshAndLoadData;
                    addRentalForm.ShowDialog();
                    break;
                case var t when t == ContextMenuItems[(int)ContextMenuItemsEnum.AllRentals]:
                    ShowAllRentals showAllRentalsForm = new ShowAllRentals(e.RecordId, AddRental.RentalType.Apartment);
                    showAllRentalsForm.FormClosed += RefreshAndLoadData;
                    showAllRentalsForm.ShowDialog();
                    break;
                case var t when t == ContextMenuItems[(int)ContextMenuItemsEnum.Edit]:
                    AddUpdateApartment form = new AddUpdateApartment(e.RecordId);
                    form.FormClosed += RefreshAndLoadData;
                    form.ShowDialog();
                    break;
                case var t when t == ContextMenuItems[(int)ContextMenuItemsEnum.Delete]:
                        await DeleteApartment(e.RecordId);
                    break;
                case var t when t == ContextMenuItems[(int)ContextMenuItemsEnum.MoreDetails]:
                    throw new NotImplementedException();


            }
        }

       

        async void RefreshAndLoadData(object? sender, FormClosedEventArgs e)
        {
            dataGridViewWithFilterAndContextMenu1.SetData(await
                    Util.FetchAllDataFromApiAsync<ApartmentDTO>($"Landlord/GetAllApartmentsForLandlord/{LocalLandlord.Id}"));

        }
        async Task DeleteApartment(int apartmentId)
        {
            if (MessageBox.Show("Are you sure you want to delete apartment?\nNote: apartment will not be deleted if it has relations", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HttpResponseMessage response = await Util.DeleteItemAsync($"Apartment/Delete/{apartmentId}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Apartment deleted successfully.");
                    RefreshAndLoadData(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to delete apartment. It may have related rentals or other dependencies.");
                }
            }
        }
    }
}
