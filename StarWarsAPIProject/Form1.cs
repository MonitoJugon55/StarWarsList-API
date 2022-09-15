using StarWarsListAPI;

namespace StarWarsAPIProject
{
    public partial class Form1 : Form
    {
        DBApi dbApi = new DBApi();

        dynamic data = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgChar.Rows.Clear();
            var selectedItem = cboNames.SelectedItem;

            for (int i = 0; i < data.results.Count; i++)
            {
                if (selectedItem == data.results[i].name)
                {
                    dtgChar.Rows.Add(data.results[i].name, data.results[i].height, data.results[i].mass, data.results[i].hair_color, data.results[i].skin_color, data.results[i].eye_color, data.results[i].gender);
                    return;
                }

            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            dynamic jsonData = dbApi.Get("https://swapi.dev/api/people");
            data = jsonData;
            for (int i = 0; i < jsonData.results.Count; i++)
            {

                cboNames.Items.Add(jsonData.results[i].name);
                dtgChar.Rows.Add(jsonData.results[i].name, jsonData.results[i].height, jsonData.results[i].mass, jsonData.results[i].hair_color, jsonData.results[i].skin_color, jsonData.results[i].eye_color, jsonData.results[i].birth_year, jsonData.results[i].gender);
            }
        }
    }
}

