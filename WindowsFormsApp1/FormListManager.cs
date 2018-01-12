using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ConsoleManager.Model.Command;
using ConsoleManager.Properties;
using ConsoleManager.ViewModel;

namespace ConsoleManager
{
    public partial class FormListManager : Form
    {

        #region Costumise dgv

        private void CostumiseDGV()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.Columns["CommandText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["ProgramPath"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns["Id"].Width = 50;
            dataGridView1.Columns["CommandText"].MinimumWidth = 50;
        }

        #endregion

        #region Fields

        private BindingSource bindingSource;
        private readonly Data d;
        private List<DataGridViewRow> index;
        private BindingList<UserCommand> list;

        #endregion

        #region FormMethod

        public FormListManager()
        {
            InitializeComponent();
            Text = Settings.Default.ManagerName + " - Commands List";           
            d = new Data();
            DisableButton();
        }

        private void DisableButton()
        {
            if (!(dataGridView1.SelectedRows.Count > 0))
            {
                toolStripMenuDelete.Enabled = false;
                //toolStripMenuEdit.Enabled = false;
                toolStripMenuStart.Enabled = false;
                toolStripMenuSave.Enabled = false;
                toolStripMenuDelete.Enabled = false;
            }
        }

        #endregion

        #region FormEvents

        private void FormListManager_Load(object sender, EventArgs e)
        {
            GetDataSource();
        }

        #region KeyDown

        private void FormListManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.S))
                SaveChange();
        }

        #endregion

        #endregion

        #region Methods

        private bool StartCommand(string commandtext, string key = " ")
        {
            try
            {
                string command = String.Concat(key," ", " ",commandtext );
                Console.WriteLine(command);
                ProcessConsole.CommandRun(command);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }           
        }

        private void GetDataSource()//get data for list and binding list to datagridview
        {
            list = new BindingList<UserCommand>();
            bindingSource = new BindingSource();
            list = d.GetData();
            bindingSource.DataSource = list;
            dataGridView1.DataSource = bindingSource;
            CostumiseDGV();
        }

        private void AddRows()
        {
            
            bindingSource.AddNew();
            bindingSource.EndEdit();
        }

        private void SaveChange()
        {
            d.SetData(list);
        }

        private void UpdateList()
        {
            d.SetData(list);
            GetDataSource();
        }

        private void CancelChange()
        {
            GetDataSource();
        }

        private void DeleteRows()
        {
            if (index.Count > 0)
                foreach (var drv in index)
                {
                    var k = drv.Index;
                    dataGridView1.Rows.RemoveAt(drv.Index);
                }
            else
                MessageBox.Show("The row is not selected.", "Error", MessageBoxButtons.OK);
        }

        #endregion

        #region MenuButtonEvents

        private void ToolStripMenuAdd_Click(object sender, EventArgs e)
        {
            AddRows();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            index = dataGridView1.SelectedRows.Cast<DataGridViewRow>().ToList();
            index.Reverse();
            for (var i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            DisableButton();
            toolStripMenuCommand.Enabled = true;
            toolStripMenuCommand.Enabled = true;
            toolStripMenuStart.Enabled = true;
            toolStripMenuSave.Enabled = true;
            toolStripMenuDelete.Enabled = true;
            //toolStripMenuEdit.Enabled = true;
        }

        private void ToolStripMenuSave_Click(object sender, EventArgs e)
        {
            d.SetData(list);
        }

        private void ToolStripMenuDelete_Click(object sender, EventArgs e)
        {
            DeleteRows();
        }

        private void ToolStripMenuUpdate_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void ToolStripMenuCancel_Click(object sender, EventArgs e)
        {
            CancelChange();
        }

        private void ToolStripMenuStartCommand_Click(object sender, EventArgs e)
        {
            if (index.Count > 0)
            {
                bool b = false;
                try
                {
                    foreach (var drv in index)
                    {
                        var k = drv.Cells[5].Value;
                        b = StartCommand(k.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Command is empty." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if(b) Console.WriteLine("Command is successful");
                }
            }
            else
                MessageBox.Show("The row is not selected.", "Error", MessageBoxButtons.OK);

        }

        #endregion

        #region dataGridViewEvents

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var f = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[f].Selected = true;
        }

        #endregion


    }
}