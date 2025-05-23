using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_Page.Views.Home
{
    public class ProjectOption : PageModel
    {
        public void OnGet()
        {
            Console.WriteLine("OnGet called.");
            // This method is called when the page is loaded.
        }

        public void OnPost()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Project added successfully!");
            Console.ResetColor();
        }

        public void OnPostTest()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test method executed.");
            Console.ResetColor();
        }
    }
}