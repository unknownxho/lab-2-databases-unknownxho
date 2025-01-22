using System;
using System.Data;     
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_Hunley_Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.cityBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.cityDBDataSet);
                MessageBox.Show("Saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save. " + ex.Message);
            }
        }

        // Loads table data into cityDBDataSet on form load
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'cityDBDataSet.City' table.
               
                this.cityTableAdapter.Fill(this.cityDBDataSet.City);

                // Display database in grid view
                cityDataGridView.DataSource = cityDBDataSet.City;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. No Data Available. " + ex.Message);
            }
        }

        // Sorting buttons

        private void bAscOrd_Click(object sender, EventArgs e)
        {
            // Sort by population in ascending order
            cityDBDataSet.City.DefaultView.Sort = "Population ASC";
            cityDataGridView.DataSource = cityDBDataSet.City.DefaultView.ToTable();
        }

        private void bDescOrd_Click(object sender, EventArgs e)
        {
            // Sort by population in descending order
            cityDBDataSet.City.DefaultView.Sort = "Population DESC";
            cityDataGridView.DataSource = cityDBDataSet.City.DefaultView.ToTable();
        }

        private void bNameSort_Click(object sender, EventArgs e)
        {
            // Sort by city name in ascending order
            cityDBDataSet.City.DefaultView.Sort = "City ASC";
            cityDataGridView.DataSource = cityDBDataSet.City.DefaultView.ToTable();
        }

        // Calculation buttons

        // Print the  total population for all listed cities
        private void bTotal_Click(object sender, EventArgs e)
        {
            object result = cityDBDataSet.City.Compute("SUM(Population)", "");
            if (result == DBNull.Value)
            {
                MessageBox.Show("No data available.");
            }
            else
            {
                MessageBox.Show("Total Population: " + result.ToString());
            }
        }

        // Print the average population of all listed cities
        private void bAvg_Click(object sender, EventArgs e)
        {
            object result = cityDBDataSet.City.Compute("AVG(Population)", "");
            if (result == DBNull.Value)
            {
                MessageBox.Show("No data available.");
            }
            else
            {
                double avgValue = Convert.ToDouble(result);
                MessageBox.Show("Average Population: " + avgValue.ToString("F2"));
            }
        }

        // Print teh city with the highest population
        private void bHigh_Click(object sender, EventArgs e)
        {
            object result = cityDBDataSet.City.Compute("MAX(Population)", "");
            if (result == DBNull.Value)
            {
                MessageBox.Show("No data available.");
            }
            else
            {
                MessageBox.Show("Highest Population: " + result.ToString());
            }
        }

        // Print the city with the lowest population
        private void bLow_Click(object sender, EventArgs e)
        {
            object result = cityDBDataSet.City.Compute("MIN(Population)", "");
            if (result == DBNull.Value)
            {
                MessageBox.Show("No data available.");
            }
            else
            {
                MessageBox.Show("Lowest Population: " + result.ToString());
            }
        }
    }
}

