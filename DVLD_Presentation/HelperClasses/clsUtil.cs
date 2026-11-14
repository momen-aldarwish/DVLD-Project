using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DVLD_Presentation.HelperClasses
{
    public class clsUtil
    {
        private static readonly string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
            "DVLD", "PeoplePictures" );

        private static string _GenerateUniqueFileName(string sourceFilePath)
        {
            FileInfo fileInfo = new FileInfo(sourceFilePath);
            return Guid.NewGuid().ToString() + fileInfo.Extension;
        }

        public static bool CopyImage(string sourceFilePath, out string destinationFilePath)
        {
            destinationFilePath = string.Empty;

            if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
                return false;

            try
            {
                if (!Directory.Exists(FolderPath))
                    Directory.CreateDirectory(FolderPath);

                destinationFilePath = Path.Combine(FolderPath, _GenerateUniqueFileName(sourceFilePath));

                File.Copy(sourceFilePath, destinationFilePath, true);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteImage(string sourceFilePath)
        {
            if (string.IsNullOrEmpty(sourceFilePath))
                return false;

            if (!File.Exists(sourceFilePath))
                return true;

            try
            {
                File.Delete(sourceFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public class FilterItem<T>
        {
            public string DisplayText { get; set; }
            public T Value { get; set; }

            public FilterItem(string displayText, T value)
            {
                DisplayText = displayText;
                Value = value;
            }
        }

        private static DataView GetDataView (DataGridView dgv)
        {
            if (dgv.DataSource is DataTable dt)
            {
                return dt.DefaultView;
            }
            else if (dgv.DataSource is BindingSource bs && bs.DataSource is DataTable dtSource)
            {
                return dtSource.DefaultView;
            }
            else
                return null;

        }

        public static void SearchByNumber(DataGridView DGV, TextBox TB, string By)
        {
            if (DGV.DataSource is null || !DGV.Columns.Contains(By))
                return;

            DataView dv = GetDataView(DGV);
            if (dv is null)
                return;

            if (int.TryParse(TB.Text, out int ID))
                dv.RowFilter = $"[{By}] = {ID}";
            else
                dv.RowFilter = "";
        }

        public static void SearchByString(DataGridView DGV, TextBox TB, string By)
        {
            if (DGV.DataSource is null || !DGV.Columns.Contains(By)) 
                return;

            DataView dv = GetDataView(DGV);
            if (dv is null)
                return;

            dv.RowFilter = $"[{By}] LIKE '{TB.Text.Trim()}%'";
        }

        public static void SearchByBool (DataGridView DGV, bool Value, string By)
        {
            if (DGV.DataSource is null || !DGV.Columns.Contains(By))
                return;

            DataView dv = GetDataView(DGV);
            if (dv is null)
                return;

            dv.RowFilter = $"[{By}] = {Value}";
        }
    
        public static void ShowAllDGVData (DataGridView DGV)
        {
            if (DGV.DataSource is null)
                return;

            DataView dv = GetDataView(DGV);
            if (dv is null)
                return;

            dv.RowFilter = "";
        }
    
    
    }

}

