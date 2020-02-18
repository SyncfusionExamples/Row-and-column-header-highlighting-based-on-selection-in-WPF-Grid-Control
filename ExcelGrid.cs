using Syncfusion.Windows.Controls.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VirtualGrid
{
    class ExcelGrid : GridControl
    {
        protected override void OnPrepareRenderCell(GridPrepareRenderCellEventArgs e)
        {
            base.OnPrepareRenderCell(e);

            if (e.Cell.RowIndex == 0 && Model.SelectedRanges.AnyRangeIntersects(GridRangeInfo.Col(e.Cell.ColumnIndex)))
            {
                e.Style.Background = this.excelOrange;
            }

            else if (e.Cell.ColumnIndex == 0 && Model.SelectedRanges.AnyRangeIntersects(GridRangeInfo.Row(e.Cell.RowIndex)))
            {
                e.Style.Background = this.excelOrange;
            }
        }
        private Brush excelOrange = new SolidColorBrush(Color.FromRgb(244, 198, 111));
    }
}
