#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using ColorConverter = System.Drawing.ColorConverter;

namespace VirtualGrid
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            InitializeGridControl();

        }
        #region "DataTable"
        string[] name1 = new string[] { "John", "Peter", "Smith", "Jay", "Krish", "Mike" };
        string[] country = new string[] { "UK", "USA", "Pune", "India", "China", "England" };
        string[] city = new string[] { "Graz", "Resende", "Bruxelles", "Aires", "Rio de janeiro", "Campinas" };
        string[] scountry = new string[] { "Brazil", "Belgium", "Austria", "Argentina", "France", "Beiging" };
        DataTable dt = new DataTable();
        Random r = new Random();
        int col = 0;
        private DataTable CreateTable()
        {

            dt.Columns.Add("Name");
            dt.Columns.Add("Id");
            dt.Columns.Add("Date");
            dt.Columns.Add("Country");
            dt.Columns.Add("Ship City");
            dt.Columns.Add("Ship Country");
            dt.Columns.Add("Freight");
            dt.Columns.Add("Postal code");
            dt.Columns.Add("Salary");
            dt.Columns.Add("PF");
            dt.Columns.Add("EMI");

            for (int l = 0; l < 100; l++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = name1[r.Next(0, 5)];
                dr[1] = "E" + r.Next(30);
                dr[2] = new DateTime(2012, 5, 23);
                dr[3] = country[r.Next(0, 5)];
                dr[4] = city[r.Next(0, 5)];
                dr[5] = scountry[r.Next(0, 5)];
                dr[6] = "12,789";
                dr[7] = r.Next(10 + (r.Next(600000, 600100)));
                dr[8] = r.Next(14000, 20000);
                dr[9] = r.Next(r.Next(2000, 4000));
                dr[10] = r.Next(300, 1000);

                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        private void InitializeGridControl()
        {
            CreateTable();
            grid.Model.RowCount = dt.Rows.Count;
            grid.Model.ColumnCount = dt.Columns.Count;


            for (int i = 1; i <= grid.Model.ColumnCount; i++)
            {
                grid.Model[0, i].HorizontalAlignment = HorizontalAlignment.Center;
                grid.Model[0, i].CellValue = dt.Columns[i - 1].ColumnName;
            }

            for (int i = 1; i <= grid.Model.RowCount; i++)
                for (int j = 0; j <= grid.Model.ColumnCount; j++)
                    if (j == 0)
                    {
                        grid.Model[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                        grid.Model[i, j].CellValue = i;
                    }
                    else
                        grid.Model[i, j].CellValue = dt.Rows[i - 1][j - 1];
            grid.CellMouseUp += Grid_CellMouseUp;
        }

        private void Grid_CellMouseUp(object sender, GridCellMouseControllerEventArgs args)
        {
            grid.InvalidateCells();
        }
    }
}