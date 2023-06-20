using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;
using Prodavnica_Filmova2.Repository;
using System.Configuration;
using Prodavnica_Filmova2.Tools;

namespace Prodavnica_Filmova2.Repository
{

    class AdminWindowRepository
    {
        private string _workbookPath;
        public AdminWindowRepository(string workbookPath)
        {
            _workbookPath = workbookPath;
        }
        public void DataBaseLoadFilm(DataGridView dataGridView)
        {
            var exceldoc = WorkBook.LoadExcel(ConfigUtil.GetWorksheetPath());
            var Edataset = exceldoc.ToDataSet().Tables[Consts.FilmWorksheet];
            for (int i = 0; i < Edataset.Columns.Count; i++)
            {
                Edataset.Columns[i].ColumnName = Edataset.Rows[0].ItemArray[i].ToString();
            }
            dataGridView.DataSource = Edataset;
            dataGridView.Rows.RemoveAt(0);
        }
        public void DataBaseLoadSales(DataGridView dataGridView)
        {
            var exceldoc = WorkBook.LoadExcel(ConfigUtil.GetWorksheetPath());
            var Edataset = exceldoc.ToDataSet().Tables[Consts.Purchasing];
            for (int i = 0; i < Edataset.Columns.Count; i++)
            {
                Edataset.Columns[i].ColumnName = Edataset.Rows[0].ItemArray[i].ToString();
            }
            dataGridView.DataSource = Edataset;
            dataGridView.Rows.RemoveAt(0);
        }
        public void DeleteRow(DataGridView dataGridView)
        {
            WorkBook wb = WorkBook.Load(ConfigUtil.GetWorksheetPath());
            WorkSheet ws = wb.GetWorkSheet(Consts.FilmWorksheet);
            int i = dataGridView.CurrentCell.RowIndex;
            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                dataGridView.Rows.RemoveAt(item.Index);
            }
            ws.GetRow(i + 1).RemoveRow();
            wb.SaveAs(ConfigUtil.GetWorksheetPath());
        }
        public void CellValueChange(DataGridView dataGridView)
        {
            WorkBook wb = WorkBook.Load(ConfigUtil.GetWorksheetPath());
            WorkSheet ws = wb.GetWorkSheet(Consts.FilmWorksheet);            
        }
    }
}
