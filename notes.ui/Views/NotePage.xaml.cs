namespace notes.ui.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class NotePage : ContentPage
{
	string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

	public string ItemId
	{
		set { LoadNote(value); }
	}
	public NotePage()
	{
		InitializeComponent();
		string appDataPatch = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

		LoadNote(Path.Combine(appDataPatch, randomFileName));
	}

	private void LoadNote(string fileName)
	{
		Models.Note noteModel = new Models.Note();
		noteModel.FileName = fileName;

		if (File.Exists(fileName))
		{
			noteModel.Date = File.GetCreationTime(fileName);
			noteModel.Text = File.ReadAllText(fileName);
		}

		BindingContext = noteModel;
	}

	private void btnSalvar_Clicked(object sender, EventArgs e)
	{
		File.WriteAllText(_fileName, txtEditor.Text);
    }

	private void btnDeletar_Clicked(object sender, EventArgs e)
	{
		if (File.Exists(_fileName)) File.Delete(_fileName);

		txtEditor.Text = string.Empty;
	}
}