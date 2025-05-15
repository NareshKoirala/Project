namespace Project_Page.Views.Home
{
    public class AddProject
    {
        public void OnGet()
        {
            // This method is called when the page is accessed via a GET request
            // You can add your logic here to handle the GET request
        }
        public void OnPost()
        {
            // This method is called when the page is accessed via a POST request
            // You can add your logic here to handle the POST request

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Project added successfully!");
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
        }
    }
}
