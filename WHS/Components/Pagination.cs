using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WHS.Components
{
    public partial class Pagination : UserControl
    {
        public int CurrentPage { get; private set; } = 1;
        public int TotalPages { get; private set; } = 1;
        public int TotalRecords { get; private set; } = 0;

        public event EventHandler<int>? PageChanged;

        public Pagination()
        {
            InitializeComponent();
            SetupEvents();
        }

        private void SetupEvents()
        {
            prevBtn.Click += (s, e) => GoToPage(CurrentPage - 1);
            nextBtn.Click += (s, e) => GoToPage(CurrentPage + 1);
            pageNumeric.KeyDown += (s, e) =>
            {
                if ((int)pageNumeric.Value > TotalPages) pageNumeric.Value = TotalPages;

                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    GoToPage((int)pageNumeric.Value);
                }
            };
        }

        public void UpdatePagination(int currentPage, int totalPages, int totalRecords)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            TotalRecords = totalRecords;

            pageNumeric.Value = Math.Max(1, Math.Min(currentPage, totalPages));
            totalPageLabel.Text = totalPages.ToString();
            recordLabel.Text = totalRecords.ToString();

            prevBtn.Enabled = currentPage > 1;
            nextBtn.Enabled = currentPage < totalPages;
        }

        private void GoToPage(int page)
        {
            if (page < 1) page = 1;
            if (page > TotalPages) page = TotalPages;

            if (CurrentPage != page)
            {
                CurrentPage = page;
                PageChanged?.Invoke(this, CurrentPage);
            }
        }
    }
}
