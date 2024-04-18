using Spectre.Console;




public class Task {
	public string status {get; set;}
	public string name {get; set;}
	public string category {get; set;}

}


public static class Program
{

    public static void Main(string[] args)
    {

		List<Task> taskList = new List<Task>();
		bool exitProgram = false;
		string notification_message = "";

		// Add some sample tasks to the list

		taskList.Add(new Task()
		{
			status = "TODO",
			name = "Call mom",
			category = "Personal",
		});

		taskList.Add(new Task()
		{
			status = "TODO",
			name = "Update resume",
			category = "Career",
		});

		taskList.Add(new Task()
		{
			status = "TODO",
			name = "Go for a run",
			category = "Fitness",
		});

		taskList.Add(new Task()
		{
			status = "TODO",
			name = "Read a book",
			category = "Personal",
		});

		taskList.Add(new Task()
		{
			status = "TODO",
			name = "Prepare dinner",
			category = "Cooking",
		});

		taskList.Add(new Task()
		{
			status = "TODO",
			name = "Learn C#",
			category = "Learn",
		});

		taskList.Add(new Task()
		{
			status = "TODO",
			name = "Clean the house",
			category = "Personal",
		});

		taskList.Add(new Task()
		{
			status = "TODO",
			name = "Do yoga",
			category = "Fitness",
		});

		taskList.Add(new Task()
		{
			status = "TODO",
			name = "Research a topic",
			category = "Learn",
		});







		while (!exitProgram)
		{
			
		Console.Clear();

		AnsiConsole.Markup("\n\n");

		AnsiConsole.Write(
			new FigletText("RALDIN CASIDAR")
				.Centered()
        .Color(Color.Green));

		var rule = new Rule("TASK MANAGEMENT SYSTEM V1.1");
		rule.Justification = Justify.Center;
		AnsiConsole.Write(rule);



		AnsiConsole.Markup("\n [lime]:information: What is this program?[/]: [white]This program is designed to manage your taskList with ease. It is designed to be a simple and efficient tool.[/] \n \n \n ");


		// Display notification messages if they exist
		if (notification_message != "") {
			AnsiConsole.Markup("\n\n");
			var panel5 = new Panel($"[green]{notification_message}[/]");
			panel5.Header = new PanelHeader("Notification");
			panel5.Padding = new Padding(1, 1, 1, 1);
			panel5.Expand = true;
			AnsiConsole.Write(panel5);
			AnsiConsole.Markup("\n\n");
			notification_message = "";
		}



		// Ask for user action
		var actions = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.Title("Select your [red]actions[/]?")
				.PageSize(10)
				.MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
				.AddChoices(new[] {
					"View/Manage Tasks", "About this Program", "Exit"
				}));


		if (actions == "View/Manage Tasks") {


			// Create a table
			var table = new Table();

			// Add title some borders and 
			table.Border = TableBorder.Rounded;
			table.Title = new TableTitle("[lime]Undone Task[/]");

			// Add some columns
			table.AddColumn("[yellow]Priority Order[/]");
			table.AddColumn("[yellow]Status[/]");
			table.AddColumn("[yellow]Task Name[/]");
			table.AddColumn("[yellow]Category[/]");
			table.Expand();

			// Add some rows
			int index = 1;
			foreach (var task in taskList) 
			{

				if (task.status == "DONE") {
					continue;
				}

				// If task is DONE, color is green, else red
				string isDone = (task.status == "DONE") ? "green" : "red";
				string isDone2 = (task.status == "DONE") ? "strikethrough" : "bold";


				table.AddRow(
					new Markup(Convert.ToString(index)), 
					new Markup($"[{isDone}][bold]{task.status}[/][/]"), 
					new Markup($"[{isDone2}]{task.name}[/]"), 
					new Markup($"[blue]{task.category}[/]")
				);


				index++;
			}

			// Create a table
			var table2 = new Table();

			// Add title and some borders 
			table2.Border = TableBorder.Rounded;
			table2.Title = new TableTitle("[lime]Done Task[/]");

			// Add some columns
			table2.AddColumn("[yellow]Order[/]");
			table2.AddColumn("[yellow]Status[/]");
			table2.AddColumn("[yellow]Task Name[/]");
			table2.AddColumn("[yellow]Category[/]");
			table2.Expand();

			// Add some rows
			int index2 = 1;
			foreach (var task in taskList) 
			{

				if (task.status != "DONE") {
					continue;
				}



				string isDone = (task.status == "DONE") ? "green" : "red";
				string isDone2 = (task.status == "DONE") ? "strikethrough" : "bold";


				table2.AddRow(
					new Markup(Convert.ToString(index2)), 
					new Markup($"[{isDone}][bold]{task.status}[/][/]"), 
					new Markup($"[{isDone2}]{task.name}[/]"), 
					new Markup($"[blue]{task.category}[/]")
				);
				
				
				index2++;
			}

			// Render the table to the console
			AnsiConsole.Write(table);
			AnsiConsole.Write(table2);

			// Ask for the user's actions for the the task table
			var otherAction = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("\nSelect your [red]actions[/]?")
					.PageSize(10)
					.MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
					.AddChoices(new[] {
						"Add New Tasks", "Mark task as done", "Remove Task", "Set Priority Order",  "Go Back"
					}));

			if (otherAction == "Add New Tasks") {

				var task_name = AnsiConsole.Ask<string>("What's your [yellow]task[/]?");
				var task_category = AnsiConsole.Ask<string>("What [yellow]category[/]?");



				taskList.Add( new Task() { name = task_name, category = task_category, status = "TODO" } );

				notification_message = "Successfuly added new task!";
			}
			
			if (otherAction == "Mark task as done") {

				List<string> choices = new List<string>();

				// Find the task that is not DONE
				foreach(var task in taskList)
				{
					if (task.status == "DONE") {
						continue;
					}
					choices.Add(task.name);
					
				}

				choices.Add("Go Back");

				// Ask user which task to mark as done
				string actionToMarkDone = AnsiConsole.Prompt(
					new SelectionPrompt<string>()
						.Title("\nWhich task would you like to [green]MARK AS DONE[/]?")
						.PageSize(10)
						.MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
						.AddChoices(choices.ToArray()));

				if (actionToMarkDone != "Go Back") {
					
					// find the task selected and mark as done
					for (int i = 0; i < taskList.Count; i++) 
					{
						if (taskList[i].name == actionToMarkDone) {
							taskList[i].status = "DONE";
						}
						
					}

					// Notify user
					notification_message = "Successfuly marked task as done!";

				}
			}

			if (otherAction == "Remove Task") {

				
				List<string> choices = new List<string>();

				foreach(var task in taskList)
				{
					choices.Add(task.name);
					
				}

				choices.Add("Go Back");

				string actionToMarkDone = AnsiConsole.Prompt(
					new SelectionPrompt<string>()
						.Title("\nWhich task would you like to [red]REMOVE[/]?")
						.PageSize(10)
						.MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
						.AddChoices(choices.ToArray()));

				if (actionToMarkDone != "Go Back") {
					
					for (int i = 0; i < taskList.Count; i++) 
					{
						if (taskList[i].name == actionToMarkDone) {
							
							var itemToRemove = taskList.SingleOrDefault(r => r.name == actionToMarkDone);
							if (itemToRemove != null)
								taskList.Remove(itemToRemove);

						}
						
					}

					notification_message = "Successfuly deleted task!";

				}
			}

			if (otherAction == "Set Priority Order") {
				

				List<string> choices = new List<string>();

				foreach(var task in taskList)
				{
					choices.Add(task.name);
					
				}

				choices.Add("Go Back");

				string actionToMarkDone = AnsiConsole.Prompt(
					new SelectionPrompt<string>()
						.Title("\nWhich task would you like to [red]MOVE PRIORITY[/]?")
						.PageSize(10)
						.MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
						.AddChoices(choices.ToArray()));

				if (actionToMarkDone != "Go Back") {
					
					for (int i = 0; i < taskList.Count; i++) 
					{
						if (taskList[i].name == actionToMarkDone) {
							
							var new_index = Convert.ToInt32(AnsiConsole.Ask<string>($"Input priority number: [yellow](1-{taskList.Count})[/]?")) - 1;
							var item = taskList[i];

							// Remove task from list and re-insert at specific index
							taskList.RemoveAt(i);
							taskList.Insert(new_index, item);

							// Finally stop the for loop
							break;
						}
						
					}

					notification_message = "Successfuly changed priority!";

				}
			}
		}



		if (actions == "About this Program") {
			
			// Display information about this program
			AnsiConsole.Markup("\n\n");
			var panel6 = new Panel($"[green]This Task Management was made by [yellow]Raldin Casidar[/]. Raldin Casidar is a student at JRMSU Main Campus and this project is made in compliance to the Final Project of sir [yellow]Edgardo Olmoguez[/]. \n \nPlease contact me at [yellow]raldin.disomimba13@gmail.com[/] if you seen any problem.[/]");
			panel6.Header = new PanelHeader("About this Program");
			panel6.Padding = new Padding(1, 1, 1, 1);
			panel6.Expand = true;
			AnsiConsole.Write(panel6);
			AnsiConsole.Markup("\n\n");


			// Go Back button
			var goBack = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title("Select [red]Actions[/]:?")
					.PageSize(10)
					.MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
					.AddChoices(new[] {
						"Go Back"
					}));
		}
	


		if (actions == "Exit") {
			Console.Clear();

			AnsiConsole.Markup("\n\n");

			AnsiConsole.Write(
				new FigletText("THANK YOU FOR USING MY PROGRAM!")
					.Centered()
			.Color(Color.Red));

			var ruleExit = new Rule("Visit https://raldincasidar.studio/ for more softwares and projects");
			ruleExit.Justification = Justify.Center;
			AnsiConsole.Write(ruleExit);
			
			// Maek exitProgram true to exit while loop
			exitProgram = true;
		}
		}
		

	}
}